namespace Act2.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<RazasLetraModel> listaPerroxletra { get; set; } = null!;
        public IEnumerable<string> Letras { get; set; }= null!;
    }
    public class RazasLetraModel
    {
        public uint Id { get; set; }
        public string NombreRaza { get; set; } = null!;
    }
}
