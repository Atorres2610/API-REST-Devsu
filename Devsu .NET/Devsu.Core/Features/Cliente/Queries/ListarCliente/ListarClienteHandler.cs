using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Core.Features.Cliente.Queries.ListarCliente
{
    public class ListarClienteHandler : IRequestHandler<ListarClienteQuery, Result>
    {
        private readonly IClienteRepository clienteRepository;

        public ListarClienteHandler(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        async Task<Result> IRequestHandler<ListarClienteQuery, Result>.Handle(ListarClienteQuery request, CancellationToken cancellationToken)
        {
            var listaClientes = await clienteRepository.Listar(c => c.Include(x => x.IdPersonaNavigation));
            ListarClienteResponse response = new(listaClientes);
            return new Result(StatusCodes.Status200OK, response.Clientes);
        }
    }
}
