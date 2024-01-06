using Arowolo_Delivery_Project.Dtos.BasketDto;
<<<<<<< HEAD

using Arowolo_Delivery_Project.Dtos.OrderDtos;
using Arowolo_Delivery_Project.Models;
=======
<<<<<<< HEAD
=======
using Arowolo_Delivery_Project.Dtos.OrderDtos;
using Arowolo_Delivery_Project.Models;
>>>>>>> order_related
>>>>>>> basket

namespace Arowolo_Delivery_Project.Services.OrderService
{
    public interface IOrderService
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
        Task GetOrderById(Guid OrderId, string UserId);

        Task<List<DishBasketDto>> GetOrder(string UserId);

        Task PostOrder(string UserId);

        Task ConfirmOrder(Guid OrderId,string UserId);
=======
>>>>>>> basket
        Task<GetOrderDto> GetOrderById(Guid OrderId, string UserId);

        Task<List<GetOrderInfoDto>> GetOrder(string UserId);

        Task PostOrder(CreateOrderDto model, string UserId);

        Task ConfirmOrder(Guid OrderId, string UserId);
<<<<<<< HEAD
=======
>>>>>>> order_related
>>>>>>> basket
    }
}
