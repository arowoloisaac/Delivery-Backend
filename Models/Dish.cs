using Arowolo_Delivery_Project.Enums;

namespace Arowolo_Delivery_Project.Models
{
    public class Dish
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public bool IsVegetarian { get; set; }
        public Category Category { get; set; }
        public int Rating { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;

        public ICollection<Rating> RatingList { get; set; }
    }
}
