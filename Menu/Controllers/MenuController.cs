using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        // Injecting Model into View using context constructor
        private readonly MenuContext _menuContext;
        public MenuController(MenuContext menuContext) {
            _menuContext = menuContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _menuContext.Dishes.ToListAsync());
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
