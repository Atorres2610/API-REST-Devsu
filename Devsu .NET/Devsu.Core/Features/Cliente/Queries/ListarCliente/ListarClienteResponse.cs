namespace Devsu.Core.Features.Cliente.Queries.ListarCliente
{
    public class ListarClienteResponse
    {
        public List<ClienteResponse> Clientes { get; set; }

        public ListarClienteResponse(List<Entities.Cliente> clientes)
        {
            Clientes = new();

            foreach (var cliente in clientes)
            {
                Clientes.Add(new ClienteResponse(cliente));
            }
        }

        public class ClienteResponse
        {
            public int IdCliente { get; set; }
            public string? Cliente { get; set; }
            public bool Estado { get; set; }

            public ClienteResponse(Entities.Cliente cliente)
            {
                IdCliente = cliente.IdCliente;
                Cliente = cliente.IdPersonaNavigation.Nombre;
                Estado = cliente.Estado;
            }
        }
    }
}
