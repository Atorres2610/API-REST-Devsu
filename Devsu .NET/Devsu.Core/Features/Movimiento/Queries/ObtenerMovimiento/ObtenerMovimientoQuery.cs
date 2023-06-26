using MediatR;

namespace Devsu.Core.Features.Movimiento.Queries.ObtenerMovimiento
{
    public record ObtenerMovimientoQuery(int IdMovimiento) : IRequest<ObtenerMovimientoResponse>;
}
