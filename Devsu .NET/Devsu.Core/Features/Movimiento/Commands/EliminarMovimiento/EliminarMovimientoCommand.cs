using Devsu.Core.Models;
using MediatR;

namespace Devsu.Core.Features.Movimiento.Commands.EliminarMovimiento
{
    public record EliminarMovimientoCommand(int IdMovimiento) : IRequest<Result>;
}
