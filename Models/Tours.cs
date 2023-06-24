using System.Net.NetworkInformation;

namespace DreamyReefs.Models
{
    public class Tours
    {
        public int IDTours { get; set; }
        public string? Nombre { get; set; }
        public string? Itinerario { get; set; }
        public int Precio { get; set; }
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
        public int PrecioAdulto { get; set; }
        public int PrecioInfantes { get; set; }

        // Propiedades de navegación para las categorías
        public ICollection<Categoria> Categorias { get; set; }

        // Propiedades de navegación para las características
        public ICollection<Caracteristica> Caracteristicas { get; set; }

        // Propiedades de navegación para las características
        public ICollection<Estatus> Estatuses { get; set; }

        public Tours()
        {
            Categorias = new List<Categoria>();
            Caracteristicas = new List<Caracteristica>();
            Estatuses = new List<Estatus>();
        }
    }
}
