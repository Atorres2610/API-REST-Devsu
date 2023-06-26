using Devsu.Core.Models;
using System.Net;

namespace Devsu.Core.Features.Cliente.Queries.ObtenerCliente
{
    public class ObtenerClienteResponse : Result
    {
        public ObtenerClienteResponse()
        {
        }

        public ObtenerClienteResponse(HttpStatusCode code, string message) : base(code, message)
        {
        }

        public ClienteResponse? Cliente { get; set; }

        public class ClienteResponse
        {
            public int IdCliente { get; set; }
            public string? Nombres { get; set; }
            public string? Genero { get; set; }
            public int Edad { get; set; }
            public string? Identificacion { get; set; }
            public string? Direccion { get; set; }
            public string? Telefono { get; set; }
            public string? Contrasena { get; set; }
            public bool Estado { get; set; }
        }
    }
}
