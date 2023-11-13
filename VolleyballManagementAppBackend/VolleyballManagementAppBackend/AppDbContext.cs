using Microsoft.EntityFrameworkCore;
using VolleyballManagementAppBackend.Entities;

namespace VolleyballManagementAppBackend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>().HasKey(x => x.Id);
            modelBuilder.Entity<Tournament>().HasKey(x => x.Id);
        }
    }
}
