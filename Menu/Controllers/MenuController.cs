using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        // Injecting Data into Controller using context constructor
        private readonly MenuContext _menuContext;
        public MenuController(MenuContext menuContext) {
            _menuContext = menuContext;
        }

        public async Task<IActionResult> Index(string searchMenu)
        {
            var dishes = from d in _menuContext.Dishes select d;

            if(!string.IsNullOrEmpty(searchMenu))
            {
                dishes = dishes.Where(dish =>  dish.Name.Contains(searchMenu));

                return View(await dishes.ToListAsync());
            }
            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id) 
        {   
            var dish = await _menuContext.Dishes
                .Include(di => di.DishIngredients) // Both this line of code here and below inserts Ingredients
                .ThenInclude(i => i.Ingredient)  // ....data from DishIngredient Table
                .FirstOrDefaultAsync(d => d.Id == id);

            // Guard clause if dish is null
            if (dish == null) {
                return NotFound();
            }

            return View(dish);
        }

    }
}
