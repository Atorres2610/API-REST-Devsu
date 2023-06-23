namespace Devsu.Core.Entities;

public partial class Persona
{
    public int IdPersona { get; set; }

    public required string Nombre { get; set; }

    public required string Genero { get; set; }

    public int Edad { get; set; }

    public required string Identificacion { get; set; }

    public required string Direccion { get; set; }

    public required string Telefono { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();
}