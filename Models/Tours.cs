using System.Net.NetworkInformation;

namespace DreamyReefs.Models
{
    public class Tours
    {
        public int IDTours { get; set; }
        public string? Nombre { get; set; }
        public string? Itinerario { get; set; }
        public float Precio { get; set; }
        public string? Descripcion { get; set; }
        public string? Disponibilidad { get; set; }
        public string? Idioma { get; set; }
        public string? Categoria1 { get; set; }
        public string? Categoria2 { get; set; }
        public string? Categoria3 { get; set; }
        public string? Categoria4 { get; set; }
        public string? Caracteristica1 { get; set; }
        public string? Caracteristica2 { get; set; }
        public string? Caracteristica3 { get; set; }
        public string? Estatus { get; set; }
    }
}
