<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arowolo_Delivery_Project.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        public OrderController()
        {
            
=======
>>>>>>> basket
>>>>>>> master
﻿using Arowolo_Delivery_Project.Dtos.OrderDtos;
using Arowolo_Delivery_Project.Services.OrderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arowolo_Delivery_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> order_related
>>>>>>> basket
>>>>>>> master
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById()
        {
            throw new NotImplementedException();
=======
>>>>>>> basket
>>>>>>> master
            //throw new NotImplementedException();
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
            var orders = await _orderService.GetOrder(userId.Value);

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var userId =  User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication);
            //var check = await _orderService.GetOrderById(id, userId.Value);
            return Ok(await _orderService.GetOrderById(id, userId.Value));
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> order_related
>>>>>>> basket
>>>>>>> master
        }


        [HttpPost]
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
        public async Task<IActionResult> PostOrder()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> OrderStatus()
        {
            throw new NotImplementedException();
=======
>>>>>>> basket
>>>>>>> master
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
<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
>>>>>>> order_related
>>>>>>> basket
>>>>>>> master
        }
    }
}
