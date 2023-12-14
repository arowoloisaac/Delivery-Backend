using Arowolo_Delivery_Project.Enums;
using Arowolo_Delivery_Project.Models;
using Arowolo_Delivery_Project.Services.DishService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arowolo_Delivery_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        public readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        // to be deleted later
        [HttpPost("PostDish")]
        public async Task<ActionResult<List<Dish>>> PostDish(Dish newDish)
        {
            return Ok(_dishService.AddDishes(newDish));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Dish>>> GetDishById(Guid id)
        {
            return Ok(_dishService.GetDishById(id));
        }

        /*[HttpGet("GetAllDish")]
        public Task<ActionResult<List<Dish>>> GetDishes(Category? category, bool? vegetarian, Sort? sort, int? page)
        {
            throw new NotImplementedException();
        }*/

    }
}
