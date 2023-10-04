using Act1.Models.Entities;
using Act1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Especies(string Id)
        {
            AnimalesContext context =new();
            var clase = context.Clase.Where(x=>x.Nombre ==Id).Select(x=>x.Id).First();
            var datos = context.Especies.Where(x=>(x.IdClaseNavigation!=null?x.IdClaseNavigation.Nombre:"") == Id).Select(x=>new AnimalModel
            {
                AnimalId = x.Id,
                AnimalName = x.Especie
            });
            EspeciesViewModel viewModel = new()
            {
                IdClase = clase,
                NClase = Id,
                ListaAnimales = datos,
            };
            return View(viewModel);
        }
        public IActionResult Detalles(string Id)
        {
            AnimalesContext context = new();
            var seleccionado = context.Especies.Include(x=>x.IdClaseNavigation).First(x=>x.Especie ==Id);
            DetallesViewModel vm = new()
            {
                Id = seleccionado.Id,
                Nombre = seleccionado.Especie,
                Clase = seleccionado.IdClaseNavigation?.Nombre ?? "",
                Peso = seleccionado.Peso,
                Descripcion = seleccionado.Observaciones ?? "",
                Tamano = seleccionado.Tamaño,
                Habitat = seleccionado.Habitat ?? ""
            };
            return View(vm);
        }
    }
}
