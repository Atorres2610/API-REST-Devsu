﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Devsu.Core.Entities;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Nombres { get; set; }

    public string Genero { get; set; }

    public int Edad { get; set; }

    public string Identificacion { get; set; }

    public string Direccion { get; set; }

    public string Telefono { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();
}