using Arowolo_Delivery_Project.Data;
using Arowolo_Delivery_Project.Dtos.DishDto;
using Arowolo_Delivery_Project.Enums;
using Arowolo_Delivery_Project.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Arowolo_Delivery_Project.Services.DishService
{
    public class DishService : IDishService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public DishService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<List<GetDishDto>> AddDishes(AddDishDto newDish)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync( dish => dish.Name.ToLower() == newDish.Name.ToLower());

            if (dish is not null)
            {
                throw new ArgumentException($"Dish with {dish.Name} already exist");
            }

            _context.Dishes.Add(_mapper.Map<Dish>(newDish));
            await _context.SaveChangesAsync();

            var dbDishes = await _context.Dishes.ToListAsync();
            
            var mapperDishes = dbDishes.Select( dish => _mapper.Map<GetDishDto>(dish) ).ToList();

            return mapperDishes;
        }

        //for getting dish by ID
        public async Task<GetDishDto> GetDishById(Guid id)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(d => d.Id == id);

            if (dish is null)
            {
                throw new Exception($"Dish with {dish?.Id} doesn't exist");
            }
            return _mapper.Map<GetDishDto>(dish);
        }

    }
}
