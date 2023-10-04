using System.Drawing.Printing;

namespace Act1.Models.ViewModels
{
    public class DetallesViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Clase { get; set; } = null!;
        public double? Peso { get; set; }
        public int? Tamano { get; set; }  
        public string Habitat { get; set; }=null!;
        public string Descripcion { get; set; } = null!;
    }
}
