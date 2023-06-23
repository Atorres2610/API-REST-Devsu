using Devsu.Core.Entities;
using Devsu.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;

namespace Devsu.Infrastructure.Data;

public partial class DevsuContext : DbContext
{
    public DevsuContext() { }

    public DevsuContext(DbContextOptions<DevsuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Cuenta> Cuenta { get; set; }

    public virtual DbSet<Movimiento> Movimiento { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new CuentaConfiguration());
        modelBuilder.ApplyConfiguration(new MovimientoConfiguration());
        modelBuilder.ApplyConfiguration(new PersonaConfiguration());

        //Filtrando globalmente los datos eliminados de las tablas
        foreach (IMutableEntityType tipoEntidad in modelBuilder.Model.GetEntityTypes())
        {
            IMutableProperty? propiedad = tipoEntidad.FindProperty("Eliminado");
            if (propiedad is not null && propiedad.ClrType == typeof(bool))
            {
                ParameterExpression parametro = Expression.Parameter(tipoEntidad.ClrType);
                LambdaExpression filtro = Expression.Lambda(Expression.Equal(Expression.Property(parametro, "Eliminado"), Expression.Constant(false)), parametro);
                modelBuilder.Entity(tipoEntidad.ClrType).HasQueryFilter(filtro);
            }
        }
    }
}