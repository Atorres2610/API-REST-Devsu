using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using System.Net;

namespace Devsu.Core.Features.Cuenta.Commands.GuardarCuenta
{
    public class GuardarCuentaHandler : IRequestHandler<GuardarCuentaCommand, Result>
    {
        private readonly ICuentaRepository cuentaRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public GuardarCuentaHandler(ICuentaRepository cuentaRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            this.cuentaRepository = cuentaRepository;
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(GuardarCuentaCommand? request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                bool existeCliente = await clienteRepository.ValidarExistencia(c => c.IdCliente == request.IdCliente);
                if (existeCliente)
                {
                    await cuentaRepository.Insertar(mapper.Map<Entities.Cuenta>(request));
                    await cuentaRepository.GuardarCambios();
                    return new Result(HttpStatusCode.Created, "¡Cuenta creada exitosamente!");
                }

                return new Result(HttpStatusCode.BadRequest, "El cliente no existe o ha sido eliminado.");
            }

            return new Result(HttpStatusCode.BadRequest, "El modelo de datos es incorrecto.");
        }
    }
}
