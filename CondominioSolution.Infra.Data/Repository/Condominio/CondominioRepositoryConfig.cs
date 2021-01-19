using CondominioSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Infra.Data.Repository
{
    public class CondominioRepositoryConfig : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(ai => ai.Id).ValueGeneratedOnAdd();

            builder.ToTable("Condominio");
        }
    }
}
