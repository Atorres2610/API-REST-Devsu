using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Devsu.Core.Features.Cuenta.Commands.ActualizarCuenta
{
    public class ActualizarCuentaHandler : IRequestHandler<ActualizarCuentaCommand, Result>
    {
        private readonly ICuentaRepository cuentaRepository;

        public ActualizarCuentaHandler(ICuentaRepository cuentaRepository)
        {
            this.cuentaRepository = cuentaRepository;
        }

        public async Task<Result> Handle(ActualizarCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await cuentaRepository.Obtener(request.IdCuenta);
            if (cuenta is not null)
            {
            }

            return new Result(StatusCodes.Status204NoContent, "¡Se actualizó la cuenta exitosamente!");
        }
    }
}
