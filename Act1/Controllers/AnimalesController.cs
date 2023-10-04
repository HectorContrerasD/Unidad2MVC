using Microsoft.AspNetCore.Mvc;

namespace Act1.Controllers
{
    public class AnimalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
