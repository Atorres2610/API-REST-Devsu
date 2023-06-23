using Devsu.Core.Models;
using MediatR;

namespace Devsu.Core.Features.Cuenta.Queries.ListarCuenta
{
    public record ListarCuentaQuery : IRequest<Result>
    {
    }
}
