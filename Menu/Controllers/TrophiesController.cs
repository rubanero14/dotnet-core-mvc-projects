using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    public class TrophiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
