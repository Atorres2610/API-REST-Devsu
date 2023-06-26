using Devsu.Core.Features.Cuenta.Commands.ActualizarCuenta;
using Devsu.Core.Features.Cuenta.Commands.EliminarCuenta;
using Devsu.Core.Features.Cuenta.Commands.GuardarCuenta;
using Devsu.Core.Features.Cuenta.Queries.ListarCuenta;
using Devsu.Core.Features.Cuenta.Queries.ObtenerCuenta;
using Devsu.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devsu.API.Controllers
{
    [Route("api/cuentas")]
    [ApiController]
    public class CuentaController : BaseController
    {
        private readonly IMediator mediator;
        public CuentaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> ListarCuenta()
        {
            var query = new ListarCuentaQuery();
            var response = await mediator.Send(query);
            return ResultResponse(response);
        }

        [HttpGet("{idCuenta}")]
        public async Task<ActionResult> ObtenerCuenta(int idCuenta)
        {
            var query = new ObtenerCuentaQuery(idCuenta);
            var response = await mediator.Send(query);
            return ResultResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> GuardarCuenta([FromBody] GuardarCuentaCommand request)
        {
            var response = await mediator.Send(request);
            return ResultResponse(response);
        }

        [HttpPut("{idCuenta}")]
        public async Task<ActionResult> ActualizarCuenta(int idCuenta, [FromBody] ActualizarCuentaCommand request)
        {
            if (request is not null && request.IdCuenta == idCuenta)
            {
                request.IdCuenta = idCuenta;
                var response = await mediator.Send(request);
                return ResultResponse(response);
            }

            return ResultResponse(new Result(HttpStatusCode.BadRequest, "El modelo de datos o el id de la cuenta no es el correcto."));
        }

        [HttpDelete("{idCuenta}")]
        public async Task<ActionResult> EliminarCuenta(int idCuenta)
        {
            var command = new EliminarCuentaCommand(idCuenta);
            var response = await mediator.Send(command);
            return ResultResponse(response);
        }
    }
}
