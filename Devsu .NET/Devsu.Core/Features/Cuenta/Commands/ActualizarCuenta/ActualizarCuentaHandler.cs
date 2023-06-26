using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using System.Net;

namespace Devsu.Core.Features.Cuenta.Commands.ActualizarCuenta
{
    public class ActualizarCuentaHandler : IRequestHandler<ActualizarCuentaCommand, Result>
    {
        private readonly ICuentaRepository cuentaRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ActualizarCuentaHandler(ICuentaRepository cuentaRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            this.cuentaRepository = cuentaRepository;
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(ActualizarCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await cuentaRepository.Obtener(c => c.IdCuenta == request.IdCuenta);
            if (cuenta is not null)
            {
                var existeCliente = await clienteRepository.ValidarExistencia(c => c.IdCliente == request.IdCliente);
                if (existeCliente)
                {
                    cuentaRepository.Actualizar(mapper.Map(request, cuenta));
                    await cuentaRepository.GuardarCambios();
                    return new Result(HttpStatusCode.OK, "¡Cuenta actualizada exitosamente!");
                }

                return new Result(HttpStatusCode.BadRequest, "El cliente no existe o ha sido eliminada.");
            }

            return new Result(HttpStatusCode.NotFound, "La cuenta no existe o ha sido eliminada.");
        }
    }
}
