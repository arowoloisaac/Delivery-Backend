using System.ComponentModel.DataAnnotations.Schema;

namespace Arowolo_Delivery_Project.Models
{
    public class Basket
    {
        public Guid Id { get; set; }

        public int Count { get; set; }

        public Dish Dish { get; set; }
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> basket

        public Order? Order { get; set; }

        public User User { get; set; }

<<<<<<< HEAD
=======
=======

        public Order? Order { get; set; }

        public User User { get; set; }
>>>>>>> order_related
>>>>>>> basket
    }
}
