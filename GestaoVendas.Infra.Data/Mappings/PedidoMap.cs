using GestaoVendas.Domain.Entitieis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Infra.Data.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            //nome da tabela
            builder.ToTable("Pedido");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.ClienteId)
                 .HasMaxLength(100)
                 .IsRequired();

            builder.Property(p => p.Valor)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.HasOne(t => t.Cliente)
                   .WithMany(t => t.Pedidos)
                   .HasForeignKey(t => t.ClienteId);

        }
    }
}
