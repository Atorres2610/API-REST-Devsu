using Devsu.Core.Models;
using MediatR;

namespace Devsu.Core.Features.Cuenta.Commands.EliminarCuenta
{
    public record EliminarCuentaCommand(int IdCuenta) : IRequest<Result>;
}
