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
<<<<<<< HEAD
            //await _basketService.GetBasket(userId.Value);
=======
            if (userId == null)
            {
                return Unauthorized();
            }

>>>>>>> order_related
            return Ok(await _basketService.GetBasket(userId.Value));
        }

        [HttpPost("dish/{dishId}")]
        public async Task<IActionResult> AddToCart(Guid dishId)
        {
<<<<<<< HEAD
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
            await _basketService.AddDishToCart(dishId, userId.Value);
            return Ok();
        }


        [HttpDelete("dish/{dishId}")]
        public async Task<IActionResult> DeleteCart(Guid dishId, bool increase)
        {
            var userId = User.Claims.FirstOrDefault( x => x.Type == ClaimTypes.Authentication);
            await _basketService.DeleteDishInCart(dishId, increase, userId.Value);
            return Ok();
=======
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


        /// <summary>
        /// This endpoint deletes dishes from the cart either by reducing it or removing it from the cart
        /// </summary>
        /// <param name="dishId">The dish Id in which the user wants to perform the delete operation</param>
        /// <param name="increase"> A boolean datatype used which aim reduce or removing the dish from basket</param>
        /// <returns></returns>
        /// <response code="401">Unauthorized access.</response>
        [HttpDelete("dish/{dishId}")]
        public async Task<IActionResult> DeleteCart(Guid dishId, bool increase)
        {
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
            
            
>>>>>>> order_related
        }
    }*/
}
