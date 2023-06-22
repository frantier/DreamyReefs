using System.ComponentModel.DataAnnotations.Schema;

namespace DreamyReefs.Models
{
    public class AccesoWeb
    {
        public int IDAccesoWeb { get; set; }
        public string? Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? Estatus { get; set; }
        public string? RefreshToken { get; set; }
        [NotMapped]
        public bool sesion { get; set; }
    }
}