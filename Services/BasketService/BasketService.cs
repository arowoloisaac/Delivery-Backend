using Arowolo_Delivery_Project.Data;
using Arowolo_Delivery_Project.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arowolo_Delivery_Project.Services.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketService(ApplicationDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddDishToCart(Guid dishId)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(dish => dish.Id == dishId);
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            /*if (dish == null)
            {
                throw new Exception($"Dish not found");
            }

            var addToCart = new Basket
            {
                DishId = dishId,
                Count = 1,
            };

            _context.Baskets.Add(addToCart);
            await _context.SaveChangesAsync();

            return addToCart;*/

            if (currentUser == null)
            {
                throw new Exception("Not found");
            }

            var addToCart = new Basket
            {
                DishId = dishId,
                Count = 1,
                UserId = currentUser.Id 
            };

            _context.Baskets.Add(addToCart);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteDishInCart(Guid dishId, bool increase)
        {
            var dish = await _context.Baskets.FirstOrDefaultAsync(dish => dish.DishId == dishId);

            if (dish == null)
            {
                throw new Exception($"Dish not found");
            }

            _context.Baskets.Remove(dish);
            await _context.SaveChangesAsync();
        }
    }
}
