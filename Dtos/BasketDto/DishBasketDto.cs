namespace Arowolo_Delivery_Project.Dtos.BasketDto
{
    public class DishBasketDto
    {
        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public int TotalPrice { get; set; }

        public int Amount { get; set; }

        public string Image { get; set; } = string.Empty;

    }
}
