using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arowolo_Delivery_Project.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        public OrderController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById()
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public async Task<IActionResult> PostOrder()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> OrderStatus()
        {
            throw new NotImplementedException();
        }
    }
}
