using Devsu.Core.Models;
using System.Net;

namespace Devsu.Core.Features.Movimiento.Queries.ObtenerMovimiento
{
    public class ObtenerMovimientoResponse : Result
    {
        public MovimientoResponse? Movimiento { get; set; }

        public ObtenerMovimientoResponse(HttpStatusCode code, string message) : base(code, message) { }

        public ObtenerMovimientoResponse() { }

        public class MovimientoResponse
        {
            public int IdMovimiento { get; set; }

            public int IdCuenta { get; set; }

            public DateTime Fecha { get; set; }

            public string? Tipo { get; set; }

            public decimal Valor { get; set; }

            public decimal Saldo { get; set; }

            public decimal Limite { get; set; }

        }
    }
}
