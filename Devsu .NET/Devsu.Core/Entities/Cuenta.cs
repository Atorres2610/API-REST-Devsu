namespace Devsu.Core.Entities;

public partial class Cuenta
{
    public int IdCuenta { get; set; }

    public required string Numero { get; set; }

    public required string Tipo { get; set; }

    public decimal SaldoInicial { get; set; }

    public bool Estado { get; set; }

    public bool Eliminado { get; set; }
}