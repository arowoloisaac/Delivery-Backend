﻿using Arowolo_Delivery_Project.Cofiguration;
using Arowolo_Delivery_Project.Dtos.UserDtos;
using Arowolo_Delivery_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Arowolo_Delivery_Project.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtBearerTokenSettings _bearerTokenSettings;

        public UserService(UserManager<User> userManger, IOptions<JwtBearerTokenSettings> jwtTokenOptions)
        {
            _userManager = userManger;
            _bearerTokenSettings = jwtTokenOptions.Value;
        }

        public async Task EditProfile(EditUserDto request)
        {
            var existingUser = await _userManager.Users.FirstOrDefaultAsync( x => x.FullName.ToLower() == request.FullName.ToLower() );

            if (existingUser is not null)
            {
                existingUser.Address = request.Address;
                existingUser.BirthDate = request.BirthDate;
                existingUser.PhoneNumber = request.PhoneNumber;
                existingUser.Gender = request.Gender;
                existingUser.FullName = request.FullName;

                var updateUser = await _userManager.UpdateAsync(existingUser);

                if (!updateUser.Succeeded)
                {
                    throw new Exception("Failed to update user profile");
                }
            }

            throw new ArgumentNullException("No Active user");
        }

        public async Task<UserProfileDto> GetProfile(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with email {email} already exist");
            }

            return new UserProfileDto
            {
                Email = user.Email,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                Name = user.FullName,
                Address = user.Address,
                Gender = user.Gender,
                Id = user.Id,
            };
        }

        public async Task<string> Login(LoginUserDto request)
        {
            var user = await ValidateUser(request);

            if (user == null)
            {
                throw new InvalidOperationException("Login Failed");
            }

            var role = await _userManager.IsInRoleAsync(user, ApplicationRoleNames.Administrator);
            return GenerateToken(user, role);
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



        private async Task<User> ValidateUser(LoginUserDto request)
        {
            var identifyUser = await _userManager.FindByEmailAsync(request.Email);

            if (identifyUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identifyUser, identifyUser.PasswordHash, request.Password);

                return result == PasswordVerificationResult.Success ? identifyUser : null;
            }
            return null;
        }


        private string GenerateToken(User user, bool isAdmin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_bearerTokenSettings.SecretKey);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Authentication, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, isAdmin ? ApplicationRoleNames.Administrator : ApplicationRoleNames.User)
                }),
                Expires = DateTime.UtcNow.AddSeconds(_bearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _bearerTokenSettings.Audience,
                Issuer = _bearerTokenSettings.Issuer,
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}