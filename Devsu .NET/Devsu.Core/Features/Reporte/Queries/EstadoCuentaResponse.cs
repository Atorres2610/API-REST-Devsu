namespace Devsu.Core.Features.Reporte.Queries
{
    public class EstadoCuentaResponse
    {
        public required string Fecha { get; set; }
        public required string Cliente { get; set; }
        public required string NumeroCuenta { get; set; }
        public required string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
