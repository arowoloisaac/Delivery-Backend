using Arowolo_Delivery_Project.Dtos.DishDto;
using Arowolo_Delivery_Project.Models;

namespace Arowolo_Delivery_Project.Services.DishService
{
    public interface IDishService
    {
        Task<GetDishDto> GetDishById(Guid id);

        Task<List<GetDishDto>> AddDishes(AddDishDto newDish);
    }
}
