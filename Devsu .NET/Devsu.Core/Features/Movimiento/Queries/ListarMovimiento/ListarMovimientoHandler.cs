using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using MediatR;

namespace Devsu.Core.Features.Movimiento.Queries.ListarMovimiento
{
    public class ListarMovimientoHandler : IRequestHandler<ListarMovimientoQuery, ListarMovimientoResponse>
    {
        private readonly IMovimientoRepository movimientoRepository;
        private readonly IMapper mapper;

        public ListarMovimientoHandler(IMovimientoRepository movimientoRepository, IMapper mapper)
        {
            this.movimientoRepository = movimientoRepository;
            this.mapper = mapper;
        }

        public async Task<ListarMovimientoResponse> Handle(ListarMovimientoQuery request, CancellationToken cancellationToken)
        {
            var movimientos = await movimientoRepository.Listar();
            return mapper.Map<ListarMovimientoResponse>(movimientos);
        }
    }
}
