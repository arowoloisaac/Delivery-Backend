using Arowolo_Delivery_Project.Dtos.UserDtos;
using Arowolo_Delivery_Project.Services.TokenService;
using Arowolo_Delivery_Project.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arowolo_Delivery_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private ITokenStorageService _tokenStorageService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userService.Register(user);
                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile() 
        {  
            throw new NotImplementedException(); 
        }

        [HttpPut("profile")]
        public async Task<IActionResult> EditProfile()
        {
            throw new NotImplementedException();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            throw new NotImplementedException();
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            var id = Guid.Parse(User.FindFirst(ClaimTypes.Authentication).Value);
            _tokenStorageService.LogoutToken(id);
            return Ok();
        }
    }
}
