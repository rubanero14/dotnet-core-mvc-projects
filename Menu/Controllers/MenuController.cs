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
    }
}
