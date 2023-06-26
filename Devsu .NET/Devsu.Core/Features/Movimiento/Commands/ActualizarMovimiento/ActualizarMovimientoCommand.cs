using Devsu.Core.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Devsu.Core.Features.Movimiento.Commands.ActualizarMovimiento
{
    public record ActualizarMovimientoCommand : IRequest<Result>
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1} y menor que {2}.")]
        public int IdMovimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1} y menor que {2}.")]
        public int IdCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EnumDataType(typeof(Entities.Movimiento.Tipos), ErrorMessage = "El valor del campo {0} no es válido.")]
        public Entities.Movimiento.Tipos Tipo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Saldo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Limite { get; set; }
    }
}
