using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Devsu.Core.Features.Cliente.Queries.ObtenerCliente
{
    public class ObtenerClienteHandler : IRequestHandler<ObtenerClienteQuery, ObtenerClienteResponse>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ObtenerClienteHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<ObtenerClienteResponse> Handle(ObtenerClienteQuery request, CancellationToken cancellationToken)
        {
            var cliente = await clienteRepository.Obtener(c => c.IdCliente == request.IdCliente, c => c.Include(x => x.IdPersonaNavigation));

            if (cliente is not null)
            {
                return mapper.Map<ObtenerClienteResponse>(cliente);
            }

            return new ObtenerClienteResponse(HttpStatusCode.NotFound, "El cliente no existe o ha sido eliminado.");
        }
    }
}
