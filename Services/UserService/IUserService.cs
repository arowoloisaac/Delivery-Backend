using Arowolo_Delivery_Project.Dtos.UserDtos;

namespace Arowolo_Delivery_Project.Services.UserService
{
    public interface IUserService
    {
        Task Register(RegisterUserDto request);

        Task<UserProfileDto> GetProfile(string email);
        
        Task<string> Login(LoginUserDto request);

        Task EditProfile(EditUserDto request);
    }
}
