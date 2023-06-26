using Devsu.Core.Features.Reporte.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devsu.API.Controllers
{
    [Route("api/reportes")]
    [ApiController]
    public class ReporteController : BaseController
    {
        private readonly IMediator mediator;

        public ReporteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("[action]/{idCliente}")]
        public async Task<ActionResult> EstadosCuentas(int idCliente, DateTime? fechaInicio, DateTime? fechaFinal)
        {
            var query = new EstadoCuentaQuery(idCliente, fechaInicio, fechaFinal);
            var resultData = await mediator.Send(query);
            return ResultResponse(resultData);
        }
    }
}
