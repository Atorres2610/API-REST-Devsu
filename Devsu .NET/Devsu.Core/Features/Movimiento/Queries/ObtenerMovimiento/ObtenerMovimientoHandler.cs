using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using MediatR;
using System.Net;

namespace Devsu.Core.Features.Movimiento.Queries.ObtenerMovimiento
{
    public class ObtenerMovimientoHandler : IRequestHandler<ObtenerMovimientoQuery, ObtenerMovimientoResponse>
    {
        private readonly IMovimientoRepository movimientoRepository;
        private readonly IMapper mapper;

        public ObtenerMovimientoHandler(IMovimientoRepository movimientoRepository, IMapper mapper)
        {
            this.movimientoRepository = movimientoRepository;
            this.mapper = mapper;
        }

        public async Task<ObtenerMovimientoResponse> Handle(ObtenerMovimientoQuery request, CancellationToken cancellationToken)
        {
            var movimiento = await movimientoRepository.Obtener(m => m.IdMovimiento == request.IdMovimiento);

            if (movimiento is not null)
            {
                return mapper.Map<ObtenerMovimientoResponse>(movimiento);
            }

            return new ObtenerMovimientoResponse(HttpStatusCode.NotFound, "No se encontró el movimiento.");
        }
    }
}
