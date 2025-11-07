using LivroDeReceitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceitas.Infrastructure.DataAcess
{
    public class LivroDeReceitasDbContext : DbContext
    {
        public LivroDeReceitasDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivroDeReceitasDbContext).Assembly);
        }
    }
}
