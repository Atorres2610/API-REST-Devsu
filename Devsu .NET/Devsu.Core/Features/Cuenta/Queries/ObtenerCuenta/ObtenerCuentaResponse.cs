namespace Devsu.Core.Features.Cuenta.Queries.ObtenerCuenta
{
    public class ObtenerCuentaResponse
    {
        public int IdCuenta { get; set; }
        public string? Numero { get; set; }
        public string? Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public ObtenerCuentaResponse(Entities.Cuenta cuenta)
        {
            IdCuenta = cuenta.IdCuenta;
            Numero = cuenta.Numero;
            Tipo = cuenta.Tipo;
            SaldoInicial = cuenta.SaldoInicial;
            Estado = cuenta.Estado;
        }
    }
}
