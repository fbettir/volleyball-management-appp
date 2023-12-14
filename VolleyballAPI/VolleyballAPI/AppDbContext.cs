using Microsoft.EntityFrameworkCore;
using System.Data;
using VolleyballAPI.Entities;
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
            var userId6 = Guid.NewGuid();
            var userId7 = Guid.NewGuid();
            var userId8 = Guid.NewGuid();
            var userId9 = Guid.NewGuid();
            var userId01 = Guid.NewGuid();
            var playerId1 = Guid.NewGuid();
            var playerId2 = Guid.NewGuid();
            var playerId3 = Guid.NewGuid();
            var playerId4 = Guid.NewGuid();
            var playerId5 = Guid.NewGuid();
            var playerId6 = Guid.NewGuid();
            var playerId7 = Guid.NewGuid();
            var playerId8 = Guid.NewGuid();
            var playerId9 = Guid.NewGuid();
            var playerId01 = Guid.NewGuid();
            var tournamentId1 = Guid.NewGuid();
            var tournamentId2 = Guid.NewGuid();
            var tournamentId3 = Guid.NewGuid();
            var trainingId1 = Guid.NewGuid();
            var trainingId2 = Guid.NewGuid();
            var trainingId3 = Guid.NewGuid();
            var trainingId4 = Guid.NewGuid();
            var trainingId5 = Guid.NewGuid();
            var trainingId6 = Guid.NewGuid();
            var trainingId7 = Guid.NewGuid();
            var trainingId8 = Guid.NewGuid();
            var trainingId9 = Guid.NewGuid();
            var trainingId01 = Guid.NewGuid();
                 
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = teamId1,
                    Name = "Team 1",
                    Picture = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_095029_opeter.jpg",
                    Description = "Description Team 1",
                },
                new Team
                {
                    Id = teamId2,
                    Name = "Team 2",
                    Picture = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg",
                    Description = "Description Team 2"
                },
                new Team
                {
                    Id = teamId3,
                    Name = "Team 3",
                    Picture = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_114305_adam.jpg",
                    Description = "Description Team 3"
                },
                new Team
                {
                    Id = teamId4,
                    Name = "Team 4",
                    Picture = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg",
                    Description = "Description Team 4"
                }
            );

            modelBuilder.Entity<Tournament>().HasData(
                new Tournament
                {
                    Id = tournamentId1,
                    Name = "Tournament 1",
                    Date = DateTime.Now,
                    Location = "Location tournament 1",
                    Picture = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg",
                    Description = "Description Team 1"
                },
                new Tournament
                {
                    Id = tournamentId2,
                    Name = "Tournament 2",
                    Date = DateTime.Now,
                    Location = "Location tournament 2",
                    Picture = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg",
                    Description = "Description Tournament 2"
                },
                new Tournament
                {
                    Id = tournamentId3,
                    Name = "Tournament 3",
                    Date = DateTime.Now,
                    Location = "Location tournament 3",
                    Picture = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg",
                    Description = "Description Tournament 3"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId1,
                    Name = "Jancs",
                    Password = "pass1",
                    Email = "user1@user.com",
                    Roles = new List<Role> { Role.Coach, Role.BasicUser }

                },
                new User
                {
                    Id = userId2,
                    Name = "Aranka",
                    Password = "pass2",
                    Email = "user2@user.com",
                    Roles = new List<Role> { Role.Administrator, Role.BasicUser }
                },
                new User
                {
                    Id = userId3,
                    Name = "Dani",
                    Password = "pass3",
                    Email = "user3@user.com",
                    Roles = new List<Role> { Role.BasicUser }
                },
                new User
                {
                    Id = userId4,
                    Name = "Kristóf",
                    Password = "pass4",
                    Email = "user4@user.com",
                    Roles = new List<Role> { Role.BasicUser }
                },
                new User
                {
                    Id = userId5,
                    Name = "Lajos",
                    Password = "pass5",
                    Email = "user5@user.com",
                    Roles = new List<Role>{ Role.Coach }
                },
                new User
                {
                    Id = userId6,
                    Name = "Péter",
                    Password = "pass6",
                    Email = "user6@user.com",
                    Roles = new List<Role> { Role.BasicUser }
                },
                new User
                {
                    Id = userId7,
                    Name = "Felícia",
                    Password = "pass7",
                    Email = "user7@user.com",
                    Roles = new List<Role> { Role.Coach }
                },
                new User
                {
                    Id = userId8,
                    Name = "Name 8",
                    Password = "pass8",
                    Email = "user8@user.com",
                    Roles = new List<Role> { Role.Administrator, Role.BasicUser }
                },
                new User
                {
                    Id = userId9,
                    Name = "Name 9",
                    Password = "pass9",
                    Email = "user9@user.com",
                    Roles = new List<Role> { Role.BasicUser }
                },
                new User
                {
                    Id = userId01,
                    Name = "Name 10",
                    Password = "pass10",
                    Email = "user10@user.com",
                    Roles = new List<Role> { Role.BasicUser }
                }
            );

            modelBuilder.Entity<PlayerDetails>().HasData(
                new PlayerDetails
                {
                    Id = playerId1,
                    UserId = userId1,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 3,
                    Posts = new List<Post> { Post.Libero , Post.Receiver },
                },
                new PlayerDetails
                {
                    Id = playerId2,
                    UserId = userId2,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 9,
                    Posts = new List<Post> {  Post.Receiver },
                },
                new PlayerDetails
                {
                    Id = playerId3,
                    UserId = userId3,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 12,
                    Posts = new List<Post> { Post.Setter },
                },
                new PlayerDetails
                {
                    Id = playerId4,
                    UserId = userId4,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 5,
                    Posts = new List<Post> { Post.Receiver },
                },
                new PlayerDetails
                {
                    Id = playerId5,
                    UserId = userId5,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 6,
                    Posts = new List<Post> { Post.Libero },
                },
                new PlayerDetails
                {
                    Id = playerId6,
                    UserId = userId6,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 7,
                    Posts = new List<Post> { Post.Libero,  },
                },
                new PlayerDetails
                {
                    Id = playerId7,
                    UserId = userId7,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 13,
                    Posts = new List<Post> { Post.Libero, Post.Hitter,  },
                },
                new PlayerDetails
                {
                    Id = playerId8,
                    UserId = userId8,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 2,
                    Posts = new List<Post> { Post.Hitter, Post.Receiver },
                },
                new PlayerDetails
                {
                    Id = playerId9,
                    UserId = userId9,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 69,
                    Posts = new List<Post> { Post.Libero, Post.Hitter, Post.Receiver },
                },
                new PlayerDetails
                {
                    Id = playerId01,
                    UserId = userId01,
                    Birthday = DateTime.Now,
                    Phone = "",
                    PlayerNumber = 17,
                    Posts = new List<Post> { Post.Libero, Post.Hitter, Post.Receiver },
                }
            );

            modelBuilder.Entity<TeamPlayer>().HasData(
                new TeamPlayer
                {
                    PlayerId = playerId1,
                    TeamId = teamId1,
                },
                new TeamPlayer
                {
                    PlayerId = playerId2,
                    TeamId = teamId1,
                },
                new TeamPlayer
                {
                    PlayerId = playerId3,
                    TeamId = teamId1,
                },
                new TeamPlayer
                {
                    PlayerId = playerId4,
                    TeamId = teamId1,
                },
                new TeamPlayer
                {
                    PlayerId = playerId5,
                    TeamId = teamId1,
                },
                new TeamPlayer
                {
                    PlayerId = playerId6,
                    TeamId = teamId2,
                }
            );
            modelBuilder.Entity<Training>().HasData(
                new Training
                {
                    Id = trainingId1,
                    Location = "Training court 1",
                    Date = DateTime.Now,
                    Description = "Training1",
                    TeamId = teamId1
                },
                new Training
                {
                    Id = trainingId2,
                    Location = "Training court 2",
                    Date = DateTime.Now,
                    Description = "Training2",
                    TeamId = teamId1
                },
                new Training
                {
                    Id = trainingId3,
                    Location = "Training court 3",
                    Date = DateTime.Now,
                    Description = "Training1",
                    TeamId = teamId2
                },
                new Training
                {
                    Id = trainingId4,
                    Location = "Training court 4",
                    Date = DateTime.Now,
                    Description = "Training4",
                    TeamId = teamId3
                },
                new Training
                {
                    Id = trainingId5,
                    Location = "Training court 5",
                    Date = DateTime.Now,
                    Description = "Training5",
                    TeamId = teamId3
                },
                new Training
                {
                    Id = trainingId6,
                    Location = "Training court 6",
                    Date = DateTime.Now,
                    Description = "Training6",
                    TeamId = teamId2
                },
                new Training
                {
                    Id = trainingId7,
                    Location = "Training court 7",
                    Date = DateTime.Now,
                    Description = "Training7",
                    TeamId = teamId3
                },
                new Training
                {
                    Id = trainingId8,
                    Location = "Training court 8",
                    Date = DateTime.Now,
                    Description = "Training8",
                    TeamId = teamId2
                },
                new Training
                {
                    Id = trainingId9,
                    Location = "Training court 9",
                    Date = DateTime.Now,
                    Description = "Training9",
                    TeamId = teamId4
                },
                new Training
                {
                    Id = trainingId01,
                    Location = "Training court 10",
                    Date = DateTime.Now,
                    Description = "Training10",
                    TeamId = teamId4
                }
            );
            modelBuilder.Entity<TrainingParticipant>().HasData(
                new TrainingParticipant
                {
                    TrainingId = trainingId1,
                    PlayerDetailsId = playerId1,
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId1,
                    PlayerDetailsId = playerId2,
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId1,
                    PlayerDetailsId = playerId3,
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId2,
                    PlayerDetailsId = playerId4,
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId2,
                    PlayerDetailsId = playerId5,
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId3,
                    PlayerDetailsId = playerId6,
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId3,
                    PlayerDetailsId = playerId7,
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId4,
                    PlayerDetailsId = playerId8,
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId5,
                    PlayerDetailsId = playerId9,
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId5,
                    PlayerDetailsId = playerId01,
                }
            );

            modelBuilder.Entity<TournamentCompetitor>().HasData(
                new TournamentCompetitor
                {
                    TournamentId = tournamentId1,
                    TeamId = teamId1,
                },
                new TournamentCompetitor
                {
                    TournamentId = tournamentId2,
                    TeamId = teamId2,
                },
                new TournamentCompetitor
                {
                    TournamentId = tournamentId3,
                    TeamId = teamId3,
                }
            );
        }

        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        public DbSet<TournamentCompetitor> TournamentCompetitors => Set<TournamentCompetitor>();
        public DbSet<TeamPlayer> TeamPlayers => Set<TeamPlayer>();
        public DbSet<PlayerDetails> PlayerDetails => Set<PlayerDetails>();
        public DbSet<Training> Trainings => Set<Training>();
        public DbSet<User> Users => Set<User>();
        public DbSet<TrainingParticipant> TrainingParticipants => Set<TrainingParticipant>();

    }
}
