using Microsoft.EntityFrameworkCore;
using VolleyballManagementAppBackend.Entities;

namespace VolleyballManagementAppBackend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerDetails>()
                .Property(e => e.Posts)
                .HasConversion(
                    v => string.Join(",", v.Select(e => e.ToString())),
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                          .Select(e => Enum.Parse<Post>(e))
                          .ToList()
                );
            modelBuilder.Entity<User>()
                .Property(e => e.Roles)
                .HasConversion(
                    v => string.Join(",", v.Select(e => e.ToString())),
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                          .Select(e => Enum.Parse<Role>(e))
                          .ToList()
                );

            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Team 1",
                    Picture = "pic1",
                    Description = "Description Team 1",
                },
                new Team
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Team 2",
                    Picture = "pic2",
                    Description = "Description Team 2",
                },
                new Team
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Team 3",
                    Picture = "pic3",
                    Description = "Description Team 3",
                },
                new Team
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Team 4",
                    Picture = "pic4",
                    Description = "Description Team 4",
                }
            );

            modelBuilder.Entity<Tournament>().HasData(
                new Tournament
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Tournament 1",
                    Date = DateTime.Now,
                    Location = "Location tournament 1",
                    Picture = "pic4",
                    Description = "Description Team 1",
                },
                new Tournament
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Tournament 2",
                    Date = DateTime.Now,
                    Location = "Location tournament 2",
                    Picture = "pic2",
                    Description = "Description Tournament 2",
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Name 1",
                    Password = "pass1",
                    Email = "user1@user.com"
                },
                new User
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Name 2",
                    Password = "pass2",
                    Email = "user2@user.com"
                },
                new User
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Name 3",
                    Password = "pass3",
                    Email = "user3@user.com"
                },
                new User
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Name 4",
                    Password = "pass4",
                    Email = "user4@user.com"
                },
                new User
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Name 5",
                    Password = "pass5",
                    Email = "user5@user.com"
                }
            );



        }

        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();

    }
}
