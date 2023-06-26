using Devsu.Core.Models;
using System.Net;

namespace Devsu.Core.Features.Cuenta.Queries.ObtenerCuenta
{
    public class ObtenerCuentaResponse : Result
    {
        public CuentaResponse? Cuenta { get; set; }

        public ObtenerCuentaResponse() { }
        public ObtenerCuentaResponse(HttpStatusCode code, string message) : base(code, message) { }

        public class CuentaResponse
        {
            public int IdCuenta { get; set; }
            public int IdCliente { get; set; }
            public string? Numero { get; set; }
            public string? Tipo { get; set; }
            public decimal SaldoInicial { get; set; }
            public bool Estado { get; set; }
        }
    }
}
