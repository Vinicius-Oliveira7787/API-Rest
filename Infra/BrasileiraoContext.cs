using System.Reflection;
using Domain.AnswerSheets;
using Domain.Questions;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class BrasileiraoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Players { get; set; }
        public DbSet<AnswerSheet> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;PWD=some(!)Password;Initial Catalog=Brasileirao");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );
        }
    }
}