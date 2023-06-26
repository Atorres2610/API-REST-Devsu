using Microsoft.AspNetCore.Http;

namespace Devsu.Test.IntegrationTests.Controllers
{
    public class ClienteController : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient httpClient;

        public ClienteController(CustomWebApplicationFactory<Program> applicationFactory)
        {
            httpClient = applicationFactory.CreateClient();
        }

        //[Theory]
        //[InlineData("/api/clientes")]
        [Fact]
        public async Task ListarClientesRetornaOK(/*string url*/)
        {
            var response = await httpClient.GetAsync("/api/clientes");
            Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        [Fact]
        public async Task ObtenerClienteNoEncontrado(/*string url*/)
        {
            var response = await httpClient.GetAsync("/api/clientes/5");
            Assert.Equal(StatusCodes.Status404NotFound, (int)response.StatusCode);
        }
    }
}
