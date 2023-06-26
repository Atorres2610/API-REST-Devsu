using Devsu.Core.Models;
using Devsu.Core.Models.Validaciones;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Devsu.Core.Features.Cliente.Commands.GuardarCliente
{
    public record GuardarClienteCommand : IRequest<Result>
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1} y menor que {2}.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public string? Identificacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(250, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener menos de {1} caracteres.")]
        public string? Contrasena { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [BooleanRequired(ErrorMessage = "El campo {0} es inválido")]
        public bool Estado { get; set; }
    }
}
