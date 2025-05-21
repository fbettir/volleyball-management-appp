using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VolleyballAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerNumber = table.Column<int>(type: "int", nullable: false),
                    PictureLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false),
                    PriceType = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Posts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Courts = table.Column<int>(type: "int", nullable: false),
                    MaxTeamsPerLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categories = table.Column<int>(type: "int", nullable: false),
                    PriceType = table.Column<int>(type: "int", nullable: false),
                    TournamentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteTournaments",
                columns: table => new
                {
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteTournaments", x => new { x.TournamentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteTournaments_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteTournaments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteTeams",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteTeams", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteTeams_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefereeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchState = table.Column<int>(type: "int", nullable: false),
                    TournamentType = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamCoaches",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCoaches", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TeamCoaches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCoaches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayers",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayers", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TournamentCompetitors",
                columns: table => new
                {
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentCompetitors", x => new { x.TournamentId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TournamentCompetitors_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentCompetitors_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcceptableTickets = table.Column<int>(type: "int", nullable: false),
                    PictureLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_Users_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchTeams",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTeams", x => new { x.MatchId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MatchTeams_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteTrainings",
                columns: table => new
                {
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteTrainings", x => new { x.TrainingId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteTrainings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteTrainings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingParticipants",
                columns: table => new
                {
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingParticipants", x => new { x.UserId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_TrainingParticipants_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingParticipants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("047c7823-ea55-4147-8682-c76c380ccf20"), "Location Addr 4", "Location4" },
                    { new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), "Budapest, Bogdánfy u. 12, 1117", "BME Sporttelep" },
                    { new Guid("1fd71364-dce1-4154-8f12-95b83314d328"), "Location Addr 10", "Location10" },
                    { new Guid("3744aacd-d782-47ab-96de-8235b7572cb0"), "Location Addr 7", "Location7" },
                    { new Guid("69d584b2-236a-4de8-9891-e7bbe123f2ff"), "Location Addr 5", "Location5" },
                    { new Guid("81bc618a-17f3-402a-9a68-dc71bfb16863"), "Location Addr 6", "Location6" },
                    { new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), "1114 Budapest, Villányi út 27.", "Budai Ciszterci Szent Imre Gimnázium Tornacsarnok" },
                    { new Guid("cc3c3996-0091-40a0-8d6f-c23367a9c45e"), "Location Addr 9", "Location9" },
                    { new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), "Budapest, Bertalan Lajos u. 4-6, 1111", "BME Sportközpont" },
                    { new Guid("fc6913da-3981-4e7d-9f88-487ffe3a6637"), "Location Addr 8", "Location8" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Gender", "Name", "Password", "Phone", "PictureLink", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("0f0620e8-5b4c-48fa-8ce7-6c129d4d304b"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(982), "user4@user.com", 0, "Kristóf", "pass4", "83568", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("14985d68-4be7-4efc-a794-cb57d98449e6"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(973), "user2@user.com", 1, "Aranka", "pass2", "965463", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("1b9c93cd-1c38-462e-98ef-2d94a8b1baa6"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(978), "user3@user.com", 0, "Dani", "pass3", "123555", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("5b5896d5-b54f-4a65-9410-fa0ddc67c859"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(994), "user7@user.com", 1, "Felícia", "pass7", "32134", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 2 },
                    { new Guid("92a6f3c5-0755-4615-aa80-0c5a933fe07b"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(990), "user6@user.com", 0, "Péter", "pass6", "4221", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("a53e825a-154d-4be9-8bbf-a123cbd71373"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(1059), "user10@user.com", 0, "Name 10", "pass10", "13556", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("a559e4bb-7178-4c72-a3a8-b48a0811c167"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(986), "user5@user.com", 0, "Lajos", "pass5", "54337", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 4, 2 },
                    { new Guid("aaea9744-809d-4da8-b348-ff4c66d0e1fa"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(998), "user8@user.com", 0, "Name 8", "pass8", "893935", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(967), "user1@user.com", 0, "Jancsi", "pass1", "34214124", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 2, 3 },
                    { new Guid("dfb24d0c-972a-47a8-94c1-7779b9fde4f4"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(1054), "user9@user.com", 0, "Name 9", "pass9", "2716717", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId", "PictureLink" },
                values: new object[,]
                {
                    { new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), "Description Team 16", new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), "Team 16", new Guid("5b5896d5-b54f-4a65-9410-fa0ddc67c859"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), "Description Team 6", new Guid("81bc618a-17f3-402a-9a68-dc71bfb16863"), "Team 6", new Guid("92a6f3c5-0755-4615-aa80-0c5a933fe07b"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                    { new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94"), "Description Team 17", new Guid("047c7823-ea55-4147-8682-c76c380ccf20"), "Team 17", new Guid("aaea9744-809d-4da8-b348-ff4c66d0e1fa"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), "Description Team 14", new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), "Team 14", new Guid("a559e4bb-7178-4c72-a3a8-b48a0811c167"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e"), "Description Team 12", new Guid("047c7823-ea55-4147-8682-c76c380ccf20"), "Team 12", new Guid("1b9c93cd-1c38-462e-98ef-2d94a8b1baa6"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), "Description Team 9", new Guid("cc3c3996-0091-40a0-8d6f-c23367a9c45e"), "Team 9", new Guid("dfb24d0c-972a-47a8-94c1-7779b9fde4f4"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" },
                    { new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), "Description Team 5", new Guid("69d584b2-236a-4de8-9891-e7bbe123f2ff"), "Team 5", new Guid("1b9c93cd-1c38-462e-98ef-2d94a8b1baa6"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" },
                    { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), "Description Team 1", new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), "Team 1", new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" },
                    { new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), "Description Team 3", new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), "Team 3", new Guid("1b9c93cd-1c38-462e-98ef-2d94a8b1baa6"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                    { new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), "Description Team 8", new Guid("fc6913da-3981-4e7d-9f88-487ffe3a6637"), "Team 8", new Guid("aaea9744-809d-4da8-b348-ff4c66d0e1fa"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                    { new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72"), "Description Team 13", new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), "Team 13", new Guid("0f0620e8-5b4c-48fa-8ce7-6c129d4d304b"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), "Description Team 4", new Guid("047c7823-ea55-4147-8682-c76c380ccf20"), "Team 4", new Guid("0f0620e8-5b4c-48fa-8ce7-6c129d4d304b"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                    { new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), "Description Team 10", new Guid("047c7823-ea55-4147-8682-c76c380ccf20"), "Team 10", new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" },
                    { new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), "Description Team 15", new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), "Team 15", new Guid("92a6f3c5-0755-4615-aa80-0c5a933fe07b"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("c773db15-6499-4e69-b73b-586c76049261"), "Description Team 7", new Guid("3744aacd-d782-47ab-96de-8235b7572cb0"), "Team 7", new Guid("5b5896d5-b54f-4a65-9410-fa0ddc67c859"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                    { new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), "Description Team 2", new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), "Team 2", new Guid("14985d68-4be7-4efc-a794-cb57d98449e6"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" },
                    { new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), "Description Team 11", new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), "Team 11", new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Courts", "Date", "Description", "EntryDeadline", "LocationId", "MaxTeamsPerLevel", "Name", "Organizer", "PictureLink", "PriceType", "RegistrationPolicy", "TeamPolicy", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 5, 3, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), "[10,7]", "Műegyetemi röplabda torna A10 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 1 },
                    { new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 2, 2, new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(713), "Description Tournament 1", new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(725), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), "[8]", "Fanatics 8 csapat körbejátszás", "Organizer 1", "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg", 16, "Registration Policy 1", "Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 0 },
                    { new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 5, 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), "[9,7]", "Műegyetemi röplabda torna A9 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 2 }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "MatchState", "Points", "RefereeId", "StartTime", "TournamentId", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("03a06d04-87ea-448a-9eca-5344ccfa1ab0"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("05c2cdfb-4f4b-4059-9514-785f4b1ba58b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("0943afbf-e525-4b44-b17f-e9a6099a7fb2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("0bc80544-3115-4595-a775-a17c8ad343cc"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("0e6f982d-2ea0-43f3-b5a1-05cce2670c52"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("0f2a1518-7551-4d20-9846-4fc139b5c3d5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("11adff45-e848-45eb-93ed-6d92c873a078"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("125054cf-f902-4521-8c58-9db553d2a0b3"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9352), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("144b9ee0-a912-447a-8492-b401bf8cc74c"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9347), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("155989a4-7c7e-446c-8355-261f4894a754"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("176f3122-490b-47cd-b88a-0d675b0255c6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("178ff88c-2f3b-4bc0-a155-7e3d17d34aaf"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("19d3288d-fe75-44bd-8015-335f01230f3f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("1a2d138d-fc9c-4508-af70-226ea5575a10"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("1db342cd-433d-479f-a426-769a1f734113"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("20e6f969-5b59-46fb-92a8-ad863e5e8d87"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("21687c59-b1df-4cc2-9f32-0770b664c913"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("2274fa40-18ae-4f95-a6f3-734686faa913"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("22a64baf-e122-4d6b-8cd4-65e4d088366d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("297d3170-45ab-43b2-99fe-3904447f07b6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("2c0d7d3e-d7a7-4782-9d8b-b91559fb06b6"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9342), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("2d7dd864-9507-4072-80e3-0ac72b5ebe67"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("2f810407-c485-4cad-86cd-4394e365769f"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9317), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("3082760f-8b72-4711-bc0f-050e42976e0f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("31c6d60b-048c-456a-b6a7-3faa5f200f8b"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9312), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("33a81a77-2ca2-4591-a503-0cd40ea9f6ad"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9268), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("34b59d6c-48bc-43e4-9750-362b78c5d5f6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("34fb3fc0-94e6-468a-a2b8-7370c88d0e08"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("355faf40-b70d-45c0-806e-c499db255977"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("3605cfd9-c802-4cd9-9be6-c7fa9f72a76b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("373a296c-428b-4d4b-b0de-ba894215a0ce"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9416), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("38b40692-e0e1-4149-ab95-a1e8bff78f85"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("39b4904d-96e6-4e3a-b893-d11b7ac8fe43"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("3c8b24ee-69ff-4a56-ab00-06579133a925"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("3df0d627-079d-4805-aa99-e6f4023afc0e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("3f1e726b-9b21-493e-808b-0051d9226465"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("3f5c2d67-a1ed-4a29-8f9f-40cca4c46185"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("4198205c-21d9-4d7e-9a07-b34df448ff10"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("45adfb6b-5a62-4bc8-943f-786e03b49d10"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("4672c04c-1dd9-4c70-9b32-c8fcd53a73c5"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("4761947b-e5bd-48ed-b090-36202764db38"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9436), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("47a3a6fa-6251-4a56-a5f0-24b91011c987"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("49280231-ab69-4b11-b2db-dcded9726c10"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("4afad4ec-dbe2-4e8d-a201-78ca45566334"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("4dba24f2-ed38-4654-9144-8fe22974c89f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("4e322024-a8cb-4829-ba16-906aa7e75a23"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("5014fcd8-f031-4572-895d-ba850531f65f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("50ef5ccb-fb73-4113-a526-aa2e1b48f9f3"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("5106eb80-0df2-4376-a715-b0ef22aeb805"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9421), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("54d4d746-8699-477b-adf4-1f1da8dab4cb"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("581d0deb-df54-44e8-8f5e-6bac7b4b344c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("584ae2f3-6fd4-4cde-b8d9-20757d36ffce"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9411), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("59ba2cd9-0c95-4b00-92b3-d4b1887d3410"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("5b35f533-75aa-4945-9fda-8c53d54ba8a4"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("5be8b30d-6ee2-42ea-8699-2497bbb71f1e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("5ca16acf-eb3e-4a5b-8cf0-c1eae0e792de"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("5e19ed46-d5ce-4c6c-bd38-bf7b28386674"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("613b0213-1ea9-4855-afa3-837e2195a583"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("624db938-a784-4e92-94a9-fac5613ec01a"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9431), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("641e3000-e9e2-45ba-a16e-bf712e9dc6d5"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9257), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("668d8ec9-538b-42db-8297-21ed1115933b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("67781b44-4a03-496d-a1de-9f9368840295"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("67cf98d9-eeb7-4666-bf71-32526b447e9d"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9332), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("693ef6f5-83f4-4cbc-bcd6-3d192fbcf4ef"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("6c094351-a6e2-4210-b631-2f337212df5f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("6c3ac530-415a-4654-92c1-db85464f9482"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("6e8273a5-5bed-470d-ae71-37e228ecd526"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9327), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("6ff8f907-ec44-49ff-8e9a-3891e6cbf47a"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("7024738e-348b-4ad7-a7d1-007464426eeb"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("7057ff24-573e-4c77-9375-f2366c9f26bf"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("70946aca-fb8c-4bf0-9ff0-3520ae585a67"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("734c1470-70e5-4e4a-b50e-48d7a309abb4"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("780eed06-07be-43fd-8d44-3d01e481a3d5"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("79ff7af4-abf2-48b0-9d07-24f166554bca"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9302), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("7a672e81-3fc2-4b34-8a5f-1fb82290c1aa"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("7a7b99f7-87c0-48b5-aa5a-68a84a29190a"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9284), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("7e6752a6-a188-4bce-b3c9-19a7c84e3605"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("7fb2c2b2-e667-4b7c-8c45-11b50e43d6d2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("84d8a6c8-a172-4d7d-a77b-9d6471b4915c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("85e23d75-70ce-47d5-95c8-10f87e7a1221"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9406), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("866becfb-6b05-422b-87ec-5f0272cffb73"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("887f4409-9e4b-4c80-a565-8f18e0162066"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9322), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("8a113060-aeff-4892-816c-6bdfe651d887"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("8b3d75f5-8f57-4f2a-bac1-d50a8f62a83a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("8df92a0d-b47e-4c07-8325-74d5dccafb18"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("90dc5027-9d96-47b5-9bf0-462ce625c870"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9263), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("9212cf72-a3ea-4f25-b53a-eff00582b2c9"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("924e79e8-e386-4804-a888-dcfdda9a3658"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("93220b49-b7c5-4422-9d63-3601c9d7ebb5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("948ea11e-0648-4119-a288-d3dde3fc06e4"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("960d4ab5-4395-4ef0-ad1b-6e635e1ae574"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("98055336-7b4d-4d0d-a25e-c77825aaa8fb"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("9891d390-68af-4606-8230-147ea50da876"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9337), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("98f436c7-82a8-4639-89ce-2d9fea73b132"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("9a4ec2ac-e395-44ce-a1f2-02c8a9e93ca5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("9a99021b-0769-443a-b464-d209fed682ae"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("9c5f9a9c-c082-4e53-ae1f-8fe150a13dd7"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("9cc6cd70-f316-4c1a-951d-2065d5735af2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("9ea02802-3004-46d4-a317-8db70af292f8"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("a1ac6829-91fd-4429-b80e-0878cb0b4a0d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("a4855234-a713-4624-8041-3cde8c9230fa"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("a8dcdd6e-65d1-4af4-8f88-447fd0382168"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("adacfb10-f742-4776-a390-f2ee88a4aa64"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9273), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("b07ee76a-9337-4f87-9956-4317877502f0"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("b107d5f4-06f3-4344-91f2-0c9303bdda36"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("b3f4f1c1-37b2-434d-beab-655fcb1d7de8"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("b5094aea-43ae-4e2f-900d-1a393821fdb8"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("b615386e-3ed9-4758-8b9e-8ff7059b85d2"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9278), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("b68cecf6-fc64-4432-a430-13f8653149ad"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("b87f2a57-8514-42c1-b345-6389aafc6be1"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("bb64eb17-c378-4746-8668-f944a81d078c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("bf5da33d-bb33-4c29-8fd6-93c20b960dfe"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("c4f98cb4-6c1c-46ca-9129-1b8b2c36c23d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("c5a1d78b-2ca0-4b21-8080-be7a9c230951"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9426), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("c5e2fdbb-ffc5-4978-9eca-78fe371260b6"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9297), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("c69fbfc9-cb52-46de-a28a-7a72effab922"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("c747cc7b-7382-4989-a6d4-70569f732da0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("c89fba25-6021-4765-a299-713bd8221f50"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9307), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("cca9c4e5-edc4-4756-bddf-56cdeae1c286"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("cda62882-1966-4680-8062-5ec85d0ff0ce"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("d0b7e484-dcae-4c7c-9208-c145ef95dad4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("d122e4fb-7b14-420e-95fe-36b199e64bbc"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("d1d7c68f-f81a-482d-869c-fe36aa3d56fa"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("d3d0ce79-c568-4185-8665-8fc524bcdefa"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("d56eabb9-6410-408f-837d-bcf274d85b04"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("d5f3f18d-2421-4942-8640-5f81e0413357"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("d6ee8f37-8f74-4acf-b6ab-e1bfc0c6d6c5"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9400), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("d970691f-4c1f-4acf-995c-2d0034d86daa"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9190), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("da8f8636-787a-48d2-b4a5-576fb2e0cc01"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("db36f37c-b96d-4fc4-a7de-48c0a8850456"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("e2c07cbc-2aa7-4fc3-aaa5-24e6db9d1314"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("c773db15-6499-4e69-b73b-586c76049261"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("e43d5722-c01e-4657-8d6f-25d26f660101"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("e6af20cf-e7fd-40fb-92b6-49d874e86ab5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("e873b714-1b5c-4fa1-87aa-afb6d2de5af3"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("e8bd571a-4c8e-48dc-b1a7-85f1bce31f62"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("e96abc84-b230-41f6-90a3-1b329264f171"), new DateTime(2025, 5, 21, 19, 43, 3, 536, DateTimeKind.Local).AddTicks(9292), new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1"), 0 },
                    { new Guid("e9752d77-5177-400d-96c5-c4e6fb7aa698"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("e9aecb3a-5163-43d6-ba11-6ff4931cd811"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("e9b2c099-0091-43cd-8bd0-0352e3266da1"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("ea5fdfbb-d689-47c7-91e2-17ecc2da641f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("ebb01412-97ac-46dd-a38f-01a5fa4d8cf3"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("ed9b45af-1af6-4be5-ba61-50f7fb2872ed"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("efac9301-58d1-4521-bce0-f1ecec7d66ba"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("f1528a21-a344-4a0e-b045-bb443121588f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("f25988eb-7263-40e3-89fd-75232ab2b556"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("f756214a-96db-4339-a55b-576c476d7057"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("f76cb624-f075-428a-93ac-c88e4b71875e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("f8616df6-de41-4c82-bf98-397f35cdb766"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0"), 1 },
                    { new Guid("fa948dd1-aeed-4214-b4f2-c48b98e2cdcf"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("fdef1594-6dd6-467f-9ab2-2243529d9a09"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 },
                    { new Guid("fef64b77-3018-435f-9262-e46a29732cfd"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), 0, "[0,0]", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a"), 2 }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), new Guid("0f0620e8-5b4c-48fa-8ce7-6c129d4d304b") },
                    { new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new Guid("5b5896d5-b54f-4a65-9410-fa0ddc67c859") },
                    { new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94"), new Guid("a559e4bb-7178-4c72-a3a8-b48a0811c167") },
                    { new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), new Guid("14985d68-4be7-4efc-a794-cb57d98449e6") },
                    { new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e"), new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3") },
                    { new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new Guid("a53e825a-154d-4be9-8bbf-a123cbd71373") },
                    { new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new Guid("92a6f3c5-0755-4615-aa80-0c5a933fe07b") },
                    { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new Guid("14985d68-4be7-4efc-a794-cb57d98449e6") },
                    { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3") },
                    { new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new Guid("0f0620e8-5b4c-48fa-8ce7-6c129d4d304b") },
                    { new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new Guid("dfb24d0c-972a-47a8-94c1-7779b9fde4f4") },
                    { new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72"), new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3") },
                    { new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new Guid("a559e4bb-7178-4c72-a3a8-b48a0811c167") },
                    { new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), new Guid("a53e825a-154d-4be9-8bbf-a123cbd71373") },
                    { new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), new Guid("1b9c93cd-1c38-462e-98ef-2d94a8b1baa6") },
                    { new Guid("c773db15-6499-4e69-b73b-586c76049261"), new Guid("aaea9744-809d-4da8-b348-ff4c66d0e1fa") },
                    { new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new Guid("1b9c93cd-1c38-462e-98ef-2d94a8b1baa6") },
                    { new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), new Guid("a559e4bb-7178-4c72-a3a8-b48a0811c167") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new Guid("1b9c93cd-1c38-462e-98ef-2d94a8b1baa6") },
                    { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new Guid("a559e4bb-7178-4c72-a3a8-b48a0811c167") },
                    { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3") },
                    { new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new Guid("5b5896d5-b54f-4a65-9410-fa0ddc67c859") },
                    { new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new Guid("92a6f3c5-0755-4615-aa80-0c5a933fe07b") },
                    { new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new Guid("aaea9744-809d-4da8-b348-ff4c66d0e1fa") },
                    { new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new Guid("a53e825a-154d-4be9-8bbf-a123cbd71373") },
                    { new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new Guid("dfb24d0c-972a-47a8-94c1-7779b9fde4f4") },
                    { new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new Guid("0f0620e8-5b4c-48fa-8ce7-6c129d4d304b") },
                    { new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new Guid("14985d68-4be7-4efc-a794-cb57d98449e6") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("c773db15-6499-4e69-b73b-586c76049261"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), new Guid("5213d2b4-4cbc-48b4-839d-d1be6011edc0") },
                    { new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1") },
                    { new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1") },
                    { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1") },
                    { new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1") },
                    { new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1") },
                    { new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1") },
                    { new Guid("c773db15-6499-4e69-b73b-586c76049261"), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1") },
                    { new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new Guid("c1f26ea4-25a2-4a1b-9f4e-f7da045f5bf1") },
                    { new Guid("04d92837-1b83-4287-9b4c-01a22c091d70"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("4687d372-e0a3-4244-98a8-901a310a61ba"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("48998e7d-225e-4fc1-8c1e-678e95061016"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("9039bbd7-e63c-4599-9432-7bc3def41868"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("c773db15-6499-4e69-b73b-586c76049261"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") },
                    { new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f"), new Guid("d69e288f-1c09-440a-9c2c-eda9e11f7c2a") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "AcceptableTickets", "CoachId", "Date", "Description", "LocationId", "PictureLink", "TeamId" },
                values: new object[,]
                {
                    { new Guid("1c78c06c-c29e-4aa7-b5a9-0c944776b4fa"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(858), "Training1", new Guid("832a04d9-ccd0-4fd5-b0d5-d4ef7e9567c9"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("49b5f7d0-d8f2-41d2-852e-14d5184a4279"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(874), "Training5", new Guid("69d584b2-236a-4de8-9891-e7bbe123f2ff"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("571e311d-73e5-4794-adb4-029046ca3f1d"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(863), "Training2", new Guid("d5485f4a-a9e4-4aa2-97ab-73af6349b037"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg", new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("718e4037-8aa9-4e3e-9bc2-43fbbe0b391a"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(878), "Training6", new Guid("81bc618a-17f3-402a-9a68-dc71bfb16863"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("ad4a26c3-7d41-4fba-a0d7-78114daaed3d"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(885), "Training8", new Guid("fc6913da-3981-4e7d-9f88-487ffe3a6637"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("afce0bb9-11ee-4721-adf5-8a83b3f52e58"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(893), "Training10", new Guid("1fd71364-dce1-4154-8f12-95b83314d328"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("b9682415-34b6-44b0-9032-f9bd186851b2"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(871), "Training4", new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("ca2ab64d-721a-4e86-90f5-22dd4d1dfddd"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(881), "Training7", new Guid("3744aacd-d782-47ab-96de-8235b7572cb0"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg", new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("d164db65-9090-4632-b95a-353bcb6a0c22"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(889), "Training9", new Guid("cc3c3996-0091-40a0-8d6f-c23367a9c45e"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg", new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("ffe00045-f28e-4daf-a743-fb6614d3b97c"), 5, new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3"), new DateTime(2025, 5, 21, 19, 43, 3, 537, DateTimeKind.Local).AddTicks(867), "Training3", new Guid("0dc5faf8-f9b8-4596-a57c-3fa5d321b0bc"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg", new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("1c78c06c-c29e-4aa7-b5a9-0c944776b4fa"), new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("03a06d04-87ea-448a-9eca-5344ccfa1ab0"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("03a06d04-87ea-448a-9eca-5344ccfa1ab0"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("05c2cdfb-4f4b-4059-9514-785f4b1ba58b"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("05c2cdfb-4f4b-4059-9514-785f4b1ba58b"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("0943afbf-e525-4b44-b17f-e9a6099a7fb2"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("0943afbf-e525-4b44-b17f-e9a6099a7fb2"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("0bc80544-3115-4595-a775-a17c8ad343cc"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("0bc80544-3115-4595-a775-a17c8ad343cc"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("0e6f982d-2ea0-43f3-b5a1-05cce2670c52"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("0e6f982d-2ea0-43f3-b5a1-05cce2670c52"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("0f2a1518-7551-4d20-9846-4fc139b5c3d5"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("0f2a1518-7551-4d20-9846-4fc139b5c3d5"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("11adff45-e848-45eb-93ed-6d92c873a078"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("11adff45-e848-45eb-93ed-6d92c873a078"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("125054cf-f902-4521-8c58-9db553d2a0b3"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("125054cf-f902-4521-8c58-9db553d2a0b3"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("144b9ee0-a912-447a-8492-b401bf8cc74c"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("144b9ee0-a912-447a-8492-b401bf8cc74c"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("155989a4-7c7e-446c-8355-261f4894a754"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("155989a4-7c7e-446c-8355-261f4894a754"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("176f3122-490b-47cd-b88a-0d675b0255c6"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("176f3122-490b-47cd-b88a-0d675b0255c6"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("178ff88c-2f3b-4bc0-a155-7e3d17d34aaf"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("178ff88c-2f3b-4bc0-a155-7e3d17d34aaf"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("19d3288d-fe75-44bd-8015-335f01230f3f"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("19d3288d-fe75-44bd-8015-335f01230f3f"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("1a2d138d-fc9c-4508-af70-226ea5575a10"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("1a2d138d-fc9c-4508-af70-226ea5575a10"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("1db342cd-433d-479f-a426-769a1f734113"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("1db342cd-433d-479f-a426-769a1f734113"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("20e6f969-5b59-46fb-92a8-ad863e5e8d87"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("20e6f969-5b59-46fb-92a8-ad863e5e8d87"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("21687c59-b1df-4cc2-9f32-0770b664c913"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("21687c59-b1df-4cc2-9f32-0770b664c913"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("2274fa40-18ae-4f95-a6f3-734686faa913"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("2274fa40-18ae-4f95-a6f3-734686faa913"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("22a64baf-e122-4d6b-8cd4-65e4d088366d"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("22a64baf-e122-4d6b-8cd4-65e4d088366d"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("297d3170-45ab-43b2-99fe-3904447f07b6"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("297d3170-45ab-43b2-99fe-3904447f07b6"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("2c0d7d3e-d7a7-4782-9d8b-b91559fb06b6"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("2c0d7d3e-d7a7-4782-9d8b-b91559fb06b6"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("2d7dd864-9507-4072-80e3-0ac72b5ebe67"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("2d7dd864-9507-4072-80e3-0ac72b5ebe67"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("2f810407-c485-4cad-86cd-4394e365769f"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("2f810407-c485-4cad-86cd-4394e365769f"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("3082760f-8b72-4711-bc0f-050e42976e0f"), new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94") },
                    { new Guid("3082760f-8b72-4711-bc0f-050e42976e0f"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("31c6d60b-048c-456a-b6a7-3faa5f200f8b"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("31c6d60b-048c-456a-b6a7-3faa5f200f8b"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("33a81a77-2ca2-4591-a503-0cd40ea9f6ad"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("33a81a77-2ca2-4591-a503-0cd40ea9f6ad"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("34b59d6c-48bc-43e4-9750-362b78c5d5f6"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("34b59d6c-48bc-43e4-9750-362b78c5d5f6"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("34fb3fc0-94e6-468a-a2b8-7370c88d0e08"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("34fb3fc0-94e6-468a-a2b8-7370c88d0e08"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("355faf40-b70d-45c0-806e-c499db255977"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("355faf40-b70d-45c0-806e-c499db255977"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("3605cfd9-c802-4cd9-9be6-c7fa9f72a76b"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("3605cfd9-c802-4cd9-9be6-c7fa9f72a76b"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("373a296c-428b-4d4b-b0de-ba894215a0ce"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("373a296c-428b-4d4b-b0de-ba894215a0ce"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("38b40692-e0e1-4149-ab95-a1e8bff78f85"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("38b40692-e0e1-4149-ab95-a1e8bff78f85"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("39b4904d-96e6-4e3a-b893-d11b7ac8fe43"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("39b4904d-96e6-4e3a-b893-d11b7ac8fe43"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("3c8b24ee-69ff-4a56-ab00-06579133a925"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("3c8b24ee-69ff-4a56-ab00-06579133a925"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("3df0d627-079d-4805-aa99-e6f4023afc0e"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("3df0d627-079d-4805-aa99-e6f4023afc0e"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("3f1e726b-9b21-493e-808b-0051d9226465"), new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94") },
                    { new Guid("3f1e726b-9b21-493e-808b-0051d9226465"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("3f5c2d67-a1ed-4a29-8f9f-40cca4c46185"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("3f5c2d67-a1ed-4a29-8f9f-40cca4c46185"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("4198205c-21d9-4d7e-9a07-b34df448ff10"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("4198205c-21d9-4d7e-9a07-b34df448ff10"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("45adfb6b-5a62-4bc8-943f-786e03b49d10"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("45adfb6b-5a62-4bc8-943f-786e03b49d10"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("4672c04c-1dd9-4c70-9b32-c8fcd53a73c5"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("4672c04c-1dd9-4c70-9b32-c8fcd53a73c5"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("4761947b-e5bd-48ed-b090-36202764db38"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("4761947b-e5bd-48ed-b090-36202764db38"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("47a3a6fa-6251-4a56-a5f0-24b91011c987"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("47a3a6fa-6251-4a56-a5f0-24b91011c987"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("49280231-ab69-4b11-b2db-dcded9726c10"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("49280231-ab69-4b11-b2db-dcded9726c10"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("4afad4ec-dbe2-4e8d-a201-78ca45566334"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("4afad4ec-dbe2-4e8d-a201-78ca45566334"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("4dba24f2-ed38-4654-9144-8fe22974c89f"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("4dba24f2-ed38-4654-9144-8fe22974c89f"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("4e322024-a8cb-4829-ba16-906aa7e75a23"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("4e322024-a8cb-4829-ba16-906aa7e75a23"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("5014fcd8-f031-4572-895d-ba850531f65f"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("5014fcd8-f031-4572-895d-ba850531f65f"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("50ef5ccb-fb73-4113-a526-aa2e1b48f9f3"), new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94") },
                    { new Guid("50ef5ccb-fb73-4113-a526-aa2e1b48f9f3"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("5106eb80-0df2-4376-a715-b0ef22aeb805"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("5106eb80-0df2-4376-a715-b0ef22aeb805"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("54d4d746-8699-477b-adf4-1f1da8dab4cb"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("54d4d746-8699-477b-adf4-1f1da8dab4cb"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("581d0deb-df54-44e8-8f5e-6bac7b4b344c"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("581d0deb-df54-44e8-8f5e-6bac7b4b344c"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("584ae2f3-6fd4-4cde-b8d9-20757d36ffce"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("584ae2f3-6fd4-4cde-b8d9-20757d36ffce"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("59ba2cd9-0c95-4b00-92b3-d4b1887d3410"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("59ba2cd9-0c95-4b00-92b3-d4b1887d3410"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("5b35f533-75aa-4945-9fda-8c53d54ba8a4"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("5b35f533-75aa-4945-9fda-8c53d54ba8a4"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("5be8b30d-6ee2-42ea-8699-2497bbb71f1e"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("5be8b30d-6ee2-42ea-8699-2497bbb71f1e"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("5ca16acf-eb3e-4a5b-8cf0-c1eae0e792de"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("5ca16acf-eb3e-4a5b-8cf0-c1eae0e792de"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("5e19ed46-d5ce-4c6c-bd38-bf7b28386674"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("5e19ed46-d5ce-4c6c-bd38-bf7b28386674"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("613b0213-1ea9-4855-afa3-837e2195a583"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("613b0213-1ea9-4855-afa3-837e2195a583"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("624db938-a784-4e92-94a9-fac5613ec01a"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("624db938-a784-4e92-94a9-fac5613ec01a"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("641e3000-e9e2-45ba-a16e-bf712e9dc6d5"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("641e3000-e9e2-45ba-a16e-bf712e9dc6d5"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("668d8ec9-538b-42db-8297-21ed1115933b"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("668d8ec9-538b-42db-8297-21ed1115933b"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("67781b44-4a03-496d-a1de-9f9368840295"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("67781b44-4a03-496d-a1de-9f9368840295"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("67cf98d9-eeb7-4666-bf71-32526b447e9d"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("67cf98d9-eeb7-4666-bf71-32526b447e9d"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("693ef6f5-83f4-4cbc-bcd6-3d192fbcf4ef"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("693ef6f5-83f4-4cbc-bcd6-3d192fbcf4ef"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("6c094351-a6e2-4210-b631-2f337212df5f"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("6c094351-a6e2-4210-b631-2f337212df5f"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("6c3ac530-415a-4654-92c1-db85464f9482"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("6c3ac530-415a-4654-92c1-db85464f9482"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("6e8273a5-5bed-470d-ae71-37e228ecd526"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("6e8273a5-5bed-470d-ae71-37e228ecd526"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("6ff8f907-ec44-49ff-8e9a-3891e6cbf47a"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("6ff8f907-ec44-49ff-8e9a-3891e6cbf47a"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("7024738e-348b-4ad7-a7d1-007464426eeb"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("7024738e-348b-4ad7-a7d1-007464426eeb"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("7057ff24-573e-4c77-9375-f2366c9f26bf"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("7057ff24-573e-4c77-9375-f2366c9f26bf"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("70946aca-fb8c-4bf0-9ff0-3520ae585a67"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("70946aca-fb8c-4bf0-9ff0-3520ae585a67"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("734c1470-70e5-4e4a-b50e-48d7a309abb4"), new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94") },
                    { new Guid("734c1470-70e5-4e4a-b50e-48d7a309abb4"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("780eed06-07be-43fd-8d44-3d01e481a3d5"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("780eed06-07be-43fd-8d44-3d01e481a3d5"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("79ff7af4-abf2-48b0-9d07-24f166554bca"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("79ff7af4-abf2-48b0-9d07-24f166554bca"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("7a672e81-3fc2-4b34-8a5f-1fb82290c1aa"), new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94") },
                    { new Guid("7a672e81-3fc2-4b34-8a5f-1fb82290c1aa"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("7a7b99f7-87c0-48b5-aa5a-68a84a29190a"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("7a7b99f7-87c0-48b5-aa5a-68a84a29190a"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("7e6752a6-a188-4bce-b3c9-19a7c84e3605"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("7e6752a6-a188-4bce-b3c9-19a7c84e3605"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("7fb2c2b2-e667-4b7c-8c45-11b50e43d6d2"), new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94") },
                    { new Guid("7fb2c2b2-e667-4b7c-8c45-11b50e43d6d2"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("84d8a6c8-a172-4d7d-a77b-9d6471b4915c"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("84d8a6c8-a172-4d7d-a77b-9d6471b4915c"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("85e23d75-70ce-47d5-95c8-10f87e7a1221"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("85e23d75-70ce-47d5-95c8-10f87e7a1221"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("866becfb-6b05-422b-87ec-5f0272cffb73"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("866becfb-6b05-422b-87ec-5f0272cffb73"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("887f4409-9e4b-4c80-a565-8f18e0162066"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("887f4409-9e4b-4c80-a565-8f18e0162066"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("8a113060-aeff-4892-816c-6bdfe651d887"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("8a113060-aeff-4892-816c-6bdfe651d887"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("8b3d75f5-8f57-4f2a-bac1-d50a8f62a83a"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("8b3d75f5-8f57-4f2a-bac1-d50a8f62a83a"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("8df92a0d-b47e-4c07-8325-74d5dccafb18"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("8df92a0d-b47e-4c07-8325-74d5dccafb18"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("90dc5027-9d96-47b5-9bf0-462ce625c870"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("90dc5027-9d96-47b5-9bf0-462ce625c870"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("9212cf72-a3ea-4f25-b53a-eff00582b2c9"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("9212cf72-a3ea-4f25-b53a-eff00582b2c9"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("924e79e8-e386-4804-a888-dcfdda9a3658"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("924e79e8-e386-4804-a888-dcfdda9a3658"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("93220b49-b7c5-4422-9d63-3601c9d7ebb5"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("93220b49-b7c5-4422-9d63-3601c9d7ebb5"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("948ea11e-0648-4119-a288-d3dde3fc06e4"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("948ea11e-0648-4119-a288-d3dde3fc06e4"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("960d4ab5-4395-4ef0-ad1b-6e635e1ae574"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("960d4ab5-4395-4ef0-ad1b-6e635e1ae574"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("98055336-7b4d-4d0d-a25e-c77825aaa8fb"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("98055336-7b4d-4d0d-a25e-c77825aaa8fb"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("9891d390-68af-4606-8230-147ea50da876"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("9891d390-68af-4606-8230-147ea50da876"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("98f436c7-82a8-4639-89ce-2d9fea73b132"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("98f436c7-82a8-4639-89ce-2d9fea73b132"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("9a4ec2ac-e395-44ce-a1f2-02c8a9e93ca5"), new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94") },
                    { new Guid("9a4ec2ac-e395-44ce-a1f2-02c8a9e93ca5"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("9a99021b-0769-443a-b464-d209fed682ae"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("9a99021b-0769-443a-b464-d209fed682ae"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("9c5f9a9c-c082-4e53-ae1f-8fe150a13dd7"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("9c5f9a9c-c082-4e53-ae1f-8fe150a13dd7"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("9cc6cd70-f316-4c1a-951d-2065d5735af2"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("9cc6cd70-f316-4c1a-951d-2065d5735af2"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("9ea02802-3004-46d4-a317-8db70af292f8"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("9ea02802-3004-46d4-a317-8db70af292f8"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("a1ac6829-91fd-4429-b80e-0878cb0b4a0d"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("a1ac6829-91fd-4429-b80e-0878cb0b4a0d"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("a4855234-a713-4624-8041-3cde8c9230fa"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("a4855234-a713-4624-8041-3cde8c9230fa"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("a8dcdd6e-65d1-4af4-8f88-447fd0382168"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("a8dcdd6e-65d1-4af4-8f88-447fd0382168"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("adacfb10-f742-4776-a390-f2ee88a4aa64"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("adacfb10-f742-4776-a390-f2ee88a4aa64"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("b07ee76a-9337-4f87-9956-4317877502f0"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("b07ee76a-9337-4f87-9956-4317877502f0"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("b107d5f4-06f3-4344-91f2-0c9303bdda36"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("b107d5f4-06f3-4344-91f2-0c9303bdda36"), new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94") },
                    { new Guid("b3f4f1c1-37b2-434d-beab-655fcb1d7de8"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("b3f4f1c1-37b2-434d-beab-655fcb1d7de8"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("b5094aea-43ae-4e2f-900d-1a393821fdb8"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("b5094aea-43ae-4e2f-900d-1a393821fdb8"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("b615386e-3ed9-4758-8b9e-8ff7059b85d2"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("b615386e-3ed9-4758-8b9e-8ff7059b85d2"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("b68cecf6-fc64-4432-a430-13f8653149ad"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("b68cecf6-fc64-4432-a430-13f8653149ad"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("b87f2a57-8514-42c1-b345-6389aafc6be1"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("b87f2a57-8514-42c1-b345-6389aafc6be1"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("bb64eb17-c378-4746-8668-f944a81d078c"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("bb64eb17-c378-4746-8668-f944a81d078c"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("bf5da33d-bb33-4c29-8fd6-93c20b960dfe"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("bf5da33d-bb33-4c29-8fd6-93c20b960dfe"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("c4f98cb4-6c1c-46ca-9129-1b8b2c36c23d"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("c4f98cb4-6c1c-46ca-9129-1b8b2c36c23d"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("c5a1d78b-2ca0-4b21-8080-be7a9c230951"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("c5a1d78b-2ca0-4b21-8080-be7a9c230951"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("c5e2fdbb-ffc5-4978-9eca-78fe371260b6"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("c5e2fdbb-ffc5-4978-9eca-78fe371260b6"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("c69fbfc9-cb52-46de-a28a-7a72effab922"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("c69fbfc9-cb52-46de-a28a-7a72effab922"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("c747cc7b-7382-4989-a6d4-70569f732da0"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("c747cc7b-7382-4989-a6d4-70569f732da0"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("c89fba25-6021-4765-a299-713bd8221f50"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("c89fba25-6021-4765-a299-713bd8221f50"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("cca9c4e5-edc4-4756-bddf-56cdeae1c286"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("cca9c4e5-edc4-4756-bddf-56cdeae1c286"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("cda62882-1966-4680-8062-5ec85d0ff0ce"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("cda62882-1966-4680-8062-5ec85d0ff0ce"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("d0b7e484-dcae-4c7c-9208-c145ef95dad4"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("d0b7e484-dcae-4c7c-9208-c145ef95dad4"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("d122e4fb-7b14-420e-95fe-36b199e64bbc"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("d122e4fb-7b14-420e-95fe-36b199e64bbc"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("d1d7c68f-f81a-482d-869c-fe36aa3d56fa"), new Guid("04d92837-1b83-4287-9b4c-01a22c091d70") },
                    { new Guid("d1d7c68f-f81a-482d-869c-fe36aa3d56fa"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("d3d0ce79-c568-4185-8665-8fc524bcdefa"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("d3d0ce79-c568-4185-8665-8fc524bcdefa"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("d56eabb9-6410-408f-837d-bcf274d85b04"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("d56eabb9-6410-408f-837d-bcf274d85b04"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("d5f3f18d-2421-4942-8640-5f81e0413357"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("d5f3f18d-2421-4942-8640-5f81e0413357"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("d6ee8f37-8f74-4acf-b6ab-e1bfc0c6d6c5"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("d6ee8f37-8f74-4acf-b6ab-e1bfc0c6d6c5"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("d970691f-4c1f-4acf-995c-2d0034d86daa"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("d970691f-4c1f-4acf-995c-2d0034d86daa"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("da8f8636-787a-48d2-b4a5-576fb2e0cc01"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("da8f8636-787a-48d2-b4a5-576fb2e0cc01"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("db36f37c-b96d-4fc4-a7de-48c0a8850456"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("db36f37c-b96d-4fc4-a7de-48c0a8850456"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("e2c07cbc-2aa7-4fc3-aaa5-24e6db9d1314"), new Guid("1f85cacc-72e2-4dcd-a2ca-1caf21c6ed94") },
                    { new Guid("e2c07cbc-2aa7-4fc3-aaa5-24e6db9d1314"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("e43d5722-c01e-4657-8d6f-25d26f660101"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("e43d5722-c01e-4657-8d6f-25d26f660101"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("e6af20cf-e7fd-40fb-92b6-49d874e86ab5"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("e6af20cf-e7fd-40fb-92b6-49d874e86ab5"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("e873b714-1b5c-4fa1-87aa-afb6d2de5af3"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("e873b714-1b5c-4fa1-87aa-afb6d2de5af3"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("e8bd571a-4c8e-48dc-b1a7-85f1bce31f62"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("e8bd571a-4c8e-48dc-b1a7-85f1bce31f62"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("e96abc84-b230-41f6-90a3-1b329264f171"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("e96abc84-b230-41f6-90a3-1b329264f171"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("e9752d77-5177-400d-96c5-c4e6fb7aa698"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("e9752d77-5177-400d-96c5-c4e6fb7aa698"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") },
                    { new Guid("e9aecb3a-5163-43d6-ba11-6ff4931cd811"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("e9aecb3a-5163-43d6-ba11-6ff4931cd811"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("e9b2c099-0091-43cd-8bd0-0352e3266da1"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("e9b2c099-0091-43cd-8bd0-0352e3266da1"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("ea5fdfbb-d689-47c7-91e2-17ecc2da641f"), new Guid("4687d372-e0a3-4244-98a8-901a310a61ba") },
                    { new Guid("ea5fdfbb-d689-47c7-91e2-17ecc2da641f"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("ebb01412-97ac-46dd-a38f-01a5fa4d8cf3"), new Guid("35eb0aa1-9ca2-41b7-b1a0-85b91ed6af0e") },
                    { new Guid("ebb01412-97ac-46dd-a38f-01a5fa4d8cf3"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("ed9b45af-1af6-4be5-ba61-50f7fb2872ed"), new Guid("48998e7d-225e-4fc1-8c1e-678e95061016") },
                    { new Guid("ed9b45af-1af6-4be5-ba61-50f7fb2872ed"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("efac9301-58d1-4521-bce0-f1ecec7d66ba"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("efac9301-58d1-4521-bce0-f1ecec7d66ba"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("f1528a21-a344-4a0e-b045-bb443121588f"), new Guid("5f73b486-2c56-464e-bb3e-3ab0d4f33554") },
                    { new Guid("f1528a21-a344-4a0e-b045-bb443121588f"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("f25988eb-7263-40e3-89fd-75232ab2b556"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("f25988eb-7263-40e3-89fd-75232ab2b556"), new Guid("9791b377-0e08-4560-8f70-cd3f5020eb12") },
                    { new Guid("f756214a-96db-4339-a55b-576c476d7057"), new Guid("3055b7e7-26e0-4cd0-8aa7-7d66398dba12") },
                    { new Guid("f756214a-96db-4339-a55b-576c476d7057"), new Guid("941bd9d3-2a51-4f5f-acf5-ed10f54694c4") },
                    { new Guid("f76cb624-f075-428a-93ac-c88e4b71875e"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("f76cb624-f075-428a-93ac-c88e4b71875e"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("f8616df6-de41-4c82-bf98-397f35cdb766"), new Guid("6f9a1d61-1d61-4151-a0be-cc361a08d4b0") },
                    { new Guid("f8616df6-de41-4c82-bf98-397f35cdb766"), new Guid("9039bbd7-e63c-4599-9432-7bc3def41868") },
                    { new Guid("fa948dd1-aeed-4214-b4f2-c48b98e2cdcf"), new Guid("7b469fd9-9af1-41d0-9296-788f92d63f72") },
                    { new Guid("fa948dd1-aeed-4214-b4f2-c48b98e2cdcf"), new Guid("f0caa1f5-ee84-45c2-84e2-ed335f457c6f") },
                    { new Guid("fdef1594-6dd6-467f-9ab2-2243529d9a09"), new Guid("c773db15-6499-4e69-b73b-586c76049261") },
                    { new Guid("fdef1594-6dd6-467f-9ab2-2243529d9a09"), new Guid("e687ab96-ae1e-4301-9942-8fce2e8697ea") },
                    { new Guid("fef64b77-3018-435f-9262-e46a29732cfd"), new Guid("15cdc848-f1e4-4ed8-bfac-7bc8ebc34aff") },
                    { new Guid("fef64b77-3018-435f-9262-e46a29732cfd"), new Guid("5ba0b483-a265-43dd-adc2-6abc18cb2075") }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b9682415-34b6-44b0-9032-f9bd186851b2"), new Guid("0f0620e8-5b4c-48fa-8ce7-6c129d4d304b") },
                    { new Guid("571e311d-73e5-4794-adb4-029046ca3f1d"), new Guid("14985d68-4be7-4efc-a794-cb57d98449e6") },
                    { new Guid("ffe00045-f28e-4daf-a743-fb6614d3b97c"), new Guid("1b9c93cd-1c38-462e-98ef-2d94a8b1baa6") },
                    { new Guid("ca2ab64d-721a-4e86-90f5-22dd4d1dfddd"), new Guid("5b5896d5-b54f-4a65-9410-fa0ddc67c859") },
                    { new Guid("718e4037-8aa9-4e3e-9bc2-43fbbe0b391a"), new Guid("92a6f3c5-0755-4615-aa80-0c5a933fe07b") },
                    { new Guid("afce0bb9-11ee-4721-adf5-8a83b3f52e58"), new Guid("a53e825a-154d-4be9-8bbf-a123cbd71373") },
                    { new Guid("49b5f7d0-d8f2-41d2-852e-14d5184a4279"), new Guid("a559e4bb-7178-4c72-a3a8-b48a0811c167") },
                    { new Guid("ad4a26c3-7d41-4fba-a0d7-78114daaed3d"), new Guid("aaea9744-809d-4da8-b348-ff4c66d0e1fa") },
                    { new Guid("1c78c06c-c29e-4aa7-b5a9-0c944776b4fa"), new Guid("bb6550b1-6e5e-4445-a181-e0dfcf052fa3") },
                    { new Guid("d164db65-9090-4632-b95a-353bcb6a0c22"), new Guid("dfb24d0c-972a-47a8-94c1-7779b9fde4f4") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteTeams_UserId",
                table: "FavouriteTeams",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteTournaments_UserId",
                table: "FavouriteTournaments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteTrainings_UserId",
                table: "FavouriteTrainings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LocationId",
                table: "Matches",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RefereeId",
                table: "Matches",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeams_TeamId",
                table: "MatchTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCoaches_UserId",
                table: "TeamCoaches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayers_UserId",
                table: "TeamPlayers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LocationId",
                table: "Teams",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_OwnerId",
                table: "Teams",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentCompetitors_TeamId",
                table: "TournamentCompetitors",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_LocationId",
                table: "Tournaments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingParticipants_TrainingId",
                table: "TrainingParticipants",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CoachId",
                table: "Trainings",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_LocationId",
                table: "Trainings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TeamId",
                table: "Trainings",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteTeams");

            migrationBuilder.DropTable(
                name: "FavouriteTournaments");

            migrationBuilder.DropTable(
                name: "FavouriteTrainings");

            migrationBuilder.DropTable(
                name: "MatchTeams");

            migrationBuilder.DropTable(
                name: "TeamCoaches");

            migrationBuilder.DropTable(
                name: "TeamPlayers");

            migrationBuilder.DropTable(
                name: "TournamentCompetitors");

            migrationBuilder.DropTable(
                name: "TrainingParticipants");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
