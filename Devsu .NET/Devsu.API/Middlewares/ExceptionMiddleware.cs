using Devsu.Core.Models;
using System.Net;
using System.Text;

namespace Devsu.API.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                string mensaje = $"Ocurrió un error inesperado: {ex.Message}";
                string resultadoExcepcion = new Result(HttpStatusCode.InternalServerError, mensaje).ToString();

                await EscribirResultadoExcepcion(context, ex, StatusCodes.Status500InternalServerError, mensaje, resultadoExcepcion);
            }
        }

        private async Task EscribirResultadoExcepcion(HttpContext context, Exception ex, int statusCodes, string message, string resultException)
        {
            logger.LogError("{Mensaje} - {StackTrace}", message, ex.StackTrace);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCodes;
            await context.Response.WriteAsync(resultException, Encoding.UTF8);
        }
    }
}
