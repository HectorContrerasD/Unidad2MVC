using Act2.Models.Entities;
using Act2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Act2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PerrosContext context= new PerrosContext();
            var datos = context.Razas.Select(x => new IndexViewModel
            {
                Id = x.Id,
                NombreRaza = x.Nombre

            }).OrderBy(x=>x.NombreRaza);
            return View(datos);

        }

        public IActionResult Detalles()
        {
            return View();
        }
        public IActionResult PorPais()
        {
            return View();
        }
      
    }
}
