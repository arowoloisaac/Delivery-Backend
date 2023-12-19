namespace Arowolo_Delivery_Project.Models
{
    public class Basket
    {
        public Guid Id { get; set; }

        public int Count { get; set; }

        public Guid DishId { get; set; }

        public Guid UserId { get; set; }
    }
}
