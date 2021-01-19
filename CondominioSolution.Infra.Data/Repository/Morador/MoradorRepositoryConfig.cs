using CondominioSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Infra.Data.Repository
{
    public class MoradorRepositoryConfig : IEntityTypeConfiguration<Morador>
    {
        public void Configure(EntityTypeBuilder<Morador> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(ai => ai.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Familia)
                .WithMany(p => p.Moradores)
                .HasForeignKey(o => o.Id_Familia);

            builder.ToTable("Morador");
        }
    }
}
