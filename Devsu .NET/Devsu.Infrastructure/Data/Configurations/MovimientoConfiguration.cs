using Devsu.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devsu.Infrastructure.Data.Configurations
{
    internal class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> entity)
        {
            entity.HasKey(e => e.IdMovimiento);

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Saldo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Limite).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Movimiento)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimiento_Cuenta");
        }
    }
}
