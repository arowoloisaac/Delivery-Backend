using Arowolo_Delivery_Project.Data;
using Arowolo_Delivery_Project.Dtos.DishDto;
using Arowolo_Delivery_Project.Enums;
using Arowolo_Delivery_Project.Models;
using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Arowolo_Delivery_Project.Services.DishService
{
    public class DishService : IDishService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public DishService(IMapper mapper, ApplicationDbContext context, UserManager<User> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        //for getting dish by ID
        public async Task<GetDishDto> GetDishById(Guid id)
        {
            var dish = await _context.Dishes.Include(dish => dish.RatingList).FirstOrDefaultAsync(d => d.Id == id);

            if (dish is null)
            {
                throw new Exception($"Dish with {id} doesn't exist");
            }
            return _mapper.Map<GetDishDto>(dish);
        }

        // for getting all the dishes
        public async Task<ServiceResponses> GetDishes([FromQuery] List<Category>? category, bool? vegetarian, Sorting? sort, int? page)
        {
            IQueryable<Dish> query = _context.Dishes.Include(dish => dish.RatingList);

            if (category != null && category.Any())
            {
                query = query.Where(d => category.Contains(d.Category));
            }
            

            if (vegetarian.HasValue)
            {
                query = query.Where(d => d.IsVegetarian == vegetarian);
            }

            if (sort != null)
            {
                switch (sort)
                {
                    case Sorting.NameAsc:
                        query = query.OrderBy(d => d.Name);
                        break;
                    case Sorting.NameDesc:
                        query = query.OrderByDescending(d => d.Name);
                        break;                     
                    case Sorting.PriceAsc:
                        query = query.OrderBy(filterBy => filterBy.Price);
                        break;
                    case Sorting.PriceDesc:
                        query = query.OrderByDescending(filterBy => filterBy.Price);
                        break;
                    case Sorting.RatingAsc:
                        query = query.OrderBy(filterBy => filterBy.RatingList);
                        break;
                    case Sorting.RatingDesc:
                        query = query.OrderByDescending(filterBy => filterBy.RatingList);
                        break;
                }
            }

            int pageResult = 5;
            int currentPage = page.HasValue && page > 0 ? page.Value : 1;

            int totalItems = await query.CountAsync();
            int pageCount = (int)Math.Ceiling((double)totalItems / pageResult);

            var dishes = await query.Skip((currentPage - 1) * pageResult)
                                    .Take(pageResult)
                                    .ToListAsync();

            totalItems = dishes.Count;

            var mappedDishes = _mapper.Map<IEnumerable<GetDishDto>>(dishes);

            var response = new ServiceResponses(mappedDishes.ToList(), currentPage, totalItems, pageCount);
            return response;
        }


        
        //for checking rating 
        public async Task<bool> GetDishRating(Guid dishId, string userId)
        {
            var currentUser = await _userManager.FindByIdAsync(userId);
            var dishRating = await _context.Rating.AnyAsync( rating => rating.DishId == dishId && rating.UserId == currentUser.Id);

            return dishRating;
        }


        //for adding rating to the dish
        public async Task<Rating> AddRating(Guid dishId, int ratingScore, string UserId)
        {
            var dishes = await _context.Dishes.FirstOrDefaultAsync(dish => dish.Id == dishId);
            var currentUser = await _userManager.FindByIdAsync(UserId);

            //to get where the dish has been previously ordered
            var ordered = await _context.Order.Include(order => order.Baskets).ThenInclude(basket => basket.Dish)
                .Where(order => order.UserId == currentUser.Id && order.Baskets.Any(basket => basket.Dish.Id == dishId)).AnyAsync();

            if (ordered)
            {
                var newRating = new Rating
                {
                    DishId = dishId,
                    Value = ratingScore,
                    UserId = currentUser.Id
                };

                _context.Rating.Add(newRating);
                await _context.SaveChangesAsync();

                return newRating;
            }
            
            else { return null; }
            
        }

    }

    //to map the rating average for the dishes using automapper. reference https://docs.automapper.org/en/stable/Custom-value-resolvers.html
    public class AverageRatingResolver : IValueResolver<Dish, GetDishDto, double>
    {
        public double Resolve(Dish source, GetDishDto destination, double destMember, ResolutionContext context)
        {
            if (source.RatingList == null || source.RatingList.Count == 0)
            {
                return 0; // or any default value you want to use
            }

            double average = source.RatingList.Select(r => r.Value).Average();
            return average;
        }
    }
}
