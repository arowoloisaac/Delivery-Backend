using Arowolo_Delivery_Project.Enums;

namespace Arowolo_Delivery_Project.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime DeliveryTime { get; set; }

        public DateTime OrderTime { get; set; }

<<<<<<< HEAD
        public Status Status { get; set; } = Status.Delivered;
=======
        public Status Status { get; set; } = Status.InProcess;
>>>>>>> confirm_order

        public double Price { get; set; }

        //public Guid BasketId { get; set; }

        //public Basket Baskets { get; set; }

        public ICollection<Basket> Baskets { get; set; }

        public string Address { get; set; } = string.Empty;

        public Guid UserId { get; set; }
    }
}
