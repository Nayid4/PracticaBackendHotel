using Domain.Clientes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Configuraciones
{
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasConversion(
                usuarioId => usuarioId.Valor,
                valor => new UsuarioId(valor));

            builder.Property(u => u.Nombre)
                .HasMaxLength(50);

            builder.Property(u => u.Apellido)
                .HasMaxLength(50);

            builder.Property(u => u.Correo)
                .HasMaxLength(255);

            builder.HasIndex(u => u.Correo).IsUnique();

            builder.Property(u => u.NumeroDeCelular).HasConversion(
                numeroDeCelular => numeroDeCelular.Valor,
                valor => NumeroDeCelular.Crear(valor)!);
        }
    }
}
