using MediatR;

namespace Devsu.Core.Features.Cuenta.Queries.ObtenerCuenta
{
    public record ObtenerCuentaQuery(int IdCuenta) : IRequest<ObtenerCuentaResponse>;
}
