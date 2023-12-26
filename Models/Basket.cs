namespace Arowolo_Delivery_Project.Models
{
    public class Basket
    {
        public Guid Id { get; set; }

        public int Count { get; set; }


        public Guid DishId { get; set; } // just for test run

        public Guid UserId { get; set; }

        public Dish? Dish { get; set; }

        public virtual User User { get; set; }

    }
}
