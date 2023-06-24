namespace DreamyReefs.Models
{
    public class Caracteristica
    {
        public int IDCaracteristicas { get; set; }
        public string? NombreCaracteristica { get; set; }
        
        // Propiedades de navegación para los tours
        public ICollection<Tours> Tours { get; set; }

        public Caracteristica()
        {
            Tours = new List<Tours>();
        }
    }
}
