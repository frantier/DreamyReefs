namespace DreamyReefs.Models.ViewModels
{
    public class ViewModelReservacion
    {
        public int IDReservacionUsuario { get; set; }
        public string? NombrePersona { get; set; }
        public string? TelefonoPersona { get; set; }
        public string? EmailPersona { get; set; }
        public int AdultosPersona { get; set; }
        public int InfantesPersona { get; set; }
        public int TourIDPersona { get; set; }
        public string? NombreTour { get; set; }
        public string? DescripcionTour { get; set; }
        public string? ItinerarioTour { get; set; }
        public string? Horario { get; set; }
        public string? IdiomaTour { get; set; }
        public string? imagenTour { get; set; }
        public int PrecioTour { get; set; }
        public int AdultoPrecio { get; set; }
        public int InfantePrecio { get; set; }

        public int TotalAdultos { get; set; }
        public int TotalInfantes { get; set; }
        public int Total { get; set; }

        // Método para calcular los totales
        public void CalcularTotales()
        {
            TotalAdultos = AdultosPersona * AdultoPrecio;
            TotalInfantes = InfantesPersona * InfantePrecio;
            Total = TotalAdultos + TotalInfantes + PrecioTour;
        }

        public string? RutaImagenQR { get; set; }
    }
}
