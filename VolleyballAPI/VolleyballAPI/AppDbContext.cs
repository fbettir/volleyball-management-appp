using Microsoft.EntityFrameworkCore;
using System.Data;
using VolleyballAPI.Entities;

namespace VolleyballAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .Property(e => e.Posts)
            //    .HasConversion(
            //        v => string.Join(",", v.Select(e => e.ToString())),
            //        v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
            //              .Select(e => Enum.Parse<Post>(e))
            //              .ToList()
            //    );
            //modelBuilder.Entity<User>()
            //    .Property(e => e.Roles)
            //    .HasConversion(
            //        v => string.Join(",", v.Select(e => e.ToString())),
            //        v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
            //              .Select(e => Enum.Parse<Role>(e))
            //              .ToList()
            //    );

            //modelBuilder.Entity<Order>()
            //      .HasMany(o => o.ProductOrders)
            //      .WithOne(po => po.Order)
            //      .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FavouriteTeam>()
                .HasOne(ft => ft.User)
                .WithMany(u => u.FavouriteTeams)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamCoach>()
                .HasOne(tc => tc.User)
                .WithMany(u => u.CoachedTeams)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamPlayer>()
                .HasOne(tp => tp.User)
                .WithMany(u => u.JoinedTeams)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TournamentCompetitor>()
                .HasOne(tc => tc.Tournament)
                .WithMany(t => t.Teams)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Training>()
                .HasOne(tc => tc.Team)
                .WithMany(t => t.Trainings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MatchTeam>()
                .HasOne(tc => tc.Team)
                .WithMany(t => t.Matches)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Referee)
                .WithMany()
                .HasForeignKey(m => m.RefereeId)
                .OnDelete(DeleteBehavior.Restrict);


            var teamId1 = Guid.NewGuid();
            var teamId2 = Guid.NewGuid();
            var teamId3 = Guid.NewGuid();
            var teamId4 = Guid.NewGuid(); 
            var teamId5 = Guid.NewGuid();
            var teamId6 = Guid.NewGuid();
            var teamId7 = Guid.NewGuid();
            var teamId8 = Guid.NewGuid(); 
            var teamId9 = Guid.NewGuid();
            var teamId01 = Guid.NewGuid();
            var teamId02 = Guid.NewGuid();
            var teamId03 = Guid.NewGuid();
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
            var locationId1 = Guid.NewGuid();
            var locationId2 = Guid.NewGuid();
            var locationId3 = Guid.NewGuid();
            var locationId4 = Guid.NewGuid();
            var locationId5 = Guid.NewGuid();
            var locationId6 = Guid.NewGuid();
            var locationId7 = Guid.NewGuid();
            var locationId8 = Guid.NewGuid();
            var locationId9 = Guid.NewGuid();
            var locationId01 = Guid.NewGuid();
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
            var matchId1 = Guid.NewGuid();
            var matchId2 = Guid.NewGuid();
            var matchId3 = Guid.NewGuid();
            var matchId4 = Guid.NewGuid();
            var matchId5 = Guid.NewGuid();
            var matchId6 = Guid.NewGuid();
            var matchId7 = Guid.NewGuid();
            var matchId8 = Guid.NewGuid();
            var matchId9 = Guid.NewGuid();
            var matchId10 = Guid.NewGuid(); 
            var matchId11 = Guid.NewGuid();
            var matchId12 = Guid.NewGuid();
            var matchId13 = Guid.NewGuid();
            var matchId14 = Guid.NewGuid();
            var matchId15 = Guid.NewGuid();
            var matchId16 = Guid.NewGuid();
            var matchId17 = Guid.NewGuid();
            var matchId18 = Guid.NewGuid();
            var matchId19 = Guid.NewGuid();
            var matchId20 = Guid.NewGuid();
            var matchId21 = Guid.NewGuid();
            var matchId22 = Guid.NewGuid();
            var matchId23 = Guid.NewGuid();
            var matchId24 = Guid.NewGuid();
            var matchId25 = Guid.NewGuid();
            var matchId26 = Guid.NewGuid();
            var matchId27 = Guid.NewGuid();
            var matchId28 = Guid.NewGuid();
            var matchId29 = Guid.NewGuid();
            var matchId30 = Guid.NewGuid();

            modelBuilder.Entity<FavouriteTeam>().HasData(
                new FavouriteTeam
                {
                    TeamId = teamId1,
                    UserId = userId1,
                }
            );
            modelBuilder.Entity<FavouriteTournament>().HasData(
                new FavouriteTournament
                {
                    TournamentId = tournamentId2,
                    UserId = userId1,
                }
            );
            modelBuilder.Entity<FavouriteTraining>().HasData(
                new FavouriteTraining
                {
                    TrainingId = trainingId1,
                    UserId = userId1,
                }
            );
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = locationId1,
                    Address = "Location Addr 1",
                    Name = "Location1"
                }, new Location
                {
                    Id = locationId2,
                    Address = "Location Addr 2",
                    Name = "Location2"
                }, new Location
                {
                    Id = locationId3,
                    Address = "Location Addr 3",
                    Name = "Location3"
                }, new Location
                {
                    Id = locationId4,
                    Address = "Location Addr 4",
                    Name = "Location4"
                },new Location
                {
                    Id = locationId5,
                    Address = "Location Addr 5",
                    Name = "Location5"
                }, new Location
                {
                    Id = locationId6,
                    Address = "Location Addr 6",
                    Name = "Location6"
                }, new Location
                {
                    Id = locationId7,
                    Address = "Location Addr 7",
                    Name = "Location7"
                }, new Location
                {
                    Id = locationId8,
                    Address = "Location Addr 8",
                    Name = "Location8"
                }, new Location
                {
                    Id = locationId9,
                    Address = "Location Addr 9",
                    Name = "Location9"
                }, new Location
                {
                    Id = locationId01,
                    Address = "Location Addr 10",
                    Name = "Location10"
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = matchId1,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 13, 55, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId6
                },
                new Match
                {
                    Id = matchId2,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 14, 15, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId7
                },
                new Match
                {
                    Id = matchId3,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 14, 40, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId8
                },
                new Match
                {
                    Id = matchId4,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 15, 0, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId1
                },
                new Match
                {
                    Id = matchId5,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 15, 25, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId4
                },
                new Match
                {
                    Id = matchId6,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 15, 50, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId8
                },
                new Match
                {
                    Id = matchId7,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 16, 15, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId2
                }, new Match
                {
                    Id = matchId8,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 16, 40, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId6
                },
                new Match
                {
                    Id = matchId9,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 17, 05, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId2
                },
                new Match
                {
                    Id = matchId10,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 17, 30, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId3
                },
                new Match
                {
                    Id = matchId11,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 17, 55, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId6
                }, new Match
                {
                    Id = matchId12,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 18, 20, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId5
                }, new Match
                {
                    Id = matchId13,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 18, 45, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId7
                }, new Match
                {
                    Id = matchId14,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 19, 10, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId3
                }, new Match
                {
                    Id = matchId15,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 13, 55, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId2
                },
                new Match
                {
                    Id = matchId16,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 14, 15, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId4
                },
                new Match
                {
                    Id = matchId17,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 14, 40, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId5
                },
                new Match
                {
                    Id = matchId18,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 15, 0, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId7
                },
                new Match
                {
                    Id = matchId19,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 15, 25, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId2
                },
                new Match
                {
                    Id = matchId20,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 15, 50, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId1
                },
                new Match
                {
                    Id = matchId21,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 16, 15, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId4
                }, new Match
                {
                    Id = matchId22,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 16, 40, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId3
                },
                new Match
                {
                    Id = matchId23,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 17, 05, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId8
                },
                new Match
                {
                    Id = matchId24,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 17, 30, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId5
                },
                new Match
                {
                    Id = matchId25,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 17, 55, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId7
                }, new Match
                {
                    Id = matchId26,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 18, 20, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId6
                }, new Match
                {
                    Id = matchId27,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 18, 45, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId1
                }, new Match
                {
                    Id = matchId28,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 19, 10, 0),
                    TournamentId = tournamentId1,
                    RefereeId = teamId4
                }, new Match
                {
                    Id = matchId29,
                    LocationId = locationId2,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 9, 0, 0),
                    TournamentId = tournamentId2,
                    RefereeId = teamId1
                }, new Match
                {
                    Id = matchId30,
                    LocationId = locationId3,
                    Date = DateTime.Now,
                    StartTime = new DateTime(2024, 4, 3, 9, 0, 0),
                    TournamentId = tournamentId3,
                    RefereeId = teamId1
                }
            );
            modelBuilder.Entity<MatchTeam>().HasData(
                new MatchTeam
                {
                    MatchId = matchId1,
                    TeamId = teamId5,
                },
                new MatchTeam
                {
                    MatchId = matchId1,
                    TeamId = teamId3,
                },
                new MatchTeam
                {
                    MatchId = matchId2,
                    TeamId = teamId3,
                },
                new MatchTeam
                {
                    MatchId = matchId2,
                    TeamId = teamId8,
                },
                new MatchTeam
                {
                    MatchId = matchId3,
                    TeamId = teamId6,
                },
                new MatchTeam
                {
                    MatchId = matchId3,
                    TeamId = teamId7,
                },
                new MatchTeam
                {
                    MatchId = matchId4,
                    TeamId = teamId6,
                },
                new MatchTeam
                {
                    MatchId = matchId4,
                    TeamId = teamId4,
                },
                new MatchTeam
                {
                    MatchId = matchId5,
                    TeamId = teamId3,
                },
                new MatchTeam
                {
                    MatchId = matchId5,
                    TeamId = teamId1,
                },
                new MatchTeam
                {
                    MatchId = matchId6,
                    TeamId = teamId6,
                },
                new MatchTeam
                {
                    MatchId = matchId6,
                    TeamId = teamId2,
                },
                new MatchTeam
                {
                    MatchId = matchId7,
                    TeamId = teamId3,
                },
                new MatchTeam
                {
                    MatchId = matchId7,
                    TeamId = teamId6,
                },
                new MatchTeam
                {
                    MatchId = matchId8,
                    TeamId = teamId8,
                },
                new MatchTeam
                {
                    MatchId = matchId8,
                    TeamId = teamId4,
                },
                new MatchTeam
                {
                    MatchId = matchId9,
                    TeamId = teamId3,
                },
                new MatchTeam
                {
                    MatchId = matchId9,
                    TeamId = teamId7,
                },
                new MatchTeam
                {
                    MatchId = matchId10,
                    TeamId = teamId8,
                },
                new MatchTeam
                {
                    MatchId = matchId10,
                    TeamId = teamId6,
                },
                new MatchTeam
                {
                    MatchId = matchId11,
                    TeamId = teamId3,
                },
                new MatchTeam
                {
                    MatchId = matchId11,
                    TeamId = teamId4,
                },
                new MatchTeam
                {
                    MatchId = matchId12,
                    TeamId = teamId7,
                },
                new MatchTeam
                {
                    MatchId = matchId12,
                    TeamId = teamId8,
                },
                new MatchTeam
                {
                    MatchId = matchId13,
                    TeamId = teamId2,
                },
                new MatchTeam
                {
                    MatchId = matchId13,
                    TeamId = teamId3,
                },
                new MatchTeam
                {
                    MatchId = matchId14,
                    TeamId = teamId2,
                },
                new MatchTeam
                {
                    MatchId = matchId14,
                    TeamId = teamId8,
                },
                new MatchTeam
                {
                    MatchId = matchId15,
                    TeamId = teamId8,
                },
                new MatchTeam
                {
                    MatchId = matchId15,
                    TeamId = teamId1,
                },
                new MatchTeam
                {
                    MatchId = matchId16,
                    TeamId = teamId5,
                },
                new MatchTeam
                {
                    MatchId = matchId16,
                    TeamId = teamId1,
                },
                new MatchTeam
                {
                    MatchId = matchId17,
                    TeamId = teamId4,
                },
                new MatchTeam
                {
                    MatchId = matchId17,
                    TeamId = teamId2,
                },
                new MatchTeam
                {
                    MatchId = matchId18,
                    TeamId = teamId7,
                },
                new MatchTeam
                {
                    MatchId = matchId18,
                    TeamId = teamId2,
                },
                new MatchTeam
                {
                    MatchId = matchId19,
                    TeamId = teamId8,
                },
                new MatchTeam
                {
                    MatchId = matchId19,
                    TeamId = teamId5,
                },
                new MatchTeam
                {
                    MatchId = matchId20,
                    TeamId = teamId7,
                },
                new MatchTeam
                {
                    MatchId = matchId20,
                    TeamId = teamId4,
                },
                new MatchTeam
                {
                    MatchId = matchId21,
                    TeamId = teamId5,
                },
                new MatchTeam
                {
                    MatchId = matchId21,
                    TeamId = teamId7,
                },
                new MatchTeam
                {
                    MatchId = matchId22,
                    TeamId = teamId1,
                },
                new MatchTeam
                {
                    MatchId = matchId22,
                    TeamId = teamId2,
                },
                new MatchTeam
                {
                    MatchId = matchId23,
                    TeamId = teamId5,
                },
                new MatchTeam
                {
                    MatchId = matchId23,
                    TeamId = teamId4,
                },
                new MatchTeam
                {
                    MatchId = matchId24,
                    TeamId = teamId1,
                },
                new MatchTeam
                {
                    MatchId = matchId24,
                    TeamId = teamId7,
                },
                new MatchTeam
                {
                    MatchId = matchId25,
                    TeamId = teamId5,
                },
                new MatchTeam
                {
                    MatchId = matchId25,
                    TeamId = teamId2,
                },
                new MatchTeam
                {
                    MatchId = matchId26,
                    TeamId = teamId1,
                },
                new MatchTeam
                {
                    MatchId = matchId26,
                    TeamId = teamId4,
                },
                new MatchTeam
                {
                    MatchId = matchId27,
                    TeamId = teamId5,
                },
                new MatchTeam
                {
                    MatchId = matchId27,
                    TeamId = teamId6,
                },
                new MatchTeam
                {
                    MatchId = matchId28,
                    TeamId = teamId1,
                },
                new MatchTeam
                {
                    MatchId = matchId28,
                    TeamId = teamId6,
                },
                new MatchTeam
                {
                    MatchId = matchId29,
                    TeamId = teamId9,
                },
                new MatchTeam
                {
                    MatchId = matchId29,
                    TeamId = teamId01,
                },
                new MatchTeam
                {
                    MatchId = matchId30,
                    TeamId = teamId02,
                },
                new MatchTeam
                {
                    MatchId = matchId30,
                    TeamId = teamId03,
                }
            );

            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = teamId1,
                    Name = "Team 1",
                    Description = "Description Team 1",
                    LocationId = locationId1,
                    OwnerId = userId1
                },
                new Team
                {
                    Id = teamId2,
                    Name = "Team 2",
                    Description = "Description Team 2",
                    LocationId = locationId2,
                    OwnerId = userId2
                },
                new Team
                {
                    Id = teamId3,
                    Name = "Team 3",
                    Description = "Description Team 3",
                    LocationId = locationId3,
                    OwnerId = userId3
                },
                new Team
                {
                    Id = teamId4,
                    Name = "Team 4",
                    Description = "Description Team 4",
                    LocationId = locationId4,
                    OwnerId = userId4
                },
                new Team
                {
                    Id = teamId5,
                    Name = "Team 5",
                    Description = "Description Team 5",
                    LocationId = locationId5,
                    OwnerId = userId3
                },
                new Team
                {
                    Id = teamId6,
                    Name = "Team 6",
                    Description = "Description Team 6",
                    LocationId = locationId6,
                    OwnerId = userId6
                },
                new Team
                {
                    Id = teamId7,
                    Name = "Team 7",
                    Description = "Description Team 7",
                    LocationId = locationId7,
                    OwnerId = userId7
                },
                new Team
                {
                    Id = teamId8,
                    Name = "Team 8",
                    Description = "Description Team 8",
                    LocationId = locationId8,
                    OwnerId = userId8
                },                
                new Team
                {
                    Id = teamId9,
                    Name = "Team 9",
                    Description = "Description Team 9",
                    LocationId = locationId9,
                    OwnerId = userId9
                },
                new Team
                {
                    Id = teamId01,
                    Name = "Team 10",
                    Description = "Description Team 10",
                    LocationId = locationId4,
                    OwnerId = userId1
                },
                new Team
                {
                    Id = teamId02,
                    Name = "Team 11",
                    Description = "Description Team 11",
                    LocationId = locationId3,
                    OwnerId = userId1
                },
                new Team
                {
                    Id = teamId03,
                    Name = "Team 12",
                    Description = "Description Team 12",
                    LocationId = locationId4,
                    OwnerId = userId3
                }
            );
            modelBuilder.Entity<TeamCoach>().HasData(
                new TeamCoach
                {
                    TeamId = teamId1,
                    UserId = userId1,
                }, new TeamCoach
                {
                    TeamId = teamId1,
                    UserId = userId2,
                }, new TeamCoach
                {
                    TeamId = teamId2,
                    UserId = userId3,
                }, new TeamCoach
                {
                    TeamId = teamId3,
                    UserId = userId4,
                }, new TeamCoach
                {
                    TeamId = teamId4,
                    UserId = userId5,
                }, new TeamCoach
                {
                    TeamId = teamId5,
                    UserId = userId6,
                }, new TeamCoach
                {
                    TeamId = teamId6,
                    UserId = userId7,
                }, new TeamCoach
                {
                    TeamId = teamId7,
                    UserId = userId8,
                }, new TeamCoach
                {
                    TeamId = teamId8,
                    UserId = userId9,
                }, new TeamCoach
                {
                    TeamId = teamId9,
                    UserId = userId01,
                }, new TeamCoach
                {
                    TeamId = teamId01,
                    UserId = userId01,
                }, new TeamCoach
                {
                    TeamId = teamId02,
                    UserId = userId5,
                }, new TeamCoach
                {
                    TeamId = teamId03,
                    UserId = userId8,
                }
            );
            modelBuilder.Entity<TeamPlayer>().HasData(
                new TeamPlayer
                {
                    UserId = userId1,
                    TeamId = teamId1,
                },
                new TeamPlayer
                {
                    UserId = userId2,
                    TeamId = teamId2,
                },
                new TeamPlayer
                {
                    UserId = userId3,
                    TeamId = teamId1,
                },
                new TeamPlayer
                {
                    UserId = userId4,
                    TeamId = teamId2,
                },
                new TeamPlayer
                {
                    UserId = userId5,
                    TeamId = teamId1,
                },
                new TeamPlayer
                {
                    UserId = userId6,
                    TeamId = teamId3,
                },
                new TeamPlayer
                {
                    UserId = userId7,
                    TeamId = teamId3,
                }, new TeamPlayer
                {
                    UserId = userId8,
                    TeamId = teamId3,
                }, new TeamPlayer
                {
                    UserId = userId9,
                    TeamId = teamId4,
                }, new TeamPlayer
                {
                    UserId = userId01,
                    TeamId = teamId4,
                }
            );
            modelBuilder.Entity<Tournament>().HasData(
                new Tournament
                {
                    Id = tournamentId1,
                    Name = "Tournament 1",
                    Date = DateTime.Now,
                    LocationId = locationId2,
                    Description = "Description Tournament 1",
                    PriceType = PriceType.TournamentTicket,
                    EntryDeadline = DateTime.Now,
                    Organizer = "Organizer 1",
                    RegistrationPolicy = "Registration Policy 1",
                    TeamPolicy = "Team Policy 1",
                    Categories = Level.Experienced | Level.Starter
                },
                new Tournament
                {
                    Id = tournamentId2,
                    Name = "Tournament 2",
                    Date = DateTime.Now,
                    LocationId = locationId3,
                    Description = "Description Tournament 2",
                    PriceType = PriceType.TournamentTicket,
                    EntryDeadline = DateTime.Now,
                    Organizer = "Organizer 2",
                    RegistrationPolicy = "Registration Policy 2",
                    TeamPolicy = "Team Policy 2",
                    Categories = Level.Experienced 
                },
                new Tournament
                {
                    Id = tournamentId3,
                    Name = "Tournament 3",
                    Date = DateTime.Now,
                    LocationId = locationId4,
                    Description = "Description Tournament 3",
                    PriceType = PriceType.TournamentTicket,
                    EntryDeadline = DateTime.Now,
                    Organizer = "Organizer 3",
                    RegistrationPolicy = "Registration Policy 3",
                    TeamPolicy = "Team Policy 3",
                    Categories = Level.Starter
                }
            );
            modelBuilder.Entity<TournamentCompetitor>().HasData(
               new TournamentCompetitor
               {
                   TournamentId = tournamentId1,
                   TeamId = teamId1
               }, 
               new TournamentCompetitor
               {
                   TournamentId = tournamentId1,
                   TeamId = teamId2
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId1,
                   TeamId = teamId3
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId1,
                   TeamId = teamId4
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId1,
                   TeamId = teamId5
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId1,
                   TeamId = teamId6
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId1,
                   TeamId = teamId7
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId1,
                   TeamId = teamId8
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId2,
                   TeamId = teamId9
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId2,
                   TeamId = teamId01
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId3,
                   TeamId = teamId02
               },
               new TournamentCompetitor
               {
                   TournamentId = tournamentId3,
                   TeamId = teamId03
               }
            );
            modelBuilder.Entity<Training>().HasData(
                new Training
                {
                    Id = trainingId1,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    Description = "Training1",
                    TeamId = teamId1,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                },
                new Training
                {
                    Id = trainingId2,
                    LocationId = locationId2,
                    Date = DateTime.Now,
                    Description = "Training2",
                    TeamId = teamId1,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                },
                new Training
                {
                    Id = trainingId3,
                    LocationId = locationId3,
                    Date = DateTime.Now,
                    Description = "Training3",
                    TeamId = teamId2,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                },
                new Training
                {
                    Id = trainingId4,
                    LocationId = locationId3,
                    Date = DateTime.Now,
                    Description = "Training4",
                    TeamId = teamId3,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                },
                new Training
                {
                    Id = trainingId5,
                    LocationId = locationId5,
                    Date = DateTime.Now,
                    Description = "Training5",
                    TeamId = teamId3,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                },
                new Training
                {
                    Id = trainingId6,
                    LocationId = locationId6,
                    Date = DateTime.Now,
                    Description = "Training6",
                    TeamId = teamId2,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                },
                new Training
                {
                    Id = trainingId7,
                    LocationId = locationId7,
                    Date = DateTime.Now,
                    Description = "Training7",
                    TeamId = teamId3,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                },
                new Training
                {
                    Id = trainingId8,
                    LocationId = locationId8,
                    Date = DateTime.Now,
                    Description = "Training8",
                    TeamId = teamId2,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                },
                new Training
                {
                    Id = trainingId9,
                    LocationId = locationId9,
                    Date = DateTime.Now,
                    Description = "Training9",
                    TeamId = teamId4,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                },
                new Training
                {
                    Id = trainingId01,
                    LocationId = locationId01,
                    Date = DateTime.Now,
                    Description = "Training10",
                    TeamId = teamId4,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass
                }
            );

            modelBuilder.Entity<TrainingParticipant>().HasData(
                new TrainingParticipant
                {
                    TrainingId = trainingId1,
                    UserId = userId1
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId2,
                    UserId = userId2
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId3,
                    UserId = userId3
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId4,
                    UserId = userId4
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId5,
                    UserId = userId5
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId6,
                    UserId = userId6
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId7,
                    UserId = userId7
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId8,
                    UserId = userId8
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId9,
                    UserId = userId9
                },
                new TrainingParticipant
                {
                    TrainingId = trainingId01,
                    UserId = userId01
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId1,
                    Name = "Jancsi",
                    Password = "pass1",
                    Email = "user1@user.com",
                    Roles = Role.Administrator | Role.Coach,
                    Birthday = DateTime.Now,
                    Phone = "34214124",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.StudentTicket,
                    Gender = Gender.Man
                },
                new User
                {
                    Id = userId2,
                    Name = "Aranka",
                    Password = "pass2",
                    Email = "user2@user.com",
                    Roles = Role.Administrator | Role.BasicUser,
                    Birthday = DateTime.Now,
                    Phone = "965463",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Ticket,
                    Gender = Gender.Woman
                },
                new User
                {
                    Id = userId3,
                    Name = "Dani",
                    Password = "pass3",
                    Email = "user3@user.com",
                    Roles = Role.BasicUser,
                    Birthday = DateTime.Now,
                    Phone = "123555",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Ticket,
                    Gender = Gender.Man
                },
                new User
                {
                    Id = userId4,
                    Name = "Kristóf",
                    Password = "pass4",
                    Email = "user4@user.com",
                    Roles = Role.BasicUser,
                    Birthday = DateTime.Now,
                    Phone = "83568",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Ticket,
                    Gender = Gender.Man
                },
                new User
                {
                    Id = userId5,
                    Name = "Lajos",
                    Password = "pass5",
                    Email = "user5@user.com",
                    Roles = Role.Coach,
                    Birthday = DateTime.Now,
                    Phone = "54337",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Pass,
                    Gender = Gender.Man
                },
                new User
                {
                    Id = userId6,
                    Name = "Péter",
                    Password = "pass6",
                    Email = "user6@user.com",
                    Roles = Role.BasicUser,
                    Birthday = DateTime.Now,
                    Phone = "4221",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Ticket,
                    Gender = Gender.Man
                },
                new User
                {
                    Id = userId7,
                    Name = "Felícia",
                    Password = "pass7",
                    Email = "user7@user.com",
                    Roles = Role.Coach,
                    Birthday = DateTime.Now,
                    Phone = "32134",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Ticket,
                    Gender = Gender.Woman
                },
                new User
                {
                    Id = userId8,
                    Name = "Name 8",
                    Password = "pass8",
                    Email = "user8@user.com",
                    Roles = Role.Administrator | Role.BasicUser,
                    Birthday = DateTime.Now,
                    Phone = "893935",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Ticket,
                    Gender = Gender.Man
                },
                new User
                {
                    Id = userId9,
                    Name = "Name 9",
                    Password = "pass9",
                    Email = "user9@user.com",
                    Roles = Role.BasicUser,
                    Birthday = DateTime.Now,
                    Phone = "2716717",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Ticket,
                    Gender = Gender.Man
                },
                new User
                {
                    Id = userId01,
                    Name = "Name 10",
                    Password = "pass10",
                    Email = "user10@user.com",
                    Roles = Role.BasicUser,
                    Birthday = DateTime.Now,
                    Phone = "13556",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Ticket,
                    Gender = Gender.Man
                }
            );
        }

        public DbSet<FavouriteTeam> FavouriteTeams => Set<FavouriteTeam>();
        public DbSet<FavouriteTraining> FavouriteTrainings => Set<FavouriteTraining>();
        public DbSet<FavouriteTournament> FavouriteTournaments => Set<FavouriteTournament>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<MatchTeam> MatchTeams => Set<MatchTeam>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<TeamCoach> TeamCoaches => Set<TeamCoach>();
        public DbSet<TeamPlayer> TeamPlayers => Set<TeamPlayer>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        public DbSet<TournamentCompetitor> TournamentCompetitors => Set<TournamentCompetitor>();
        public DbSet<Training> Trainings => Set<Training>();
        public DbSet<TrainingParticipant> TrainingParticipants => Set<TrainingParticipant>();
        public DbSet<User> Users => Set<User>();

    }
}
