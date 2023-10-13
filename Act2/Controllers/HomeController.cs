
using Act2.Models.Entities;
using Act2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Act2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string id)
        {
            IndexViewModel viewModel = new();
            PerrosContext context= new PerrosContext();
            var letras = context.Razas.Select(x => x.Nombre.Substring(0, 1)).Distinct().OrderBy(x=>x).ToList();
            viewModel.Letras   = letras;
            var Razas = context.Razas.Select(x => new RazasLetraModel
            {
                Id = x.Id,
                NombreRaza = x.Nombre
            }).OrderBy(x=>x.NombreRaza);
            if (id != null)
            {
                var datos = Razas.Where(x => x.NombreRaza.StartsWith(id));
                viewModel.listaPerroxletra= datos;
            }
            else
                viewModel.listaPerroxletra= Razas;
                
               

               
            return View(viewModel);
                
          
        }

        [Route("/Detalles/{nombrer}")]
        public IActionResult Detalles(string nombrer)
        {
            PerrosContext cont = new PerrosContext();
            nombrer = nombrer.Replace("-"," ");
            Random r = new Random();
            var datos = cont.Razas.Include(x => x.IdPaisNavigation).Include(x => x.Caracteristicasfisicas)
                .Include(x => x.Estadisticasraza).Where(r => r.Nombre == nombrer).FirstOrDefault();
            var rnd = cont.Razas.Where(x => x.Nombre != nombrer).ToList().Select(x=> new RazasModel() {
                Id = x.Id,
                Name = x.Nombre
            }).OrderBy(x=> r.Next()).ToList().Take(4);
            if (datos == null)
               return RedirectToAction("Index");

            DetallesViewModel vm = new()
            {
                Id = datos.Id,
                AlturaMax = datos.AlturaMax,
                AlturaMin = datos.AlturaMin,
                AmistadDesconocidos = datos.Estadisticasraza != null ? datos.Estadisticasraza.AmistadDesconocidos : 0,
                AmistadPerros = datos.Estadisticasraza != null ? datos.Estadisticasraza.AmistadPerros : 0,
                Cola = datos.Caracteristicasfisicas != null ? datos.Caracteristicasfisicas.Cola : "",
                Color = datos.Caracteristicasfisicas != null ? datos.Caracteristicasfisicas.Color : "",
                Descripcion = datos.Descripcion,
                EjercicioObligatorio = datos.Estadisticasraza != null ? datos.Estadisticasraza.EjercicioObligatorio : 0,
                EsperanzaVida = datos.EsperanzaVida,
                FacilidadEntrenamiento = datos.Estadisticasraza != null ? datos.Estadisticasraza.FacilidadEntrenamiento : 0,
                Hocico = datos.Caracteristicasfisicas != null ? datos.Caracteristicasfisicas.Hocico : "",
                NecesidadCepillado = datos.Estadisticasraza != null ? datos.Estadisticasraza.NecesidadCepillado : 0,
                NivelEnergia = datos.Estadisticasraza != null ? datos.Estadisticasraza.NivelEnergia : 0,
                Nombre = datos.Nombre,
                OtrosNombres = datos.OtrosNombres,
                PaisOrigen = datos.IdPaisNavigation.Nombre ?? "",
                Patas = datos.Caracteristicasfisicas != null ? datos.Caracteristicasfisicas.Patas : "",
                Pelo = datos.Caracteristicasfisicas != null ? datos.Caracteristicasfisicas.Pelo : "",
                PesoMax = datos.PesoMax,
                PesoMin = datos.PesoMin,
                ListaRazasR = rnd
            };
            return View(vm);
        }
        public IActionResult PorPais()
        {

            PerrosContext ctx = new();

            var datos = ctx.Razas.OrderBy(x => x.IdPaisNavigation.Nombre).GroupBy(x => x.IdPaisNavigation.Nombre)
                .Select(x => new RazaPorPaisViewModel
                {
                    NombreP = x.Key??"",
                    ListaRazaxPais = x.Select(x=> new PerrosxPaisModel
                    {
                        Id= x.Id,
                        Name= x.Nombre
                    })
                });
            //var datos = ctx.Paises.OrderBy(x => x.Nombre).Select(x => new RazaPorPaisViewModel
            //{
            //    NombreP = x.Nombre ?? "",
            //    ListaRazaxPais = ctx.Razas.OrderBy(x => x.Nombre).Select(x => new PerrosxPaisModel
            //    {
            //        Id = x.Id,
            //        Name = x.Nombre
            //    })
            //});

            return View(datos);
        }
      
    }
}
