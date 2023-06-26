using Devsu.Core.Models;

namespace Devsu.Core.Features.Movimiento.Queries.ListarMovimiento
{
    public class ListarMovimientoResponse : Result
    {
        public List<MovimientoResponse> Movimientos { get; set; } = new();

        public class MovimientoResponse
        {
            public int IdMovimiento { get; set; }

            public int IdCuenta { get; set; }

            public DateTime Fecha { get; set; }

            public required string Tipo { get; set; }

            public decimal Valor { get; set; }

            public decimal Saldo { get; set; }

            public decimal Limite { get; set; }
        }
    }
}