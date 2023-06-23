using Devsu.Core.Models;
using MediatR;

namespace Devsu.Core.Features.Cuenta.Commands.GuardarCuenta
{
    public record GuardarCuentaCommand(string Numero, string Tipo, decimal SaldoInicial, bool Estado) : IRequest<Result>;
}
