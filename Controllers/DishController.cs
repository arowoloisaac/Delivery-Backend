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
            
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetDishDto>>> GetDishById(Guid id)
        {
            try
            {
                var dish = await _dishService.GetDishById(id);

                if (dish is not null)
                {
                    return Ok(dish);
                }

                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetDishes([FromQuery] List<Category>? category, bool? vegetarian, Sorting? sort, int? page)
        {
            return Ok(await _dishService.GetDishes(category, vegetarian, sort, page));
        }


        [HttpGet("{id}/check/rating")]
        public async Task<IActionResult> CheckRating(Guid id)
        {
            return Ok(await _dishService.GetDishRating(id));
        }


        [HttpPost("rating")]
        public async Task<IActionResult> PostRating(Guid id, int value)
        {
            try
            {

                if (value < 0 || value > 10)
                {
                    throw new Exception("Rating can't be less than Zero nor greater than 10");
                }

                return Ok(await _dishService.AddRating(id, value));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpGet("test")]
        public async Task<IActionResult> GetDish([FromQuery] List<Category>? category, bool? vegetarian, Sorting? sort, int? page)
        {
            var result = await _dishService.GetDishes(category, vegetarian, sort, page);
            return Ok(result);        
        }*/

    }
}
