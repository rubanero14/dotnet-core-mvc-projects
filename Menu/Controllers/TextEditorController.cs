using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    public class TextEditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
