using CondominioSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Infra.Data.Repository
{
    public class FamiliaRepositoryConfig : IEntityTypeConfiguration<Familia>
    {
        public void Configure(EntityTypeBuilder<Familia> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(ai => ai.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Condominio)
                .WithMany(p => p.Familias)
                .HasForeignKey(o => o.Id_Condominio);

            builder.ToTable("Familia");
        }
    }
}
