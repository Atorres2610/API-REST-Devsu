using Devsu.Core.Features.Cliente.Queries;
using Devsu.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            Result result = await mediator.Send(query);
            return ResultResponse(result);
        }
    }
}
