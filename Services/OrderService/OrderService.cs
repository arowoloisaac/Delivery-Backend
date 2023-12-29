using Arowolo_Delivery_Project.Dtos.BasketDto;
using Arowolo_Delivery_Project.Models;

namespace Arowolo_Delivery_Project.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public Task ConfirmOrder(Guid OrderId, string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DishBasketDto>> GetOrder(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task GetOrderById(Guid OrderId, string UserId)
        {
            throw new NotImplementedException();
        }

        public Task PostOrder(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
