using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Devsu.Core.Features.Cuenta.Commands.GuardarCuenta
{
    public class GuardarCuentaHandler : IRequestHandler<GuardarCuentaCommand, Result>
    {
        private readonly ICuentaRepository cuentaRepository;

        public GuardarCuentaHandler(ICuentaRepository cuentaRepository)
        {
            this.cuentaRepository = cuentaRepository;
        }

        public async Task<Result> Handle(GuardarCuentaCommand request, CancellationToken cancellationToken)
        {
            await cuentaRepository.Insertar(new Entities.Cuenta
            {
                Numero = request.Numero,
                Tipo = request.Tipo,
                Estado = request.Estado,
            });

            await cuentaRepository.GuardarCambios();

            return new Result(StatusCodes.Status201Created, "¡Cuenta creada exitosamente!");
        }
    }
}
