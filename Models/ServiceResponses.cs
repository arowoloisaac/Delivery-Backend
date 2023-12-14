using Arowolo_Delivery_Project.Dtos.DishDto;

namespace Arowolo_Delivery_Project.Models
{
    public class ServiceResponses
    {
        public List<GetDishDto> Dishes { get; set; } = new List<GetDishDto>();
        public PageInfo Pagination { get; set; }

        public ServiceResponses(List<GetDishDto> dish, int page, int total, int size)
        {
            this.Dishes = dish;

            //this.pagination = new PageInfo(page, total, size);
            this.Pagination = new PageInfo
            {
                Count = total,
                Current = page,
                Size = size
            };
        }
    }


    public class PageInfo
    {
        public int Size { get; set; }
        public int Current { get; set; }
        public int Count { get; set; }

        public PageInfo() { }

        public PageInfo(int size, int current, int count)
        {
            this.Size = size;
            this.Current = current;
            this.Count = count;
        }
    }
}
