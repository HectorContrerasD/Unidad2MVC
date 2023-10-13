namespace Act2.Models.ViewModels
{
    public class RazaPorPaisViewModel
    {
        public string NombreP { get; set; }=null!;
        public IEnumerable<PerrosxPaisModel> ListaRazaxPais { get; set; } =null!;
    }
    public class PerrosxPaisModel
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
