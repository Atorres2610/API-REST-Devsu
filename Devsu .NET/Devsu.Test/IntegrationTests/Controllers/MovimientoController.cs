using Microsoft.AspNetCore.Http;

namespace Devsu.Test.IntegrationTests.Controllers
{
    public class MovimientoController : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient httpClient;

        public MovimientoController(CustomWebApplicationFactory<Program> applicationFactory)
        {
            httpClient = applicationFactory.CreateClient();
        }

        [Fact]
        public async Task ListarMovimientoRetornaOK()
        {
            var response = await httpClient.GetAsync("/api/movimientos");
            Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        [Fact]
        public async Task ObtenerMovimientoRetornaNoEncontrado()
        {
            var response = await httpClient.GetAsync("/api/movimientos/3");
            Assert.Equal(StatusCodes.Status404NotFound, (int)response.StatusCode);
        }
    }
}
