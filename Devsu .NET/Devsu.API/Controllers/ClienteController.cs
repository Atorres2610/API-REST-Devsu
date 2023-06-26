using Devsu.Core.Features.Cliente.Commands.ActualizarCliente;
using Devsu.Core.Features.Cliente.Commands.EliminarCliente;
using Devsu.Core.Features.Cliente.Commands.GuardarCliente;
using Devsu.Core.Features.Cliente.Queries.ListarCliente;
using Devsu.Core.Features.Cliente.Queries.ObtenerCliente;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devsu.API.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IMediator mediator;
        public ClienteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> ListarCliente()
        {
            var query = new ListarClienteQuery();
            var response = await mediator.Send(query);
            return ResultResponse(response);
        }

        [HttpGet("{idCliente}", Name = "clienteCreado")]
        public async Task<ActionResult> ObtenerCliente(int idCliente)
        {
            var query = new ObtenerClienteQuery(idCliente);
            var response = await mediator.Send(query);
            return ResultResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> GuardarCliente([FromBody] GuardarClienteCommand request)
        {
            var response = await mediator.Send(request);
            return ResultResponse(response);
        }

        [HttpPut("{idCliente}")]
        public async Task<ActionResult> ActualizarCliente(int idCliente, [FromBody] ActualizarClienteCommand request)
        {
            if (request is not null && request.IdCliente == idCliente)
            {
                request.IdCliente = idCliente;
                var response = await mediator.Send(request);
                return ResultResponse(response);
            }

            return ResultResponse(new Core.Models.Result(HttpStatusCode.BadRequest, "El modelo de datos o el id del cliente no es el correcto."));
        }

        [HttpDelete("{idCliente}")]
        public async Task<ActionResult> EliminarCliente(int idCliente)
        {
            var command = new EliminarClienteCommand(idCliente);
            var response = await mediator.Send(command);
            return ResultResponse(response);
        }
    }
}
