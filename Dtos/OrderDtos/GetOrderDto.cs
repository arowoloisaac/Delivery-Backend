<<<<<<< HEAD
﻿using Arowolo_Delivery_Project.Enums;
=======
﻿using Arowolo_Delivery_Project.Dtos.BasketDto;
using Arowolo_Delivery_Project.Enums;
>>>>>>> confirm_order

namespace Arowolo_Delivery_Project.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public Guid Id { get; set; }

        public DateTime DeliveryTime { get; set; }

        public DateTime OrderTime { get; set; }

        public Status Status { get; set; } = Status.Delivered;

        public double Price { get; set; }

<<<<<<< HEAD
=======
        public ICollection<DishBasketDto> Dishes { get; set; }

>>>>>>> confirm_order
        public string Address { get; set; } = string.Empty;
    }
}
