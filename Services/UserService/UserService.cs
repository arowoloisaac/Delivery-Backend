using Arowolo_Delivery_Project.Dtos.UserDtos;
using Arowolo_Delivery_Project.Models;
using Microsoft.AspNetCore.Identity;

namespace Arowolo_Delivery_Project.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManger)
        {
            _userManager = userManger;
        }

        public Task EditProfile(EditUserDto request)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileDto> GetProfile(string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(LoginUserDto request)
        {
            throw new NotImplementedException();
        }

        public async Task Register(RegisterUserDto request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                throw new ArgumentNullException("User with same Email Exists");
            }

            var identityUser = new User
            {
                UserName = request.Email,
                FullName = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                BirthDate = request.BirthdDate,
                Address = request.Address,
            };

            var saveUser = await _userManager.CreateAsync(identityUser, request.Password);

            if (!saveUser.Succeeded)
            {
                throw new Exception($"Failed to validate user {request.Email}");
            }
        }
    }
}
