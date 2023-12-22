using Arowolo_Delivery_Project.Cofiguration;
using Arowolo_Delivery_Project.Data;
using Arowolo_Delivery_Project.Models;
using Arowolo_Delivery_Project.Services.BackgroundJobs;
using Arowolo_Delivery_Project.Services.BasketService;
using Arowolo_Delivery_Project.Services.DishService;
using Arowolo_Delivery_Project.Services.Initialization;
using Arowolo_Delivery_Project.Services.TokenService;
using Arowolo_Delivery_Project.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using Quartz;
using System.Security.Claims;
using System.Text;

namespace Arowolo_Delivery_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IDishService, DishService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<ITokenStorageService, TokenDbStorageService>();

            //add automapper
            //builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
            builder.Host.UseNLog();

            //builder.Services.AddHttpContextAccessor();
            builder.Services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(ApplicationRoleNames.User,
                    new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

                /*options.AddPolicy(ApplicationRoleNames.Administrator, new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireRole(ApplicationRoleNames.Administrator)
                    .RequireClaim(ClaimTypes.Role, ApplicationRoleNames.Administrator)
                    .Build());*/
            });


            //Adding Quartz
            builder.Services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.AddJob<BackgroundJob>(o => o.WithIdentity(nameof(BackgroundJob)));

                q.AddTrigger(o =>
                    o.ForJob(nameof(BackgroundJob))
                        .WithIdentity(nameof(BackgroundJob))
                        .StartNow()
                        .WithSimpleSchedule(x => x.WithIntervalInHours(24)
                            .RepeatForever()));
            });

            builder.Services.AddQuartzHostedService(x => x.WaitForJobsToComplete = true);

            var jwtSection = builder.Configuration.GetSection("JwtBearerTokenSettings");
            builder.Services.Configure<JwtBearerTokenSettings>(jwtSection);

            var jwtConfiguration = jwtSection.Get<JwtBearerTokenSettings>();
            var key = Encoding.ASCII.GetBytes(jwtConfiguration.SecretKey);

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = jwtConfiguration.Audience,
                    ValidIssuer = jwtConfiguration.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            var app = builder.Build();

            using var serviceScope = app.Services.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            await app.ConfigureIdentityAsync();

            app.MapControllers();

            app.Run();
        }
    }
}