using Arowolo_Delivery_Project.Enums;
using Arowolo_Delivery_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arowolo_Delivery_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {

        private static List<Dish> dishes = new List<Dish>
        {
            new Dish(),
            new Dish
            {
                Name = "Bean",
                Description = "sweet igboyin beans",
                Category = Category.Soup,
                IsVegetarian = false,
                Price = 100,

            },
            new Dish
            {
                Name = "Yam",
                Description = "sweet mashed yam",
                Category = Category.Soup,
                IsVegetarian = true,
                Price = 150,
            }
        };


        // to be deleted later
        [HttpPost("PostDish")]
        public async Task<ActionResult<List<Dish>>> PostDish(Dish newDish)
        {
            dishes.Add(newDish);
            return Ok(dishes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Dish>>> GetDishById(Guid id)
        {
            var dish = dishes.FirstOrDefault(d => d.Id == id);
            return Ok(dish);
        }

        [HttpGet("GetAllDish")]
        public Task<ActionResult<List<Dish>>> GetDishes(Category? category, bool? vegetarian, Sort? sort, int? page)
        {
            throw new NotImplementedException();
        }

    }
}
