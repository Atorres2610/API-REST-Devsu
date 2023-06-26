using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Devsu.Core.Features.Cliente.Commands.EliminarCliente
{
    public class EliminarClienteHandler : IRequestHandler<EliminarClienteCommand, Result>
    {
        private readonly IClienteRepository clienteRepository;

        public EliminarClienteHandler(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<Result> Handle(EliminarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await clienteRepository.Obtener(c => c.IdCliente == request.IdCliente, c => c.Include(x => x.IdPersonaNavigation).Include(x => x.Cuenta).ThenInclude(x => x.Movimiento), false);

            if (cliente is not null)
            {
                cliente.Eliminar();
                await clienteRepository.GuardarCambios();
                return new Result(HttpStatusCode.OK, "¡Cliente eliminado exitosamente!");
            }

            return new Result(HttpStatusCode.NotFound, "El cliente no existe o ha sido eliminado.");
        }
    }
}
