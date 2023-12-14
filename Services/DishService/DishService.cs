using Arowolo_Delivery_Project.Dtos.DishDto;
using Arowolo_Delivery_Project.Enums;
using Arowolo_Delivery_Project.Models;

namespace Arowolo_Delivery_Project.Services.DishService
{
    public class DishService : IDishService
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


        public List<Dish> AddDishes(Dish newDish)
        {

            var newD = new Dish
            {
                Name = newDish.Name,
                Description = newDish.Description,
                Category = newDish.Category,
                Price = newDish.Price,
                Rating = 7
            };

            dishes.Add(newD);

            return dishes;
        }

        public Dish GetDishById(Guid id)
        {
            var dish = dishes.FirstOrDefault(d => d.Id == id);

            return dish;
        }
    }
}
