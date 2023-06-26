using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Devsu.Core.Features.Cuenta.Commands.EliminarCuenta
{
    public class EliminarCuentaHandler : IRequestHandler<EliminarCuentaCommand, Result>
    {
        private readonly ICuentaRepository cuentaRepository;

        public EliminarCuentaHandler(ICuentaRepository cuentaRepository)
        {
            this.cuentaRepository = cuentaRepository;
        }

        public async Task<Result> Handle(EliminarCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await cuentaRepository.Obtener(c => c.IdCuenta == request.IdCuenta, c => c.Include(i => i.Movimiento), false);
            if (cuenta is not null)
            {
                cuenta.ELiminar();
                await cuentaRepository.GuardarCambios();
                return new Result(HttpStatusCode.OK, "¡Cuenta eliminada exitosamente!");
            }

            return new Result(HttpStatusCode.NotFound, "La cuenta no existe o ha sido eliminada.");
        }
    }
}
