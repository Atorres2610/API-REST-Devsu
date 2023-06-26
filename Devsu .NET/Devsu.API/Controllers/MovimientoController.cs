using Devsu.Core.Features.Movimiento.Commands.ActualizarMovimiento;
using Devsu.Core.Features.Movimiento.Commands.EliminarMovimiento;
using Devsu.Core.Features.Movimiento.Commands.GuardarMovimiento;
using Devsu.Core.Features.Movimiento.Queries.ListarMovimiento;
using Devsu.Core.Features.Movimiento.Queries.ObtenerMovimiento;
using Devsu.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devsu.API.Controllers
{
    [Route("api/movimientos")]
    [ApiController]
    public class MovimientoController : BaseController
    {
        private readonly IMediator mediator;
        public MovimientoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> ListarMovimiento()
        {
            var query = new ListarMovimientoQuery();
            var response = await mediator.Send(query);
            return ResultResponse(response);
        }

        [HttpGet("{idMovimiento}")]
        public async Task<ActionResult> ObtenerMovimiento(int idMovimiento)
        {
            var query = new ObtenerMovimientoQuery(idMovimiento);
            var response = await mediator.Send(query);
            return ResultResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> GuardarMovimiento([FromBody] GuardarMovimientoCommand request)
        {
            var response = await mediator.Send(request);
            return ResultResponse(response);
        }

        [HttpPut("{idMovimiento}")]
        public async Task<ActionResult> ActualizarMovimiento(int idMovimiento, [FromBody] ActualizarMovimientoCommand request)
        {
            if (request is not null && request.IdMovimiento == idMovimiento)
            {
                var response = await mediator.Send(request);
                return ResultResponse(response);
            }

            return ResultResponse(new Result(HttpStatusCode.BadRequest, "El modelo de datos es incorrecto."));
        }

        [HttpDelete("{idMovimiento}")]
        public async Task<ActionResult> EliminarMovimiento(int idMovimiento)
        {
            var command = new EliminarMovimientoCommand(idMovimiento);
            var response = await mediator.Send(command);
            return ResultResponse(response);
        }
    }
}
