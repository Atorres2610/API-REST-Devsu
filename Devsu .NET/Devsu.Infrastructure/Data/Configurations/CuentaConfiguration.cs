﻿using Devsu.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devsu.Infrastructure.Data.Configurations
{
    internal class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> entity)
        {
            entity.HasKey(e => e.IdCuenta);

            entity.Property(e => e.IdCuenta).ValueGeneratedNever();
            entity.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SaldoInicial).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
