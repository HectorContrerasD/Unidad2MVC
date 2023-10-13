namespace Act2.Models.ViewModels
{
    public class RazaPorPaisViewModel
    {
        public string NombreP { get; set; }=null!;
        public IEnumerable<RazasModel> ListaRazaxPais { get; set; } =null!;
    }
}
