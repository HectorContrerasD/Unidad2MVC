

namespace Act2.Models.ViewModels
{
    public class DetallesViewModel
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string? OtrosNombres { get; set; }
        public string PaisOrigen { get; set; } = null!;
        public float PesoMin { get; set; }
        public float PesoMax { get; set; }
        public float AlturaMin { get; set; }
        public float AlturaMax { get; set; }
        public float EsperanzaVida { get; set; }
        public uint NivelEnergia { get; set; }
        public uint FacilidadEntrenamiento { get; set; }
        public uint EjercicioObligatorio { get; set; }
        public uint AmistadDesconocidos { get; set; }
        public uint AmistadPerros { get; set; }
        public uint NecesidadCepillado { get; set; }
        public string? Patas { get; set; }
        public string? Cola { get; set; }
        public string? Hocico { get; set; }
        public string? Pelo { get; set; }
        public string? Color { get; set; }
        public IEnumerable<RazasModel> ListaRazasR { get; set;}

    }
    public class RazasModel
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
