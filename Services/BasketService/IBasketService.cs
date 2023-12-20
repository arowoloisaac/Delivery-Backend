using Arowolo_Delivery_Project.Models;

namespace Arowolo_Delivery_Project.Services.BasketService
{
    public interface IBasketService
    {
        Task AddDishToCart(Guid dishId);

        Task DeleteDishInCart(Guid dishId, bool increase);
    }
}
