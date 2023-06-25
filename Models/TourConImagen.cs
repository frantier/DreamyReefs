using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamyReefs.Models
{
    public class TourConImagen
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
        public string? ImagenTour { get; set; }
    }
}