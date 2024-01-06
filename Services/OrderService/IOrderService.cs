using Arowolo_Delivery_Project.Dtos.BasketDto;
<<<<<<< HEAD
=======
using Arowolo_Delivery_Project.Dtos.OrderDtos;
using Arowolo_Delivery_Project.Models;
>>>>>>> confirm_order

namespace Arowolo_Delivery_Project.Services.OrderService
{
    public interface IOrderService
    {
<<<<<<< HEAD
        Task GetOrderById(Guid OrderId, string UserId);

        Task<List<DishBasketDto>> GetOrder(string UserId);

        Task PostOrder(string UserId);

        Task ConfirmOrder(Guid OrderId,string UserId);
=======
        Task<GetOrderDto> GetOrderById(Guid OrderId, string UserId);

        Task<List<GetOrderInfoDto>> GetOrder(string UserId);

        Task PostOrder(CreateOrderDto model, string UserId);

        Task ConfirmOrder(Guid OrderId, string UserId);
>>>>>>> confirm_order
    }
}
