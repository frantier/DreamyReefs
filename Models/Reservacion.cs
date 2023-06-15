namespace DreamyReefs.Models
{
    public class Reservacion
    {
        public int IDReservaciones { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public int Adultos { get; set; }
        public int Infantes { get; set; }
        public string? Estatus { get; set; }
    }
}
