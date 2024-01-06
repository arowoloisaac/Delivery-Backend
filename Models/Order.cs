using Arowolo_Delivery_Project.Enums;

namespace Arowolo_Delivery_Project.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime DeliveryTime { get; set; }

        public DateTime OrderTime { get; set; }

<<<<<<< HEAD
=======
<<<<<<< HEAD

>>>>>>> master
        public Status Status { get; set; } = Status.InProcess;

        public double Price { get; set; }
=======
<<<<<<< HEAD
        public Status Status { get; set; } = Status.Delivered;

        public int Price { get; set; }
=======
        public Status Status { get; set; } = Status.InProcess;

        public double Price { get; set; }
>>>>>>> order_related
>>>>>>> basket

        //public Guid BasketId { get; set; }

        //public Basket Baskets { get; set; }

        public ICollection<Basket> Baskets { get; set; }

        public string Address { get; set; } = string.Empty;

        public Guid UserId { get; set; }
    }
}
