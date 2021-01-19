using CondominioSolution.Domain.Entities;
using CondominioSolution.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CondominioSolution.Infra.Data.Context
{
    public class CondominioDbContext : DbContext
    {
        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Morador> Morador { get; set; }

        public CondominioDbContext(DbContextOptions<CondominioDbContext> opcoes)
            : base(opcoes)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MoradorRepositoryConfig());
            modelBuilder.ApplyConfiguration(new FamiliaRepositoryConfig());
            modelBuilder.ApplyConfiguration(new CondominioRepositoryConfig());

            modelBuilder.Entity<Condominio>().HasData(
                new Condominio() { Id=1, Nome = "Serra Negra", Bairro = "Vila Nova" },
                new Condominio() { Id=2, Nome = "Casa Branca", Bairro = "Moema" },
                new Condominio() { Id=3, Nome = "Bom Recanto", Bairro = "Vila Guarani" },
                new Condominio() { Id=4, Nome = "Imaré", Bairro = "Capuava" },
                new Condominio() { Id=5, Nome = "Andorinha", Bairro = "Jardim América" }
                );


            modelBuilder.Entity<Familia>().HasData(
                new Familia() { Id = 1, Nome = "Campineli", Apto = "712" , Id_Condominio=1},
                new Familia() { Id=2, Nome = "Souza", Apto = "715", Id_Condominio = 1 },
                new Familia() { Id=3, Nome = "Gonçalves", Apto = "640", Id_Condominio = 3 },
                new Familia() { Id=4, Nome = "Camargo", Apto = "356", Id_Condominio = 3 },
                new Familia() { Id=5, Nome = "Brito", Apto = "156", Id_Condominio = 5 },
                new Familia() { Id = 6, Nome = "Oliveira", Apto = "23", Id_Condominio = 3 },
                new Familia() { Id = 7, Nome = "Jovanelli", Apto = "456", Id_Condominio = 4 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
