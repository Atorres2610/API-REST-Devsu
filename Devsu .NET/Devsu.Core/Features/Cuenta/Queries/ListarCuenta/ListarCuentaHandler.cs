using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using MediatR;

namespace Devsu.Core.Features.Cuenta.Queries.ListarCuenta
{
    public class ListarCuentaHandler : IRequestHandler<ListarCuentaQuery, ListarCuentaResponse>
    {
        private readonly ICuentaRepository cuentaRepository;
        private readonly IMapper mapper;

        public ListarCuentaHandler(ICuentaRepository cuentaRepository, IMapper mapper)
        {
            this.cuentaRepository = cuentaRepository;
            this.mapper = mapper;
        }

        public async Task<ListarCuentaResponse> Handle(ListarCuentaQuery request, CancellationToken cancellationToken)
        {
            var cuentas = await cuentaRepository.Listar();
            return mapper.Map<ListarCuentaResponse>(cuentas);
        }
    }
}
