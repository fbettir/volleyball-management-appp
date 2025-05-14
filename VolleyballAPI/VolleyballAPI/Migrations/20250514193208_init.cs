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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "MatchTeams",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentType = table.Column<int>(type: "int", nullable: true)
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
                    { new Guid("2f591da4-9c6b-4df5-96b6-0f856b437e07"), "Location Addr 5", "Location5" },
                    { new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), "Budapest, Bogdánfy u. 12, 1117", "BME Sporttelep" },
                    { new Guid("493018d0-544e-43d7-82c7-b1149fe135fd"), "Location Addr 9", "Location9" },
                    { new Guid("6ad98138-1bf4-45c4-a5c4-0447a2976f0f"), "Location Addr 4", "Location4" },
                    { new Guid("b214fc0d-42af-4399-804f-6e3b5e8357cf"), "Location Addr 6", "Location6" },
                    { new Guid("b73ff1ea-1ad8-4364-a054-86306badb5fb"), "Location Addr 7", "Location7" },
                    { new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), "Budapest, Bertalan Lajos u. 4-6, 1111", "BME Sportközpont" },
                    { new Guid("cf7083b4-c222-47e4-ae8e-d5d66719a4a6"), "Location Addr 8", "Location8" },
                    { new Guid("dd0e713e-e209-4f85-9f57-9c794a8bdaab"), "Location Addr 10", "Location10" },
                    { new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), "1114 Budapest, Villányi út 27.", "Budai Ciszterci Szent Imre Gimnázium Tornacsarnok" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Gender", "Name", "Password", "Phone", "PictureLink", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("1fbd5781-81f5-4776-b507-a12a75c51fad"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7363), "user4@user.com", 0, "Kristóf", "pass4", "83568", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("38f1a72a-50b3-4b47-abe1-11e67bdfd2bc"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7375), "user7@user.com", 1, "Felícia", "pass7", "32134", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 2 },
                    { new Guid("685b59ab-27c4-4f88-928e-171e1a866b0e"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7379), "user8@user.com", 0, "Name 8", "pass8", "893935", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("7d84498c-0e7b-4277-8404-4f7c63a544a1"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7431), "user10@user.com", 0, "Name 10", "pass10", "13556", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("7eeab7e6-1a8e-49e5-bac3-60de3e004b42"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7367), "user5@user.com", 0, "Lajos", "pass5", "54337", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 4, 2 },
                    { new Guid("8cfbb7e9-cfbc-4673-81a3-4006d7ad23cf"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7359), "user3@user.com", 0, "Dani", "pass3", "123555", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("95f68c65-9a0f-47af-826a-a4950f81e6da"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7355), "user2@user.com", 1, "Aranka", "pass2", "965463", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("a9b9fae7-2fe3-4fdf-a676-9cd9769dee88"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7371), "user6@user.com", 0, "Péter", "pass6", "4221", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("e6c246f1-1d05-40c3-b948-3b6bbeae2e3c"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7383), "user9@user.com", 0, "Name 9", "pass9", "2716717", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7348), "user1@user.com", 0, "Jancsi", "pass1", "34214124", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId", "PictureLink" },
                values: new object[,]
                {
                    { new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), "Description Team 4", new Guid("6ad98138-1bf4-45c4-a5c4-0447a2976f0f"), "Team 4", new Guid("1fbd5781-81f5-4776-b507-a12a75c51fad"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                    { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), "Description Team 1", new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), "Team 1", new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" },
                    { new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), "Description Team 5", new Guid("2f591da4-9c6b-4df5-96b6-0f856b437e07"), "Team 5", new Guid("8cfbb7e9-cfbc-4673-81a3-4006d7ad23cf"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" },
                    { new Guid("24157da1-5360-47f0-a541-a78bca725a58"), "Description Team 17", new Guid("6ad98138-1bf4-45c4-a5c4-0447a2976f0f"), "Team 17", new Guid("685b59ab-27c4-4f88-928e-171e1a866b0e"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), "Description Team 8", new Guid("cf7083b4-c222-47e4-ae8e-d5d66719a4a6"), "Team 8", new Guid("685b59ab-27c4-4f88-928e-171e1a866b0e"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                    { new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), "Description Team 10", new Guid("6ad98138-1bf4-45c4-a5c4-0447a2976f0f"), "Team 10", new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" },
                    { new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), "Description Team 7", new Guid("b73ff1ea-1ad8-4364-a054-86306badb5fb"), "Team 7", new Guid("38f1a72a-50b3-4b47-abe1-11e67bdfd2bc"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                    { new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), "Description Team 2", new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), "Team 2", new Guid("95f68c65-9a0f-47af-826a-a4950f81e6da"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" },
                    { new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), "Description Team 14", new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), "Team 14", new Guid("7eeab7e6-1a8e-49e5-bac3-60de3e004b42"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), "Description Team 3", new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), "Team 3", new Guid("8cfbb7e9-cfbc-4673-81a3-4006d7ad23cf"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                    { new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), "Description Team 11", new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), "Team 11", new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" },
                    { new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), "Description Team 15", new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), "Team 15", new Guid("a9b9fae7-2fe3-4fdf-a676-9cd9769dee88"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), "Description Team 9", new Guid("493018d0-544e-43d7-82c7-b1149fe135fd"), "Team 9", new Guid("e6c246f1-1d05-40c3-b948-3b6bbeae2e3c"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" },
                    { new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), "Description Team 13", new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), "Team 13", new Guid("1fbd5781-81f5-4776-b507-a12a75c51fad"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), "Description Team 6", new Guid("b214fc0d-42af-4399-804f-6e3b5e8357cf"), "Team 6", new Guid("a9b9fae7-2fe3-4fdf-a676-9cd9769dee88"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                    { new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), "Description Team 12", new Guid("6ad98138-1bf4-45c4-a5c4-0447a2976f0f"), "Team 12", new Guid("8cfbb7e9-cfbc-4673-81a3-4006d7ad23cf"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), "Description Team 16", new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), "Team 16", new Guid("38f1a72a-50b3-4b47-abe1-11e67bdfd2bc"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Courts", "Date", "Description", "EntryDeadline", "LocationId", "MaxTeamsPerLevel", "Name", "Organizer", "PictureLink", "PriceType", "RegistrationPolicy", "TeamPolicy", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 5, 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), "[9,7]", "Műegyetemi röplabda torna A9 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 2 },
                    { new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 2, 2, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7038), "Description Tournament 1", new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7050), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), "[8]", "Fanatics 8 csapat körbejátszás", "Organizer 1", "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg", 16, "Registration Policy 1", "Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 0 },
                    { new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 5, 3, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), "[10,7]", "Műegyetemi röplabda torna A10 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 1 }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "MatchState", "Points", "RefereeId", "StartTime", "TournamentId", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("02a56e6c-1fe5-48a9-8155-5c1cb69ad237"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("0566dac4-ae3b-458a-8681-6bb8b513a568"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("06b88b00-5b76-41f2-be2f-52753e6a7d07"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("07cc6554-98b4-4b21-bba4-01da49ddee0c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("24157da1-5360-47f0-a541-a78bca725a58"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("09a6bf2d-e6c3-4ec8-b28e-c7e11b4bfef5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("0d0954f4-8d6a-48ee-95a5-4f103b9c6c99"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("10ad83f7-e6c1-415b-8b6b-da05d09aa10e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("10d50793-5834-4d63-a74d-6d198c6328c4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("11e43402-bb87-4759-86ef-a4cd397f45da"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("151de486-e6ab-4004-94da-275085587023"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("1954198d-9be5-403f-afac-d7b6e6caa799"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("19a0ad04-59e9-4acc-b22f-065897aba8ef"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5221), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("1ab67bd2-c3a8-49b5-880a-172cac6c474a"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("20464c5c-bbdc-4e14-872c-d30f5aba7502"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("24157da1-5360-47f0-a541-a78bca725a58"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("20f1831b-89ed-48d9-95f9-be778fc85347"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5206), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("21c01a6e-834c-4e19-a699-26165fd84e06"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("2595a2c1-87a4-4963-9d73-474b747d5cd2"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5319), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("265da6de-d912-42cf-b0b0-e5cc1911a714"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("294cd854-5bac-4903-8794-1eadff57713f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("2b6b5fc0-b5df-4429-8331-f7ca4943eecb"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("2dff8535-16b0-4c28-a105-723177258e2e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("2ea6592f-0012-486c-a662-f202e90a288f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("2fc81f8d-7214-4b98-a9e2-f5241a0db4bf"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("34c455f2-91c7-4b06-be30-c01ce76a16ad"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("3595f75f-5d85-4191-8984-b36b08cba9d4"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("3b166bb8-f151-4a23-86b3-d949afb7286d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("3c7d7eb6-b136-496b-a01c-e28f0ca5866f"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5298), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("3dec0ccc-a28c-47b5-abfa-d7e5c8414779"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("41d427de-5561-48f8-8deb-86c3a7ef03e2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("428d409b-499f-4669-85e5-3014c835ab82"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5279), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("433a1025-3d12-41dc-a827-d9b749c70bb0"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("44d4ebc4-a71b-49bb-99f4-9c583c37bc02"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("458a9acf-f513-48e5-810f-b0d92783ac7f"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5272), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("459d3818-a28a-41cc-a054-37972e331ad6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("45b10f61-a582-43a4-bbdc-44a9dc54187e"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5257), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("47218242-3997-4c73-8444-1ca7d44abff5"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("49beecf9-4286-4d74-a321-ff57c973e8f6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("4baacee9-1eb6-42e4-8926-15322b9ab9c4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("4bec9a44-b2fc-40d4-91c7-7cf57b3328d5"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("4cdbffc6-d434-472e-b151-f940137fa265"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("4cf2d5b5-6938-4628-9999-0f08507b5c2b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("4e99fc92-e881-41cd-8888-4a43818655ef"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("55a301de-8e4f-4bd3-a7f7-ec1d6044cab5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("59c6db5d-5674-4294-9f43-aa74403a43ca"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5243), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("5a24b229-e1ab-4a9f-b506-bac9042f9824"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("5b17c4cc-9fe6-4848-809d-73e0c55de164"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("5ea6acda-2f19-48fe-b38a-1660ec6175b2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("5f0959a5-d745-48da-8ce9-134c3e143fda"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5227), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("6098b0c3-f444-42cc-87e9-9a8c082f5819"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("6129b94a-40c5-443f-932f-c8f2613b1648"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("647ded90-aeb4-448a-951e-862d7ddb970d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("65507e1c-09a5-4f88-b9d2-9e7f503871f2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("66da2306-c8cf-4c37-900e-f3132b1d5015"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5284), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("67dc0e51-822d-4634-972e-465e343dbf14"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("69d184a7-38fd-4e4f-9a48-b464e3d2dd12"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("6ecb7b3d-33c7-4e25-87dc-2636bef8a93a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("6fc57c42-4efc-41cb-b8f3-c16aa086fca5"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5252), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("6fe24315-f4ad-4a74-842e-a8c5f8ea1c9c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("700effdd-a13b-4c85-91d7-8551f316d818"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("72d5ce81-5890-46b4-91f1-2e8c2ab3c9d9"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("7343fa06-1d38-40dc-9731-a230d34637be"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("73b3ed9c-d7ea-4e27-a790-543b979c1d4e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("77a992f4-b7c3-4e29-99b3-d4a5a3fb5ac1"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("77b74bbf-7608-4460-9c0d-68c9a30cbcb0"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5324), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("792911d6-887f-4701-9066-b33179589c64"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("79b761fc-75d9-4e50-b920-80d5505bccb6"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5347), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("7ee3a02e-bb3e-40fc-9961-a47c9620091a"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5267), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("7f3f2b19-8c24-485f-b908-c48761c8134a"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5288), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("82caf6a8-41e2-4391-b6c5-b95a421d7105"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("836d14d5-cff4-4b2e-a049-f278ad420bb0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("837f46dc-536a-4d67-84aa-773a0c4d89a7"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("860e9f6c-786e-4072-a7d9-92e530129613"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("86e6965d-44df-421a-93d8-ee195bce0c29"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("87df045a-7cf0-4137-992f-379634829d72"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("88295687-14be-4c54-a975-32769082f9bc"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("88751bdd-6b04-4542-8536-087b99744508"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("888e146a-d769-44db-bc04-f93eee365d74"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("8b8b4acd-b37e-4d03-afee-6ed6dffbd85a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("8c72d5a6-91c8-433e-a523-a3a27e9b209d"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5215), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("8ed9e072-251c-4250-88f5-0748fd48fd35"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("8f0eb22e-b693-460e-a873-c8ca8a331b6d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("928162af-2659-4f8a-873c-a44c085890c1"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("9282bdfd-9ca1-4e59-b617-1dfa5d309184"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5232), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("93ee7d14-d3d2-4292-8fb6-15146dcec36b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("9489ab72-307e-4e4a-8e0d-9a3b9083c981"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("95cf1cde-2726-4b78-89f1-0ee0b3fc612f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("9a343a24-b006-4588-bc84-5b93e6c00587"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("9d974caf-bb07-4899-b666-4f2dfff520bb"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("9f220fa8-ae79-4413-99fe-b8f441181c43"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5293), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("a20a3399-6a1a-487f-bb6b-d0c8ac20c29e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("a28a7131-2a45-4b66-b9f0-c62c33189d0e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("a526ddda-1fef-417d-ad19-67cac7fce711"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("a5cf2df9-1289-4ba7-9755-b65b8db65db1"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("a71a8d38-cbb4-4429-8916-7cc4c734778b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("a78923a1-3291-4b73-b5be-0964c8982847"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("a83feba6-40ff-4382-897d-702d83102f72"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("a8b976c8-bd6d-4739-8b78-4fec9451a7a0"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("a909a25b-b1cd-44cf-bc4b-b80cd4dc4401"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("aa4945b5-0f5c-4726-a41e-9afc0b1ae371"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("aae36f62-eaf9-482c-a5fa-073bfffbbf8c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("abd122fa-04fa-4964-8351-ca1eeed495cb"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("ac1463ef-7f84-461a-9465-e6e12752250e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("ad9f73cd-2126-4d5d-bcb1-1877a8f560fa"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("adc50f10-3797-4b0d-9c92-cd30d029f4ed"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("b00e8a30-6164-4d55-b757-29f663546185"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("b05c26df-e1d8-4a63-84b8-b4e27258f512"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5079), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("b06141a9-d811-4d76-b773-4ba4b635280e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("24157da1-5360-47f0-a541-a78bca725a58"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("b0a44a74-c875-4fc7-ae15-31f380e1a784"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("b1eb0cec-b0aa-457b-be95-b64f9bd3fa4f"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5315), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("b280d0d8-a977-4831-9428-fd67800a7834"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("24157da1-5360-47f0-a541-a78bca725a58"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("b446280a-68bf-466d-948f-1222f853b1bf"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("b481c51a-600d-460d-bdd3-fd81eaa51d3a"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5330), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("b7309fcf-5af1-415c-9c1e-fc442667982e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("b750652d-6a48-42cf-ab62-d34c4d6fa9c8"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("b9d5c0ab-0124-47c2-adfd-ec1807420f01"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("ba7ff38d-80ff-4255-b194-9044d78341c1"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5305), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("c072587b-fdb2-49f3-a25c-68fb85ecdd15"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("c442964b-13a9-42b3-ba5e-de78816d8787"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5310), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("c47783c4-0c1c-4591-b391-de5b6cd30e7d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("c6346a8d-bef8-488f-b3ea-c64e0f807bdc"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5342), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("c8258fe6-9189-4b29-86f7-c0eec7c05848"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("ca6f1fe1-db02-4136-9f30-45ea726b086d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("cd9cd4db-842d-47c8-852c-67bfca1c1f93"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("cf9c9d41-e3c8-4aeb-9302-0b3c0dd2b4a5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("cff7d27d-5cc9-47da-9653-d5bbb7296bee"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("d8c1501a-e1b0-4314-8e9f-a0570f5f86e6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("d95bbd7f-6da9-4311-bf9e-3e91ab576e42"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("dbf3653d-38b7-4d31-be1a-35d782a6adc8"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("dd87aff5-4bf8-47ae-87a5-7e22aaae14be"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("de1b04a6-1271-4eef-95d8-46c4fe02e28a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("e2ac794e-8cfc-4f9a-bbf6-2c3fd9ad34d0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("e3243c85-5645-4519-a565-ebaf389a8118"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("e3dec7b6-0080-40db-9965-fea1b37f847f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("e74e701e-5524-402c-87b1-e6de1fda45d0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("e76e5e49-aedf-4a98-aae5-27fe30113f3a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("e8d860f3-0ab3-410b-b3d1-0e821f6f5e94"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("eb3e0bd0-3e34-452d-bc86-24a933f2fe35"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("ecd900f3-61dd-4088-8a14-f558c9f450bf"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5247), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("ef863690-d494-4757-9675-9f9c5dd57e2d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("f055ec82-1b29-42f1-83de-816a0ca87f77"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("f3abe31b-9069-4677-8b1f-8e4f0b45e13e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("f41f857f-54df-48dd-831b-8f2e10d27833"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5237), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("f4e95e93-10ee-470d-8025-2cddad56afb0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("f51e77ce-6a08-4f43-a8c8-2e0cf20e02cd"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5211), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 },
                    { new Guid("f5769f4a-b80f-4998-9012-e4967e81c36d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("f684be51-d498-4b78-9318-b5b9ef44ef35"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("f9be8cc7-e129-4b00-bc57-0b19ed1b4987"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("fc140974-6e7e-4cf8-85b6-bc6adbc1e4b8"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("fccfb96a-3f6d-498d-92f0-3bf80f12dd7d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), 0, "[0,0]", new Guid("24157da1-5360-47f0-a541-a78bca725a58"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23"), 1 },
                    { new Guid("fe3ffdc5-c582-455b-9cd2-9c3465385d2f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), 0, "[0,0]", new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa"), 2 },
                    { new Guid("fe81f155-c001-4456-822d-a747a0e28311"), new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(5262), new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), 0, "[0,0]", new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85"), 0 }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new Guid("7eeab7e6-1a8e-49e5-bac3-60de3e004b42") },
                    { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new Guid("95f68c65-9a0f-47af-826a-a4950f81e6da") },
                    { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12") },
                    { new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new Guid("a9b9fae7-2fe3-4fdf-a676-9cd9769dee88") },
                    { new Guid("24157da1-5360-47f0-a541-a78bca725a58"), new Guid("7eeab7e6-1a8e-49e5-bac3-60de3e004b42") },
                    { new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new Guid("e6c246f1-1d05-40c3-b948-3b6bbeae2e3c") },
                    { new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), new Guid("7d84498c-0e7b-4277-8404-4f7c63a544a1") },
                    { new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new Guid("685b59ab-27c4-4f88-928e-171e1a866b0e") },
                    { new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new Guid("8cfbb7e9-cfbc-4673-81a3-4006d7ad23cf") },
                    { new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), new Guid("95f68c65-9a0f-47af-826a-a4950f81e6da") },
                    { new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new Guid("1fbd5781-81f5-4776-b507-a12a75c51fad") },
                    { new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), new Guid("7eeab7e6-1a8e-49e5-bac3-60de3e004b42") },
                    { new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), new Guid("8cfbb7e9-cfbc-4673-81a3-4006d7ad23cf") },
                    { new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new Guid("7d84498c-0e7b-4277-8404-4f7c63a544a1") },
                    { new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12") },
                    { new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new Guid("38f1a72a-50b3-4b47-abe1-11e67bdfd2bc") },
                    { new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12") },
                    { new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), new Guid("1fbd5781-81f5-4776-b507-a12a75c51fad") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new Guid("7d84498c-0e7b-4277-8404-4f7c63a544a1") },
                    { new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new Guid("e6c246f1-1d05-40c3-b948-3b6bbeae2e3c") },
                    { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new Guid("7eeab7e6-1a8e-49e5-bac3-60de3e004b42") },
                    { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new Guid("8cfbb7e9-cfbc-4673-81a3-4006d7ad23cf") },
                    { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12") },
                    { new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new Guid("1fbd5781-81f5-4776-b507-a12a75c51fad") },
                    { new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new Guid("95f68c65-9a0f-47af-826a-a4950f81e6da") },
                    { new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new Guid("38f1a72a-50b3-4b47-abe1-11e67bdfd2bc") },
                    { new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new Guid("685b59ab-27c4-4f88-928e-171e1a866b0e") },
                    { new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new Guid("a9b9fae7-2fe3-4fdf-a676-9cd9769dee88") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("24157da1-5360-47f0-a541-a78bca725a58"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), new Guid("40df3fa5-42c2-4177-b9ec-f300e9fd63aa") },
                    { new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85") },
                    { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85") },
                    { new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85") },
                    { new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85") },
                    { new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85") },
                    { new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85") },
                    { new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85") },
                    { new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new Guid("91e4d6b4-959b-4277-8b5e-bc6bb08eea85") },
                    { new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("24157da1-5360-47f0-a541-a78bca725a58"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") },
                    { new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), new Guid("b8832589-df25-444c-9e70-2c957d7aaf23") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "AcceptableTickets", "Date", "Description", "LocationId", "PictureLink", "TeamId" },
                values: new object[,]
                {
                    { new Guid("0127bb3b-697b-4864-9d31-c3a214174dbe"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7236), "Training3", new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67") },
                    { new Guid("0d756cc1-76c2-4322-a479-2006dba40e28"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7232), "Training2", new Guid("bd783ce1-4119-4b6a-b9da-dc4d692f362f"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d") },
                    { new Guid("10627fb2-9cb9-487e-87b3-634d36f84c22"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7239), "Training4", new Guid("3e329c8a-67d4-4ba4-8fc7-8424ce2f7e34"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8") },
                    { new Guid("560e7602-3cc6-4202-a251-ebd620e2ecd4"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7258), "Training10", new Guid("dd0e713e-e209-4f85-9f57-9c794a8bdaab"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6") },
                    { new Guid("791d4c49-57fd-41fa-adfe-ba4c82380bae"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7252), "Training8", new Guid("cf7083b4-c222-47e4-ae8e-d5d66719a4a6"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67") },
                    { new Guid("bb231403-bd51-4b20-8fe1-bf01b76dfc68"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7255), "Training9", new Guid("493018d0-544e-43d7-82c7-b1149fe135fd"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg", new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6") },
                    { new Guid("bb5db74f-90ad-4d6a-9cdf-042eb15616ca"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7246), "Training6", new Guid("b214fc0d-42af-4399-804f-6e3b5e8357cf"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg", new Guid("62ea4c98-c725-4ac0-821e-8be638120f67") },
                    { new Guid("bf3ba67f-e470-405e-b53e-1304d614bc70"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7243), "Training5", new Guid("2f591da4-9c6b-4df5-96b6-0f856b437e07"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8") },
                    { new Guid("e1fa7fd7-08de-4f7f-b976-49729198e4c8"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7249), "Training7", new Guid("b73ff1ea-1ad8-4364-a054-86306badb5fb"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg", new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8") },
                    { new Guid("e9afc046-a044-49d8-b27a-fa9c9c206833"), 5, new DateTime(2025, 5, 14, 21, 32, 7, 383, DateTimeKind.Local).AddTicks(7227), "Training1", new Guid("fbb5450a-b0e5-4e3e-8d14-2a4e48e5d8ae"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg", new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("e9afc046-a044-49d8-b27a-fa9c9c206833"), new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("02a56e6c-1fe5-48a9-8155-5c1cb69ad237"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("02a56e6c-1fe5-48a9-8155-5c1cb69ad237"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("0566dac4-ae3b-458a-8681-6bb8b513a568"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("0566dac4-ae3b-458a-8681-6bb8b513a568"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("06b88b00-5b76-41f2-be2f-52753e6a7d07"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("06b88b00-5b76-41f2-be2f-52753e6a7d07"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("07cc6554-98b4-4b21-bba4-01da49ddee0c"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("07cc6554-98b4-4b21-bba4-01da49ddee0c"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("09a6bf2d-e6c3-4ec8-b28e-c7e11b4bfef5"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("09a6bf2d-e6c3-4ec8-b28e-c7e11b4bfef5"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("0d0954f4-8d6a-48ee-95a5-4f103b9c6c99"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("0d0954f4-8d6a-48ee-95a5-4f103b9c6c99"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("10ad83f7-e6c1-415b-8b6b-da05d09aa10e"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("10ad83f7-e6c1-415b-8b6b-da05d09aa10e"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("10d50793-5834-4d63-a74d-6d198c6328c4"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("10d50793-5834-4d63-a74d-6d198c6328c4"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("11e43402-bb87-4759-86ef-a4cd397f45da"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("11e43402-bb87-4759-86ef-a4cd397f45da"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("151de486-e6ab-4004-94da-275085587023"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("151de486-e6ab-4004-94da-275085587023"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("1954198d-9be5-403f-afac-d7b6e6caa799"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("1954198d-9be5-403f-afac-d7b6e6caa799"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("19a0ad04-59e9-4acc-b22f-065897aba8ef"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("19a0ad04-59e9-4acc-b22f-065897aba8ef"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("1ab67bd2-c3a8-49b5-880a-172cac6c474a"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("1ab67bd2-c3a8-49b5-880a-172cac6c474a"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("20464c5c-bbdc-4e14-872c-d30f5aba7502"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("20464c5c-bbdc-4e14-872c-d30f5aba7502"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("20f1831b-89ed-48d9-95f9-be778fc85347"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("20f1831b-89ed-48d9-95f9-be778fc85347"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("21c01a6e-834c-4e19-a699-26165fd84e06"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("21c01a6e-834c-4e19-a699-26165fd84e06"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("2595a2c1-87a4-4963-9d73-474b747d5cd2"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("2595a2c1-87a4-4963-9d73-474b747d5cd2"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("265da6de-d912-42cf-b0b0-e5cc1911a714"), new Guid("24157da1-5360-47f0-a541-a78bca725a58"), null },
                    { new Guid("265da6de-d912-42cf-b0b0-e5cc1911a714"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("294cd854-5bac-4903-8794-1eadff57713f"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("294cd854-5bac-4903-8794-1eadff57713f"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("2b6b5fc0-b5df-4429-8331-f7ca4943eecb"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("2b6b5fc0-b5df-4429-8331-f7ca4943eecb"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("2dff8535-16b0-4c28-a105-723177258e2e"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("2dff8535-16b0-4c28-a105-723177258e2e"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("2ea6592f-0012-486c-a662-f202e90a288f"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("2ea6592f-0012-486c-a662-f202e90a288f"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("2fc81f8d-7214-4b98-a9e2-f5241a0db4bf"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("2fc81f8d-7214-4b98-a9e2-f5241a0db4bf"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("34c455f2-91c7-4b06-be30-c01ce76a16ad"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("34c455f2-91c7-4b06-be30-c01ce76a16ad"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("3595f75f-5d85-4191-8984-b36b08cba9d4"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("3595f75f-5d85-4191-8984-b36b08cba9d4"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("3b166bb8-f151-4a23-86b3-d949afb7286d"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("3b166bb8-f151-4a23-86b3-d949afb7286d"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("3c7d7eb6-b136-496b-a01c-e28f0ca5866f"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("3c7d7eb6-b136-496b-a01c-e28f0ca5866f"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("3dec0ccc-a28c-47b5-abfa-d7e5c8414779"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("3dec0ccc-a28c-47b5-abfa-d7e5c8414779"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("41d427de-5561-48f8-8deb-86c3a7ef03e2"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("41d427de-5561-48f8-8deb-86c3a7ef03e2"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("428d409b-499f-4669-85e5-3014c835ab82"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("428d409b-499f-4669-85e5-3014c835ab82"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("433a1025-3d12-41dc-a827-d9b749c70bb0"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("433a1025-3d12-41dc-a827-d9b749c70bb0"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("44d4ebc4-a71b-49bb-99f4-9c583c37bc02"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("44d4ebc4-a71b-49bb-99f4-9c583c37bc02"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("458a9acf-f513-48e5-810f-b0d92783ac7f"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("458a9acf-f513-48e5-810f-b0d92783ac7f"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("459d3818-a28a-41cc-a054-37972e331ad6"), new Guid("24157da1-5360-47f0-a541-a78bca725a58"), null },
                    { new Guid("459d3818-a28a-41cc-a054-37972e331ad6"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("45b10f61-a582-43a4-bbdc-44a9dc54187e"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("45b10f61-a582-43a4-bbdc-44a9dc54187e"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("47218242-3997-4c73-8444-1ca7d44abff5"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("47218242-3997-4c73-8444-1ca7d44abff5"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("49beecf9-4286-4d74-a321-ff57c973e8f6"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("49beecf9-4286-4d74-a321-ff57c973e8f6"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("4baacee9-1eb6-42e4-8926-15322b9ab9c4"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("4baacee9-1eb6-42e4-8926-15322b9ab9c4"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("4bec9a44-b2fc-40d4-91c7-7cf57b3328d5"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("4bec9a44-b2fc-40d4-91c7-7cf57b3328d5"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("4cdbffc6-d434-472e-b151-f940137fa265"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("4cdbffc6-d434-472e-b151-f940137fa265"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("4cf2d5b5-6938-4628-9999-0f08507b5c2b"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("4cf2d5b5-6938-4628-9999-0f08507b5c2b"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("4e99fc92-e881-41cd-8888-4a43818655ef"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("4e99fc92-e881-41cd-8888-4a43818655ef"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("55a301de-8e4f-4bd3-a7f7-ec1d6044cab5"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("55a301de-8e4f-4bd3-a7f7-ec1d6044cab5"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("59c6db5d-5674-4294-9f43-aa74403a43ca"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("59c6db5d-5674-4294-9f43-aa74403a43ca"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("5a24b229-e1ab-4a9f-b506-bac9042f9824"), new Guid("24157da1-5360-47f0-a541-a78bca725a58"), null },
                    { new Guid("5a24b229-e1ab-4a9f-b506-bac9042f9824"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("5b17c4cc-9fe6-4848-809d-73e0c55de164"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("5b17c4cc-9fe6-4848-809d-73e0c55de164"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("5ea6acda-2f19-48fe-b38a-1660ec6175b2"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("5ea6acda-2f19-48fe-b38a-1660ec6175b2"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("5f0959a5-d745-48da-8ce9-134c3e143fda"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("5f0959a5-d745-48da-8ce9-134c3e143fda"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("6098b0c3-f444-42cc-87e9-9a8c082f5819"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("6098b0c3-f444-42cc-87e9-9a8c082f5819"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("6129b94a-40c5-443f-932f-c8f2613b1648"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("6129b94a-40c5-443f-932f-c8f2613b1648"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("647ded90-aeb4-448a-951e-862d7ddb970d"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("647ded90-aeb4-448a-951e-862d7ddb970d"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("65507e1c-09a5-4f88-b9d2-9e7f503871f2"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("65507e1c-09a5-4f88-b9d2-9e7f503871f2"), new Guid("24157da1-5360-47f0-a541-a78bca725a58"), null },
                    { new Guid("66da2306-c8cf-4c37-900e-f3132b1d5015"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("66da2306-c8cf-4c37-900e-f3132b1d5015"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("67dc0e51-822d-4634-972e-465e343dbf14"), new Guid("24157da1-5360-47f0-a541-a78bca725a58"), null },
                    { new Guid("67dc0e51-822d-4634-972e-465e343dbf14"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("69d184a7-38fd-4e4f-9a48-b464e3d2dd12"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("69d184a7-38fd-4e4f-9a48-b464e3d2dd12"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("6ecb7b3d-33c7-4e25-87dc-2636bef8a93a"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("6ecb7b3d-33c7-4e25-87dc-2636bef8a93a"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("6fc57c42-4efc-41cb-b8f3-c16aa086fca5"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("6fc57c42-4efc-41cb-b8f3-c16aa086fca5"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("6fe24315-f4ad-4a74-842e-a8c5f8ea1c9c"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("6fe24315-f4ad-4a74-842e-a8c5f8ea1c9c"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("700effdd-a13b-4c85-91d7-8551f316d818"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("700effdd-a13b-4c85-91d7-8551f316d818"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("72d5ce81-5890-46b4-91f1-2e8c2ab3c9d9"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("72d5ce81-5890-46b4-91f1-2e8c2ab3c9d9"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("7343fa06-1d38-40dc-9731-a230d34637be"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("7343fa06-1d38-40dc-9731-a230d34637be"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("73b3ed9c-d7ea-4e27-a790-543b979c1d4e"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("73b3ed9c-d7ea-4e27-a790-543b979c1d4e"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("77a992f4-b7c3-4e29-99b3-d4a5a3fb5ac1"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("77a992f4-b7c3-4e29-99b3-d4a5a3fb5ac1"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("77b74bbf-7608-4460-9c0d-68c9a30cbcb0"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("77b74bbf-7608-4460-9c0d-68c9a30cbcb0"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("792911d6-887f-4701-9066-b33179589c64"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("792911d6-887f-4701-9066-b33179589c64"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("79b761fc-75d9-4e50-b920-80d5505bccb6"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("79b761fc-75d9-4e50-b920-80d5505bccb6"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("7ee3a02e-bb3e-40fc-9961-a47c9620091a"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("7ee3a02e-bb3e-40fc-9961-a47c9620091a"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("7f3f2b19-8c24-485f-b908-c48761c8134a"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("7f3f2b19-8c24-485f-b908-c48761c8134a"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("82caf6a8-41e2-4391-b6c5-b95a421d7105"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("82caf6a8-41e2-4391-b6c5-b95a421d7105"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("836d14d5-cff4-4b2e-a049-f278ad420bb0"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("836d14d5-cff4-4b2e-a049-f278ad420bb0"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("837f46dc-536a-4d67-84aa-773a0c4d89a7"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("837f46dc-536a-4d67-84aa-773a0c4d89a7"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("860e9f6c-786e-4072-a7d9-92e530129613"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("860e9f6c-786e-4072-a7d9-92e530129613"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("86e6965d-44df-421a-93d8-ee195bce0c29"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("86e6965d-44df-421a-93d8-ee195bce0c29"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("87df045a-7cf0-4137-992f-379634829d72"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("87df045a-7cf0-4137-992f-379634829d72"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("88295687-14be-4c54-a975-32769082f9bc"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("88295687-14be-4c54-a975-32769082f9bc"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("88751bdd-6b04-4542-8536-087b99744508"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("88751bdd-6b04-4542-8536-087b99744508"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("888e146a-d769-44db-bc04-f93eee365d74"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("888e146a-d769-44db-bc04-f93eee365d74"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("8b8b4acd-b37e-4d03-afee-6ed6dffbd85a"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("8b8b4acd-b37e-4d03-afee-6ed6dffbd85a"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("8c72d5a6-91c8-433e-a523-a3a27e9b209d"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("8c72d5a6-91c8-433e-a523-a3a27e9b209d"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("8ed9e072-251c-4250-88f5-0748fd48fd35"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("8ed9e072-251c-4250-88f5-0748fd48fd35"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("8f0eb22e-b693-460e-a873-c8ca8a331b6d"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("8f0eb22e-b693-460e-a873-c8ca8a331b6d"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("928162af-2659-4f8a-873c-a44c085890c1"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("928162af-2659-4f8a-873c-a44c085890c1"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("9282bdfd-9ca1-4e59-b617-1dfa5d309184"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("9282bdfd-9ca1-4e59-b617-1dfa5d309184"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("93ee7d14-d3d2-4292-8fb6-15146dcec36b"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("93ee7d14-d3d2-4292-8fb6-15146dcec36b"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("9489ab72-307e-4e4a-8e0d-9a3b9083c981"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("9489ab72-307e-4e4a-8e0d-9a3b9083c981"), new Guid("24157da1-5360-47f0-a541-a78bca725a58"), null },
                    { new Guid("95cf1cde-2726-4b78-89f1-0ee0b3fc612f"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("95cf1cde-2726-4b78-89f1-0ee0b3fc612f"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("9a343a24-b006-4588-bc84-5b93e6c00587"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("9a343a24-b006-4588-bc84-5b93e6c00587"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("9d974caf-bb07-4899-b666-4f2dfff520bb"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("9d974caf-bb07-4899-b666-4f2dfff520bb"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("9f220fa8-ae79-4413-99fe-b8f441181c43"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("9f220fa8-ae79-4413-99fe-b8f441181c43"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("a20a3399-6a1a-487f-bb6b-d0c8ac20c29e"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("a20a3399-6a1a-487f-bb6b-d0c8ac20c29e"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("a28a7131-2a45-4b66-b9f0-c62c33189d0e"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("a28a7131-2a45-4b66-b9f0-c62c33189d0e"), new Guid("24157da1-5360-47f0-a541-a78bca725a58"), null },
                    { new Guid("a526ddda-1fef-417d-ad19-67cac7fce711"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("a526ddda-1fef-417d-ad19-67cac7fce711"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("a5cf2df9-1289-4ba7-9755-b65b8db65db1"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("a5cf2df9-1289-4ba7-9755-b65b8db65db1"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("a71a8d38-cbb4-4429-8916-7cc4c734778b"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("a71a8d38-cbb4-4429-8916-7cc4c734778b"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("a78923a1-3291-4b73-b5be-0964c8982847"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("a78923a1-3291-4b73-b5be-0964c8982847"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("a83feba6-40ff-4382-897d-702d83102f72"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("a83feba6-40ff-4382-897d-702d83102f72"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("a8b976c8-bd6d-4739-8b78-4fec9451a7a0"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("a8b976c8-bd6d-4739-8b78-4fec9451a7a0"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("a909a25b-b1cd-44cf-bc4b-b80cd4dc4401"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("a909a25b-b1cd-44cf-bc4b-b80cd4dc4401"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("aa4945b5-0f5c-4726-a41e-9afc0b1ae371"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("aa4945b5-0f5c-4726-a41e-9afc0b1ae371"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("aae36f62-eaf9-482c-a5fa-073bfffbbf8c"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("aae36f62-eaf9-482c-a5fa-073bfffbbf8c"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("abd122fa-04fa-4964-8351-ca1eeed495cb"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("abd122fa-04fa-4964-8351-ca1eeed495cb"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("ac1463ef-7f84-461a-9465-e6e12752250e"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("ac1463ef-7f84-461a-9465-e6e12752250e"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("ad9f73cd-2126-4d5d-bcb1-1877a8f560fa"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("ad9f73cd-2126-4d5d-bcb1-1877a8f560fa"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("adc50f10-3797-4b0d-9c92-cd30d029f4ed"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("adc50f10-3797-4b0d-9c92-cd30d029f4ed"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("b00e8a30-6164-4d55-b757-29f663546185"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("b00e8a30-6164-4d55-b757-29f663546185"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("b05c26df-e1d8-4a63-84b8-b4e27258f512"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("b05c26df-e1d8-4a63-84b8-b4e27258f512"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("b06141a9-d811-4d76-b773-4ba4b635280e"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("b06141a9-d811-4d76-b773-4ba4b635280e"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("b0a44a74-c875-4fc7-ae15-31f380e1a784"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("b0a44a74-c875-4fc7-ae15-31f380e1a784"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("b1eb0cec-b0aa-457b-be95-b64f9bd3fa4f"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("b1eb0cec-b0aa-457b-be95-b64f9bd3fa4f"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("b280d0d8-a977-4831-9428-fd67800a7834"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("b280d0d8-a977-4831-9428-fd67800a7834"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("b446280a-68bf-466d-948f-1222f853b1bf"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("b446280a-68bf-466d-948f-1222f853b1bf"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("b481c51a-600d-460d-bdd3-fd81eaa51d3a"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("b481c51a-600d-460d-bdd3-fd81eaa51d3a"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("b7309fcf-5af1-415c-9c1e-fc442667982e"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("b7309fcf-5af1-415c-9c1e-fc442667982e"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("b750652d-6a48-42cf-ab62-d34c4d6fa9c8"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("b750652d-6a48-42cf-ab62-d34c4d6fa9c8"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("b9d5c0ab-0124-47c2-adfd-ec1807420f01"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("b9d5c0ab-0124-47c2-adfd-ec1807420f01"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("ba7ff38d-80ff-4255-b194-9044d78341c1"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("ba7ff38d-80ff-4255-b194-9044d78341c1"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("c072587b-fdb2-49f3-a25c-68fb85ecdd15"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("c072587b-fdb2-49f3-a25c-68fb85ecdd15"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("c442964b-13a9-42b3-ba5e-de78816d8787"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("c442964b-13a9-42b3-ba5e-de78816d8787"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("c47783c4-0c1c-4591-b391-de5b6cd30e7d"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("c47783c4-0c1c-4591-b391-de5b6cd30e7d"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("c6346a8d-bef8-488f-b3ea-c64e0f807bdc"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("c6346a8d-bef8-488f-b3ea-c64e0f807bdc"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("c8258fe6-9189-4b29-86f7-c0eec7c05848"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("c8258fe6-9189-4b29-86f7-c0eec7c05848"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("ca6f1fe1-db02-4136-9f30-45ea726b086d"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("ca6f1fe1-db02-4136-9f30-45ea726b086d"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("cd9cd4db-842d-47c8-852c-67bfca1c1f93"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("cd9cd4db-842d-47c8-852c-67bfca1c1f93"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("cf9c9d41-e3c8-4aeb-9302-0b3c0dd2b4a5"), new Guid("24157da1-5360-47f0-a541-a78bca725a58"), null },
                    { new Guid("cf9c9d41-e3c8-4aeb-9302-0b3c0dd2b4a5"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("cff7d27d-5cc9-47da-9653-d5bbb7296bee"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("cff7d27d-5cc9-47da-9653-d5bbb7296bee"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("d8c1501a-e1b0-4314-8e9f-a0570f5f86e6"), new Guid("809c8811-8712-4bdf-9532-0bd5bda02195"), null },
                    { new Guid("d8c1501a-e1b0-4314-8e9f-a0570f5f86e6"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("d95bbd7f-6da9-4311-bf9e-3e91ab576e42"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("d95bbd7f-6da9-4311-bf9e-3e91ab576e42"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("dbf3653d-38b7-4d31-be1a-35d782a6adc8"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("dbf3653d-38b7-4d31-be1a-35d782a6adc8"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("dd87aff5-4bf8-47ae-87a5-7e22aaae14be"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("dd87aff5-4bf8-47ae-87a5-7e22aaae14be"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("de1b04a6-1271-4eef-95d8-46c4fe02e28a"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("de1b04a6-1271-4eef-95d8-46c4fe02e28a"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("e2ac794e-8cfc-4f9a-bbf6-2c3fd9ad34d0"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("e2ac794e-8cfc-4f9a-bbf6-2c3fd9ad34d0"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("e3243c85-5645-4519-a565-ebaf389a8118"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("e3243c85-5645-4519-a565-ebaf389a8118"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("e3dec7b6-0080-40db-9965-fea1b37f847f"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("e3dec7b6-0080-40db-9965-fea1b37f847f"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("e74e701e-5524-402c-87b1-e6de1fda45d0"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("e74e701e-5524-402c-87b1-e6de1fda45d0"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("e76e5e49-aedf-4a98-aae5-27fe30113f3a"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("e76e5e49-aedf-4a98-aae5-27fe30113f3a"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("e8d860f3-0ab3-410b-b3d1-0e821f6f5e94"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("e8d860f3-0ab3-410b-b3d1-0e821f6f5e94"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("eb3e0bd0-3e34-452d-bc86-24a933f2fe35"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("eb3e0bd0-3e34-452d-bc86-24a933f2fe35"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("ecd900f3-61dd-4088-8a14-f558c9f450bf"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("ecd900f3-61dd-4088-8a14-f558c9f450bf"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("ef863690-d494-4757-9675-9f9c5dd57e2d"), new Guid("8d988af3-356d-4194-ad79-e1a63d375540"), null },
                    { new Guid("ef863690-d494-4757-9675-9f9c5dd57e2d"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("f055ec82-1b29-42f1-83de-816a0ca87f77"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("f055ec82-1b29-42f1-83de-816a0ca87f77"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null },
                    { new Guid("f3abe31b-9069-4677-8b1f-8e4f0b45e13e"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("f3abe31b-9069-4677-8b1f-8e4f0b45e13e"), new Guid("e5ce420e-2b5a-4687-9b3e-d8487ac97888"), null },
                    { new Guid("f41f857f-54df-48dd-831b-8f2e10d27833"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("f41f857f-54df-48dd-831b-8f2e10d27833"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("f4e95e93-10ee-470d-8025-2cddad56afb0"), new Guid("231eb368-cec7-4ed1-8793-5774726d8a81"), null },
                    { new Guid("f4e95e93-10ee-470d-8025-2cddad56afb0"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("f51e77ce-6a08-4f43-a8c8-2e0cf20e02cd"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("f51e77ce-6a08-4f43-a8c8-2e0cf20e02cd"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("f5769f4a-b80f-4998-9012-e4967e81c36d"), new Guid("24157da1-5360-47f0-a541-a78bca725a58"), null },
                    { new Guid("f5769f4a-b80f-4998-9012-e4967e81c36d"), new Guid("25137659-c15a-4946-8b8d-ab503002bf68"), null },
                    { new Guid("f684be51-d498-4b78-9318-b5b9ef44ef35"), new Guid("b0bee39d-f737-4f86-ad69-231ccdb99d59"), null },
                    { new Guid("f684be51-d498-4b78-9318-b5b9ef44ef35"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("f9be8cc7-e129-4b00-bc57-0b19ed1b4987"), new Guid("9bcbe57a-97d6-44a6-b68d-fb725f0b4d8e"), null },
                    { new Guid("f9be8cc7-e129-4b00-bc57-0b19ed1b4987"), new Guid("bce81337-7628-4eb1-9ca9-d4b86c8546b5"), null },
                    { new Guid("fc140974-6e7e-4cf8-85b6-bc6adbc1e4b8"), new Guid("43a9362a-0fff-4708-822a-99c5ea4cefa6"), null },
                    { new Guid("fc140974-6e7e-4cf8-85b6-bc6adbc1e4b8"), new Guid("dd97ff8b-b1a0-4de7-9616-9f9003f50730"), null },
                    { new Guid("fccfb96a-3f6d-498d-92f0-3bf80f12dd7d"), new Guid("010a8c1c-4837-484e-9ff7-bae2abf2c7a6"), null },
                    { new Guid("fccfb96a-3f6d-498d-92f0-3bf80f12dd7d"), new Guid("1b25dac5-f0bf-4dcb-bfec-c07547fc3a5d"), null },
                    { new Guid("fe3ffdc5-c582-455b-9cd2-9c3465385d2f"), new Guid("31a51f5d-1a09-44d5-a900-095cf166e59c"), null },
                    { new Guid("fe3ffdc5-c582-455b-9cd2-9c3465385d2f"), new Guid("f313b5f0-c378-466e-9fe1-5b586cf830d9"), null },
                    { new Guid("fe81f155-c001-4456-822d-a747a0e28311"), new Guid("62ea4c98-c725-4ac0-821e-8be638120f67"), null },
                    { new Guid("fe81f155-c001-4456-822d-a747a0e28311"), new Guid("87f6ffcb-a823-4457-b307-820e85dbcba8"), null }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("10627fb2-9cb9-487e-87b3-634d36f84c22"), new Guid("1fbd5781-81f5-4776-b507-a12a75c51fad") },
                    { new Guid("e1fa7fd7-08de-4f7f-b976-49729198e4c8"), new Guid("38f1a72a-50b3-4b47-abe1-11e67bdfd2bc") },
                    { new Guid("791d4c49-57fd-41fa-adfe-ba4c82380bae"), new Guid("685b59ab-27c4-4f88-928e-171e1a866b0e") },
                    { new Guid("560e7602-3cc6-4202-a251-ebd620e2ecd4"), new Guid("7d84498c-0e7b-4277-8404-4f7c63a544a1") },
                    { new Guid("bf3ba67f-e470-405e-b53e-1304d614bc70"), new Guid("7eeab7e6-1a8e-49e5-bac3-60de3e004b42") },
                    { new Guid("0127bb3b-697b-4864-9d31-c3a214174dbe"), new Guid("8cfbb7e9-cfbc-4673-81a3-4006d7ad23cf") },
                    { new Guid("0d756cc1-76c2-4322-a479-2006dba40e28"), new Guid("95f68c65-9a0f-47af-826a-a4950f81e6da") },
                    { new Guid("bb5db74f-90ad-4d6a-9cdf-042eb15616ca"), new Guid("a9b9fae7-2fe3-4fdf-a676-9cd9769dee88") },
                    { new Guid("bb231403-bd51-4b20-8fe1-bf01b76dfc68"), new Guid("e6c246f1-1d05-40c3-b948-3b6bbeae2e3c") },
                    { new Guid("e9afc046-a044-49d8-b27a-fa9c9c206833"), new Guid("edb079cb-ce92-4013-afaa-2e9dbb46af12") }
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
