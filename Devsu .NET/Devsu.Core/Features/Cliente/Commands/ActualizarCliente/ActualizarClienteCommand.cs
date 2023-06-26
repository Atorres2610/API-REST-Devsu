using Devsu.Core.Models;
using Devsu.Core.Models.Validaciones;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Devsu.Core.Features.Cliente.Commands.ActualizarCliente
{
    public record ActualizarClienteCommand : IRequest<Result>
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1} y menor que {2}.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public required string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public required string Genero { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1} y menor que {2}.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public required string Identificacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public required string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public required string Telefono { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public required string Contrasena { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [BooleanRequired(ErrorMessage = "El campo {0} es inválido")]
        public bool? Estado { get; set; }
    }
}
