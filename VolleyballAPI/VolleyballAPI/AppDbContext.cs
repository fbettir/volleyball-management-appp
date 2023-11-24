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

            var teamId1 = Guid.NewGuid();
            var teamId2 = Guid.NewGuid();
            var teamId3 = Guid.NewGuid();
            var teamId4 = Guid.NewGuid();
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var userId3 = Guid.NewGuid();
            var userId4 = Guid.NewGuid();
            var userId5 = Guid.NewGuid();
            var playerId1 = Guid.NewGuid();
                 
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = teamId1,
                    Name = "Team 1",
                    Picture = "pic1",
                    Description = "Description Team 1",
                },
                new Team
                {
                    Id = teamId2,
                    Name = "Team 2",
                    Picture = "pic2",
                    Description = "Description Team 2"
                },
                new Team
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Team 3",
                    Picture = "pic3",
                    Description = "Description Team 3"
                },
                new Team
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Team 4",
                    Picture = "pic4",
                    Description = "Description Team 4"
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
                    Description = "Description Team 1"
                },
                new Tournament
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Tournament 2",
                    Date = DateTime.Now,
                    Location = "Location tournament 2",
                    Picture = "pic2",
                    Description = "Description Tournament 2"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId1,
                    Name = "Name 1",
                    Password = "pass1",
                    Email = "user1@user.com",
                    Roles = new List<Role> { Role.Coach, Role.BasicUser }

                },
                new User
                {
                    Id = userId2,
                    Name = "Name 2",
                    Password = "pass2",
                    Email = "user2@user.com",
                    Roles = new List<Role> { Role.Administrator, Role.BasicUser }
                },
                new User
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Name 3",
                    Password = "pass3",
                    Email = "user3@user.com",
                    Roles = new List<Role> { Role.BasicUser }
                },
                new User
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Name 4",
                    Password = "pass4",
                    Email = "user4@user.com",
                    Roles = new List<Role> { Role.BasicUser }

                },
                new User
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    Name = "Name 5",
                    Password = "pass5",
                    Email = "user5@user.com",
                    Roles = new List<Role>{ Role.Coach }
                }
            );

            modelBuilder.Entity<PlayerDetails>().HasData(
                new PlayerDetails
                {
                    Id = playerId1,
                    UserId = userId1,
                    Birthday = DateTime.Now,
                    Phone = "",
                    Posts = new List<Post> { Post.Libero , Post.Hitter, Post.Receiver },
                }
            );

            modelBuilder.Entity<TeamPlayer>().HasData(
                new TeamPlayer
                {
                    PlayerId = playerId1,
                    TeamId = teamId1,
                }
            );

        }

        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();

    }
}
