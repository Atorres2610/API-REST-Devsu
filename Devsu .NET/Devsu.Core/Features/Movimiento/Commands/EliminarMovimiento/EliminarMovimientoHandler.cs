using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using System.Net;

namespace Devsu.Core.Features.Movimiento.Commands.EliminarMovimiento
{
    public class EliminarMovimientoHandler : IRequestHandler<EliminarMovimientoCommand, Result>
    {
        private readonly IMovimientoRepository movimientoRepository;

        public EliminarMovimientoHandler(IMovimientoRepository movimientoRepository)
        {
            this.movimientoRepository = movimientoRepository;
        }

        public async Task<Result> Handle(EliminarMovimientoCommand request, CancellationToken cancellationToken)
        {
            var movimiento = await movimientoRepository.Obtener(m => m.IdMovimiento == request.IdMovimiento, null, false);
            if (movimiento is not null)
            {
                movimiento.Eliminar();
                await movimientoRepository.GuardarCambios();

                return new Result(HttpStatusCode.OK, "¡Movimiento eliminado exitosamente!");
            }

            return new Result(HttpStatusCode.NotFound, "El movimiento no existe o ha sido eliminado.");
        }
    }
}
