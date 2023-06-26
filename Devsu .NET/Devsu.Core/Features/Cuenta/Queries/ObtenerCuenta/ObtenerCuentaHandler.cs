using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using MediatR;
using System.Net;

namespace Devsu.Core.Features.Cuenta.Queries.ObtenerCuenta
{
    public class ObtenerCuentaHandler : IRequestHandler<ObtenerCuentaQuery, ObtenerCuentaResponse>
    {
        private readonly ICuentaRepository cuentaRepository;
        private readonly IMapper mapper;

        public ObtenerCuentaHandler(ICuentaRepository cuentaRepository, IMapper mapper)
        {
            this.cuentaRepository = cuentaRepository;
            this.mapper = mapper;
        }

        public async Task<ObtenerCuentaResponse> Handle(ObtenerCuentaQuery request, CancellationToken cancellationToken)
        {
            var cuenta = await cuentaRepository.Obtener(c => c.IdCuenta == request.IdCuenta);
            if (cuenta is not null)
            {
                return mapper.Map<ObtenerCuentaResponse>(cuenta);
            }

            return new ObtenerCuentaResponse(HttpStatusCode.NotFound, "La cuenta no existe o ha sido eliminada.");
        }
    }
}
