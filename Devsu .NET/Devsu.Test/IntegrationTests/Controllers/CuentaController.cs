using Microsoft.AspNetCore.Http;

namespace Devsu.Test.IntegrationTests.Controllers
{
    public class CuentaController : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient httpClient;

        public CuentaController(CustomWebApplicationFactory<Program> applicationFactory)
        {
            httpClient = applicationFactory.CreateClient();
        }

        [Fact]
        public async Task ListarCuentaRetornaOK()
        {
            var response = await httpClient.GetAsync("/api/cuentas");
            Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        [Fact]
        public async Task ObtenerCuentaRetornaNoEncontrado()
        {
            var response = await httpClient.GetAsync("/api/cuentas/2");
            Assert.Equal(StatusCodes.Status404NotFound, (int)response.StatusCode);
        }
    }
}
