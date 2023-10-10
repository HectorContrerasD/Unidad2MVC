using Microsoft.AspNetCore.Mvc;

namespace Act2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult PorPais()
        {
            return View();
        }
        public IActionResult Detalles()
        { 
            return View();
        }
    }
}
