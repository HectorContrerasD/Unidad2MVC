namespace Act1.Models.ViewModels
{
    public class EspeciesViewModel
    {
        public int IdClase { get; set; }
        public string NClase { get; set; } = null!;
        public IEnumerable<AnimalModel> ListaAnimales { get; set; } = null!;
    }
    public class AnimalModel
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }=null!;
    }
}
