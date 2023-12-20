using Arowolo_Delivery_Project.Models;
using Arowolo_Delivery_Project.Services.BasketService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arowolo_Delivery_Project.Controllers
{
    [Route("api/[controller]")]
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
            throw new NotImplementedException();
        }

        [HttpPost("dish/{dishId}")]
        public async Task<IActionResult> AddToCart(Guid dishId)
        {
            await _basketService.AddDishToCart(dishId);
            return Ok();
        }

        [HttpDelete("dish/{dishId}")]
        public async Task<IActionResult> DeleteCart(Guid dishId, bool increase)
        {
            await _basketService.DeleteDishInCart(dishId, increase);
            return Ok();
        }
    }
}
