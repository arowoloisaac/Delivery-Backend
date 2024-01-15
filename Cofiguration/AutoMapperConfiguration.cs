using Arowolo_Delivery_Project.Dtos.BasketDto;
using Arowolo_Delivery_Project.Dtos.DishDto;
using Arowolo_Delivery_Project.Dtos.OrderDtos;
using Arowolo_Delivery_Project.Models;
using Arowolo_Delivery_Project.Services.DishService;
using AutoMapper;

namespace Arowolo_Delivery_Project.Cofiguration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Dish, GetDishDto>().ForMember(dest => dest.Rating, opt => opt.MapFrom<AverageRatingResolver>());
            CreateMap<AddDishDto, Dish>();
            CreateMap<RatingDto, Rating>();
            CreateMap<Rating,  RatingDto>();
            CreateMap<Order, GetOrderInfoDto>();
            CreateMap<Order, GetOrderDto>();
            CreateMap<Basket, DishBasketDto>();
        }
    }
}


/**/