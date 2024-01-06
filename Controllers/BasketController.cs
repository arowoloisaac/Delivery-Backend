using Arowolo_Delivery_Project.Models;
using Arowolo_Delivery_Project.Services.BasketService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arowolo_Delivery_Project.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
            if (userId == null)
            {
                return Unauthorized();
            }

            return Ok(await _basketService.GetBasket(userId.Value));
        }

        [HttpPost("dish/{dishId}")]
        public async Task<IActionResult> AddToCart(Guid dishId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
                if (userId == null)
                {
                    return Unauthorized("User is not authorized");
                }
                await _basketService.AddDishToCart(dishId, userId.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    Status = "Error",
                    Message = "Internal Service Error: " + ex.Message
                };

                return StatusCode(500, response);
            }
            
        }


        [HttpDelete("dish/{dishId}")]
        public async Task<IActionResult> DeleteCart(Guid dishId, bool increase)
        {
<<<<<<< HEAD
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);

                if (userId == null)
                {
                    return Unauthorized("User is not authorized");
                }
                if (dishId == Guid.Empty)
                {
                    return BadRequest("Invalid dish id");
                }

                await _basketService.DeleteDishInCart(dishId, increase, userId.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    Status = "Error",
                    Message = "Internal Service Error: " + ex.Message
                };

                return StatusCode(500, response);
            }
            
            
=======
<<<<<<< HEAD
            var userId = User.Claims.FirstOrDefault( x => x.Type == ClaimTypes.Authentication);
=======
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
>>>>>>> confirm_order
            await _basketService.DeleteDishInCart(dishId, increase, userId.Value);
            return Ok();
>>>>>>> master
        }
    }*/
}
