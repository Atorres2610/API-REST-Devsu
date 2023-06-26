using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Core.Features.Cliente.Queries.ListarCliente
{
    public class ListarClienteHandler : IRequestHandler<ListarClienteQuery, ListarClienteResponse>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ListarClienteHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<ListarClienteResponse> Handle(ListarClienteQuery request, CancellationToken cancellationToken)
        {
            var listaClientes = await clienteRepository.Listar(c => c.Include(x => x.IdPersonaNavigation));
            return mapper.Map<ListarClienteResponse>(listaClientes);
        }
    }
}
