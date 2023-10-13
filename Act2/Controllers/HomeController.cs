using Act2.Models.Entities;
using Act2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
       
        public IActionResult Detalles(string nombrer)
        {
            PerrosContext cont = new PerrosContext();
            nombrer = nombrer.Replace("-"," ");
            Random r = new Random();
            var existe = cont.Razas.Where(x=>x.Nombre == nombrer).First();
            if (existe == null)
               return RedirectToAction("Index");

            var datos = cont.Razas.Include(x => x.IdPaisNavigation).Include(x => x.Caracteristicasfisicas)
                .Include(x => x.Estadisticasraza).Where(r => r.Nombre == nombrer).Select(x => new DetallesViewModel
                {
                    Id = x.Id,
                    AlturaMax = x.AlturaMax,
                    AlturaMin = x.AlturaMin,
                    AmistadDesconocidos = x.Estadisticasraza != null ? x.Estadisticasraza.AmistadDesconocidos : 0,
                    AmistadPerros = x.Estadisticasraza != null ? x.Estadisticasraza.AmistadPerros:0,
                    Cola = x.Caracteristicasfisicas != null? x.Caracteristicasfisicas.Cola:"",
                    Color = x.Caracteristicasfisicas != null?x.Caracteristicasfisicas.Color:"",
                    Descripcion = x.Descripcion,
                    EjercicioObligatorio= x.Estadisticasraza !=null ?x.Estadisticasraza.EjercicioObligatorio:0,
                    EsperanzaVida = x.EsperanzaVida,
                    FacilidadEntrenamiento = x.Estadisticasraza != null?x.Estadisticasraza.FacilidadEntrenamiento:0,
                    Hocico = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Hocico:"",
                    NecesidadCepillado = x.Estadisticasraza != null ? x.Estadisticasraza.NecesidadCepillado : 0,
                    NivelEnergia = x.Estadisticasraza != null ? x.Estadisticasraza.NivelEnergia : 0,
                    Nombre = x.Nombre,
                    OtrosNombres = x.OtrosNombres,
                    PaisOrigen = x.IdPaisNavigation.Nombre??"",
                    Patas = x.Caracteristicasfisicas!=null?x.Caracteristicasfisicas.Patas:"",
                    Pelo = x.Caracteristicasfisicas!= null?x.Caracteristicasfisicas.Pelo:"",
                    PesoMax = x.PesoMax,
                    PesoMin = x.PesoMin,
                    ListaRazasR = cont.Razas.Where(x=>x.Nombre != nombrer).Select(x=> new RazasModel
                    {
                        Id = x.Id,
                        Name = x.Nombre
                    }).OrderBy(x=> r.Next()).Take(4)
                }); 
            return View(datos);
        }
        public IActionResult PorPais()
        {
            return View();
        }
      
    }
}
