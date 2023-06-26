using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Devsu.Core.Features.Cliente.Commands.ActualizarCliente
{
    public class ActualizarClienteHandler : IRequestHandler<ActualizarClienteCommand, Result>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ActualizarClienteHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(ActualizarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await clienteRepository.Obtener(c => c.IdCliente == request.IdCliente, c => c.Include(x => x.IdPersonaNavigation));

            if (cliente is not null)
            {
                cliente = mapper.Map(request, cliente);
                cliente.IdPersonaNavigation = mapper.Map(request, cliente.IdPersonaNavigation);
                clienteRepository.Actualizar(cliente);
                await clienteRepository.GuardarCambios();

                return new Result(HttpStatusCode.OK, "¡Cliente actualizado exitosamente!");
            }

            return new Result(HttpStatusCode.NotFound, "El cliente no existe o ha sido eliminado.");
        }
    }
}
