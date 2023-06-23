namespace Devsu.Core.Entities;

public partial class Movimiento
{
    public int IdMovimiento { get; set; }

    public DateTime Fecha { get; set; }

    public required string Tipo { get; set; }

    public decimal Valor { get; set; }

    public decimal Saldo { get; set; }

    public bool Eliminado { get; set; }
}