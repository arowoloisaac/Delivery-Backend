using Arowolo_Delivery_Project.Models;
using Arowolo_Delivery_Project.Services.BasketService;
using Microsoft.AspNetCore.Http;
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
            //await _basketService.GetBasket(userId.Value);
            return Ok(await _basketService.GetBasket(userId.Value));
        }

        [HttpPost("dish/{dishId}")]
        public async Task<IActionResult> AddToCart(Guid dishId)
        {
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
        }
    }*/
}
