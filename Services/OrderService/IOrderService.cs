<<<<<<< HEAD
﻿
using Arowolo_Delivery_Project.Dtos.OrderDtos;
using Arowolo_Delivery_Project.Models;
=======
﻿using Arowolo_Delivery_Project.Dtos.BasketDto;
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
>>>>>>> master

namespace Arowolo_Delivery_Project.Services.OrderService
{
    public interface IOrderService
    {
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
        Task GetOrderById(Guid OrderId, string UserId);

        Task<List<DishBasketDto>> GetOrder(string UserId);

        Task PostOrder(string UserId);

        Task ConfirmOrder(Guid OrderId,string UserId);
=======
>>>>>>> basket
>>>>>>> master
        Task<GetOrderDto> GetOrderById(Guid OrderId, string UserId);

        Task<List<GetOrderInfoDto>> GetOrder(string UserId);

        Task PostOrder(CreateOrderDto model, string UserId);

        Task ConfirmOrder(Guid OrderId, string UserId);
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> order_related
>>>>>>> basket
>>>>>>> master
    }
}
