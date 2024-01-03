﻿using Arowolo_Delivery_Project.Dtos.BasketDto;
using Arowolo_Delivery_Project.Enums;

namespace Arowolo_Delivery_Project.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public Guid Id { get; set; }

        public DateTime DeliveryTime { get; set; }

        public DateTime OrderTime { get; set; }

        public Status Status { get; set; } = Status.Delivered;

        public int Price { get; set; }

        public ICollection<DishBasketDto> Dishes { get; set; }

        public string Address { get; set; } = string.Empty;
    }
}
