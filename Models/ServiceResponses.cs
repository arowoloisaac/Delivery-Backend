using Arowolo_Delivery_Project.Dtos.DishDto;

namespace Arowolo_Delivery_Project.Models
{
    public class ServiceResponses
    {
        public List<GetDishDto> dishes { get; set; } = new List<GetDishDto>();
        public PageInfo pagination { get; set; }

        public ServiceResponses(List<GetDishDto> dish, int page, int total, int size)
        {
            this.dishes = dish;

            //this.pagination = new PageInfo(page, total, size);
            this.pagination = new PageInfo
            {
                count = total,
                current = page,
                size = size
            };
        }
    }


    public class PageInfo
    {
        public int size { get; set; }
        public int current { get; set; }
        public int count { get; set; }

        public PageInfo() { }

        public PageInfo(int size, int current, int count)
        {
            this.size = size;
            this.current = current;
            this.count = count;
        }
    }
}
