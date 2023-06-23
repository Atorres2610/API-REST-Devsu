using Devsu.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace Devsu.Core.Features.Cuenta.Commands.ActualizarCuenta
{
    public record ActualizarCuentaCommand : IRequest<Result>
    {
        [JsonIgnore]
        public int IdCuenta { get; set; }
        public required string Numero { get; set; }
        public required string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    }
}
