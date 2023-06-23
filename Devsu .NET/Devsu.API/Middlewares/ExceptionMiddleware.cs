using Devsu.Core.Models;
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
                await EscribirResultadoExcepcion(context, ex, "Ocurrió un error inesperado");
            }
        }

        private async Task EscribirResultadoExcepcion(HttpContext context, Exception exception, string mensaje)
        {
            logger.LogError("{Mensaje}: {Message} - {StackTrace}", mensaje, exception.Message, exception.StackTrace);

            string resultExpection = new Result(StatusCodes.Status500InternalServerError, $"{mensaje}: {exception.Message}").ToString();

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(resultExpection, Encoding.UTF8);
        }
    }
}
