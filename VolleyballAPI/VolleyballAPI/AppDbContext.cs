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
            var teamId10 = Guid.NewGuid();
            var teamId11 = Guid.NewGuid();
            var teamId12 = Guid.NewGuid();
            var teamId13 = Guid.NewGuid();
            var teamId14 = Guid.NewGuid();
            var teamId15 = Guid.NewGuid();
            var teamId16 = Guid.NewGuid();
            var teamId17 = Guid.NewGuid();
            var teamId18 = Guid.NewGuid();
            var teamId19 = Guid.NewGuid();
            var teamId20 = Guid.NewGuid();

            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var userId3 = Guid.NewGuid();
            var userId4 = Guid.NewGuid();
            var userId5 = Guid.NewGuid();
            var userId6 = Guid.NewGuid();
            var userId7 = Guid.NewGuid();
            var userId8 = Guid.NewGuid();
            var userId9 = Guid.NewGuid();
            var userId10 = Guid.NewGuid();
            var locationId1 = Guid.NewGuid();
            var locationId2 = Guid.NewGuid();
            var locationId3 = Guid.NewGuid();
            var locationId4 = Guid.NewGuid();
            var locationId5 = Guid.NewGuid();
            var locationId6 = Guid.NewGuid();
            var locationId7 = Guid.NewGuid();
            var locationId8 = Guid.NewGuid();
            var locationId9 = Guid.NewGuid();
            var locationId10 = Guid.NewGuid();
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

            var matchId100 = Guid.NewGuid();
            var matchId101 = Guid.NewGuid();
            var matchId102 = Guid.NewGuid();
            var matchId103 = Guid.NewGuid();
            var matchId104 = Guid.NewGuid();
            var matchId105 = Guid.NewGuid();
            var matchId106 = Guid.NewGuid();
            var matchId107 = Guid.NewGuid();
            var matchId108 = Guid.NewGuid();
            var matchId109 = Guid.NewGuid();
            var matchId110 = Guid.NewGuid();
            var matchId111 = Guid.NewGuid();
            var matchId112 = Guid.NewGuid();
            var matchId113 = Guid.NewGuid();
            var matchId114 = Guid.NewGuid();
            var matchId115 = Guid.NewGuid();
            var matchId116 = Guid.NewGuid();
            var matchId117 = Guid.NewGuid();
            var matchId118 = Guid.NewGuid();
            var matchId119 = Guid.NewGuid();
            var matchId120 = Guid.NewGuid();
            var matchId121 = Guid.NewGuid();
            var matchId122 = Guid.NewGuid();
            var matchId123 = Guid.NewGuid();
            var matchId124 = Guid.NewGuid();
            var matchId125 = Guid.NewGuid();
            var matchId126 = Guid.NewGuid();
            var matchId127 = Guid.NewGuid();
            var matchId128 = Guid.NewGuid();
            var matchId129 = Guid.NewGuid();
            var matchId130 = Guid.NewGuid();
            var matchId131 = Guid.NewGuid();
            var matchId132 = Guid.NewGuid();
            var matchId133 = Guid.NewGuid();
            var matchId134 = Guid.NewGuid();
            var matchId135 = Guid.NewGuid();
            var matchId136 = Guid.NewGuid();
            var matchId137 = Guid.NewGuid();
            var matchId138 = Guid.NewGuid();
            var matchId139 = Guid.NewGuid();
            var matchId140 = Guid.NewGuid();
            var matchId141 = Guid.NewGuid();
            var matchId142 = Guid.NewGuid();
            var matchId143 = Guid.NewGuid();
            var matchId144 = Guid.NewGuid();
            var matchId145 = Guid.NewGuid();
            var matchId146 = Guid.NewGuid();
            var matchId147 = Guid.NewGuid();
            var matchId148 = Guid.NewGuid();
            var matchId149 = Guid.NewGuid();
            var matchId150 = Guid.NewGuid();
            var matchId151 = Guid.NewGuid();
            var matchId152 = Guid.NewGuid();
            var matchId153 = Guid.NewGuid();
            var matchId154 = Guid.NewGuid();
            var matchId155 = Guid.NewGuid();
            var matchId156 = Guid.NewGuid();
            var matchId157 = Guid.NewGuid();
            var matchId158 = Guid.NewGuid();
            var matchId159 = Guid.NewGuid();
            var matchId160 = Guid.NewGuid();
            var matchId161 = Guid.NewGuid();
            var matchId162 = Guid.NewGuid();

            var matchId200 = Guid.NewGuid();
            var matchId201 = Guid.NewGuid();
            var matchId202 = Guid.NewGuid();
            var matchId203 = Guid.NewGuid();
            var matchId204 = Guid.NewGuid();
            var matchId205 = Guid.NewGuid();
            var matchId206 = Guid.NewGuid();
            var matchId207 = Guid.NewGuid();
            var matchId208 = Guid.NewGuid();
            var matchId209 = Guid.NewGuid();
            var matchId210 = Guid.NewGuid();
            var matchId211 = Guid.NewGuid();
            var matchId212 = Guid.NewGuid();
            var matchId213 = Guid.NewGuid();
            var matchId214 = Guid.NewGuid();
            var matchId215 = Guid.NewGuid();
            var matchId216 = Guid.NewGuid();
            var matchId217 = Guid.NewGuid();
            var matchId218 = Guid.NewGuid();
            var matchId219 = Guid.NewGuid();
            var matchId220 = Guid.NewGuid();
            var matchId221 = Guid.NewGuid();
            var matchId222 = Guid.NewGuid();
            var matchId223 = Guid.NewGuid();
            var matchId224 = Guid.NewGuid();
            var matchId225 = Guid.NewGuid();
            var matchId226 = Guid.NewGuid();
            var matchId227 = Guid.NewGuid();
            var matchId228 = Guid.NewGuid();
            var matchId229 = Guid.NewGuid();
            var matchId230 = Guid.NewGuid();
            var matchId231 = Guid.NewGuid();
            var matchId232 = Guid.NewGuid();
            var matchId233 = Guid.NewGuid();
            var matchId234 = Guid.NewGuid();
            var matchId235 = Guid.NewGuid();
            var matchId236 = Guid.NewGuid();
            var matchId237 = Guid.NewGuid();
            var matchId238 = Guid.NewGuid();
            var matchId239 = Guid.NewGuid();
            var matchId240 = Guid.NewGuid();
            var matchId241 = Guid.NewGuid();
            var matchId242 = Guid.NewGuid();
            var matchId243 = Guid.NewGuid();
            var matchId244 = Guid.NewGuid();
            var matchId245 = Guid.NewGuid();
            var matchId246 = Guid.NewGuid();
            var matchId247 = Guid.NewGuid();
            var matchId248 = Guid.NewGuid();
            var matchId249 = Guid.NewGuid();
            var matchId250 = Guid.NewGuid();
            var matchId251 = Guid.NewGuid();
            var matchId252 = Guid.NewGuid();
            var matchId253 = Guid.NewGuid();
            var matchId254 = Guid.NewGuid();
            var matchId255 = Guid.NewGuid();
            var matchId256 = Guid.NewGuid();
            var matchId257 = Guid.NewGuid();
            var matchId258 = Guid.NewGuid();
            var matchId259 = Guid.NewGuid();
            var matchId260 = Guid.NewGuid();
            var matchId261 = Guid.NewGuid();
            var matchId262 = Guid.NewGuid();
            var matchId263 = Guid.NewGuid();
            var matchId264 = Guid.NewGuid();
            var matchId265 = Guid.NewGuid();
            var matchId266 = Guid.NewGuid();



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
                new Location { Id = locationId1, Address = "1114 Budapest, Villányi út 27.", Name = "Budai Ciszterci Szent Imre Gimnázium Tornacsarnok" },
                new Location { Id = locationId2, Address = "Budapest, Bertalan Lajos u. 4-6, 1111", Name = "BME Sportközpont" },
                new Location { Id = locationId3, Address = "Budapest, Bogdánfy u. 12, 1117", Name = "BME Sporttelep" },
                new Location { Id = locationId4, Address = "Location Addr 4", Name = "Location4" },
                new Location { Id = locationId5, Address = "Location Addr 5", Name = "Location5" },
                new Location { Id = locationId6, Address = "Location Addr 6", Name = "Location6" },
                new Location { Id = locationId7, Address = "Location Addr 7", Name = "Location7" },
                new Location { Id = locationId8, Address = "Location Addr 8", Name = "Location8" },
                new Location { Id = locationId9, Address = "Location Addr 9", Name = "Location9" },
                new Location { Id = locationId10, Address = "Location Addr 10", Name = "Location10" }
            );

            modelBuilder.Entity<Match>().HasData(
                //tournament1 matches
                new Match { Id = matchId1, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 13, 55, 0), TournamentId = tournamentId1, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId2, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 14, 15, 0), TournamentId = tournamentId1, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId3, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 14, 40, 0), TournamentId = tournamentId1, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId4, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 15, 0, 0), TournamentId = tournamentId1, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId5, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 15, 25, 0), TournamentId = tournamentId1, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId6, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 15, 50, 0), TournamentId = tournamentId1, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId7, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 16, 15, 0), TournamentId = tournamentId1, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId8, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 16, 40, 0), TournamentId = tournamentId1, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId9, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 17, 5, 0), TournamentId = tournamentId1, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId10, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 17, 30, 0), TournamentId = tournamentId1, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId11, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 17, 55, 0), TournamentId = tournamentId1, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId12, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 18, 20, 0), TournamentId = tournamentId1, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId13, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 18, 45, 0), TournamentId = tournamentId1, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId14, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 19, 10, 0), TournamentId = tournamentId1, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId15, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 13, 55, 0), TournamentId = tournamentId1, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId16, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 14, 15, 0), TournamentId = tournamentId1, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId17, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 14, 40, 0), TournamentId = tournamentId1, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId18, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 15, 0, 0), TournamentId = tournamentId1, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId19, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 15, 25, 0), TournamentId = tournamentId1, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId20, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 15, 50, 0), TournamentId = tournamentId1, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId21, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 16, 15, 0), TournamentId = tournamentId1, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId22, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 16, 40, 0), TournamentId = tournamentId1, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId23, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 17, 5, 0), TournamentId = tournamentId1, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId24, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 17, 30, 0), TournamentId = tournamentId1, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId25, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 17, 55, 0), TournamentId = tournamentId1, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId26, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 18, 20, 0), TournamentId = tournamentId1, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId27, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 18, 45, 0), TournamentId = tournamentId1, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId28, LocationId = locationId1, Date = DateTime.Now, StartTime = new DateTime(2024, 4, 3, 19, 10, 0), TournamentId = tournamentId1, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },


                //tournament2 matches
                new Match { Id = matchId100, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 9, 0, 0), TournamentId = tournamentId2, RefereeId = teamId13, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId101, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 9, 0, 0), TournamentId = tournamentId2, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId102, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 9, 0, 0), TournamentId = tournamentId2, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId103, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 9, 25, 0), TournamentId = tournamentId2, RefereeId = teamId14, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId104, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 9, 25, 0), TournamentId = tournamentId2, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId105, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 9, 25, 0), TournamentId = tournamentId2, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId106, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 9, 50, 0), TournamentId = tournamentId2, RefereeId = teamId11, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId107, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 9, 50, 0), TournamentId = tournamentId2, RefereeId = teamId9, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId108, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 9, 50, 0), TournamentId = tournamentId2, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId109, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 10, 15, 0), TournamentId = tournamentId2, RefereeId = teamId10, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId110, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 10, 15, 0), TournamentId = tournamentId2, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId111, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 10, 15, 0), TournamentId = tournamentId2, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId112, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 10, 40, 0), TournamentId = tournamentId2, RefereeId = teamId16, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId113, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 10, 40, 0), TournamentId = tournamentId2, RefereeId = teamId9, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId114, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 10, 40, 0), TournamentId = tournamentId2, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId115, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 11, 5, 0), TournamentId = tournamentId2, RefereeId = teamId14, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId116, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 11, 5, 0), TournamentId = tournamentId2, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId117, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 11, 5, 0), TournamentId = tournamentId2, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId118, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 11, 30, 0), TournamentId = tournamentId2, RefereeId = teamId15, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId119, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 11, 30, 0), TournamentId = tournamentId2, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId120, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 11, 30, 0), TournamentId = tournamentId2, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId121, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 11, 55, 0), TournamentId = tournamentId2, RefereeId = teamId10, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId122, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 11, 55, 0), TournamentId = tournamentId2, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId123, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 11, 55, 0), TournamentId = tournamentId2, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId124, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 12, 20, 0), TournamentId = tournamentId2, RefereeId = teamId11, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId125, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 12, 20, 0), TournamentId = tournamentId2, RefereeId = teamId9, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId126, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 12, 20, 0), TournamentId = tournamentId2, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId127, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 13, 10, 0), TournamentId = tournamentId2, RefereeId = teamId15, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId128, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 13, 10, 0), TournamentId = tournamentId2, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId129, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 13, 10, 0), TournamentId = tournamentId2, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId130, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 13, 35, 0), TournamentId = tournamentId2, RefereeId = teamId16, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId131, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 13, 35, 0), TournamentId = tournamentId2, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId132, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 13, 35, 0), TournamentId = tournamentId2, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId133, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 14, 0, 0), TournamentId = tournamentId2, RefereeId = teamId14, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId134, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 14, 0, 0), TournamentId = tournamentId2, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId135, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 14, 0, 0), TournamentId = tournamentId2, RefereeId = teamId9, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId136, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 14, 25, 0), TournamentId = tournamentId2, RefereeId = teamId15, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId137, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 14, 25, 0), TournamentId = tournamentId2, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId138, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 14, 25, 0), TournamentId = tournamentId2, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId139, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 14, 50, 0), TournamentId = tournamentId2, RefereeId = teamId12, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId140, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 14, 50, 0), TournamentId = tournamentId2, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId141, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 14, 50, 0), TournamentId = tournamentId2, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId142, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 15, 15, 0), TournamentId = tournamentId2, RefereeId = teamId13, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId143, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 15, 15, 0), TournamentId = tournamentId2, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId144, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 15, 15, 0), TournamentId = tournamentId2, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId145, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 15, 40, 0), TournamentId = tournamentId2, RefereeId = teamId10, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId146, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 15, 40, 0), TournamentId = tournamentId2, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId147, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 15, 40, 0), TournamentId = tournamentId2, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId148, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 16, 5, 0), TournamentId = tournamentId2, RefereeId = teamId16, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId149, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 16, 5, 0), TournamentId = tournamentId2, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId150, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 16, 5, 0), TournamentId = tournamentId2, RefereeId = teamId9, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId151, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 16, 30, 0), TournamentId = tournamentId2, RefereeId = teamId12, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId152, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 16, 30, 0), TournamentId = tournamentId2, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId153, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 16, 30, 0), TournamentId = tournamentId2, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId154, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 16, 55, 0), TournamentId = tournamentId2, RefereeId = teamId11, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId155, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 16, 55, 0), TournamentId = tournamentId2, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId156, LocationId = locationId2, Date = new DateTime(2025, 5, 18), StartTime = new DateTime(2024, 5, 18, 16, 55, 0), TournamentId = tournamentId2, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },


                //tournament3 matches
                new Match { Id = matchId200, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 9, 0, 0), TournamentId = tournamentId3, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId201, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 9, 0, 0), TournamentId = tournamentId3, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId202, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 9, 0, 0), TournamentId = tournamentId3, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId203, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 9, 25, 0), TournamentId = tournamentId3, RefereeId = teamId15, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId204, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 9, 25, 0), TournamentId = tournamentId3, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId205, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 9, 25, 0), TournamentId = tournamentId3, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId206, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 9, 50, 0), TournamentId = tournamentId3, RefereeId = teamId16, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId207, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 9, 50, 0), TournamentId = tournamentId3, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId208, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 9, 50, 0), TournamentId = tournamentId3, RefereeId = teamId9, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId209, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 10, 15, 0), TournamentId = tournamentId3, RefereeId = teamId10, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId210, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 10, 15, 0), TournamentId = tournamentId3, RefereeId = teamId17, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId211, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 10, 15, 0), TournamentId = tournamentId3, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },  
                new Match { Id = matchId212, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 10, 40, 0), TournamentId = tournamentId3, RefereeId = teamId13, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId213, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 10, 40, 0), TournamentId = tournamentId3, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId214, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 10, 40, 0), TournamentId = tournamentId3, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId215, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 11, 5, 0), TournamentId = tournamentId3, RefereeId = teamId11, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId216, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 11, 5, 0), TournamentId = tournamentId3, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId217, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 11, 5, 0), TournamentId = tournamentId3, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId218, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 11, 30, 0), TournamentId = tournamentId3, RefereeId = teamId16, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId219, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 11, 30, 0), TournamentId = tournamentId3, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId220, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 11, 30, 0), TournamentId = tournamentId3, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId221, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 11, 55, 0), TournamentId = tournamentId3, RefereeId = teamId12, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId222, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 11, 55, 0), TournamentId = tournamentId3, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId223, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 11, 55, 0), TournamentId = tournamentId3, RefereeId = teamId9, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId224, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 12, 20, 0), TournamentId = tournamentId3, RefereeId = teamId13, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId225, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 12, 20, 0), TournamentId = tournamentId3, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId226, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 12, 20, 0), TournamentId = tournamentId3, RefereeId = teamId17, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId227, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 12, 45, 0), TournamentId = tournamentId3, RefereeId = teamId10, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId228, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 12, 45, 0), TournamentId = tournamentId3, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId229, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 12, 45, 0), TournamentId = tournamentId3, RefereeId = teamId17, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId230, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 13, 10, 0), TournamentId = tournamentId3, RefereeId = teamId12, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId231, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 13, 10, 0), TournamentId = tournamentId3, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId232, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 13, 10, 0), TournamentId = tournamentId3, RefereeId = teamId9, Points = new List<int> { 0, 0 } , MatchState = MatchState.Scheduled },            
                new Match { Id = matchId233, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 13, 35, 0), TournamentId = tournamentId3, RefereeId = teamId14, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId234, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 13, 35, 0), TournamentId = tournamentId3, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId235, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 13, 35, 0), TournamentId = tournamentId3, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },             
                new Match { Id = matchId236, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 14, 10, 0), TournamentId = tournamentId3, RefereeId = teamId11, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId237, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 14, 10, 0), TournamentId = tournamentId3, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId238, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 14, 10, 0), TournamentId = tournamentId3, RefereeId = teamId17, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },              
                new Match { Id = matchId239, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 14, 35, 0), TournamentId = tournamentId3, RefereeId = teamId15, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId240, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 14, 35, 0), TournamentId = tournamentId3, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId241, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 14, 35, 0), TournamentId = tournamentId3, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },              
                new Match { Id = matchId242, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 15, 0, 0), TournamentId = tournamentId3, RefereeId = teamId16, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId243, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 15, 0, 0), TournamentId = tournamentId3, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId244, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 15, 0, 0), TournamentId = tournamentId3, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },                     
                new Match { Id = matchId245, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 15, 25, 0), TournamentId = tournamentId3, RefereeId = teamId12, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId246, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 15, 25, 0), TournamentId = tournamentId3, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId247, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 15, 25, 0), TournamentId = tournamentId3, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },                    
                new Match { Id = matchId248, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 15, 50, 0), TournamentId = tournamentId3, RefereeId = teamId14, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId249, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 15, 50, 0), TournamentId = tournamentId3, RefereeId = teamId9, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId250, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 15, 50, 0), TournamentId = tournamentId3, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },                
                new Match { Id = matchId251, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 16, 15, 0), TournamentId = tournamentId3, RefereeId = teamId15, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId252, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 16, 15, 0), TournamentId = tournamentId3, RefereeId = teamId17, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId253, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 16, 15, 0), TournamentId = tournamentId3, RefereeId = teamId2, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },                   
                new Match { Id = matchId254, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 16, 40, 0), TournamentId = tournamentId3, RefereeId = teamId13, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId255, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 16, 40, 0), TournamentId = tournamentId3, RefereeId = teamId1, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId256, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 16, 40, 0), TournamentId = tournamentId3, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },    
                new Match { Id = matchId257, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 17, 05, 0), TournamentId = tournamentId3, RefereeId = teamId11, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId258, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 17, 05, 0), TournamentId = tournamentId3, RefereeId = teamId5, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId259, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 17, 05, 0), TournamentId = tournamentId3, RefereeId = teamId3, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },    
                new Match { Id = matchId260, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 17, 30, 0), TournamentId = tournamentId3, RefereeId = teamId14, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId261, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 17, 30, 0), TournamentId = tournamentId3, RefereeId = teamId8, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId262, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 17, 30, 0), TournamentId = tournamentId3, RefereeId = teamId4, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },                  
                new Match { Id = matchId263, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 17, 55, 0), TournamentId = tournamentId3, RefereeId = teamId10, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId264, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 17, 55, 0), TournamentId = tournamentId3, RefereeId = teamId7, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled },
                new Match { Id = matchId265, LocationId = locationId3, Date = new DateTime(2025, 4, 26), StartTime = new DateTime(2025, 4, 26, 17, 55, 0), TournamentId = tournamentId3, RefereeId = teamId6, Points = new List<int> { 0, 0 }, MatchState = MatchState.Scheduled }

            );
            modelBuilder.Entity<MatchTeam>().HasData(
                new MatchTeam { MatchId = matchId1, TeamId = teamId5 }, new MatchTeam { MatchId = matchId1, TeamId = teamId3 },
                new MatchTeam { MatchId = matchId2, TeamId = teamId3 }, new MatchTeam { MatchId = matchId2, TeamId = teamId8 },
                new MatchTeam { MatchId = matchId3, TeamId = teamId6 }, new MatchTeam { MatchId = matchId3, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId4, TeamId = teamId6 }, new MatchTeam { MatchId = matchId4, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId5, TeamId = teamId3 }, new MatchTeam { MatchId = matchId5, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId6, TeamId = teamId6 }, new MatchTeam { MatchId = matchId6, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId7, TeamId = teamId3 }, new MatchTeam { MatchId = matchId7, TeamId = teamId6 },
                new MatchTeam { MatchId = matchId8, TeamId = teamId8 }, new MatchTeam { MatchId = matchId8, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId9, TeamId = teamId3 }, new MatchTeam { MatchId = matchId9, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId10, TeamId = teamId8 }, new MatchTeam { MatchId = matchId10, TeamId = teamId6 },
                new MatchTeam { MatchId = matchId11, TeamId = teamId3 }, new MatchTeam { MatchId = matchId11, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId12, TeamId = teamId7 }, new MatchTeam { MatchId = matchId12, TeamId = teamId8 },
                new MatchTeam { MatchId = matchId13, TeamId = teamId2 }, new MatchTeam { MatchId = matchId13, TeamId = teamId3 },
                new MatchTeam { MatchId = matchId14, TeamId = teamId2 }, new MatchTeam { MatchId = matchId14, TeamId = teamId8 },
                new MatchTeam { MatchId = matchId15, TeamId = teamId8 }, new MatchTeam { MatchId = matchId15, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId16, TeamId = teamId5 }, new MatchTeam { MatchId = matchId16, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId17, TeamId = teamId4 }, new MatchTeam { MatchId = matchId17, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId18, TeamId = teamId7 }, new MatchTeam { MatchId = matchId18, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId19, TeamId = teamId8 }, new MatchTeam { MatchId = matchId19, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId20, TeamId = teamId7 }, new MatchTeam { MatchId = matchId20, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId21, TeamId = teamId5 }, new MatchTeam { MatchId = matchId21, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId22, TeamId = teamId1 }, new MatchTeam { MatchId = matchId22, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId23, TeamId = teamId5 }, new MatchTeam { MatchId = matchId23, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId24, TeamId = teamId1 }, new MatchTeam { MatchId = matchId24, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId25, TeamId = teamId5 }, new MatchTeam { MatchId = matchId25, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId26, TeamId = teamId1 }, new MatchTeam { MatchId = matchId26, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId27, TeamId = teamId5 }, new MatchTeam { MatchId = matchId27, TeamId = teamId6 },
                new MatchTeam { MatchId = matchId28, TeamId = teamId1 }, new MatchTeam { MatchId = matchId28, TeamId = teamId6 },

                //tournament2
                new MatchTeam { MatchId = matchId100, TeamId = teamId16 }, new MatchTeam { MatchId = matchId100, TeamId = teamId14 },
                new MatchTeam { MatchId = matchId101, TeamId = teamId6 }, new MatchTeam { MatchId = matchId101, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId102, TeamId = teamId3 }, new MatchTeam { MatchId = matchId102, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId103, TeamId = teamId11 }, new MatchTeam { MatchId = matchId103, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId104, TeamId = teamId9 }, new MatchTeam { MatchId = matchId104, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId105, TeamId = teamId8 }, new MatchTeam { MatchId = matchId105, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId106, TeamId = teamId12 }, new MatchTeam { MatchId = matchId106, TeamId = teamId10 },
                new MatchTeam { MatchId = matchId107, TeamId = teamId3 }, new MatchTeam { MatchId = matchId107, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId108, TeamId = teamId7 }, new MatchTeam { MatchId = matchId108, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId109, TeamId = teamId16 }, new MatchTeam { MatchId = matchId109, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId110, TeamId = teamId6 }, new MatchTeam { MatchId = matchId110, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId111, TeamId = teamId8 }, new MatchTeam { MatchId = matchId111, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId112, TeamId = teamId11 }, new MatchTeam { MatchId = matchId112, TeamId = teamId14 },
                new MatchTeam { MatchId = matchId113, TeamId = teamId1 }, new MatchTeam { MatchId = matchId113, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId114, TeamId = teamId7 }, new MatchTeam { MatchId = matchId114, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId115, TeamId = teamId12 }, new MatchTeam { MatchId = matchId115, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId116, TeamId = teamId6 }, new MatchTeam { MatchId = matchId116, TeamId = teamId3 },
                new MatchTeam { MatchId = matchId117, TeamId = teamId8 }, new MatchTeam { MatchId = matchId117, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId118, TeamId = teamId10 }, new MatchTeam { MatchId = matchId118, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId119, TeamId = teamId7 }, new MatchTeam { MatchId = matchId119, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId120, TeamId = teamId2 }, new MatchTeam { MatchId = matchId120, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId121, TeamId = teamId16 }, new MatchTeam { MatchId = matchId121, TeamId = teamId11 },
                new MatchTeam { MatchId = matchId122, TeamId = teamId9 }, new MatchTeam { MatchId = matchId122, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId123, TeamId = teamId3 }, new MatchTeam { MatchId = matchId123, TeamId = teamId8 },
                new MatchTeam { MatchId = matchId124, TeamId = teamId14 }, new MatchTeam { MatchId = matchId124, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId125, TeamId = teamId12 }, new MatchTeam { MatchId = matchId125, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId126, TeamId = teamId1 }, new MatchTeam { MatchId = matchId126, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId127, TeamId = teamId16 }, new MatchTeam { MatchId = matchId127, TeamId = teamId10 },
                new MatchTeam { MatchId = matchId128, TeamId = teamId9 }, new MatchTeam { MatchId = matchId128, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId129, TeamId = teamId6 }, new MatchTeam { MatchId = matchId129, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId130, TeamId = teamId14 }, new MatchTeam { MatchId = matchId130, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId131, TeamId = teamId11 }, new MatchTeam { MatchId = matchId131, TeamId = teamId12 },
                new MatchTeam { MatchId = matchId132, TeamId = teamId8 }, new MatchTeam { MatchId = matchId132, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId133, TeamId = teamId15 }, new MatchTeam { MatchId = matchId133, TeamId = teamId10 },
                new MatchTeam { MatchId = matchId134, TeamId = teamId1 }, new MatchTeam { MatchId = matchId134, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId135, TeamId = teamId3 }, new MatchTeam { MatchId = matchId135, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId136, TeamId = teamId16 }, new MatchTeam { MatchId = matchId136, TeamId = teamId12 },
                new MatchTeam { MatchId = matchId137, TeamId = teamId6 }, new MatchTeam { MatchId = matchId137, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId138, TeamId = teamId8 }, new MatchTeam { MatchId = matchId138, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId139, TeamId = teamId11 }, new MatchTeam { MatchId = matchId139, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId140, TeamId = teamId9 }, new MatchTeam { MatchId = matchId140, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId141, TeamId = teamId3 }, new MatchTeam { MatchId = matchId141, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId142, TeamId = teamId14 }, new MatchTeam { MatchId = matchId142, TeamId = teamId10 },
                new MatchTeam { MatchId = matchId143, TeamId = teamId7 }, new MatchTeam { MatchId = matchId143, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId144, TeamId = teamId6 }, new MatchTeam { MatchId = matchId144, TeamId = teamId8 },
                new MatchTeam { MatchId = matchId145, TeamId = teamId16 }, new MatchTeam { MatchId = matchId145, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId146, TeamId = teamId4 }, new MatchTeam { MatchId = matchId146, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId147, TeamId = teamId3 }, new MatchTeam { MatchId = matchId147, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId148, TeamId = teamId14 }, new MatchTeam { MatchId = matchId148, TeamId = teamId12 },
                new MatchTeam { MatchId = matchId149, TeamId = teamId8 }, new MatchTeam { MatchId = matchId149, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId150, TeamId = teamId6 }, new MatchTeam { MatchId = matchId150, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId151, TeamId = teamId11 }, new MatchTeam { MatchId = matchId151, TeamId = teamId10 },
                new MatchTeam { MatchId = matchId152, TeamId = teamId3 }, new MatchTeam { MatchId = matchId152, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId153, TeamId = teamId9 }, new MatchTeam { MatchId = matchId153, TeamId = teamId4 },
                new MatchTeam { MatchId = matchId154, TeamId = teamId15 }, new MatchTeam { MatchId = matchId154, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId155, TeamId = teamId6 }, new MatchTeam { MatchId = matchId155, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId156, TeamId = teamId2 }, new MatchTeam { MatchId = matchId156, TeamId = teamId5 },

                //tournament3
                new MatchTeam { MatchId = matchId200, TeamId = teamId4 }, new MatchTeam { MatchId = matchId200, TeamId = teamId6 },
                new MatchTeam { MatchId = matchId201, TeamId = teamId17 }, new MatchTeam { MatchId = matchId201, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId202, TeamId = teamId3 }, new MatchTeam { MatchId = matchId202, TeamId = teamId8 },
                new MatchTeam { MatchId = matchId203, TeamId = teamId11 }, new MatchTeam { MatchId = matchId203, TeamId = teamId16 },
                new MatchTeam { MatchId = matchId204, TeamId = teamId7 }, new MatchTeam { MatchId = matchId204, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId205, TeamId = teamId5 }, new MatchTeam { MatchId = matchId205, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId206, TeamId = teamId10 }, new MatchTeam { MatchId = matchId206, TeamId = teamId12 },
                new MatchTeam { MatchId = matchId207, TeamId = teamId4 }, new MatchTeam { MatchId = matchId207, TeamId = teamId17 },
                new MatchTeam { MatchId = matchId208, TeamId = teamId3 }, new MatchTeam { MatchId = matchId208, TeamId = teamId6 },
                new MatchTeam { MatchId = matchId209, TeamId = teamId14 }, new MatchTeam { MatchId = matchId209, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId210, TeamId = teamId5 }, new MatchTeam { MatchId = matchId210, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId211, TeamId = teamId8 }, new MatchTeam { MatchId = matchId211, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId212, TeamId = teamId11 }, new MatchTeam { MatchId = matchId212, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId213, TeamId = teamId1 }, new MatchTeam { MatchId = matchId213, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId214, TeamId = teamId4 }, new MatchTeam { MatchId = matchId214, TeamId = teamId3 },
                new MatchTeam { MatchId = matchId215, TeamId = teamId16 }, new MatchTeam { MatchId = matchId215, TeamId = teamId10 },
                new MatchTeam { MatchId = matchId216, TeamId = teamId17 }, new MatchTeam { MatchId = matchId216, TeamId = teamId8 },
                new MatchTeam { MatchId = matchId217, TeamId = teamId7 }, new MatchTeam { MatchId = matchId217, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId218, TeamId = teamId12 }, new MatchTeam { MatchId = matchId218, TeamId = teamId14 },
                new MatchTeam { MatchId = matchId219, TeamId = teamId6 }, new MatchTeam { MatchId = matchId219, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId220, TeamId = teamId2 }, new MatchTeam { MatchId = matchId220, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId221, TeamId = teamId13 }, new MatchTeam { MatchId = matchId221, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId222, TeamId = teamId4 }, new MatchTeam { MatchId = matchId222, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId223, TeamId = teamId17 }, new MatchTeam { MatchId = matchId223, TeamId = teamId3 },
                new MatchTeam { MatchId = matchId224, TeamId = teamId11 }, new MatchTeam { MatchId = matchId224, TeamId = teamId10 },
                new MatchTeam { MatchId = matchId225, TeamId = teamId8 }, new MatchTeam { MatchId = matchId225, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId226, TeamId = teamId6 }, new MatchTeam { MatchId = matchId226, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId227, TeamId = teamId16 }, new MatchTeam { MatchId = matchId227, TeamId = teamId12 },
                new MatchTeam { MatchId = matchId228, TeamId = teamId3 }, new MatchTeam { MatchId = matchId228, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId229, TeamId = teamId7 }, new MatchTeam { MatchId = matchId229, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId230, TeamId = teamId14 }, new MatchTeam { MatchId = matchId230, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId231, TeamId = teamId8 }, new MatchTeam { MatchId = matchId231, TeamId = teamId6 },
                new MatchTeam { MatchId = matchId232, TeamId = teamId2 }, new MatchTeam { MatchId = matchId232, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId233, TeamId = teamId11 }, new MatchTeam { MatchId = matchId233, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId234, TeamId = teamId4 }, new MatchTeam { MatchId = matchId234, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId235, TeamId = teamId17 }, new MatchTeam { MatchId = matchId235, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId236, TeamId = teamId16 }, new MatchTeam { MatchId = matchId236, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId237, TeamId = teamId6 }, new MatchTeam { MatchId = matchId237, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId238, TeamId = teamId3 }, new MatchTeam { MatchId = matchId238, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId239, TeamId = teamId10 }, new MatchTeam { MatchId = matchId239, TeamId = teamId14 },
                new MatchTeam { MatchId = matchId240, TeamId = teamId4 }, new MatchTeam { MatchId = matchId240, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId241, TeamId = teamId8 }, new MatchTeam { MatchId = matchId241, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId242, TeamId = teamId12 }, new MatchTeam { MatchId = matchId242, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId243, TeamId = teamId5 }, new MatchTeam { MatchId = matchId243, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId244, TeamId = teamId17 }, new MatchTeam { MatchId = matchId244, TeamId = teamId7 },
                new MatchTeam { MatchId = matchId245, TeamId = teamId11 }, new MatchTeam { MatchId = matchId245, TeamId = teamId14 },
                new MatchTeam { MatchId = matchId246, TeamId = teamId8 }, new MatchTeam { MatchId = matchId246, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId247, TeamId = teamId4 }, new MatchTeam { MatchId = matchId247, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId248, TeamId = teamId10 }, new MatchTeam { MatchId = matchId248, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId249, TeamId = teamId17 }, new MatchTeam { MatchId = matchId249, TeamId = teamId6 },
                new MatchTeam { MatchId = matchId250, TeamId = teamId7 }, new MatchTeam { MatchId = matchId250, TeamId = teamId3 },
                new MatchTeam { MatchId = matchId251, TeamId = teamId16 }, new MatchTeam { MatchId = matchId251, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId252, TeamId = teamId4 }, new MatchTeam { MatchId = matchId252, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId253, TeamId = teamId8 }, new MatchTeam { MatchId = matchId253, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId254, TeamId = teamId11 }, new MatchTeam { MatchId = matchId254, TeamId = teamId12 },
                new MatchTeam { MatchId = matchId255, TeamId = teamId7 }, new MatchTeam { MatchId = matchId255, TeamId = teamId6 },
                new MatchTeam { MatchId = matchId256, TeamId = teamId3 }, new MatchTeam { MatchId = matchId256, TeamId = teamId9 },


                new MatchTeam { MatchId = matchId257, TeamId = teamId16 }, new MatchTeam { MatchId = matchId257, TeamId = teamId14 },
                new MatchTeam { MatchId = matchId258, TeamId = teamId17 }, new MatchTeam { MatchId = matchId258, TeamId = teamId2 },
                new MatchTeam { MatchId = matchId259, TeamId = teamId4 }, new MatchTeam { MatchId = matchId259, TeamId = teamId8 },
                new MatchTeam { MatchId = matchId260, TeamId = teamId10 }, new MatchTeam { MatchId = matchId260, TeamId = teamId13 },
                new MatchTeam { MatchId = matchId261, TeamId = teamId7 }, new MatchTeam { MatchId = matchId261, TeamId = teamId1 },
                new MatchTeam { MatchId = matchId262, TeamId = teamId6 }, new MatchTeam { MatchId = matchId262, TeamId = teamId9 },
                new MatchTeam { MatchId = matchId263, TeamId = teamId12 }, new MatchTeam { MatchId = matchId263, TeamId = teamId15 },
                new MatchTeam { MatchId = matchId264, TeamId = teamId17 }, new MatchTeam { MatchId = matchId264, TeamId = teamId5 },
                new MatchTeam { MatchId = matchId265, TeamId = teamId2 }, new MatchTeam { MatchId = matchId265, TeamId = teamId3 }
            );

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = teamId1, Name = "Team 1", Description = "Description Team 1", LocationId = locationId1, OwnerId = userId1, PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" },
                new Team { Id = teamId2, Name = "Team 2", Description = "Description Team 2", LocationId = locationId2, OwnerId = userId2, PictureLink = "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" },
                new Team { Id = teamId3, Name = "Team 3", Description = "Description Team 3", LocationId = locationId3, OwnerId = userId3, PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                new Team { Id = teamId4, Name = "Team 4", Description = "Description Team 4", LocationId = locationId4, OwnerId = userId4, PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                new Team { Id = teamId5, Name = "Team 5", Description = "Description Team 5", LocationId = locationId5, OwnerId = userId3, PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" },
                new Team { Id = teamId6, Name = "Team 6", Description = "Description Team 6", LocationId = locationId6, OwnerId = userId6, PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                new Team { Id = teamId7, Name = "Team 7", Description = "Description Team 7", LocationId = locationId7, OwnerId = userId7, PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                new Team { Id = teamId8, Name = "Team 8", Description = "Description Team 8", LocationId = locationId8, OwnerId = userId8, PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                new Team { Id = teamId9, Name = "Team 9", Description = "Description Team 9", LocationId = locationId9, OwnerId = userId9, PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" },
                new Team { Id = teamId10, Name = "Team 10", Description = "Description Team 10", LocationId = locationId4, OwnerId = userId1, PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" },
                new Team { Id = teamId11, Name = "Team 11", Description = "Description Team 11", LocationId = locationId3, OwnerId = userId1, PictureLink = "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" },
                new Team { Id = teamId12, Name = "Team 12", Description = "Description Team 12", LocationId = locationId4, OwnerId = userId3, PictureLink = "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                new Team { Id = teamId13, Name = "Team 13", Description = "Description Team 13", LocationId = locationId1, OwnerId = userId4, PictureLink = "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                new Team { Id = teamId14, Name = "Team 14", Description = "Description Team 14", LocationId = locationId2, OwnerId = userId5, PictureLink = "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                new Team { Id = teamId15, Name = "Team 15", Description = "Description Team 15", LocationId = locationId3, OwnerId = userId6, PictureLink = "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                new Team { Id = teamId16, Name = "Team 16", Description = "Description Team 16", LocationId = locationId1, OwnerId = userId7, PictureLink = "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                new Team { Id = teamId17, Name = "Team 17", Description = "Description Team 17", LocationId = locationId4, OwnerId = userId8, PictureLink = "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" }

            );
            modelBuilder.Entity<TeamCoach>().HasData(
                new TeamCoach { TeamId = teamId1, UserId = userId1 },
                new TeamCoach { TeamId = teamId1, UserId = userId2 },
                new TeamCoach { TeamId = teamId2, UserId = userId3 },
                new TeamCoach { TeamId = teamId3, UserId = userId4 },
                new TeamCoach { TeamId = teamId4, UserId = userId5 },
                new TeamCoach { TeamId = teamId5, UserId = userId6 },
                new TeamCoach { TeamId = teamId6, UserId = userId7 },
                new TeamCoach { TeamId = teamId7, UserId = userId8 },
                new TeamCoach { TeamId = teamId8, UserId = userId9 },
                new TeamCoach { TeamId = teamId9, UserId = userId10 },
                new TeamCoach { TeamId = teamId10, UserId = userId10 },
                new TeamCoach { TeamId = teamId11, UserId = userId5 },
                new TeamCoach { TeamId = teamId12, UserId = userId1 },
                new TeamCoach { TeamId = teamId13, UserId = userId1 },
                new TeamCoach { TeamId = teamId14, UserId = userId2 },
                new TeamCoach { TeamId = teamId15, UserId = userId3 },
                new TeamCoach { TeamId = teamId16, UserId = userId4 },
                new TeamCoach { TeamId = teamId17, UserId = userId5 }

            );
            modelBuilder.Entity<TeamPlayer>().HasData(
                new TeamPlayer { UserId = userId1, TeamId = teamId1 },
                new TeamPlayer { UserId = userId2, TeamId = teamId2 },
                new TeamPlayer { UserId = userId3, TeamId = teamId1 },
                new TeamPlayer { UserId = userId4, TeamId = teamId2 },
                new TeamPlayer { UserId = userId5, TeamId = teamId1 },
                new TeamPlayer { UserId = userId6, TeamId = teamId3 },
                new TeamPlayer { UserId = userId7, TeamId = teamId3 },
                new TeamPlayer { UserId = userId8, TeamId = teamId3 },
                new TeamPlayer { UserId = userId9, TeamId = teamId4 },
                new TeamPlayer { UserId = userId10, TeamId = teamId4 }

            );
            modelBuilder.Entity<Tournament>().HasData(
                new Tournament
                {
                    Id = tournamentId1,
                    Name = "Fanatics 8 csapat körbejátszás",
                    Date = DateTime.Now,
                    LocationId = locationId2,
                    Description = "Description Tournament 1",
                    PriceType = PriceType.TournamentTicket,
                    EntryDeadline = DateTime.Now,
                    Organizer = "Organizer 1",
                    RegistrationPolicy = "Registration Policy 1",
                    TeamPolicy = "Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.",
                    Categories = Level.Advanced,
                    PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg",
                    TournamentType = TournamentType.Fana8Kor,
                    MaxTeamsPerLevel = new List<int> { 8 },
                    Courts = 2
                },
                new Tournament
                {
                    Id = tournamentId2,
                    Name = "Műegyetemi röplabda torna A9 B7 ",
                    Date = new DateTime(2025, 5, 18),
                    LocationId = locationId2,
                    Description = "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.",
                    PriceType = PriceType.TournamentTicket,
                    EntryDeadline = new DateTime(2025, 4, 18),
                    Organizer = "MŰER szervező csapata",
                    RegistrationPolicy = "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!",
                    TeamPolicy = "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.",
                    Categories = Level.Experienced | Level.Starter,
                    PictureLink = "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg",
                    TournamentType = TournamentType.MuerA9B7,
                    MaxTeamsPerLevel = new List<int> { 9, 7 },
                    Courts = 3

                },
                new Tournament
                {
                    Id = tournamentId3,
                    Name = "Műegyetemi röplabda torna A10 B7 ",
                    Date = new DateTime(2025, 4, 26),
                    LocationId = locationId2,
                    Description = "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.",
                    PriceType = PriceType.TournamentTicket,
                    EntryDeadline = new DateTime(2025, 3, 26),
                    Organizer = "MŰER szervező csapata",
                    RegistrationPolicy = "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!",
                    TeamPolicy = "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.",
                    Categories = Level.Experienced | Level.Starter,
                    PictureLink = "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg",
                    TournamentType = TournamentType.MuerA10B7,
                    MaxTeamsPerLevel = new List<int> { 10, 7 },
                    Courts = 3
                }
            );
            modelBuilder.Entity<TournamentCompetitor>().HasData(

                //tournament1 teams
                new TournamentCompetitor { TournamentId = tournamentId1, TeamId = teamId1 },
                new TournamentCompetitor { TournamentId = tournamentId1, TeamId = teamId2 },
                new TournamentCompetitor { TournamentId = tournamentId1, TeamId = teamId3 },
                new TournamentCompetitor { TournamentId = tournamentId1, TeamId = teamId4 },
                new TournamentCompetitor { TournamentId = tournamentId1, TeamId = teamId5 },
                new TournamentCompetitor { TournamentId = tournamentId1, TeamId = teamId6 },
                new TournamentCompetitor { TournamentId = tournamentId1, TeamId = teamId7 },
                new TournamentCompetitor { TournamentId = tournamentId1, TeamId = teamId8 },

                //tournament2 teams
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId1 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId2 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId3 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId4 }, 
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId5 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId6 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId7 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId8 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId9 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId10 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId11 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId12 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId13 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId14 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId15 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId16 },
                new TournamentCompetitor { TournamentId = tournamentId2, TeamId = teamId17 },

                //tournament3 teams
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId1 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId2 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId3 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId4 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId5 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId6 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId7 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId8 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId9 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId10 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId11 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId12 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId13 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId14 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId15 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId16 },
                new TournamentCompetitor { TournamentId = tournamentId3, TeamId = teamId17 }
            );
            modelBuilder.Entity<Training>().HasData(
                new Training
                {
                    Id = trainingId1,
                    LocationId = locationId1,
                    Date = DateTime.Now,
                    Description = "Training1",
                    TeamId = teamId1,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg"
                },
                new Training
                {
                    Id = trainingId2,
                    LocationId = locationId2,
                    Date = DateTime.Now,
                    Description = "Training2",
                    TeamId = teamId1,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg"
                },
                new Training
                {
                    Id = trainingId3,
                    LocationId = locationId3,
                    Date = DateTime.Now,
                    Description = "Training3",
                    TeamId = teamId2,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg"
                },
                new Training
                {
                    Id = trainingId4,
                    LocationId = locationId3,
                    Date = DateTime.Now,
                    Description = "Training4",
                    TeamId = teamId3,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg"
                },
                new Training
                {
                    Id = trainingId5,
                    LocationId = locationId5,
                    Date = DateTime.Now,
                    Description = "Training5",
                    TeamId = teamId3,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg"
                },
                new Training
                {
                    Id = trainingId6,
                    LocationId = locationId6,
                    Date = DateTime.Now,
                    Description = "Training6",
                    TeamId = teamId2,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg"
                },
                new Training
                {
                    Id = trainingId7,
                    LocationId = locationId7,
                    Date = DateTime.Now,
                    Description = "Training7",
                    TeamId = teamId3,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg"
                },
                new Training
                {
                    Id = trainingId8,
                    LocationId = locationId8,
                    Date = DateTime.Now,
                    Description = "Training8",
                    TeamId = teamId2,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg"
                },
                new Training
                {
                    Id = trainingId9,
                    LocationId = locationId9,
                    Date = DateTime.Now,
                    Description = "Training9",
                    TeamId = teamId4,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg"
                },
                new Training
                {
                    Id = trainingId01,
                    LocationId = locationId10,
                    Date = DateTime.Now,
                    Description = "Training10",
                    TeamId = teamId4,
                    AcceptableTickets = PriceType.Ticket | PriceType.Pass,
                    PictureLink = "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg"
                }
            );

            modelBuilder.Entity<TrainingParticipant>().HasData(
                new TrainingParticipant { TrainingId = trainingId1, UserId = userId1 },
                new TrainingParticipant { TrainingId = trainingId2, UserId = userId2 },
                new TrainingParticipant { TrainingId = trainingId3, UserId = userId3 },
                new TrainingParticipant { TrainingId = trainingId4, UserId = userId4 },
                new TrainingParticipant { TrainingId = trainingId5, UserId = userId5 },
                new TrainingParticipant { TrainingId = trainingId6, UserId = userId6 },
                new TrainingParticipant { TrainingId = trainingId7, UserId = userId7 },
                new TrainingParticipant { TrainingId = trainingId8, UserId = userId8 },
                new TrainingParticipant { TrainingId = trainingId9, UserId = userId9 },
                new TrainingParticipant { TrainingId = trainingId01, UserId = userId10 }
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
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
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
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
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
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
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
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
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
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
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
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
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
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
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
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
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
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
                    PlayerNumber = 3,
                    Posts = Post.Libero | Post.MiddleBlocker,
                    PriceType = PriceType.Ticket,
                    Gender = Gender.Man
                },
                new User
                {
                    Id = userId10,
                    Name = "Name 10",
                    Password = "pass10",
                    Email = "user10@user.com",
                    Roles = Role.BasicUser,
                    Birthday = DateTime.Now,
                    Phone = "13556",
                    PictureLink = "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg",
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
