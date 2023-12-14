using Arowolo_Delivery_Project.Dtos.DishDto;
using Arowolo_Delivery_Project.Enums;
using Arowolo_Delivery_Project.Models;
using Arowolo_Delivery_Project.Services.DishService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<ActionResult<List<GetDishDto>>> PostDish(AddDishDto newDish)
        {
            try
            {
                return Ok(await _dishService.AddDishes(newDish));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            //return Ok(await _dishService.AddDishes(newDish));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetDishDto>>> GetDishById(Guid id)
        {
            return Ok( await _dishService.GetDishById(id));
        }

        /*[HttpGet("GetAllDish")]
        public Task<ActionResult<List<Dish>>> GetDishes(Category? category, bool? vegetarian, Sort? sort, int? page)
        {
            throw new NotImplementedException();
        }*/

    }
}
