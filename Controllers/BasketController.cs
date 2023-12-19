using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arowolo_Delivery_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            throw new NotImplementedException();
        }

        [HttpPost("dish/{dishId}")]
        public async Task<IActionResult> AddToCart(Guid dishId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("dish/{dishId}")]
        public async Task<IActionResult> DeleteCart(Guid dishId, bool increase)
        {
            throw new NotImplementedException();
        }
    }
}
