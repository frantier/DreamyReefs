namespace DreamyReefs.Models
{
    public class Imagen
    {
        public int IDImagenes { get; set; }
        public string? ImagenBase64 { get; set; }
        public int TourID { get; set; }

        public ICollection<Tours> Tours { get; set; }

        public Imagen()
        {
            Tours = new List<Tours>();
        }
    }
}
