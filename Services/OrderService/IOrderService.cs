using Arowolo_Delivery_Project.Dtos.BasketDto;

namespace Arowolo_Delivery_Project.Services.OrderService
{
    public interface IOrderService
    {
        Task GetOrderById(Guid OrderId, string UserId);

        Task<List<DishBasketDto>> GetOrder(string UserId);

        Task PostOrder(string UserId);

        Task ConfirmOrder(Guid OrderId,string UserId);
    }
}
