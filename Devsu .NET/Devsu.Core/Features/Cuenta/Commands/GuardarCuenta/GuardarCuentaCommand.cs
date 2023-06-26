using Devsu.Core.Models;
using Devsu.Core.Models.Validaciones;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Devsu.Core.Features.Cuenta.Commands.GuardarCuenta
{
    public record GuardarCuentaCommand : IRequest<Result>
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1} y menor que {2}.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener menos de 50 caracteres.")]
        public required string Numero { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EnumDataType(typeof(Entities.Cuenta.Tipos), ErrorMessage = "El valor del campo {0} no es válido.")]
        public Entities.Cuenta.Tipos Tipo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal SaldoInicial { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [BooleanRequired(ErrorMessage = "El campo {0} es inválido")]
        public bool Estado { get; set; }
    }
}
