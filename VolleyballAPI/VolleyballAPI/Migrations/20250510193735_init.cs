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
                    { new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), "1114 Budapest, Villányi út 27.", "Budai Ciszterci Szent Imre Gimnázium Tornacsarnok" },
                    { new Guid("2ca80d42-cceb-4ed3-8cb0-ae385310071c"), "Location Addr 8", "Location8" },
                    { new Guid("40ccb517-c8c6-4ee5-9e61-86247c437936"), "Location Addr 10", "Location10" },
                    { new Guid("655ee210-68da-4fe4-9a21-79378c0e8d78"), "Location Addr 5", "Location5" },
                    { new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), "Budapest, Bogdánfy u. 12, 1117", "BME Sporttelep" },
                    { new Guid("bad6c056-54d7-400f-868e-58145909d3b1"), "Location Addr 6", "Location6" },
                    { new Guid("c88b5db9-ee44-4c7e-98b4-9e12fea90b76"), "Location Addr 9", "Location9" },
                    { new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), "Budapest, Bertalan Lajos u. 4-6, 1111", "BME Sportközpont" },
                    { new Guid("d6f6b994-7c48-494a-ad19-6865d5f79799"), "Location Addr 7", "Location7" },
                    { new Guid("ef474517-beab-401b-b6b6-28fdf103a882"), "Location Addr 4", "Location4" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Gender", "Name", "Password", "Phone", "PictureLink", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("2c62db3a-df2f-430c-80e6-de05f921f67a"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5853), "user2@user.com", 1, "Aranka", "pass2", "965463", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("2c9d0183-d10a-46d4-aaef-d58fe287466f"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5871), "user8@user.com", 0, "Name 8", "pass8", "893935", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("34b6f77a-9197-4ed6-9a4a-38bd7a4ea35a"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5874), "user9@user.com", 0, "Name 9", "pass9", "2716717", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("439eeb86-ebdd-43dd-a529-2a8978f23365"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5856), "user3@user.com", 0, "Dani", "pass3", "123555", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("4cf75890-6008-43fc-aa9d-bd4b8acaa342"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5859), "user4@user.com", 0, "Kristóf", "pass4", "83568", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("5a0c9c24-2d48-4194-bca5-35257199a5ed"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5865), "user6@user.com", 0, "Péter", "pass6", "4221", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5849), "user1@user.com", 0, "Jancsi", "pass1", "34214124", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 2, 3 },
                    { new Guid("a860b901-c5b9-4fe4-b0a3-cedf4fe477a8"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5862), "user5@user.com", 0, "Lajos", "pass5", "54337", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 4, 2 },
                    { new Guid("b61d7a5f-5471-4b6d-99cc-b190fbb33a74"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5877), "user10@user.com", 0, "Name 10", "pass10", "13556", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("dfe7489e-bc3b-4106-8d77-61eb1682b331"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5868), "user7@user.com", 1, "Felícia", "pass7", "32134", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId", "PictureLink" },
                values: new object[,]
                {
                    { new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), "Description Team 2", new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), "Team 2", new Guid("2c62db3a-df2f-430c-80e6-de05f921f67a"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" },
                    { new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), "Description Team 14", new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), "Team 14", new Guid("a860b901-c5b9-4fe4-b0a3-cedf4fe477a8"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), "Description Team 16", new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), "Team 16", new Guid("dfe7489e-bc3b-4106-8d77-61eb1682b331"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), "Description Team 6", new Guid("bad6c056-54d7-400f-868e-58145909d3b1"), "Team 6", new Guid("5a0c9c24-2d48-4194-bca5-35257199a5ed"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                    { new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), "Description Team 5", new Guid("655ee210-68da-4fe4-9a21-79378c0e8d78"), "Team 5", new Guid("439eeb86-ebdd-43dd-a529-2a8978f23365"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" },
                    { new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), "Description Team 13", new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), "Team 13", new Guid("4cf75890-6008-43fc-aa9d-bd4b8acaa342"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), "Description Team 9", new Guid("c88b5db9-ee44-4c7e-98b4-9e12fea90b76"), "Team 9", new Guid("34b6f77a-9197-4ed6-9a4a-38bd7a4ea35a"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" },
                    { new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), "Description Team 7", new Guid("d6f6b994-7c48-494a-ad19-6865d5f79799"), "Team 7", new Guid("dfe7489e-bc3b-4106-8d77-61eb1682b331"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                    { new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), "Description Team 8", new Guid("2ca80d42-cceb-4ed3-8cb0-ae385310071c"), "Team 8", new Guid("2c9d0183-d10a-46d4-aaef-d58fe287466f"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                    { new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), "Description Team 15", new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), "Team 15", new Guid("5a0c9c24-2d48-4194-bca5-35257199a5ed"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), "Description Team 4", new Guid("ef474517-beab-401b-b6b6-28fdf103a882"), "Team 4", new Guid("4cf75890-6008-43fc-aa9d-bd4b8acaa342"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                    { new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), "Description Team 12", new Guid("ef474517-beab-401b-b6b6-28fdf103a882"), "Team 12", new Guid("439eeb86-ebdd-43dd-a529-2a8978f23365"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), "Description Team 3", new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), "Team 3", new Guid("439eeb86-ebdd-43dd-a529-2a8978f23365"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                    { new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), "Description Team 11", new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), "Team 11", new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" },
                    { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), "Description Team 1", new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), "Team 1", new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" },
                    { new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), "Description Team 17", new Guid("ef474517-beab-401b-b6b6-28fdf103a882"), "Team 17", new Guid("2c9d0183-d10a-46d4-aaef-d58fe287466f"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), "Description Team 10", new Guid("ef474517-beab-401b-b6b6-28fdf103a882"), "Team 10", new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Courts", "Date", "Description", "EntryDeadline", "LocationId", "MaxTeamsPerLevel", "Name", "Organizer", "PictureLink", "PriceType", "RegistrationPolicy", "TeamPolicy", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63"), 2, 2, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5663), "Description Tournament 1", new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5669), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), "[8]", "Fanatics 8 csapat körbejátszás", "Organizer 1", "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg", 16, "Registration Policy 1", "Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 0 },
                    { new Guid("b9cc6d79-756a-4791-865a-7896581828c3"), 5, 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), "[9,7]", "Műegyetemi röplabda torna A9 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 2 },
                    { new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d"), 1, 3, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef474517-beab-401b-b6b6-28fdf103a882"), "[10,7]", "Műegyetemi röplabda torna A10 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 1 }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("b9cc6d79-756a-4791-865a-7896581828c3"), new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "MatchState", "Points", "RefereeId", "StartTime", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("026ee765-8c83-41f4-b61f-c90c2c5a86f6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("03804604-e99a-473b-88ee-62c5a2637a6d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("04293c7c-7922-4f86-913c-259b82eff07e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("0646bf88-6c17-40d2-b3e4-fc7907231d23"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("07c0a161-1223-46b3-84ce-903ef79ffee8"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("080aa77e-f13b-49d1-b228-f67ee8e2e71d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("0861782f-c428-490b-b83b-38669a8bed14"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("0ac7164b-cfb4-4227-9ad6-1a4a0d20d2c9"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("0d1c91dc-7d1f-4493-a52d-6512c71eb717"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("1220e3b8-651e-4760-a82c-01dcfd75ffa9"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("124d4ba3-a574-4155-b61a-efd6eb50db21"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("12d1d578-a5af-49f7-b2b7-f865bf8e3474"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("17c8e352-4215-484c-bd9e-dd204d3c8678"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("18023709-49c7-4c3d-b2d7-b91ef649c36f"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4638), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("1812352d-158e-4aa4-a85c-11d4a9ba831d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("1af35ba9-ef4f-4ee5-b54b-26574bba4615"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("1b53a820-0bc1-440b-aa30-500b2ddade97"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("1d18b86d-30bc-4dfa-b7b6-95c9b1e58918"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("1db683a1-ed58-48f8-9df9-77479316b744"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("1fb24546-3bcb-4572-a4c6-4c17a71bc63d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("2160c5af-1b62-40cf-98b4-e1809ec4675d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("21da8a65-8c90-44a3-a8e3-501013e6269a"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4628), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("22bffe35-d27d-45cc-89f9-e14f11cb12a2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("2369e5cb-d20b-42d5-a188-9f138aa43da1"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("23852e2a-b934-4464-a1bf-33b659629642"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4699), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("23afd65a-b299-4aa2-9796-18c60ecb5435"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("24ad9126-7bb1-4282-bf04-b45b874e102b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("24c5db6f-5715-4969-8857-9cb14b6dedc5"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4714), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("27492a7e-4060-4743-8f0d-84846652190a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("2765630e-9ad8-4dbb-a7aa-78e21e90237f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("2eea640c-83ec-495b-b5c5-4999f1e7ad75"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("308a56aa-0a3f-44ff-8d1d-19c59b76c739"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("309f92d3-eade-4bca-9fb6-36cb625566b5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("373967ad-19b9-4ee5-9d3e-ef5db224481f"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4689), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("37b9c7e9-8ace-44ac-8ce9-7631da40db74"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("3a5a3586-07bc-4291-b874-264c17f21bbf"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("3a6cf893-df79-462f-93d9-47126b0cca76"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("3b325a56-0c47-4d09-ab2e-f8e9197fe813"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("3bc9406d-ba82-43b8-a024-4f4c8edc57f7"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4573), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("410bef57-6aa3-40fd-9b2c-dfb6442f37af"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4702), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("48018b9e-f6c4-4bf8-91cf-72985734716e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("4d988c9c-ebc5-4aa2-9b75-99df937718af"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("509a2ee0-9a2b-4d42-b0e8-04ad7d78d9b7"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("51538b4a-dfc7-402f-ab4f-c2ef8f4a6525"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("53269ebb-e7e1-4a79-82ab-20854d944beb"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("53a7bd85-9a71-40af-a151-6bfdeeed4924"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("55e7e8f2-81c8-47a5-ae9e-e0ba30f75779"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("56bcbf0e-67a1-4ecb-983f-d06718002e8d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("57853f1b-7564-4eb0-beea-e74b91f679c3"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("58875df8-70ec-4d61-93ca-778052611b5f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("59c3fc5c-71f4-4905-90c2-a91b2f587fb1"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("59c5fc3e-5e3e-4cdc-ac50-489123149dc0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("5a658acf-b83e-4882-bfab-d18fdb108966"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4642), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("6153460e-0fba-4f78-82cb-d44f3dc867df"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4645), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("62bfec43-7291-4618-9ec1-0b5abbe7e972"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("66d24811-eaa6-44c6-ab01-72dbbd23e00a"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("6b2750a6-da79-4983-b65b-5cee5408cc27"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4672), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("6d1a7874-8d23-4cdc-a144-620bc8f46fa7"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("7033eff6-72c9-4d95-afb1-963e3cea5d39"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4632), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("71a9eb47-a3d6-4ab1-9aad-f57e59791650"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("71f0452f-0e68-4f12-ba1d-766f16d0db67"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("724da739-50e1-4e9c-9ade-e7f52918b0bc"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("764d0c24-fb97-456a-ac3d-bc6ff80ed20b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("771ce191-7f2c-4e11-9179-4aa0e46834cd"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4658), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("7753dfbe-78a9-4fb7-a8a8-f8421bc5a72d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("77dcafbc-7221-46ab-a291-977bb00ee732"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4662), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("7ae5ea3e-5c80-40cd-8c84-32578f3d4555"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("7bd49ebb-27e8-45dc-846e-39c821d80d73"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("7c3a7b4d-44c5-43e7-acc5-7daaed5e5133"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("7c8a7b94-0853-4925-af9a-c03cf29c7631"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("7e6537f8-bb0e-4056-9b84-2b5683747a3b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("81d81909-2a7a-4921-af9e-f8caad2eb152"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4678), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("8433d165-a045-40eb-97a1-5c49da0f208e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("892d7daa-f0b7-4c76-9cba-efa611a61210"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("8f232f3d-4f22-4295-b9b5-4c7aff246386"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4695), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("8f39c0d1-d9e0-4773-9f5c-e9438d16f993"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4721), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("9031f0b2-9b6f-43dd-b2e3-c898bbf49fe2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("921964b5-0aef-4159-8618-dc824e73d758"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("92615697-e25d-4326-9d80-ba1ed9643618"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("96ab5dde-60e9-4b85-b386-a2ecb88da10f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("97aa991f-bd2c-4b58-af7f-4fa3dd49d9fd"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("9995c979-f07e-472e-b8e3-d498183b7ba0"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("9c80d055-be1e-443d-8d04-9af9bf292b61"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("9d5f2b1f-5ae7-4304-8ee8-29fec95115e2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("9e35eb85-08a5-48fc-9b03-8b0458d8458d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("a089043a-69e2-4176-8565-77138ccafa80"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("a1107725-7ce9-4175-9736-b15a13be1578"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("a1405d1a-31dc-4fc8-8404-c6d05b37333b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("a154d6d5-bbb3-4384-b168-16962bf3986f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("a68f47a3-770d-4174-8493-15380e7268ac"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("a7067ba2-aa54-4a06-8393-c6425b080926"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4685), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("a81e19ff-8e45-4d3f-8d60-fa4c393be06f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("a9621a0a-60b6-4eb7-9928-9ee461f78118"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("aa756d04-daa8-4932-96ed-5170d5fae17e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("aac9866d-6216-49f3-81fe-f5bc783f617e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("aae77561-c9ec-4092-92f3-f14be690dcad"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("ac11e6a4-6cf0-4ffa-b36b-98468c12ec03"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("ac3a894c-5d56-4564-960f-d34b13e6e339"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("af7be758-52a5-4c2a-8cc1-442f9abdbd7b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("b00ced74-57f8-4e42-a2c4-919011f55056"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("b178f78a-d4e7-4744-84cb-4efb3b497f68"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4675), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("b36c2594-4146-4c8b-8278-ff57f346c223"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("b3b1e03e-13eb-4ef8-b767-7b9f01399a22"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("b432c1a5-45c7-4418-855d-ee545836e32c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("b44aa88a-a5b2-4f57-8bfc-a27961fd63b0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("b6a52dd6-83c4-405a-b6f4-26a783b6592b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("b6b426fa-d61d-4289-bc10-e8338417dc2a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("b82e1b74-6345-4355-bdb0-98a980e94a7b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("b9c3cd53-9960-4267-a1a5-4477a90dfd5a"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4668), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("ba926200-d0f1-4aba-9c53-6daf9a888f86"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("bcff3859-5357-45b4-95f0-3d397e91442c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("bd4ae023-130f-4475-a0d7-92878d5689ae"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("be264203-3628-44d0-a2c4-e7b0f4e9d0c9"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("be3f81a2-0a9a-4a92-9916-692968165d96"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("be644cda-9b18-4e34-bcc6-a6ea5fcfaee1"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("be909def-11af-4ff4-9331-d38779a57a62"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("be90acf9-b5af-4c96-b550-b449871abf57"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("bf716196-da17-49c5-8f12-2f5081e9c56e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("c0cd735f-ff5b-4503-9d41-550a74b0fe9b"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4652), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("c25337e7-3d54-40fa-9cda-602673470b71"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("c4ee092c-e196-4202-9815-6d172025bd72"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4682), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("c6f4e5b0-6a4c-4f60-b71c-956ad86a104c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("c7796c71-e978-4afa-80a9-f72f16135c35"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("cb5818cb-3f67-4ccb-b71c-84a7353b1432"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("cfe26dc7-93a4-4fce-b277-05ba65f13c06"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("d2aff2ad-b5fb-4f72-9bd1-749f542c40d7"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("d321dc8d-c94d-4679-996c-a96794b561ab"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("d44bafcf-1477-4f22-a2ef-936ce0ccf313"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("d65332b6-98a7-4ddd-94e7-b625e742f77d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("d8b0f7df-b13d-4002-bc41-4742adaa1a8f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("dae9089c-42b3-4bf3-a53c-83cf130bab61"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("dc8c639a-3911-435d-896a-012d0ec8e7ff"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("ddd74eb4-2429-43b5-bd40-bd801bb633ed"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("e2e64c3e-e438-4ea0-bf04-77d0f855464c"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4718), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("e3657763-149c-47ec-942a-570ccdd32895"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4655), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("e43ebedb-cec2-44ff-986f-888e823a9c1b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("e845bd05-279f-4e31-af4e-4387c42d3aca"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("e979eb98-5ce6-446a-b1d1-adad5f457e58"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4648), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("ec5563a6-2f0f-4481-a931-21f05c582bfd"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4692), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("ec9d09c8-40ce-49ad-bed8-a4379b212913"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4635), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("f1e70228-bf9f-4e7a-95f1-9be82df5233f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("f229b431-0707-4ea4-8261-5d147e2c6369"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4710), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("f257d9a5-767c-4b1f-b77b-9cc98f0915fa"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("f35892fe-1aa0-481b-8ee4-f68662384ff8"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("f394305b-5d69-4fd0-a1d8-c10049589442"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("f57ad731-b1bb-41c8-b202-5a9c284ec661"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("f5bedbdb-9e0d-4adc-97d3-6f65b26cf114"), new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(4665), new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), 0, "[0,0]", new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("f913b84d-5e5c-4525-bd1b-698522a134b3"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("fb2ca439-1bd8-4500-950a-44a2f2b392dd"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), 0, "[0,0]", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("fd3e3f1e-0894-4f79-be40-61213a02bfbb"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), 0, "[0,0]", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new Guid("439eeb86-ebdd-43dd-a529-2a8978f23365") },
                    { new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), new Guid("2c62db3a-df2f-430c-80e6-de05f921f67a") },
                    { new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), new Guid("4cf75890-6008-43fc-aa9d-bd4b8acaa342") },
                    { new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new Guid("dfe7489e-bc3b-4106-8d77-61eb1682b331") },
                    { new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new Guid("5a0c9c24-2d48-4194-bca5-35257199a5ed") },
                    { new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3") },
                    { new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new Guid("b61d7a5f-5471-4b6d-99cc-b190fbb33a74") },
                    { new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new Guid("2c9d0183-d10a-46d4-aaef-d58fe287466f") },
                    { new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new Guid("34b6f77a-9197-4ed6-9a4a-38bd7a4ea35a") },
                    { new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), new Guid("439eeb86-ebdd-43dd-a529-2a8978f23365") },
                    { new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new Guid("a860b901-c5b9-4fe4-b0a3-cedf4fe477a8") },
                    { new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3") },
                    { new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new Guid("4cf75890-6008-43fc-aa9d-bd4b8acaa342") },
                    { new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), new Guid("a860b901-c5b9-4fe4-b0a3-cedf4fe477a8") },
                    { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new Guid("2c62db3a-df2f-430c-80e6-de05f921f67a") },
                    { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3") },
                    { new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), new Guid("a860b901-c5b9-4fe4-b0a3-cedf4fe477a8") },
                    { new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), new Guid("b61d7a5f-5471-4b6d-99cc-b190fbb33a74") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new Guid("2c62db3a-df2f-430c-80e6-de05f921f67a") },
                    { new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new Guid("4cf75890-6008-43fc-aa9d-bd4b8acaa342") },
                    { new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new Guid("34b6f77a-9197-4ed6-9a4a-38bd7a4ea35a") },
                    { new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new Guid("b61d7a5f-5471-4b6d-99cc-b190fbb33a74") },
                    { new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new Guid("2c9d0183-d10a-46d4-aaef-d58fe287466f") },
                    { new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new Guid("5a0c9c24-2d48-4194-bca5-35257199a5ed") },
                    { new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new Guid("dfe7489e-bc3b-4106-8d77-61eb1682b331") },
                    { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new Guid("439eeb86-ebdd-43dd-a529-2a8978f23365") },
                    { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3") },
                    { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new Guid("a860b901-c5b9-4fe4-b0a3-cedf4fe477a8") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new Guid("9120baaa-a888-4fdc-bb97-f00afaeebf63") },
                    { new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), new Guid("b9cc6d79-756a-4791-865a-7896581828c3") },
                    { new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") },
                    { new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), new Guid("cadcad33-02ba-4ea5-95ab-37a6e1fb4a8d") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "AcceptableTickets", "Date", "Description", "LocationId", "PictureLink", "TeamId" },
                values: new object[,]
                {
                    { new Guid("44999317-a695-4ed2-968e-6e5093dc5f37"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5773), "Training1", new Guid("03770670-a06d-4e7c-a683-d4c88d8c7db3"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f") },
                    { new Guid("4ed3607f-3b19-40f7-a75a-48ee85b4357e"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5789), "Training7", new Guid("d6f6b994-7c48-494a-ad19-6865d5f79799"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b") },
                    { new Guid("6509cca1-4e8c-4330-a5f2-1bf2b454b986"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5796), "Training10", new Guid("40ccb517-c8c6-4ee5-9e61-86247c437936"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa") },
                    { new Guid("af231539-febd-4ca8-afc2-0d663741c54d"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5784), "Training5", new Guid("655ee210-68da-4fe4-9a21-79378c0e8d78"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b") },
                    { new Guid("b01f9729-55ac-4999-8976-81ac47233d2c"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5782), "Training4", new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg", new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b") },
                    { new Guid("be5b368d-3591-424d-8da8-60a13a77ae0d"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5779), "Training3", new Guid("68597dcd-1bdc-4aa0-b275-59fd0b05e8c0"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120") },
                    { new Guid("c6c9a085-d702-4f50-8497-a84acb58b7ed"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5791), "Training8", new Guid("2ca80d42-cceb-4ed3-8cb0-ae385310071c"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120") },
                    { new Guid("f8064b4e-f657-46b6-b3fa-d9fabf43166c"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5777), "Training2", new Guid("c966b8e8-e6c9-4904-b23a-d9d7a622fc92"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg", new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f") },
                    { new Guid("fe30b919-082c-411c-b362-62d29575c98d"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5794), "Training9", new Guid("c88b5db9-ee44-4c7e-98b4-9e12fea90b76"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg", new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa") },
                    { new Guid("ff002745-8d86-4dbb-aae6-24abdc80d06e"), 5, new DateTime(2025, 5, 10, 21, 37, 34, 325, DateTimeKind.Local).AddTicks(5787), "Training6", new Guid("bad6c056-54d7-400f-868e-58145909d3b1"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg", new Guid("02ac4d3c-e34e-4df7-9136-475f34345120") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("44999317-a695-4ed2-968e-6e5093dc5f37"), new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("026ee765-8c83-41f4-b61f-c90c2c5a86f6"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("026ee765-8c83-41f4-b61f-c90c2c5a86f6"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("03804604-e99a-473b-88ee-62c5a2637a6d"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("03804604-e99a-473b-88ee-62c5a2637a6d"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("04293c7c-7922-4f86-913c-259b82eff07e"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("04293c7c-7922-4f86-913c-259b82eff07e"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("0646bf88-6c17-40d2-b3e4-fc7907231d23"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("0646bf88-6c17-40d2-b3e4-fc7907231d23"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("07c0a161-1223-46b3-84ce-903ef79ffee8"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("07c0a161-1223-46b3-84ce-903ef79ffee8"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("080aa77e-f13b-49d1-b228-f67ee8e2e71d"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("080aa77e-f13b-49d1-b228-f67ee8e2e71d"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("0861782f-c428-490b-b83b-38669a8bed14"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("0861782f-c428-490b-b83b-38669a8bed14"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("0ac7164b-cfb4-4227-9ad6-1a4a0d20d2c9"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("0ac7164b-cfb4-4227-9ad6-1a4a0d20d2c9"), new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), null },
                    { new Guid("0d1c91dc-7d1f-4493-a52d-6512c71eb717"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("1220e3b8-651e-4760-a82c-01dcfd75ffa9"), new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), null },
                    { new Guid("124d4ba3-a574-4155-b61a-efd6eb50db21"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("12d1d578-a5af-49f7-b2b7-f865bf8e3474"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("12d1d578-a5af-49f7-b2b7-f865bf8e3474"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("17c8e352-4215-484c-bd9e-dd204d3c8678"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("17c8e352-4215-484c-bd9e-dd204d3c8678"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("18023709-49c7-4c3d-b2d7-b91ef649c36f"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("18023709-49c7-4c3d-b2d7-b91ef649c36f"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("1812352d-158e-4aa4-a85c-11d4a9ba831d"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("1812352d-158e-4aa4-a85c-11d4a9ba831d"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("1af35ba9-ef4f-4ee5-b54b-26574bba4615"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("1af35ba9-ef4f-4ee5-b54b-26574bba4615"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("1b53a820-0bc1-440b-aa30-500b2ddade97"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("1b53a820-0bc1-440b-aa30-500b2ddade97"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("1d18b86d-30bc-4dfa-b7b6-95c9b1e58918"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("1d18b86d-30bc-4dfa-b7b6-95c9b1e58918"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("1db683a1-ed58-48f8-9df9-77479316b744"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("1db683a1-ed58-48f8-9df9-77479316b744"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("1fb24546-3bcb-4572-a4c6-4c17a71bc63d"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("1fb24546-3bcb-4572-a4c6-4c17a71bc63d"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("2160c5af-1b62-40cf-98b4-e1809ec4675d"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("2160c5af-1b62-40cf-98b4-e1809ec4675d"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("21da8a65-8c90-44a3-a8e3-501013e6269a"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("21da8a65-8c90-44a3-a8e3-501013e6269a"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("22bffe35-d27d-45cc-89f9-e14f11cb12a2"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("22bffe35-d27d-45cc-89f9-e14f11cb12a2"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("2369e5cb-d20b-42d5-a188-9f138aa43da1"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("2369e5cb-d20b-42d5-a188-9f138aa43da1"), new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), null },
                    { new Guid("23852e2a-b934-4464-a1bf-33b659629642"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("23852e2a-b934-4464-a1bf-33b659629642"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("23afd65a-b299-4aa2-9796-18c60ecb5435"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("23afd65a-b299-4aa2-9796-18c60ecb5435"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("24ad9126-7bb1-4282-bf04-b45b874e102b"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("24ad9126-7bb1-4282-bf04-b45b874e102b"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("24c5db6f-5715-4969-8857-9cb14b6dedc5"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("24c5db6f-5715-4969-8857-9cb14b6dedc5"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("27492a7e-4060-4743-8f0d-84846652190a"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("27492a7e-4060-4743-8f0d-84846652190a"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("2765630e-9ad8-4dbb-a7aa-78e21e90237f"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("2765630e-9ad8-4dbb-a7aa-78e21e90237f"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("2eea640c-83ec-495b-b5c5-4999f1e7ad75"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("2eea640c-83ec-495b-b5c5-4999f1e7ad75"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("308a56aa-0a3f-44ff-8d1d-19c59b76c739"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("308a56aa-0a3f-44ff-8d1d-19c59b76c739"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("309f92d3-eade-4bca-9fb6-36cb625566b5"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("309f92d3-eade-4bca-9fb6-36cb625566b5"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("3342ea36-96a6-4f22-a5a0-d00dd45a7213"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("373967ad-19b9-4ee5-9d3e-ef5db224481f"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("373967ad-19b9-4ee5-9d3e-ef5db224481f"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("37b9c7e9-8ace-44ac-8ce9-7631da40db74"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("3a5a3586-07bc-4291-b874-264c17f21bbf"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("3a5a3586-07bc-4291-b874-264c17f21bbf"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("3a6cf893-df79-462f-93d9-47126b0cca76"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("3a6cf893-df79-462f-93d9-47126b0cca76"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("3b325a56-0c47-4d09-ab2e-f8e9197fe813"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("3b325a56-0c47-4d09-ab2e-f8e9197fe813"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("3bc9406d-ba82-43b8-a024-4f4c8edc57f7"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("3bc9406d-ba82-43b8-a024-4f4c8edc57f7"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("410bef57-6aa3-40fd-9b2c-dfb6442f37af"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("410bef57-6aa3-40fd-9b2c-dfb6442f37af"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("48018b9e-f6c4-4bf8-91cf-72985734716e"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("48018b9e-f6c4-4bf8-91cf-72985734716e"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("4d988c9c-ebc5-4aa2-9b75-99df937718af"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("4d988c9c-ebc5-4aa2-9b75-99df937718af"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("509a2ee0-9a2b-4d42-b0e8-04ad7d78d9b7"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("509a2ee0-9a2b-4d42-b0e8-04ad7d78d9b7"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("51538b4a-dfc7-402f-ab4f-c2ef8f4a6525"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("51538b4a-dfc7-402f-ab4f-c2ef8f4a6525"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("53269ebb-e7e1-4a79-82ab-20854d944beb"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("53269ebb-e7e1-4a79-82ab-20854d944beb"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("53a7bd85-9a71-40af-a151-6bfdeeed4924"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("53a7bd85-9a71-40af-a151-6bfdeeed4924"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("55e7e8f2-81c8-47a5-ae9e-e0ba30f75779"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("55e7e8f2-81c8-47a5-ae9e-e0ba30f75779"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("56bcbf0e-67a1-4ecb-983f-d06718002e8d"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("57853f1b-7564-4eb0-beea-e74b91f679c3"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("57853f1b-7564-4eb0-beea-e74b91f679c3"), new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), null },
                    { new Guid("58875df8-70ec-4d61-93ca-778052611b5f"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("58875df8-70ec-4d61-93ca-778052611b5f"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("59c3fc5c-71f4-4905-90c2-a91b2f587fb1"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("59c3fc5c-71f4-4905-90c2-a91b2f587fb1"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("59c5fc3e-5e3e-4cdc-ac50-489123149dc0"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("59c5fc3e-5e3e-4cdc-ac50-489123149dc0"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("5a658acf-b83e-4882-bfab-d18fdb108966"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("5a658acf-b83e-4882-bfab-d18fdb108966"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("6153460e-0fba-4f78-82cb-d44f3dc867df"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("6153460e-0fba-4f78-82cb-d44f3dc867df"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("62bfec43-7291-4618-9ec1-0b5abbe7e972"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("62bfec43-7291-4618-9ec1-0b5abbe7e972"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("66d24811-eaa6-44c6-ab01-72dbbd23e00a"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("66d24811-eaa6-44c6-ab01-72dbbd23e00a"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("6b2750a6-da79-4983-b65b-5cee5408cc27"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("6b2750a6-da79-4983-b65b-5cee5408cc27"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("6d1a7874-8d23-4cdc-a144-620bc8f46fa7"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("6d1a7874-8d23-4cdc-a144-620bc8f46fa7"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("7033eff6-72c9-4d95-afb1-963e3cea5d39"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("7033eff6-72c9-4d95-afb1-963e3cea5d39"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("71a9eb47-a3d6-4ab1-9aad-f57e59791650"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("71a9eb47-a3d6-4ab1-9aad-f57e59791650"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("71f0452f-0e68-4f12-ba1d-766f16d0db67"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("71f0452f-0e68-4f12-ba1d-766f16d0db67"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("724da739-50e1-4e9c-9ade-e7f52918b0bc"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("724da739-50e1-4e9c-9ade-e7f52918b0bc"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("764d0c24-fb97-456a-ac3d-bc6ff80ed20b"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("764d0c24-fb97-456a-ac3d-bc6ff80ed20b"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("771ce191-7f2c-4e11-9179-4aa0e46834cd"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("771ce191-7f2c-4e11-9179-4aa0e46834cd"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("7753dfbe-78a9-4fb7-a8a8-f8421bc5a72d"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("7753dfbe-78a9-4fb7-a8a8-f8421bc5a72d"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("77dcafbc-7221-46ab-a291-977bb00ee732"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("77dcafbc-7221-46ab-a291-977bb00ee732"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("7ae5ea3e-5c80-40cd-8c84-32578f3d4555"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("7ae5ea3e-5c80-40cd-8c84-32578f3d4555"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("7bd49ebb-27e8-45dc-846e-39c821d80d73"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("7bd49ebb-27e8-45dc-846e-39c821d80d73"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("7c3a7b4d-44c5-43e7-acc5-7daaed5e5133"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("7c3a7b4d-44c5-43e7-acc5-7daaed5e5133"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("7c8a7b94-0853-4925-af9a-c03cf29c7631"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("7c8a7b94-0853-4925-af9a-c03cf29c7631"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("7e6537f8-bb0e-4056-9b84-2b5683747a3b"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("7e6537f8-bb0e-4056-9b84-2b5683747a3b"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("81d81909-2a7a-4921-af9e-f8caad2eb152"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("81d81909-2a7a-4921-af9e-f8caad2eb152"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("8433d165-a045-40eb-97a1-5c49da0f208e"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("8433d165-a045-40eb-97a1-5c49da0f208e"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("892d7daa-f0b7-4c76-9cba-efa611a61210"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("892d7daa-f0b7-4c76-9cba-efa611a61210"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("8f232f3d-4f22-4295-b9b5-4c7aff246386"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("8f232f3d-4f22-4295-b9b5-4c7aff246386"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("8f39c0d1-d9e0-4773-9f5c-e9438d16f993"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("8f39c0d1-d9e0-4773-9f5c-e9438d16f993"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("9031f0b2-9b6f-43dd-b2e3-c898bbf49fe2"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("9031f0b2-9b6f-43dd-b2e3-c898bbf49fe2"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("921964b5-0aef-4159-8618-dc824e73d758"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("921964b5-0aef-4159-8618-dc824e73d758"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("92615697-e25d-4326-9d80-ba1ed9643618"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("92615697-e25d-4326-9d80-ba1ed9643618"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("96ab5dde-60e9-4b85-b386-a2ecb88da10f"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("96ab5dde-60e9-4b85-b386-a2ecb88da10f"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("97aa991f-bd2c-4b58-af7f-4fa3dd49d9fd"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("97aa991f-bd2c-4b58-af7f-4fa3dd49d9fd"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("9995c979-f07e-472e-b8e3-d498183b7ba0"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("9995c979-f07e-472e-b8e3-d498183b7ba0"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("9c80d055-be1e-443d-8d04-9af9bf292b61"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("9c80d055-be1e-443d-8d04-9af9bf292b61"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("9d5f2b1f-5ae7-4304-8ee8-29fec95115e2"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("9d5f2b1f-5ae7-4304-8ee8-29fec95115e2"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("9e35eb85-08a5-48fc-9b03-8b0458d8458d"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("9e35eb85-08a5-48fc-9b03-8b0458d8458d"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("a089043a-69e2-4176-8565-77138ccafa80"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("a089043a-69e2-4176-8565-77138ccafa80"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("a1107725-7ce9-4175-9736-b15a13be1578"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("a1107725-7ce9-4175-9736-b15a13be1578"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("a1405d1a-31dc-4fc8-8404-c6d05b37333b"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("a1405d1a-31dc-4fc8-8404-c6d05b37333b"), new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), null },
                    { new Guid("a154d6d5-bbb3-4384-b168-16962bf3986f"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("a154d6d5-bbb3-4384-b168-16962bf3986f"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("a68f47a3-770d-4174-8493-15380e7268ac"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("a68f47a3-770d-4174-8493-15380e7268ac"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("a7067ba2-aa54-4a06-8393-c6425b080926"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("a7067ba2-aa54-4a06-8393-c6425b080926"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("a81e19ff-8e45-4d3f-8d60-fa4c393be06f"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("a81e19ff-8e45-4d3f-8d60-fa4c393be06f"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("a9621a0a-60b6-4eb7-9928-9ee461f78118"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("a9621a0a-60b6-4eb7-9928-9ee461f78118"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("aa756d04-daa8-4932-96ed-5170d5fae17e"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("aa756d04-daa8-4932-96ed-5170d5fae17e"), new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), null },
                    { new Guid("aac9866d-6216-49f3-81fe-f5bc783f617e"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("aac9866d-6216-49f3-81fe-f5bc783f617e"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("aae77561-c9ec-4092-92f3-f14be690dcad"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("aae77561-c9ec-4092-92f3-f14be690dcad"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("ac11e6a4-6cf0-4ffa-b36b-98468c12ec03"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("ac11e6a4-6cf0-4ffa-b36b-98468c12ec03"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("ac3a894c-5d56-4564-960f-d34b13e6e339"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("ac3a894c-5d56-4564-960f-d34b13e6e339"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("af7be758-52a5-4c2a-8cc1-442f9abdbd7b"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("af7be758-52a5-4c2a-8cc1-442f9abdbd7b"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("b00ced74-57f8-4e42-a2c4-919011f55056"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("b00ced74-57f8-4e42-a2c4-919011f55056"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("b178f78a-d4e7-4744-84cb-4efb3b497f68"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("b178f78a-d4e7-4744-84cb-4efb3b497f68"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("b36c2594-4146-4c8b-8278-ff57f346c223"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("b36c2594-4146-4c8b-8278-ff57f346c223"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("b3b1e03e-13eb-4ef8-b767-7b9f01399a22"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("b3b1e03e-13eb-4ef8-b767-7b9f01399a22"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("b432c1a5-45c7-4418-855d-ee545836e32c"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("b432c1a5-45c7-4418-855d-ee545836e32c"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("b44aa88a-a5b2-4f57-8bfc-a27961fd63b0"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("b44aa88a-a5b2-4f57-8bfc-a27961fd63b0"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("b6a52dd6-83c4-405a-b6f4-26a783b6592b"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("b6a52dd6-83c4-405a-b6f4-26a783b6592b"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("b6b426fa-d61d-4289-bc10-e8338417dc2a"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("b6b426fa-d61d-4289-bc10-e8338417dc2a"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("b82e1b74-6345-4355-bdb0-98a980e94a7b"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("b82e1b74-6345-4355-bdb0-98a980e94a7b"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("b9c3cd53-9960-4267-a1a5-4477a90dfd5a"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("b9c3cd53-9960-4267-a1a5-4477a90dfd5a"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("ba926200-d0f1-4aba-9c53-6daf9a888f86"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("ba926200-d0f1-4aba-9c53-6daf9a888f86"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("bcff3859-5357-45b4-95f0-3d397e91442c"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("bcff3859-5357-45b4-95f0-3d397e91442c"), new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), null },
                    { new Guid("bd4ae023-130f-4475-a0d7-92878d5689ae"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("bd4ae023-130f-4475-a0d7-92878d5689ae"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("be264203-3628-44d0-a2c4-e7b0f4e9d0c9"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("be264203-3628-44d0-a2c4-e7b0f4e9d0c9"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("be3f81a2-0a9a-4a92-9916-692968165d96"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("be3f81a2-0a9a-4a92-9916-692968165d96"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("be644cda-9b18-4e34-bcc6-a6ea5fcfaee1"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("be644cda-9b18-4e34-bcc6-a6ea5fcfaee1"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("be909def-11af-4ff4-9331-d38779a57a62"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("be909def-11af-4ff4-9331-d38779a57a62"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("be90acf9-b5af-4c96-b550-b449871abf57"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("be90acf9-b5af-4c96-b550-b449871abf57"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("bf716196-da17-49c5-8f12-2f5081e9c56e"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("bf716196-da17-49c5-8f12-2f5081e9c56e"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("c0cd735f-ff5b-4503-9d41-550a74b0fe9b"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("c0cd735f-ff5b-4503-9d41-550a74b0fe9b"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("c25337e7-3d54-40fa-9cda-602673470b71"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("c25337e7-3d54-40fa-9cda-602673470b71"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("c4ee092c-e196-4202-9815-6d172025bd72"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("c4ee092c-e196-4202-9815-6d172025bd72"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("c6f4e5b0-6a4c-4f60-b71c-956ad86a104c"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("c6f4e5b0-6a4c-4f60-b71c-956ad86a104c"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("c7796c71-e978-4afa-80a9-f72f16135c35"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("c7796c71-e978-4afa-80a9-f72f16135c35"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("cb5818cb-3f67-4ccb-b71c-84a7353b1432"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("cb5818cb-3f67-4ccb-b71c-84a7353b1432"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("cfe26dc7-93a4-4fce-b277-05ba65f13c06"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("cfe26dc7-93a4-4fce-b277-05ba65f13c06"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("d2aff2ad-b5fb-4f72-9bd1-749f542c40d7"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("d321dc8d-c94d-4679-996c-a96794b561ab"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("d321dc8d-c94d-4679-996c-a96794b561ab"), new Guid("f93cce3b-b3a2-4c06-9c24-5555e17b0539"), null },
                    { new Guid("d44bafcf-1477-4f22-a2ef-936ce0ccf313"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("d44bafcf-1477-4f22-a2ef-936ce0ccf313"), new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), null },
                    { new Guid("d65332b6-98a7-4ddd-94e7-b625e742f77d"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("d65332b6-98a7-4ddd-94e7-b625e742f77d"), new Guid("c9edb5a1-26c5-4ac7-a2d5-3390ac583ebc"), null },
                    { new Guid("d8b0f7df-b13d-4002-bc41-4742adaa1a8f"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("d8b0f7df-b13d-4002-bc41-4742adaa1a8f"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("dae9089c-42b3-4bf3-a53c-83cf130bab61"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("dae9089c-42b3-4bf3-a53c-83cf130bab61"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("dc8c639a-3911-435d-896a-012d0ec8e7ff"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("dc8c639a-3911-435d-896a-012d0ec8e7ff"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("ddd74eb4-2429-43b5-bd40-bd801bb633ed"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("e2e64c3e-e438-4ea0-bf04-77d0f855464c"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("e2e64c3e-e438-4ea0-bf04-77d0f855464c"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("e3657763-149c-47ec-942a-570ccdd32895"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("e3657763-149c-47ec-942a-570ccdd32895"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("e43ebedb-cec2-44ff-986f-888e823a9c1b"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("e43ebedb-cec2-44ff-986f-888e823a9c1b"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("e845bd05-279f-4e31-af4e-4387c42d3aca"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("e845bd05-279f-4e31-af4e-4387c42d3aca"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("e979eb98-5ce6-446a-b1d1-adad5f457e58"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null },
                    { new Guid("e979eb98-5ce6-446a-b1d1-adad5f457e58"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("ec5563a6-2f0f-4481-a931-21f05c582bfd"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("ec5563a6-2f0f-4481-a931-21f05c582bfd"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("ec9d09c8-40ce-49ad-bed8-a4379b212913"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("ec9d09c8-40ce-49ad-bed8-a4379b212913"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("f1e70228-bf9f-4e7a-95f1-9be82df5233f"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("f1e70228-bf9f-4e7a-95f1-9be82df5233f"), new Guid("74d8acbc-3b5d-4e18-b052-e6dc3eba089e"), null },
                    { new Guid("f229b431-0707-4ea4-8261-5d147e2c6369"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("f229b431-0707-4ea4-8261-5d147e2c6369"), new Guid("4339ba9d-3a20-4d47-bab6-c3b9f611272c"), null },
                    { new Guid("f257d9a5-767c-4b1f-b77b-9cc98f0915fa"), new Guid("f73d7299-2f0f-48f0-a67d-d854468cc6a8"), null },
                    { new Guid("f35892fe-1aa0-481b-8ee4-f68662384ff8"), new Guid("37aa1730-7ac2-4f54-8672-128edc0a89b5"), null },
                    { new Guid("f35892fe-1aa0-481b-8ee4-f68662384ff8"), new Guid("e4f7f8af-305b-420c-af14-087cf6434a8f"), null },
                    { new Guid("f394305b-5d69-4fd0-a1d8-c10049589442"), new Guid("34f79592-2751-4e96-af17-ff7992328ab4"), null },
                    { new Guid("f394305b-5d69-4fd0-a1d8-c10049589442"), new Guid("57ddb97e-a6aa-49d5-a8d0-bd9cd35086cb"), null },
                    { new Guid("f57ad731-b1bb-41c8-b202-5a9c284ec661"), new Guid("2b6cc5e6-6748-4386-83c5-f08b46f4907a"), null },
                    { new Guid("f57ad731-b1bb-41c8-b202-5a9c284ec661"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("f5bedbdb-9e0d-4adc-97d3-6f65b26cf114"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("f5bedbdb-9e0d-4adc-97d3-6f65b26cf114"), new Guid("c8ef2872-e2f0-4a08-bbd7-58e867fe364b"), null },
                    { new Guid("f913b84d-5e5c-4525-bd1b-698522a134b3"), new Guid("820e7c0e-f1cb-482d-a40d-4121fbadf316"), null },
                    { new Guid("f913b84d-5e5c-4525-bd1b-698522a134b3"), new Guid("c31eab70-2806-4e5d-bc09-d876c6fe5341"), null },
                    { new Guid("fb2ca439-1bd8-4500-950a-44a2f2b392dd"), new Guid("6f2a491a-188b-437e-96be-1bdb479c1acd"), null },
                    { new Guid("fb2ca439-1bd8-4500-950a-44a2f2b392dd"), new Guid("9e308945-1328-4a48-83a1-a86e7f99f8aa"), null },
                    { new Guid("fd3e3f1e-0894-4f79-be40-61213a02bfbb"), new Guid("02ac4d3c-e34e-4df7-9136-475f34345120"), null },
                    { new Guid("fd3e3f1e-0894-4f79-be40-61213a02bfbb"), new Guid("78b7b4ee-2893-4337-8668-4bc653ca663d"), null }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f8064b4e-f657-46b6-b3fa-d9fabf43166c"), new Guid("2c62db3a-df2f-430c-80e6-de05f921f67a") },
                    { new Guid("c6c9a085-d702-4f50-8497-a84acb58b7ed"), new Guid("2c9d0183-d10a-46d4-aaef-d58fe287466f") },
                    { new Guid("fe30b919-082c-411c-b362-62d29575c98d"), new Guid("34b6f77a-9197-4ed6-9a4a-38bd7a4ea35a") },
                    { new Guid("be5b368d-3591-424d-8da8-60a13a77ae0d"), new Guid("439eeb86-ebdd-43dd-a529-2a8978f23365") },
                    { new Guid("b01f9729-55ac-4999-8976-81ac47233d2c"), new Guid("4cf75890-6008-43fc-aa9d-bd4b8acaa342") },
                    { new Guid("ff002745-8d86-4dbb-aae6-24abdc80d06e"), new Guid("5a0c9c24-2d48-4194-bca5-35257199a5ed") },
                    { new Guid("44999317-a695-4ed2-968e-6e5093dc5f37"), new Guid("878d5d81-8cfe-4d68-a4cf-904d262f61d3") },
                    { new Guid("af231539-febd-4ca8-afc2-0d663741c54d"), new Guid("a860b901-c5b9-4fe4-b0a3-cedf4fe477a8") },
                    { new Guid("6509cca1-4e8c-4330-a5f2-1bf2b454b986"), new Guid("b61d7a5f-5471-4b6d-99cc-b190fbb33a74") },
                    { new Guid("4ed3607f-3b19-40f7-a75a-48ee85b4357e"), new Guid("dfe7489e-bc3b-4106-8d77-61eb1682b331") }
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
