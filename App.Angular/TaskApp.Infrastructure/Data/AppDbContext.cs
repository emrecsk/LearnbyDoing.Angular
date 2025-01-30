using Microsoft.EntityFrameworkCore;
using TaskApp.Core.Models;

namespace TaskApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vocation> Vocations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
