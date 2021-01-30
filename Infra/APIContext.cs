using System.Reflection;
using Domain.Answers;
using Domain.AnswerSheets;
using Domain.Questions;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class APIContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerSheet> AnswerSheets { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;PWD=some(!)Password;Initial Catalog=Challenge");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );
        }
    }
}