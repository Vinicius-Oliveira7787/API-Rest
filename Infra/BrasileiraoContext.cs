using System.Reflection;
using Domain.Exams;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class BrasileiraoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }

        // override, pois estamos sobrescrevando o comportamento/método padrão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Initial Catalog = nome do banco de dados que será criado
            // PWD = password
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;PWD=some(!)Password;Initial Catalog=challenge");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nesta linha estamos informando ao EF de onde ele irá ler as configurações de mapeamento das entidades
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );
        }
    }
}