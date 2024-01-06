<<<<<<< HEAD

﻿using Arowolo_Delivery_Project.Dtos.BasketDto;
using Arowolo_Delivery_Project.Enums;
=======
<<<<<<< HEAD
﻿using Arowolo_Delivery_Project.Enums;
=======
﻿using Arowolo_Delivery_Project.Dtos.BasketDto;
using Arowolo_Delivery_Project.Enums;
>>>>>>> order_related

>>>>>>> basket
namespace Arowolo_Delivery_Project.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public Guid Id { get; set; }

        public DateTime DeliveryTime { get; set; }

        public DateTime OrderTime { get; set; }

        public Status Status { get; set; } = Status.Delivered;

<<<<<<< HEAD
        public double Price { get; set; }

        public ICollection<DishBasketDto> Dishes { get; set; }
=======
<<<<<<< HEAD
        public int Price { get; set; }
=======
        public double Price { get; set; }

        public ICollection<DishBasketDto> Dishes { get; set; }
>>>>>>> order_related
>>>>>>> basket

        public string Address { get; set; } = string.Empty;

        //public List<DishBasketDto> Dishes { get; internal set; }
    }
}
