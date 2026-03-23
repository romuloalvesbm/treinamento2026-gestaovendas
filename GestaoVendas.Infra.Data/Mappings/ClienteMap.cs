using GestaoVendas.Domain.Entitieis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //nome da tabela
            builder.ToTable("Cliente");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                 .HasMaxLength(100)
                 .IsRequired();

            builder.Property(t => t.Email)
                 .HasMaxLength(100)
                 .IsRequired();

            builder.Property(t => t.Cpf)
                 .HasMaxLength(11)
                 .IsRequired();

            builder.Property(t => t.Ativo)
                 .IsRequired();

            builder.HasIndex(c => c.Email).IsUnique();
            builder.HasIndex(c => c.Cpf).IsUnique();
            
        }
    }
}
