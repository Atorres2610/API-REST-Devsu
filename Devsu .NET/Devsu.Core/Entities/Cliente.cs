namespace Devsu.Core.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int IdPersona { get; set; }

    public required string Contrasena { get; set; }

    public bool Estado { get; set; }

    public bool Eliminado { get; set; }

    public virtual required Persona IdPersonaNavigation { get; set; }
}