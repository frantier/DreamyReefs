namespace DreamyReefs.Models
{
    public class Review
    {
        public int IDReviews { get; set; }
        public int TourID { get; set; }
        public string? Comentario { get; set; }

        public ICollection<Tours> Tours { get; set; }

        public Review()
        {
            Tours = new List<Tours>();
        }
    }
}
