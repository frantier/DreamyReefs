using DreamyReefs.Models;
using FluentValidation;

namespace DreamyReefs.Validators
{
    public class Validadores : AbstractValidator<AccesoWeb>
    {
        public Validadores()
        {
            RuleFor(x => x.Usuario).NotEmpty().NotNull().WithMessage("El Usuario es obligatorio.");
            RuleFor(x => x.Nombre).NotEmpty().NotNull().WithMessage("El Nombre completo es obligatorio.");
            RuleFor(x => x.Correo).NotEmpty().NotNull().EmailAddress().WithMessage("Por favor, ingrese una dirección de correo electrónico válida.");
            RuleFor(x => x.Contrasena).NotEmpty().NotNull().WithMessage("El campo Contraseña es obligatorio");
        }
    }

    public class EmpresasValidator : AbstractValidator<Empresa>
    {
        public EmpresasValidator()
        {
            RuleFor(x => x.NombreEmpresa).NotEmpty().NotNull().WithMessage("Por favor, escriba el nombre de la empresa");
            RuleFor(x => x.Correo).NotEmpty().NotNull().EmailAddress().WithMessage("Por favor, ingrese una dirección de correo electrónico válida.");
            RuleFor(x => x.Telefono).NotEmpty().NotNull().WithMessage("Por favor, ingrese el telefono de la empresa");
            RuleFor(x => x.Direccion).NotEmpty().NotNull().WithMessage("Por favor, escriba la Direccion de la empresa");
            RuleFor(x => x.RFC).NotEmpty().NotNull().WithMessage("Por favor, escriba RFC de la empresa");
        }
    }

    public class ReservacionValidator : AbstractValidator<Reservacion>
    {
        public ReservacionValidator()
        {
            RuleFor(x => x.NombreCompleto).NotEmpty().NotNull().WithMessage("Por favor, escriba el nombre completo.");
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Por favor, ingrese una dirección de correo electrónico válida.");
            RuleFor(x => x.Telefono).NotEmpty().NotNull().WithMessage("Por favor, ingrese su numero de telefono");
            RuleFor(x => x.Adultos).NotEmpty().NotNull().WithMessage("Por favor, especifique el numero de adultos");
            RuleFor(x => x.Infantes).NotEmpty().NotNull().WithMessage("Por favor, especifique el numero de infantes");
        }
    }

    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.Comentario).NotEmpty().NotNull().WithMessage("No puede enviar una opinion vacia.");
        }
    }

    public class TourValidator : AbstractValidator<Tours>
    {
        public TourValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().NotNull().WithMessage("Por favor, escriba el nombre del tour.");
            RuleFor(x => x.Itinerario).NotEmpty().NotNull().WithMessage("Por favor, escriba el itinerario del tour.");
            RuleFor(x => x.Precio).NotEmpty().NotNull().WithMessage("Por favor, escriba el precio del tour.");
            RuleFor(x => x.Descripcion).NotEmpty().NotNull().WithMessage("Por favor, escriba la descripcion del tour");
            RuleFor(x => x.Disponibilidad).NotEmpty().NotNull().WithMessage("Por favor, especifique la disponibilidad del tour.");
            RuleFor(x => x.Idioma).NotEmpty().NotNull().WithMessage("Por favor, especifique el idioma del tour.");
            RuleFor(x => x.Categoria1).NotEmpty().NotNull().WithMessage("Por favor, selecione una categoria (categoria 1)");
            RuleFor(x => x.Categoria2).NotEmpty().NotNull().WithMessage("Por favor, selecione una categoria (categoria 2)");
            RuleFor(x => x.Categoria3).NotEmpty().NotNull().WithMessage("Por favor, selecione una categoria (categoria 3)");
            RuleFor(x => x.Categoria4).NotEmpty().NotNull().WithMessage("Por favor, selecione una categoria (categoria 4)");
            RuleFor(x => x.Caracteristica1).NotEmpty().NotNull().WithMessage("Por favor, selecione una caracteristica (caracteristica 1)");
            RuleFor(x => x.Caracteristica2).NotEmpty().NotNull().WithMessage("Por favor, selecione una caracteristica (caracteristica 2)");
            RuleFor(x => x.Caracteristica3).NotEmpty().NotNull().WithMessage("Por favor, selecione una caracteristica (caracteristica 3)");
            RuleFor(x => x.PrecioAdulto).NotEmpty().NotNull().WithMessage("Por favor, especifique el precio del adulto del tour.");
            RuleFor(x => x.PrecioInfantes).NotEmpty().NotNull().WithMessage("Por favor, especifique el precio de infantes del tour.");
        }
    }

    public class TransporteValidator : AbstractValidator<Transportes>
    {
        public TransporteValidator()
        {
            RuleFor(x => x.NombreEmpresa).NotEmpty().NotNull().WithMessage("Por favor, escriba el nombre de la empresa");
            RuleFor(x => x.Transporte).NotEmpty().NotNull().WithMessage("Por favor, especifique el tipo de transporte de la empresa");
        }
    }
}
