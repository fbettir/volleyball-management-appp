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
                    PriceType = table.Column<int>(type: "int", nullable: false),
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
                    { new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), "Budapest, Bogdánfy u. 12, 1117", "BME Sporttelep" },
                    { new Guid("34105bc4-49c8-46c1-b7d4-ee5b6474a65d"), "Location Addr 10", "Location10" },
                    { new Guid("3def4b5d-1f65-4b9e-bee1-536007548830"), "Location Addr 9", "Location9" },
                    { new Guid("8c53471f-0657-4807-8e34-d75b5610604c"), "Location Addr 4", "Location4" },
                    { new Guid("8f6dc86c-1609-406e-b5fb-85c96d80d18b"), "Location Addr 7", "Location7" },
                    { new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), "1114 Budapest, Villányi út 27.", "Budai Ciszterci Szent Imre Gimnázium Tornacsarnok" },
                    { new Guid("b65847a4-d57f-4dff-8fc8-120beeb837c9"), "Location Addr 6", "Location6" },
                    { new Guid("cde6ea9d-0a00-4a6e-9a5a-64e44813237e"), "Location Addr 5", "Location5" },
                    { new Guid("d107f422-837c-4cbc-9125-8db679ad272c"), "Location Addr 8", "Location8" },
                    { new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), "Budapest, Bertalan Lajos u. 4-6, 1111", "BME Sportközpont" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Gender", "Name", "Password", "Phone", "PictureLink", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("18ec3da8-297f-4768-b71b-c3284d52a2d7"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2520), "user8@user.com", 0, "Name 8", "pass8", "893935", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2488), "user1@user.com", 0, "Jancsi", "pass1", "34214124", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 2, 3 },
                    { new Guid("45018993-26ed-4a7a-87bf-5283db8cd4c3"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2507), "user5@user.com", 0, "Lajos", "pass5", "54337", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 4, 2 },
                    { new Guid("5b7e521f-58cf-4167-94fb-6d4bfa5d7833"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2525), "user9@user.com", 0, "Name 9", "pass9", "2716717", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("6019e025-20f9-4228-9b08-37f95b0ff681"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2499), "user3@user.com", 0, "Dani", "pass3", "123555", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("9320fbf0-ff80-4984-b2ad-068528274d84"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2516), "user7@user.com", 1, "Felícia", "pass7", "32134", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 2 },
                    { new Guid("957e04e0-6aa5-4a03-80c0-caa99250a185"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2529), "user10@user.com", 0, "Name 10", "pass10", "13556", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("9646954a-99d1-4bd3-81d3-de9d4776f180"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2511), "user6@user.com", 0, "Péter", "pass6", "4221", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("bae54f12-e64c-44c2-9834-742cbfcad9c5"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2494), "user2@user.com", 1, "Aranka", "pass2", "965463", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("f2691a5c-d20a-47f0-be8e-7bff05dd57af"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2503), "user4@user.com", 0, "Kristóf", "pass4", "83568", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId", "PictureLink" },
                values: new object[,]
                {
                    { new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), "Description Team 9", new Guid("3def4b5d-1f65-4b9e-bee1-536007548830"), "Team 9", new Guid("5b7e521f-58cf-4167-94fb-6d4bfa5d7833"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" },
                    { new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), "Description Team 11", new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), "Team 11", new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" },
                    { new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), "Description Team 7", new Guid("8f6dc86c-1609-406e-b5fb-85c96d80d18b"), "Team 7", new Guid("9320fbf0-ff80-4984-b2ad-068528274d84"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                    { new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), "Description Team 5", new Guid("cde6ea9d-0a00-4a6e-9a5a-64e44813237e"), "Team 5", new Guid("6019e025-20f9-4228-9b08-37f95b0ff681"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" },
                    { new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), "Description Team 6", new Guid("b65847a4-d57f-4dff-8fc8-120beeb837c9"), "Team 6", new Guid("9646954a-99d1-4bd3-81d3-de9d4776f180"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                    { new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), "Description Team 16", new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), "Team 16", new Guid("9320fbf0-ff80-4984-b2ad-068528274d84"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541"), "Description Team 13", new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), "Team 13", new Guid("f2691a5c-d20a-47f0-be8e-7bff05dd57af"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a"), "Description Team 12", new Guid("8c53471f-0657-4807-8e34-d75b5610604c"), "Team 12", new Guid("6019e025-20f9-4228-9b08-37f95b0ff681"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), "Description Team 15", new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), "Team 15", new Guid("9646954a-99d1-4bd3-81d3-de9d4776f180"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), "Description Team 2", new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), "Team 2", new Guid("bae54f12-e64c-44c2-9834-742cbfcad9c5"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" },
                    { new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), "Description Team 3", new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), "Team 3", new Guid("6019e025-20f9-4228-9b08-37f95b0ff681"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                    { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), "Description Team 1", new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), "Team 1", new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" },
                    { new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), "Description Team 14", new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), "Team 14", new Guid("45018993-26ed-4a7a-87bf-5283db8cd4c3"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), "Description Team 10", new Guid("8c53471f-0657-4807-8e34-d75b5610604c"), "Team 10", new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" },
                    { new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), "Description Team 8", new Guid("d107f422-837c-4cbc-9125-8db679ad272c"), "Team 8", new Guid("18ec3da8-297f-4768-b71b-c3284d52a2d7"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                    { new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), "Description Team 4", new Guid("8c53471f-0657-4807-8e34-d75b5610604c"), "Team 4", new Guid("f2691a5c-d20a-47f0-be8e-7bff05dd57af"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                    { new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5"), "Description Team 17", new Guid("8c53471f-0657-4807-8e34-d75b5610604c"), "Team 17", new Guid("18ec3da8-297f-4768-b71b-c3284d52a2d7"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Courts", "Date", "Description", "EntryDeadline", "LocationId", "MaxTeamsPerLevel", "Name", "Organizer", "PictureLink", "PriceType", "RegistrationPolicy", "TeamPolicy", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 5, 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), "[9,7]", "Műegyetemi röplabda torna A9 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 2 },
                    { new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 5, 3, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), "[10,7]", "Műegyetemi röplabda torna A10 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 1 },
                    { new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 2, 2, new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2187), "Description Tournament 1", new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2201), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), "[8]", "Fanatics 8 csapat körbejátszás", "Organizer 1", "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg", 16, "Registration Policy 1", "Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 0 }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "MatchState", "Points", "RefereeId", "StartTime", "TournamentId", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("040d6478-b0ff-4dfb-8f55-28beea402d44"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(715), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("041f2f9d-ad11-419c-a398-54c3879e4c6e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("0515deae-29f6-48eb-a779-025c12246522"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("087032e0-0529-46d5-aff3-3d38fafe5376"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("0a055cad-3e87-47e3-b06b-3d9ef1a9f22c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("0dbed4e0-e487-4ee5-8774-7943b4da55ab"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(639), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("0dd9182d-ce92-43af-901a-e4500ceed0f0"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(670), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("10bb79f8-8aff-4f4b-a783-8d414e4225f2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("11fb6c9f-5df9-425a-97f6-079ae10d9264"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("14331325-228c-4cb6-bb0b-0db96fc6b886"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("1495b5b1-7bb8-47a8-8903-0fefacae7a51"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("14e5f47f-ab1c-4082-b874-975b3fd31593"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("1706e71f-7e56-469e-979b-bf1344076eb6"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("1832dd42-a868-4be2-b0f5-eeaf155d7318"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("191d1bc7-38ad-43f7-9d5e-ac44e53cc128"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("1c28a18c-e1d4-4147-8248-b5d1af4e7e73"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("1c56ba37-9439-40df-8e62-3018cb3fbafa"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("200bd589-12b9-4f8e-bc6a-55abe9f1d05b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("21d04697-e114-40a4-9a8f-9604a33b17e5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("246e96e3-cba4-4003-bca8-2d2a21231836"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("271da954-e39f-4fa6-a2a4-26f421b428aa"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("280a95e1-253e-47eb-812b-9918286d4b2d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("29064e9d-e2d1-4920-b435-5f96cd7aeae1"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("2911c43b-177e-41f1-bf4d-73fd9cc9219e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("2912d3d1-beb5-4624-a14c-7e5de2e150cf"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("29d0316e-c24f-420a-9b83-40d0aeca98a8"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("2a593b5d-343b-4259-85a5-2e6fc129db43"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("2ba7df3f-55bc-433f-8682-c02850e1b9fd"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("2d388b50-4775-41ba-815f-5998fff85f93"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("30bd6d21-062b-4680-95ef-1921e8bc5c2b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("30e45e08-c25d-46c0-a803-4a4bec19b97a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("318d068b-561f-4616-bb55-2219f48fef7e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("32820491-1db1-4d7b-9cb2-5cee132e5b99"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("3424fa2b-cb29-410b-970d-de639e7db2f2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("35fa6b66-b98f-4bde-9b21-45f6a061bb91"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("3762132b-9792-4c5f-8808-82ea856b3690"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("37ee5aef-c855-4055-b449-3d012ad2ff25"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(701), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("37f6ae88-2bcc-444d-ad70-7f2792f8c287"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("39f3a278-7a90-43bf-bb56-3fe9b9d44015"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("3def829e-bf33-4f64-94db-43171c52b5cf"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("404a69cd-1f41-40d6-8065-a226fc8f6055"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("4528f6c8-df37-45bc-bacb-8acd9fc7cb3c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("453355a0-60c9-46a7-bf13-fb3cb759b407"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("4b105255-e054-4e66-ad99-68f848deeb94"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("4b4a9603-bdd9-4e6f-9a82-d9fdccbeba98"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("4ccb0670-5bdc-4911-b735-dcb3f3dc1e09"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("523f74a5-4e49-48d1-ae6e-d2d612c60d56"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("52bd72af-bf3e-4cf3-aac4-b76378cea492"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("5600801d-4b25-46d1-b1ec-6e967d623cf1"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("56a24455-50fa-4936-9cf8-715592ebb1fa"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("5a682787-85b1-4796-bb8c-60554eb97cd2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("619c1c40-f1d0-4e1b-bc24-1857c2cddcc6"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("62224d43-b06d-4206-a24d-3f5cd7245c99"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("64ff23a5-b5eb-469a-91ef-a3cabd1830a2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("65171aa8-27ce-4b00-b5f8-72667308de65"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("653af34a-ca79-4fd7-a0f1-f68c3cba9b43"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("653d6454-32ff-4dfe-8a8a-da9169e886da"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("65d45ffe-95ae-4ffa-91c5-fcda596f99eb"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("6bd923b6-9609-429c-9588-a467ed92eb5b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("6e1d97e6-d0f7-40c4-a9b1-258918550c55"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("6e8fa6e6-fbbb-4159-a7b4-4b2f01ed7dde"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("71209ee6-3aa0-45a2-8dcf-9c76142e06c8"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("72a7ffd1-2259-40b7-917c-3ad15e5d3632"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("737fc88f-8138-425d-993a-2dd4dd7bece0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("748f056e-747a-4c2b-960a-535a1be9ba79"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(720), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("75cf07f3-feed-44e4-82c6-b9bce39e9746"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("7702bb54-2223-45bb-ab43-055d1e6a3d46"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("77cc8fad-79a4-4e45-833c-4f307f0b9cb1"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("7ec4d54d-1c80-4d22-9134-367551f2e047"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("80809aaa-43c0-4f9d-8909-8a66dcea3867"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("81d336d0-5b36-42d8-a6c1-4ab2ebef4142"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(725), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("825784a2-de31-4320-a589-6e432bba2916"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("86904a0c-ebcf-4102-a5cf-de9e172b8389"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("87fb608b-4116-4aa6-84ba-0dc5029bafcc"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(686), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("8c07c533-d722-4c42-8da5-0f6d98ce557b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("8dbda88a-703c-487b-acbd-9f7d42c19219"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("8fa31a26-e7d3-410d-9e07-540e2e06ccdf"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(618), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("912a6640-0cd4-420d-9ff7-6f56bbb2190c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("92228221-ff4c-4f57-b97d-5f200c913f78"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("926b67dc-d93d-43a0-80fe-19cced13ebab"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("9496d5bd-0edc-4b10-9c1c-fc89e7cad2b4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("961cde8b-d151-428f-925f-5c63410d57c4"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(706), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("9716fad3-d43e-419f-970d-46d8213737c7"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("98fbc1cf-fb3f-4a90-bfe7-80d2c382c4ef"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("99faeb74-74c1-4313-bf8e-ab854b7e05e6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("9c2788e8-7693-4e7c-844f-0f541170936c"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(600), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("9c57bad9-7629-4035-bb39-0b607f6ccecb"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("9d7776c7-b5cd-4aaa-a14a-11553832b097"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(665), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("9ee60b93-835e-452d-816b-71d14c6c7505"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(613), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("a1e62844-77db-4340-99b7-1feb5faaa729"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("a1f62bcb-e4db-48be-8ada-0015c0d77411"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(644), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("a2f07b50-6559-4c79-b7be-2729a93fefee"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("a9e0289f-b932-4d08-94bf-412dbb4cace5"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(710), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("ac3d28a8-3874-422c-8c87-95150f5df937"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(533), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("af04e935-ac12-43c7-8471-f6bd44813d27"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("aff301eb-7b27-4286-b8b9-cafaf7b9d19e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("b56ca95c-dfdb-4fab-9d2a-1435773a6fe3"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("b6891940-62cf-4d63-8da7-3a7d297bef7a"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("b7514295-7707-4332-88cd-006e01abf29f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("b9a092cb-e332-4e83-8c0a-d73c2c627c25"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("bab3593d-ff36-4eb1-89c1-ec5e022aabb7"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("bbdb04f5-1311-45e0-af3b-ce2afee691d0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("bc1c5237-312d-41a0-95b9-f961726ef9fa"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(634), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("c1f6307c-afa7-489e-8c0d-360301f91db4"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(461), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("c21c8fa8-7a39-456e-b5d6-3d601f6d0618"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("c2322338-bb7d-4630-9678-7de3e5f9f0c5"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(676), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("c2abb754-967a-4bf5-9eae-4949916b485e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("c3059782-9285-4aa0-b4ea-ea8872abb1a7"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("c3949186-e248-4fef-9360-55d033545cb4"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("c53e96eb-5c2c-48aa-abfd-eab5ebfbaf66"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("c5b9be0a-a2b4-4ae1-94dd-372d591a5e6d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("c67f5dc3-53fc-4acf-975c-e457ea4ffeec"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("c82c1618-8493-4399-86d4-9a0af9747b4a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("cb50ad3d-db83-4b87-a8c5-74f67b311764"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(607), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("cb9689a2-38f4-45b2-892e-a8794e9453f2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("cd126c25-d069-49ed-a082-ae694ab54058"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(649), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("cff247f5-d3c3-458d-99e7-7b874d58b7e7"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(696), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("d3916fff-ffd4-4d54-9f5d-97bc55d1127c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("d3a7cedc-19b3-4be9-a186-5fdafa440381"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("d46d3e2b-1c72-4bb9-b762-fa4eb3b6c529"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("d5b7931f-7ed2-4305-bd28-b047cce85d42"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("d5e5bbe4-8610-4f1a-a948-d428e741947e"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(628), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("d6f22897-e1f5-4dd3-860d-d7d21413a594"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("d7b39ba8-c63c-4395-ae6c-5dbc972a4137"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("daadcdbe-c0d2-4f15-96fa-6e28dd2f2ee0"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("de6a3a3c-83d7-423d-b100-9c3a9d153538"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("deb8d2a2-a0c9-4f9e-8ba3-93ef37f94625"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("df615237-f397-41bf-ab23-a3f56a0ee91d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("e1d44d4d-efc0-48ef-9c55-c046952a74db"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("e43a0809-c686-425a-95bf-fe290261881b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("e5f4b6f9-c9cf-451b-9876-687916ac4d68"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("e7b435ec-374f-48f8-9683-1c9f317200ba"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(681), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("e800feb4-61bd-466d-9f31-7a96a43302fa"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("e8301ac5-c861-4405-b0db-ed17e6e5d4fe"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("e9e176e6-1133-48bc-9824-2b10485d9cab"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("ecf99370-b9e9-4aef-831c-ece0e316a473"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("eebf8334-8ee4-4b19-a1bd-396f03ad8cba"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("f0653248-5cc2-47df-ab9d-d9ba5929612b"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(660), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("f095c73b-dd12-4b72-8b57-48302dd2d7b4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("f2f4dafa-71c5-4b96-98f6-9b4ff4298584"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("f347635c-9050-4183-9ad4-fe2fa34bd4ee"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("f3b62885-1f32-445e-9ab7-a06fa894e92b"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(539), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("f3e1c5bb-7253-4718-8696-d17f1887a48f"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(691), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("f42febb9-bcc9-4209-aa93-2178f1f09180"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(623), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("f55d841c-79ef-40b1-97f0-50d221a5fb75"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("f8a9b523-052b-4ed5-b448-46ae6ba5e3e6"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("f94c5f17-9264-484b-a139-0519415cf61e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), 0, "[0,0]", new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07"), 2 },
                    { new Guid("f94dd2ca-6d82-4793-b56d-79ca9f35824d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("f953bc21-f610-46ad-ba3b-874eb78bc18e"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(655), new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), 0, "[0,0]", new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f"), 0 },
                    { new Guid("fb913695-aacd-4a0e-90a9-ff3434479c15"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 },
                    { new Guid("fbf88c07-e312-4740-8a0d-d4d8b7775849"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), 0, "[0,0]", new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9"), 1 }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new Guid("957e04e0-6aa5-4a03-80c0-caa99250a185") },
                    { new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), new Guid("45018993-26ed-4a7a-87bf-5283db8cd4c3") },
                    { new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new Guid("18ec3da8-297f-4768-b71b-c3284d52a2d7") },
                    { new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new Guid("9646954a-99d1-4bd3-81d3-de9d4776f180") },
                    { new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new Guid("9320fbf0-ff80-4984-b2ad-068528274d84") },
                    { new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), new Guid("f2691a5c-d20a-47f0-be8e-7bff05dd57af") },
                    { new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec") },
                    { new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec") },
                    { new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), new Guid("6019e025-20f9-4228-9b08-37f95b0ff681") },
                    { new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new Guid("6019e025-20f9-4228-9b08-37f95b0ff681") },
                    { new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new Guid("f2691a5c-d20a-47f0-be8e-7bff05dd57af") },
                    { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec") },
                    { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new Guid("bae54f12-e64c-44c2-9834-742cbfcad9c5") },
                    { new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), new Guid("bae54f12-e64c-44c2-9834-742cbfcad9c5") },
                    { new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), new Guid("957e04e0-6aa5-4a03-80c0-caa99250a185") },
                    { new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new Guid("5b7e521f-58cf-4167-94fb-6d4bfa5d7833") },
                    { new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new Guid("45018993-26ed-4a7a-87bf-5283db8cd4c3") },
                    { new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5"), new Guid("45018993-26ed-4a7a-87bf-5283db8cd4c3") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new Guid("bae54f12-e64c-44c2-9834-742cbfcad9c5") },
                    { new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new Guid("f2691a5c-d20a-47f0-be8e-7bff05dd57af") },
                    { new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new Guid("18ec3da8-297f-4768-b71b-c3284d52a2d7") },
                    { new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new Guid("9320fbf0-ff80-4984-b2ad-068528274d84") },
                    { new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new Guid("9646954a-99d1-4bd3-81d3-de9d4776f180") },
                    { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec") },
                    { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new Guid("45018993-26ed-4a7a-87bf-5283db8cd4c3") },
                    { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new Guid("6019e025-20f9-4228-9b08-37f95b0ff681") },
                    { new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new Guid("5b7e521f-58cf-4167-94fb-6d4bfa5d7833") },
                    { new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new Guid("957e04e0-6aa5-4a03-80c0-caa99250a185") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5"), new Guid("174d9284-f9a9-4cd9-83e8-0739d0774a07") },
                    { new Guid("0dd66842-4004-458a-a506-d870a016ee9f"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("735fb81e-e028-4377-892a-37a88e22d65d"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("e03e462a-0006-4a36-9110-3d5604d593c1"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5"), new Guid("21bef195-5bf3-4d32-b1cc-a55c8a2381a9") },
                    { new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019"), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f") },
                    { new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af"), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f") },
                    { new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65"), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f") },
                    { new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7"), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f") },
                    { new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715"), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f") },
                    { new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a"), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f") },
                    { new Guid("e29cab41-09a6-4781-9671-cbc8f793d962"), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f") },
                    { new Guid("e594c6d0-36de-41a6-93b5-d6322e134401"), new Guid("da5419e2-498f-47ea-9e5a-ead65d949d5f") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "CoachId", "Date", "Description", "LocationId", "PictureLink", "PriceType", "TeamId" },
                values: new object[,]
                {
                    { new Guid("18835bf9-a7f6-41fc-a200-615bb582199b"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2355), "Training7", new Guid("8f6dc86c-1609-406e-b5fb-85c96d80d18b"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg", 5, new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("2202b5de-f7a0-40cc-9bda-b7885dd8eb66"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2343), "Training4", new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg", 5, new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("3a32b026-f1ca-4176-be3d-06dc68116121"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2334), "Training2", new Guid("d6b1720e-c3f5-446b-ac42-381f0e8fc1a9"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg", 5, new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("472003dc-db41-4480-9fae-02d3e8f08fb6"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2359), "Training8", new Guid("d107f422-837c-4cbc-9125-8db679ad272c"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg", 5, new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("4f84ce9b-70a7-4ffb-b9fa-34712136caf4"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2327), "Training1", new Guid("971b5629-d9ef-4d39-845c-96a0279c8e5d"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg", 5, new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("567524ff-767b-4887-ad3f-ad39550ff808"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2347), "Training5", new Guid("cde6ea9d-0a00-4a6e-9a5a-64e44813237e"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg", 5, new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("7c804af8-7c4d-46ae-8ee4-0271a57b3f3e"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2351), "Training6", new Guid("b65847a4-d57f-4dff-8fc8-120beeb837c9"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg", 5, new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("84c338c3-f2f8-4404-8530-663bda9d435b"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2363), "Training9", new Guid("3def4b5d-1f65-4b9e-bee1-536007548830"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg", 5, new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("e460ed09-d58a-4b5b-853f-b55a8053be7a"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2406), "Training10", new Guid("34105bc4-49c8-46c1-b7d4-ee5b6474a65d"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg", 5, new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("fa2ecf8c-8af5-454d-9fba-9dd65ce45909"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec"), new DateTime(2025, 5, 24, 13, 6, 14, 436, DateTimeKind.Local).AddTicks(2338), "Training3", new Guid("103d4e59-1c8d-4306-88cf-d74fa67287e9"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg", 5, new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("4f84ce9b-70a7-4ffb-b9fa-34712136caf4"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("040d6478-b0ff-4dfb-8f55-28beea402d44"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("040d6478-b0ff-4dfb-8f55-28beea402d44"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("041f2f9d-ad11-419c-a398-54c3879e4c6e"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("041f2f9d-ad11-419c-a398-54c3879e4c6e"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("0515deae-29f6-48eb-a779-025c12246522"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("0515deae-29f6-48eb-a779-025c12246522"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("087032e0-0529-46d5-aff3-3d38fafe5376"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("087032e0-0529-46d5-aff3-3d38fafe5376"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("0a055cad-3e87-47e3-b06b-3d9ef1a9f22c"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("0a055cad-3e87-47e3-b06b-3d9ef1a9f22c"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("0dbed4e0-e487-4ee5-8774-7943b4da55ab"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("0dbed4e0-e487-4ee5-8774-7943b4da55ab"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("0dd9182d-ce92-43af-901a-e4500ceed0f0"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("0dd9182d-ce92-43af-901a-e4500ceed0f0"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("10bb79f8-8aff-4f4b-a783-8d414e4225f2"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("10bb79f8-8aff-4f4b-a783-8d414e4225f2"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("11fb6c9f-5df9-425a-97f6-079ae10d9264"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("11fb6c9f-5df9-425a-97f6-079ae10d9264"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("14331325-228c-4cb6-bb0b-0db96fc6b886"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("14331325-228c-4cb6-bb0b-0db96fc6b886"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("1495b5b1-7bb8-47a8-8903-0fefacae7a51"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("1495b5b1-7bb8-47a8-8903-0fefacae7a51"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("14e5f47f-ab1c-4082-b874-975b3fd31593"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("14e5f47f-ab1c-4082-b874-975b3fd31593"), new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5") },
                    { new Guid("1706e71f-7e56-469e-979b-bf1344076eb6"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("1706e71f-7e56-469e-979b-bf1344076eb6"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("1832dd42-a868-4be2-b0f5-eeaf155d7318"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("1832dd42-a868-4be2-b0f5-eeaf155d7318"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("191d1bc7-38ad-43f7-9d5e-ac44e53cc128"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("191d1bc7-38ad-43f7-9d5e-ac44e53cc128"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("1c28a18c-e1d4-4147-8248-b5d1af4e7e73"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("1c28a18c-e1d4-4147-8248-b5d1af4e7e73"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("1c56ba37-9439-40df-8e62-3018cb3fbafa"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("1c56ba37-9439-40df-8e62-3018cb3fbafa"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("200bd589-12b9-4f8e-bc6a-55abe9f1d05b"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("200bd589-12b9-4f8e-bc6a-55abe9f1d05b"), new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5") },
                    { new Guid("21d04697-e114-40a4-9a8f-9604a33b17e5"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("21d04697-e114-40a4-9a8f-9604a33b17e5"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("246e96e3-cba4-4003-bca8-2d2a21231836"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("246e96e3-cba4-4003-bca8-2d2a21231836"), new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5") },
                    { new Guid("271da954-e39f-4fa6-a2a4-26f421b428aa"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("271da954-e39f-4fa6-a2a4-26f421b428aa"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("280a95e1-253e-47eb-812b-9918286d4b2d"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("280a95e1-253e-47eb-812b-9918286d4b2d"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("29064e9d-e2d1-4920-b435-5f96cd7aeae1"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("29064e9d-e2d1-4920-b435-5f96cd7aeae1"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("2911c43b-177e-41f1-bf4d-73fd9cc9219e"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("2911c43b-177e-41f1-bf4d-73fd9cc9219e"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("2912d3d1-beb5-4624-a14c-7e5de2e150cf"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("2912d3d1-beb5-4624-a14c-7e5de2e150cf"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("29d0316e-c24f-420a-9b83-40d0aeca98a8"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("29d0316e-c24f-420a-9b83-40d0aeca98a8"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("2a593b5d-343b-4259-85a5-2e6fc129db43"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("2a593b5d-343b-4259-85a5-2e6fc129db43"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("2ba7df3f-55bc-433f-8682-c02850e1b9fd"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("2ba7df3f-55bc-433f-8682-c02850e1b9fd"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("2d388b50-4775-41ba-815f-5998fff85f93"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("2d388b50-4775-41ba-815f-5998fff85f93"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("30bd6d21-062b-4680-95ef-1921e8bc5c2b"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("30bd6d21-062b-4680-95ef-1921e8bc5c2b"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("30e45e08-c25d-46c0-a803-4a4bec19b97a"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("30e45e08-c25d-46c0-a803-4a4bec19b97a"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("318d068b-561f-4616-bb55-2219f48fef7e"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("318d068b-561f-4616-bb55-2219f48fef7e"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("32820491-1db1-4d7b-9cb2-5cee132e5b99"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("32820491-1db1-4d7b-9cb2-5cee132e5b99"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("3424fa2b-cb29-410b-970d-de639e7db2f2"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("3424fa2b-cb29-410b-970d-de639e7db2f2"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("35fa6b66-b98f-4bde-9b21-45f6a061bb91"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("35fa6b66-b98f-4bde-9b21-45f6a061bb91"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("3762132b-9792-4c5f-8808-82ea856b3690"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("3762132b-9792-4c5f-8808-82ea856b3690"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("37ee5aef-c855-4055-b449-3d012ad2ff25"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("37ee5aef-c855-4055-b449-3d012ad2ff25"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("37f6ae88-2bcc-444d-ad70-7f2792f8c287"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("37f6ae88-2bcc-444d-ad70-7f2792f8c287"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("39f3a278-7a90-43bf-bb56-3fe9b9d44015"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("39f3a278-7a90-43bf-bb56-3fe9b9d44015"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("3def829e-bf33-4f64-94db-43171c52b5cf"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("3def829e-bf33-4f64-94db-43171c52b5cf"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("404a69cd-1f41-40d6-8065-a226fc8f6055"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("404a69cd-1f41-40d6-8065-a226fc8f6055"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("4528f6c8-df37-45bc-bacb-8acd9fc7cb3c"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("4528f6c8-df37-45bc-bacb-8acd9fc7cb3c"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("453355a0-60c9-46a7-bf13-fb3cb759b407"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("453355a0-60c9-46a7-bf13-fb3cb759b407"), new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5") },
                    { new Guid("4b105255-e054-4e66-ad99-68f848deeb94"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("4b105255-e054-4e66-ad99-68f848deeb94"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("4b4a9603-bdd9-4e6f-9a82-d9fdccbeba98"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("4b4a9603-bdd9-4e6f-9a82-d9fdccbeba98"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("4ccb0670-5bdc-4911-b735-dcb3f3dc1e09"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("4ccb0670-5bdc-4911-b735-dcb3f3dc1e09"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("523f74a5-4e49-48d1-ae6e-d2d612c60d56"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("523f74a5-4e49-48d1-ae6e-d2d612c60d56"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("52bd72af-bf3e-4cf3-aac4-b76378cea492"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("52bd72af-bf3e-4cf3-aac4-b76378cea492"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("5600801d-4b25-46d1-b1ec-6e967d623cf1"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("5600801d-4b25-46d1-b1ec-6e967d623cf1"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("56a24455-50fa-4936-9cf8-715592ebb1fa"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("56a24455-50fa-4936-9cf8-715592ebb1fa"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("5a682787-85b1-4796-bb8c-60554eb97cd2"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("5a682787-85b1-4796-bb8c-60554eb97cd2"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("619c1c40-f1d0-4e1b-bc24-1857c2cddcc6"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("619c1c40-f1d0-4e1b-bc24-1857c2cddcc6"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("62224d43-b06d-4206-a24d-3f5cd7245c99"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("62224d43-b06d-4206-a24d-3f5cd7245c99"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("64ff23a5-b5eb-469a-91ef-a3cabd1830a2"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("64ff23a5-b5eb-469a-91ef-a3cabd1830a2"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("65171aa8-27ce-4b00-b5f8-72667308de65"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("65171aa8-27ce-4b00-b5f8-72667308de65"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("653af34a-ca79-4fd7-a0f1-f68c3cba9b43"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("653af34a-ca79-4fd7-a0f1-f68c3cba9b43"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("653d6454-32ff-4dfe-8a8a-da9169e886da"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("653d6454-32ff-4dfe-8a8a-da9169e886da"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("65d45ffe-95ae-4ffa-91c5-fcda596f99eb"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("65d45ffe-95ae-4ffa-91c5-fcda596f99eb"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("6bd923b6-9609-429c-9588-a467ed92eb5b"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("6bd923b6-9609-429c-9588-a467ed92eb5b"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("6e1d97e6-d0f7-40c4-a9b1-258918550c55"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("6e1d97e6-d0f7-40c4-a9b1-258918550c55"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("6e8fa6e6-fbbb-4159-a7b4-4b2f01ed7dde"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("6e8fa6e6-fbbb-4159-a7b4-4b2f01ed7dde"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("71209ee6-3aa0-45a2-8dcf-9c76142e06c8"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("71209ee6-3aa0-45a2-8dcf-9c76142e06c8"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("72a7ffd1-2259-40b7-917c-3ad15e5d3632"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("72a7ffd1-2259-40b7-917c-3ad15e5d3632"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("737fc88f-8138-425d-993a-2dd4dd7bece0"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("737fc88f-8138-425d-993a-2dd4dd7bece0"), new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5") },
                    { new Guid("748f056e-747a-4c2b-960a-535a1be9ba79"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("748f056e-747a-4c2b-960a-535a1be9ba79"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("75cf07f3-feed-44e4-82c6-b9bce39e9746"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("75cf07f3-feed-44e4-82c6-b9bce39e9746"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("7702bb54-2223-45bb-ab43-055d1e6a3d46"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("7702bb54-2223-45bb-ab43-055d1e6a3d46"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("77cc8fad-79a4-4e45-833c-4f307f0b9cb1"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("77cc8fad-79a4-4e45-833c-4f307f0b9cb1"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("7ec4d54d-1c80-4d22-9134-367551f2e047"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("7ec4d54d-1c80-4d22-9134-367551f2e047"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("80809aaa-43c0-4f9d-8909-8a66dcea3867"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("80809aaa-43c0-4f9d-8909-8a66dcea3867"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("81d336d0-5b36-42d8-a6c1-4ab2ebef4142"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("81d336d0-5b36-42d8-a6c1-4ab2ebef4142"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("825784a2-de31-4320-a589-6e432bba2916"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("825784a2-de31-4320-a589-6e432bba2916"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("86904a0c-ebcf-4102-a5cf-de9e172b8389"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("86904a0c-ebcf-4102-a5cf-de9e172b8389"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("87fb608b-4116-4aa6-84ba-0dc5029bafcc"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("87fb608b-4116-4aa6-84ba-0dc5029bafcc"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("8c07c533-d722-4c42-8da5-0f6d98ce557b"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("8c07c533-d722-4c42-8da5-0f6d98ce557b"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("8dbda88a-703c-487b-acbd-9f7d42c19219"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("8dbda88a-703c-487b-acbd-9f7d42c19219"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("8fa31a26-e7d3-410d-9e07-540e2e06ccdf"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("8fa31a26-e7d3-410d-9e07-540e2e06ccdf"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("912a6640-0cd4-420d-9ff7-6f56bbb2190c"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("912a6640-0cd4-420d-9ff7-6f56bbb2190c"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("92228221-ff4c-4f57-b97d-5f200c913f78"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("92228221-ff4c-4f57-b97d-5f200c913f78"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("926b67dc-d93d-43a0-80fe-19cced13ebab"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("926b67dc-d93d-43a0-80fe-19cced13ebab"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("9496d5bd-0edc-4b10-9c1c-fc89e7cad2b4"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("9496d5bd-0edc-4b10-9c1c-fc89e7cad2b4"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("961cde8b-d151-428f-925f-5c63410d57c4"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("961cde8b-d151-428f-925f-5c63410d57c4"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("9716fad3-d43e-419f-970d-46d8213737c7"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("9716fad3-d43e-419f-970d-46d8213737c7"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("98fbc1cf-fb3f-4a90-bfe7-80d2c382c4ef"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("98fbc1cf-fb3f-4a90-bfe7-80d2c382c4ef"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("99faeb74-74c1-4313-bf8e-ab854b7e05e6"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("99faeb74-74c1-4313-bf8e-ab854b7e05e6"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("9c2788e8-7693-4e7c-844f-0f541170936c"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("9c2788e8-7693-4e7c-844f-0f541170936c"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("9c57bad9-7629-4035-bb39-0b607f6ccecb"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("9c57bad9-7629-4035-bb39-0b607f6ccecb"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("9d7776c7-b5cd-4aaa-a14a-11553832b097"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("9d7776c7-b5cd-4aaa-a14a-11553832b097"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("9ee60b93-835e-452d-816b-71d14c6c7505"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("9ee60b93-835e-452d-816b-71d14c6c7505"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("a1e62844-77db-4340-99b7-1feb5faaa729"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("a1e62844-77db-4340-99b7-1feb5faaa729"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("a1f62bcb-e4db-48be-8ada-0015c0d77411"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("a1f62bcb-e4db-48be-8ada-0015c0d77411"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("a2f07b50-6559-4c79-b7be-2729a93fefee"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("a2f07b50-6559-4c79-b7be-2729a93fefee"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("a9e0289f-b932-4d08-94bf-412dbb4cace5"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("a9e0289f-b932-4d08-94bf-412dbb4cace5"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("ac3d28a8-3874-422c-8c87-95150f5df937"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("ac3d28a8-3874-422c-8c87-95150f5df937"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("af04e935-ac12-43c7-8471-f6bd44813d27"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("af04e935-ac12-43c7-8471-f6bd44813d27"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("aff301eb-7b27-4286-b8b9-cafaf7b9d19e"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("aff301eb-7b27-4286-b8b9-cafaf7b9d19e"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("b56ca95c-dfdb-4fab-9d2a-1435773a6fe3"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("b56ca95c-dfdb-4fab-9d2a-1435773a6fe3"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("b6891940-62cf-4d63-8da7-3a7d297bef7a"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("b6891940-62cf-4d63-8da7-3a7d297bef7a"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("b7514295-7707-4332-88cd-006e01abf29f"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("b7514295-7707-4332-88cd-006e01abf29f"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("b9a092cb-e332-4e83-8c0a-d73c2c627c25"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("b9a092cb-e332-4e83-8c0a-d73c2c627c25"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("bab3593d-ff36-4eb1-89c1-ec5e022aabb7"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("bab3593d-ff36-4eb1-89c1-ec5e022aabb7"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("bbdb04f5-1311-45e0-af3b-ce2afee691d0"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("bbdb04f5-1311-45e0-af3b-ce2afee691d0"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("bc1c5237-312d-41a0-95b9-f961726ef9fa"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("bc1c5237-312d-41a0-95b9-f961726ef9fa"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("c1f6307c-afa7-489e-8c0d-360301f91db4"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("c1f6307c-afa7-489e-8c0d-360301f91db4"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("c21c8fa8-7a39-456e-b5d6-3d601f6d0618"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("c21c8fa8-7a39-456e-b5d6-3d601f6d0618"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("c2322338-bb7d-4630-9678-7de3e5f9f0c5"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("c2322338-bb7d-4630-9678-7de3e5f9f0c5"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("c2abb754-967a-4bf5-9eae-4949916b485e"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("c2abb754-967a-4bf5-9eae-4949916b485e"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("c3059782-9285-4aa0-b4ea-ea8872abb1a7"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("c3059782-9285-4aa0-b4ea-ea8872abb1a7"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("c3949186-e248-4fef-9360-55d033545cb4"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("c3949186-e248-4fef-9360-55d033545cb4"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("c53e96eb-5c2c-48aa-abfd-eab5ebfbaf66"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("c53e96eb-5c2c-48aa-abfd-eab5ebfbaf66"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("c5b9be0a-a2b4-4ae1-94dd-372d591a5e6d"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("c5b9be0a-a2b4-4ae1-94dd-372d591a5e6d"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("c67f5dc3-53fc-4acf-975c-e457ea4ffeec"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("c67f5dc3-53fc-4acf-975c-e457ea4ffeec"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("c82c1618-8493-4399-86d4-9a0af9747b4a"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("c82c1618-8493-4399-86d4-9a0af9747b4a"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("cb50ad3d-db83-4b87-a8c5-74f67b311764"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("cb50ad3d-db83-4b87-a8c5-74f67b311764"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("cb9689a2-38f4-45b2-892e-a8794e9453f2"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("cb9689a2-38f4-45b2-892e-a8794e9453f2"), new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5") },
                    { new Guid("cd126c25-d069-49ed-a082-ae694ab54058"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("cd126c25-d069-49ed-a082-ae694ab54058"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("cff247f5-d3c3-458d-99e7-7b874d58b7e7"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("cff247f5-d3c3-458d-99e7-7b874d58b7e7"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("d3916fff-ffd4-4d54-9f5d-97bc55d1127c"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("d3916fff-ffd4-4d54-9f5d-97bc55d1127c"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("d3a7cedc-19b3-4be9-a186-5fdafa440381"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("d3a7cedc-19b3-4be9-a186-5fdafa440381"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("d46d3e2b-1c72-4bb9-b762-fa4eb3b6c529"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("d46d3e2b-1c72-4bb9-b762-fa4eb3b6c529"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("d5b7931f-7ed2-4305-bd28-b047cce85d42"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("d5b7931f-7ed2-4305-bd28-b047cce85d42"), new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5") },
                    { new Guid("d5e5bbe4-8610-4f1a-a948-d428e741947e"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("d5e5bbe4-8610-4f1a-a948-d428e741947e"), new Guid("8dad2fe2-b35e-4a1b-a15d-5b6629cd0715") },
                    { new Guid("d6f22897-e1f5-4dd3-860d-d7d21413a594"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("d6f22897-e1f5-4dd3-860d-d7d21413a594"), new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5") },
                    { new Guid("d7b39ba8-c63c-4395-ae6c-5dbc972a4137"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("d7b39ba8-c63c-4395-ae6c-5dbc972a4137"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("daadcdbe-c0d2-4f15-96fa-6e28dd2f2ee0"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("daadcdbe-c0d2-4f15-96fa-6e28dd2f2ee0"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("de6a3a3c-83d7-423d-b100-9c3a9d153538"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("de6a3a3c-83d7-423d-b100-9c3a9d153538"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("deb8d2a2-a0c9-4f9e-8ba3-93ef37f94625"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("deb8d2a2-a0c9-4f9e-8ba3-93ef37f94625"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("df615237-f397-41bf-ab23-a3f56a0ee91d"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("df615237-f397-41bf-ab23-a3f56a0ee91d"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("e1d44d4d-efc0-48ef-9c55-c046952a74db"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("e1d44d4d-efc0-48ef-9c55-c046952a74db"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("e43a0809-c686-425a-95bf-fe290261881b"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("e43a0809-c686-425a-95bf-fe290261881b"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("e5f4b6f9-c9cf-451b-9876-687916ac4d68"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("e5f4b6f9-c9cf-451b-9876-687916ac4d68"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("e7b435ec-374f-48f8-9683-1c9f317200ba"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("e7b435ec-374f-48f8-9683-1c9f317200ba"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("e800feb4-61bd-466d-9f31-7a96a43302fa"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("e800feb4-61bd-466d-9f31-7a96a43302fa"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("e8301ac5-c861-4405-b0db-ed17e6e5d4fe"), new Guid("0dd66842-4004-458a-a506-d870a016ee9f") },
                    { new Guid("e8301ac5-c861-4405-b0db-ed17e6e5d4fe"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("e9e176e6-1133-48bc-9824-2b10485d9cab"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("e9e176e6-1133-48bc-9824-2b10485d9cab"), new Guid("ea93bfb2-1c7e-447f-bd8b-247dea0a4cd5") },
                    { new Guid("ecf99370-b9e9-4aef-831c-ece0e316a473"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("ecf99370-b9e9-4aef-831c-ece0e316a473"), new Guid("e03e462a-0006-4a36-9110-3d5604d593c1") },
                    { new Guid("eebf8334-8ee4-4b19-a1bd-396f03ad8cba"), new Guid("56d393b2-e51e-40ea-a8ff-9fe5b9dbdf9a") },
                    { new Guid("eebf8334-8ee4-4b19-a1bd-396f03ad8cba"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") },
                    { new Guid("f0653248-5cc2-47df-ab9d-d9ba5929612b"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("f0653248-5cc2-47df-ab9d-d9ba5929612b"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("f095c73b-dd12-4b72-8b57-48302dd2d7b4"), new Guid("1d708dae-5af6-41fb-8dc1-fb7ee3fe159b") },
                    { new Guid("f095c73b-dd12-4b72-8b57-48302dd2d7b4"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("f2f4dafa-71c5-4b96-98f6-9b4ff4298584"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("f2f4dafa-71c5-4b96-98f6-9b4ff4298584"), new Guid("6b7ad148-6a38-4156-880d-bb69b7f1466a") },
                    { new Guid("f347635c-9050-4183-9ad4-fe2fa34bd4ee"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("f347635c-9050-4183-9ad4-fe2fa34bd4ee"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("f3b62885-1f32-445e-9ab7-a06fa894e92b"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("f3b62885-1f32-445e-9ab7-a06fa894e92b"), new Guid("4672a2ff-e676-4a12-9b29-ed5a8d59fa65") },
                    { new Guid("f3e1c5bb-7253-4718-8696-d17f1887a48f"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("f3e1c5bb-7253-4718-8696-d17f1887a48f"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("f42febb9-bcc9-4209-aa93-2178f1f09180"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("f42febb9-bcc9-4209-aa93-2178f1f09180"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("f55d841c-79ef-40b1-97f0-50d221a5fb75"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("f55d841c-79ef-40b1-97f0-50d221a5fb75"), new Guid("e594c6d0-36de-41a6-93b5-d6322e134401") },
                    { new Guid("f8a9b523-052b-4ed5-b448-46ae6ba5e3e6"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("f8a9b523-052b-4ed5-b448-46ae6ba5e3e6"), new Guid("3d274386-d2bb-4c79-8b34-b791dfe534af") },
                    { new Guid("f94c5f17-9264-484b-a139-0519415cf61e"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("f94c5f17-9264-484b-a139-0519415cf61e"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("f94dd2ca-6d82-4793-b56d-79ca9f35824d"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("f94dd2ca-6d82-4793-b56d-79ca9f35824d"), new Guid("735fb81e-e028-4377-892a-37a88e22d65d") },
                    { new Guid("f953bc21-f610-46ad-ba3b-874eb78bc18e"), new Guid("793eccd1-d33a-4279-baa6-529e8b2453a7") },
                    { new Guid("f953bc21-f610-46ad-ba3b-874eb78bc18e"), new Guid("e29cab41-09a6-4781-9671-cbc8f793d962") },
                    { new Guid("fb913695-aacd-4a0e-90a9-ff3434479c15"), new Guid("29a75b62-bc3c-4feb-ad79-9e8014d8f019") },
                    { new Guid("fb913695-aacd-4a0e-90a9-ff3434479c15"), new Guid("a8c2837e-7502-4c45-b1a0-c71b51a5e30a") },
                    { new Guid("fbf88c07-e312-4740-8a0d-d4d8b7775849"), new Guid("5876c772-af31-4dc3-a6b9-5dbd1fbaa541") },
                    { new Guid("fbf88c07-e312-4740-8a0d-d4d8b7775849"), new Guid("be5a7d62-8bb5-4229-ae55-9a92d5274c29") }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("472003dc-db41-4480-9fae-02d3e8f08fb6"), new Guid("18ec3da8-297f-4768-b71b-c3284d52a2d7") },
                    { new Guid("4f84ce9b-70a7-4ffb-b9fa-34712136caf4"), new Guid("291461c9-6113-4034-956c-1fe28d6662ec") },
                    { new Guid("567524ff-767b-4887-ad3f-ad39550ff808"), new Guid("45018993-26ed-4a7a-87bf-5283db8cd4c3") },
                    { new Guid("84c338c3-f2f8-4404-8530-663bda9d435b"), new Guid("5b7e521f-58cf-4167-94fb-6d4bfa5d7833") },
                    { new Guid("fa2ecf8c-8af5-454d-9fba-9dd65ce45909"), new Guid("6019e025-20f9-4228-9b08-37f95b0ff681") },
                    { new Guid("18835bf9-a7f6-41fc-a200-615bb582199b"), new Guid("9320fbf0-ff80-4984-b2ad-068528274d84") },
                    { new Guid("e460ed09-d58a-4b5b-853f-b55a8053be7a"), new Guid("957e04e0-6aa5-4a03-80c0-caa99250a185") },
                    { new Guid("7c804af8-7c4d-46ae-8ee4-0271a57b3f3e"), new Guid("9646954a-99d1-4bd3-81d3-de9d4776f180") },
                    { new Guid("3a32b026-f1ca-4176-be3d-06dc68116121"), new Guid("bae54f12-e64c-44c2-9834-742cbfcad9c5") },
                    { new Guid("2202b5de-f7a0-40cc-9bda-b7885dd8eb66"), new Guid("f2691a5c-d20a-47f0-be8e-7bff05dd57af") }
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
