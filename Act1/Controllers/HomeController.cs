using Act1.Models.Entities;
using Act1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Act1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AnimalesContext context = new();
            var clases = context.Clase.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            {
                Id = x.Id,
                NombreClase = x.Nombre??"",
                DescripcionClase = x.Descripcion??""
            }) ;
            return View(clases);
        }
        public IActionResult Especies()
        {
            return View();
        }
        public IActionResult Detalles()
        {
            return View();
        }
    }
}
