using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using System.Net;

namespace Devsu.Core.Features.Movimiento.Commands.GuardarMovimiento
{
    public class GuardarMovimientoHandler : IRequestHandler<GuardarMovimientoCommand, Result>
    {
        private readonly IMovimientoRepository movimientoRepository;
        private readonly ICuentaRepository cuentaRepository;
        private readonly IMapper mapper;

        public GuardarMovimientoHandler(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository, IMapper mapper)
        {
            this.movimientoRepository = movimientoRepository;
            this.cuentaRepository = cuentaRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(GuardarMovimientoCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                //Verificar si la cuenta existe
                var cuenta = await cuentaRepository.Obtener(c => c.IdCuenta == request.IdCuenta);

                if (cuenta is not null)
                {
                    Entities.Movimiento movimiento = mapper.Map<Entities.Movimiento>(request);

                    /* Obtener el último movimiento si existe se usa su saldo y el limite, de lo contrario el saldo inicial de la cuenta y el limite por defecto */
                    var ultimoMovimiento = await movimientoRepository.ObtenerUltimoMovimientoPorIdCuenta(cuenta.IdCuenta);
                    string respuestaTransaccion = movimiento.Transaccion(
                        request.Tipo,
                        ultimoMovimiento is not null ? ultimoMovimiento.Saldo : cuenta.SaldoInicial,
                        movimiento.Valor,
                        ultimoMovimiento is not null ? ultimoMovimiento.Limite : Entities.Movimiento.LIMITE_DIARIO);

                    if (string.IsNullOrEmpty(respuestaTransaccion))
                    {
                        //Insertamos el movimiento a la base de datos
                        await movimientoRepository.Insertar(movimiento);
                        await movimientoRepository.GuardarCambios();
                        return new Result(HttpStatusCode.Created, "¡Movimiento creado exitosamente!");
                    }

                    return new Result(HttpStatusCode.UnprocessableEntity, respuestaTransaccion);
                }

                return new Result(HttpStatusCode.BadRequest, "La cuenta no existe o ha sido eliminado.");
            }

            return new Result(HttpStatusCode.BadRequest, "El modelo de datos es incorrecto.");
        }
    }
}
