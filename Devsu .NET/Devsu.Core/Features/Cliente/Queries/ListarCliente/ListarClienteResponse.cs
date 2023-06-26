using Devsu.Core.Models;

namespace Devsu.Core.Features.Cliente.Queries.ListarCliente
{
    public class ListarClienteResponse : Result
    {
        public List<ClienteResponse> Clientes { get; set; } = new();

        public class ClienteResponse
        {
            public int IdCliente { get; set; }
            public required string Cliente { get; set; }
            public bool Estado { get; set; }
        }
    }
}