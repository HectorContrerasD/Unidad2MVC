using Microsoft.AspNetCore.Mvc;

namespace Act1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
