using Devsu.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devsu.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult ResultResponse(Result? result = null)
        {
            result ??= new Result();
            return StatusCode((int)result.Code, result);
        }
    }
}
