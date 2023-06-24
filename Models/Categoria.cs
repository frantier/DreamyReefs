namespace DreamyReefs.Models
{
    public class Categoria
    {
        public int IDCategorias { get; set; }
        public string? NombreCategoria { get; set; }

        public ICollection<Tours> Tours { get; set; }

        // Propiedades de navegación para los tours
        public Categoria()
        {
            Tours = new List<Tours>();
        }
    }
}
