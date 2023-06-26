using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using System.Net;

namespace Devsu.Core.Features.Cliente.Commands.GuardarCliente
{
    public class GuardarClienteHandler : IRequestHandler<GuardarClienteCommand, Result>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public GuardarClienteHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(GuardarClienteCommand? request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                var cliente = mapper.Map<Entities.Cliente>(request);
                cliente.IdPersonaNavigation = mapper.Map<Entities.Persona>(request);
                await clienteRepository.Insertar(cliente);
                await clienteRepository.GuardarCambios();

                return new Result(HttpStatusCode.Created, "¡Cliente creado exitosamente!");
            }

            return new Result(HttpStatusCode.BadRequest, "El modelo de datos es incorrecto.");
        }
    }
}
