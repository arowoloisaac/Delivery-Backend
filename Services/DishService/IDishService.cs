using Arowolo_Delivery_Project.Dtos.DishDto;
using Arowolo_Delivery_Project.Models;

namespace Arowolo_Delivery_Project.Services.DishService
{
    public interface IDishService
    {
        Dish GetDishById(Guid id);

        List<Dish> AddDishes(Dish newDish);
    }
}
