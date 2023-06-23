namespace Devsu.Core.Features.Cuenta.Queries.ListarCuenta
{
    public class ListarCuentaResponse
    {
        public List<CuentaResponse> Cuentas { get; set; }

        public ListarCuentaResponse(List<Entities.Cuenta> cuentas)
        {
            Cuentas = new();
            foreach (var cuenta in cuentas)
            {
                Cuentas.Add(new CuentaResponse(cuenta));
            }
        }

        public class CuentaResponse
        {
            public int IdCuenta { get; set; }
            public string? Numero { get; set; }
            public string? Tipo { get; set; }
            public decimal SaldoInicial { get; set; }
            public bool Estado { get; set; }

            public CuentaResponse(Entities.Cuenta cuenta)
            {
                IdCuenta = cuenta.IdCuenta;
                Numero = cuenta.Numero;
                Tipo = cuenta.Tipo;
                SaldoInicial = cuenta.SaldoInicial;
                Estado = cuenta.Estado;
            }
        }
    }
}
