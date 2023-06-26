using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using System.Net;

namespace Devsu.Core.Features.Movimiento.Commands.ActualizarMovimiento
{
    public class ActualizarMovimientoHandler : IRequestHandler<ActualizarMovimientoCommand, Result>
    {
        private readonly IMovimientoRepository movimientoRepository;
        private readonly ICuentaRepository cuentaRepository;
        private readonly IMapper mapper;

        public ActualizarMovimientoHandler(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository, IMapper mapper)
        {
            this.movimientoRepository = movimientoRepository;
            this.cuentaRepository = cuentaRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(ActualizarMovimientoCommand request, CancellationToken cancellationToken)
        {
            var movimiento = await movimientoRepository.Obtener(m => m.IdMovimiento == request.IdMovimiento);
            if (movimiento is not null)
            {
                var existeCuenta = await cuentaRepository.ValidarExistencia(c => c.IdCuenta == request.IdCuenta);
                if (existeCuenta)
                {
                    movimiento.Actualizar();
                    movimientoRepository.Actualizar(mapper.Map(request, movimiento));
                    await movimientoRepository.GuardarCambios();

                    return new Result(HttpStatusCode.OK, "¡Movimiento actualizado exitosamente!");
                }

                return new Result(HttpStatusCode.BadRequest, "La cuenta no existe o ha sido eliminada.");
            }

            return new Result(HttpStatusCode.NotFound, "El movimiento no existe o ha sido eliminado.");
        }
    }
}
