using Arowolo_Delivery_Project.Dtos.OrderDtos;
using Arowolo_Delivery_Project.Services.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace Arowolo_Delivery_Project.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Get order history")]
        public async Task<IActionResult> GetOrders()
        {
            //throw new NotImplementedException();
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
            var orders = await _orderService.GetOrder(userId.Value);

            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Get order by its id")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var userId =  User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
            //var check = await _orderService.GetOrderById(id, userId.Value);
            return Ok(await _orderService.GetOrderById(id, userId.Value));
        }


        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "create an order from dishes in basket")]
        public async Task<IActionResult> PostOrder(CreateOrderDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
                await _orderService.PostOrder(model, userId.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        [HttpPost("{id}/status")]
        [Authorize]
        [SwaggerOperation(Summary = "comfirm order delivery")]
        public async Task<IActionResult> OrderStatus(Guid id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
                await _orderService.ConfirmOrder(id, userId.Value);

                return Ok();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);    
            }
        }
    }
}
