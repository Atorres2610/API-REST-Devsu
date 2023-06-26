using MediatR;

namespace Devsu.Core.Features.Movimiento.Queries.ListarMovimiento
{
    public record ListarMovimientoQuery : IRequest<ListarMovimientoResponse>;
}