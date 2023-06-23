using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Devsu.Core.Features.Cuenta.Queries.ObtenerCuenta
{
    public class ObtenerCuentaHandler : IRequestHandler<ObtenerCuentaQuery, Result>
    {
        private readonly ICuentaRepository cuentaRepository;

        public ObtenerCuentaHandler(ICuentaRepository cuentaRepository)
        {
            this.cuentaRepository = cuentaRepository;
        }

        public async Task<Result> Handle(ObtenerCuentaQuery request, CancellationToken cancellationToken)
        {
            var cuenta = await cuentaRepository.Obtener(request.IdCuenta);
            return new Result(StatusCodes.Status200OK, cuenta is not null ? new ObtenerCuentaResponse(cuenta) : null);
        }
    }
}
