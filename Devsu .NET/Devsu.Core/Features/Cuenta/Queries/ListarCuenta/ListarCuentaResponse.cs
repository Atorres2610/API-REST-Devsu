using Devsu.Core.Models;

namespace Devsu.Core.Features.Cuenta.Queries.ListarCuenta
{
    public class ListarCuentaResponse : Result
    {
        public List<CuentaResponse> Cuentas { get; set; } = new();

        public class CuentaResponse
        {
            public int IdCuenta { get; set; }
            public string? Numero { get; set; }
            public string? Tipo { get; set; }
            public decimal SaldoInicial { get; set; }
            public bool Estado { get; set; }
        }
    }
}
