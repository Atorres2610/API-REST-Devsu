using Devsu.Core.Features.Cuenta.Commands.GuardarCuenta;
using Devsu.Core.Features.Cuenta.Queries.ListarCuenta;
using Devsu.Core.Features.Cuenta.Queries.ObtenerCuenta;
using Devsu.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            Result result = await mediator.Send(query);
            return ResultResponse(result);
        }

        [HttpGet("{idCuenta}")]
        public async Task<ActionResult> ObtenerCuenta(int idCuenta)
        {
            var query = new ObtenerCuentaQuery(idCuenta);
            Result result = await mediator.Send(query);
            return ResultResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult> GuardarCuenta([FromBody] GuardarCuentaCommand request)
        {
            Result result = await mediator.Send(request);
            return ResultResponse(result);
        }

        //[HttpPut("{idCuenta}")]
        //public async Task<ActionResult> ActualizarCuenta(int idCuenta, [FromBody] ActualizarCuentaCommand request)
        //{
        //    request.IdCuenta = idCuenta;

        //}

        //[HttpDelete("{idCuenta}")]
        //public async Task<ActionResult> EliminarCuenta(int idCuenta)
        //{

        //}
    }
}
