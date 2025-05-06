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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categories = table.Column<int>(type: "int", nullable: false),
                    PriceType = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("0ee0f7ae-3e29-4d0d-bf03-e50f8ebbc282"), "Location Addr 3", "Location3" },
                    { new Guid("11a213ee-89c5-4d40-8c89-65761ba758f0"), "Location Addr 10", "Location10" },
                    { new Guid("21c59515-54f8-4dcd-92e1-afcd15548e37"), "Location Addr 2", "Location2" },
                    { new Guid("5fc64673-a3ca-44dd-983e-63cf5738ace2"), "Location Addr 5", "Location5" },
                    { new Guid("65375840-06fc-4675-bd81-6e016c391e27"), "Location Addr 4", "Location4" },
                    { new Guid("7b1265ec-82ea-40d4-b2ab-b3cbec98f971"), "Location Addr 7", "Location7" },
                    { new Guid("9e6979c4-57d0-4ad7-be1c-5999259f9e56"), "Location Addr 8", "Location8" },
                    { new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "Location Addr 1", "Location1" },
                    { new Guid("bdf1d6db-3227-4fde-9932-e69e9939bf9c"), "Location Addr 6", "Location6" },
                    { new Guid("cfe4ca86-2e2a-40e0-899b-604be88fce39"), "Location Addr 9", "Location9" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Gender", "Name", "Password", "Phone", "PictureLink", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("0d13b6d7-d4ec-4ffc-ab2a-d59ae1774e77"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6930), "user9@user.com", 0, "Name 9", "pass9", "2716717", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("41d18784-2066-40a6-9aca-25c57ad94cf7"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6918), "user5@user.com", 0, "Lajos", "pass5", "54337", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 4, 2 },
                    { new Guid("5cdda27c-de07-4092-9ead-43fa45aa7fc0"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6924), "user7@user.com", 1, "Felícia", "pass7", "32134", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 2 },
                    { new Guid("78ffef69-d0b8-48d8-a14a-a0dd01ec679d"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6933), "user10@user.com", 0, "Name 10", "pass10", "13556", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("85f1ac4f-1927-4f2e-b071-dd5cf8f22009"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6915), "user4@user.com", 0, "Kristóf", "pass4", "83568", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("a35a3bee-8d57-4e50-8cc9-8c77b66ac488"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6927), "user8@user.com", 0, "Name 8", "pass8", "893935", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("ba63f9c1-f700-438b-bb95-44119038a9cf"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6909), "user2@user.com", 1, "Aranka", "pass2", "965463", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6905), "user1@user.com", 0, "Jancsi", "pass1", "34214124", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 2, 3 },
                    { new Guid("e26e1d69-523a-4564-b7c9-1c64bf4eca5d"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6921), "user6@user.com", 0, "Péter", "pass6", "4221", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("fff56dce-bd08-4889-be77-3a8ab228cd84"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6912), "user3@user.com", 0, "Dani", "pass3", "123555", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId", "PictureLink" },
                values: new object[,]
                {
                    { new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052"), "Description Team 3", new Guid("0ee0f7ae-3e29-4d0d-bf03-e50f8ebbc282"), "Team 3", new Guid("fff56dce-bd08-4889-be77-3a8ab228cd84"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                    { new Guid("56be0aa4-db65-4b88-9046-12ea002068e0"), "Description Team 2", new Guid("21c59515-54f8-4dcd-92e1-afcd15548e37"), "Team 2", new Guid("ba63f9c1-f700-438b-bb95-44119038a9cf"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" },
                    { new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de"), "Description Team 8", new Guid("9e6979c4-57d0-4ad7-be1c-5999259f9e56"), "Team 8", new Guid("a35a3bee-8d57-4e50-8cc9-8c77b66ac488"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                    { new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), "Description Team 1", new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "Team 1", new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" },
                    { new Guid("af3353d2-6917-4bf7-b41c-7a8cf647cead"), "Description Team 10", new Guid("65375840-06fc-4675-bd81-6e016c391e27"), "Team 10", new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" },
                    { new Guid("b5bab9c2-5558-4728-b491-90475d7e226b"), "Description Team 6", new Guid("bdf1d6db-3227-4fde-9932-e69e9939bf9c"), "Team 6", new Guid("e26e1d69-523a-4564-b7c9-1c64bf4eca5d"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                    { new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a"), "Description Team 7", new Guid("7b1265ec-82ea-40d4-b2ab-b3cbec98f971"), "Team 7", new Guid("5cdda27c-de07-4092-9ead-43fa45aa7fc0"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                    { new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0"), "Description Team 5", new Guid("5fc64673-a3ca-44dd-983e-63cf5738ace2"), "Team 5", new Guid("fff56dce-bd08-4889-be77-3a8ab228cd84"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" },
                    { new Guid("bca36ab3-45e9-4526-bea7-9f69efe8b756"), "Description Team 12", new Guid("65375840-06fc-4675-bd81-6e016c391e27"), "Team 12", new Guid("fff56dce-bd08-4889-be77-3a8ab228cd84"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("d1569b4f-8fa0-4764-9838-09d86096347e"), "Description Team 11", new Guid("0ee0f7ae-3e29-4d0d-bf03-e50f8ebbc282"), "Team 11", new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" },
                    { new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2"), "Description Team 4", new Guid("65375840-06fc-4675-bd81-6e016c391e27"), "Team 4", new Guid("85f1ac4f-1927-4f2e-b071-dd5cf8f22009"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                    { new Guid("f9b9dde8-554c-4e9d-b0da-a38d850a698d"), "Description Team 9", new Guid("cfe4ca86-2e2a-40e0-899b-604be88fce39"), "Team 9", new Guid("0d13b6d7-d4ec-4ffc-ab2a-d59ae1774e77"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Date", "Description", "EntryDeadline", "LocationId", "Name", "Organizer", "PictureLink", "PriceType", "RegistrationPolicy", "TeamPolicy" },
                values: new object[,]
                {
                    { new Guid("34e11b96-420c-4853-99ca-01b73be943b1"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6725), "Description Tournament 1", new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6728), new Guid("21c59515-54f8-4dcd-92e1-afcd15548e37"), "Tournament 1", "Organizer 1", "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg", 16, "Registration Policy 1", "Team Policy 1" },
                    { new Guid("5373cd3d-96a5-4bc0-a4ed-b2aab8f563d1"), 4, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6731), "Description Tournament 2", new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6733), new Guid("0ee0f7ae-3e29-4d0d-bf03-e50f8ebbc282"), "Tournament 2", "Organizer 2", "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg", 16, "Registration Policy 2", "Team Policy 2" },
                    { new Guid("e86bab50-4d0d-438b-a1a3-f706c08c1d66"), 1, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6736), "Description Tournament 3", new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6738), new Guid("65375840-06fc-4675-bd81-6e016c391e27"), "Tournament 3", "Organizer 3", "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg", 16, "Registration Policy 3", "Team Policy 3" }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("5373cd3d-96a5-4bc0-a4ed-b2aab8f563d1"), new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "Points", "RefereeId", "StartTime", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("016da2ba-c425-4d14-b0bc-771e8d1a070c"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6442), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("092e4455-83b7-4e21-9747-5b8dfee2a356"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6390), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("1629bbd8-2ac5-416f-a653-89a733644010"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6397), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("1a8cec36-5db8-4bdf-8c24-56740bd92efc"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6374), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("56be0aa4-db65-4b88-9046-12ea002068e0"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("1da10b48-f537-4428-a8a4-45151e5ed2bb"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6448), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("241b3542-fe36-4e9e-86c4-837448c24783"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6384), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("291515fe-9c65-41e1-ae42-131adbd14171"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6465), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("3266e415-be71-40ae-84b8-b075ecca7379"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6377), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b5bab9c2-5558-4728-b491-90475d7e226b"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("335dfe70-a521-4c1f-a33e-21a91a36173a"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6425), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("56be0aa4-db65-4b88-9046-12ea002068e0"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("344a101e-4435-4f55-9f23-9e161d5883cb"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6393), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("4fc5cc31-72d3-4aa7-b3e6-728be8ac6aa8"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6361), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("610c2b55-5af5-40b4-98e6-9047be14b787"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6439), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("56be0aa4-db65-4b88-9046-12ea002068e0"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("648c76d1-32a4-4a53-8893-e14d6ee4942b"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6475), new Guid("0ee0f7ae-3e29-4d0d-bf03-e50f8ebbc282"), "[0,0]", new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new DateTime(2024, 4, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e86bab50-4d0d-438b-a1a3-f706c08c1d66") },
                    { new Guid("67b79f6a-50f0-4f24-b50d-22e2e92b905a"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6429), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("6dc00010-2011-4b7d-af96-6c285314dc4c"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6302), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b5bab9c2-5558-4728-b491-90475d7e226b"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("76cb5fea-2d10-4208-b5ae-a00a1acec9b4"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6368), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("77b0dbda-0682-472d-bba8-1a73489658a8"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6358), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("8cf15dc8-bd93-4bc1-ac38-46326615c926"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6371), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("8f604272-9941-46af-a6e9-7e746c2204a8"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6471), new Guid("21c59515-54f8-4dcd-92e1-afcd15548e37"), "[0,0]", new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new DateTime(2024, 4, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5373cd3d-96a5-4bc0-a4ed-b2aab8f563d1") },
                    { new Guid("93ebf610-c2d1-4163-a0e2-a145d9b3c6f8"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6364), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("aa800f65-5d63-4cf1-8856-5b0cbebaaebb"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6452), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("abf9d241-9110-45ab-9d1e-cc0dcfd0cd06"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6468), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("ad0557b3-8ef0-4e87-bf3e-f697e10919e6"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6458), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("b7ebd0fc-231c-4593-b626-2ff7ed232607"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6445), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("df47e31a-1b47-4513-9d57-72baa5a9fb8b"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6387), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b5bab9c2-5558-4728-b491-90475d7e226b"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("e175d1f9-5c43-4f72-aab6-87d5d30cb831"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6461), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b5bab9c2-5558-4728-b491-90475d7e226b"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("e4911308-658c-4fa4-9c01-54a80c7cd2bd"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6381), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("56be0aa4-db65-4b88-9046-12ea002068e0"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("f7b8f141-034f-43b8-bb5e-f88b967c617e"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6455), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("f9f2ff1a-23cd-4760-a14e-b9f3bc991de5"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6435), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("fb61c5d5-1513-475b-9e1c-cc002fa14501"), new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6432), new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "[0,0]", new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052"), new Guid("85f1ac4f-1927-4f2e-b071-dd5cf8f22009") },
                    { new Guid("56be0aa4-db65-4b88-9046-12ea002068e0"), new Guid("fff56dce-bd08-4889-be77-3a8ab228cd84") },
                    { new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de"), new Guid("0d13b6d7-d4ec-4ffc-ab2a-d59ae1774e77") },
                    { new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new Guid("ba63f9c1-f700-438b-bb95-44119038a9cf") },
                    { new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400") },
                    { new Guid("af3353d2-6917-4bf7-b41c-7a8cf647cead"), new Guid("78ffef69-d0b8-48d8-a14a-a0dd01ec679d") },
                    { new Guid("b5bab9c2-5558-4728-b491-90475d7e226b"), new Guid("5cdda27c-de07-4092-9ead-43fa45aa7fc0") },
                    { new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a"), new Guid("a35a3bee-8d57-4e50-8cc9-8c77b66ac488") },
                    { new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0"), new Guid("e26e1d69-523a-4564-b7c9-1c64bf4eca5d") },
                    { new Guid("bca36ab3-45e9-4526-bea7-9f69efe8b756"), new Guid("a35a3bee-8d57-4e50-8cc9-8c77b66ac488") },
                    { new Guid("d1569b4f-8fa0-4764-9838-09d86096347e"), new Guid("41d18784-2066-40a6-9aca-25c57ad94cf7") },
                    { new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2"), new Guid("41d18784-2066-40a6-9aca-25c57ad94cf7") },
                    { new Guid("f9b9dde8-554c-4e9d-b0da-a38d850a698d"), new Guid("78ffef69-d0b8-48d8-a14a-a0dd01ec679d") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052"), new Guid("5cdda27c-de07-4092-9ead-43fa45aa7fc0") },
                    { new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052"), new Guid("a35a3bee-8d57-4e50-8cc9-8c77b66ac488") },
                    { new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052"), new Guid("e26e1d69-523a-4564-b7c9-1c64bf4eca5d") },
                    { new Guid("56be0aa4-db65-4b88-9046-12ea002068e0"), new Guid("85f1ac4f-1927-4f2e-b071-dd5cf8f22009") },
                    { new Guid("56be0aa4-db65-4b88-9046-12ea002068e0"), new Guid("ba63f9c1-f700-438b-bb95-44119038a9cf") },
                    { new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new Guid("41d18784-2066-40a6-9aca-25c57ad94cf7") },
                    { new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400") },
                    { new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new Guid("fff56dce-bd08-4889-be77-3a8ab228cd84") },
                    { new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2"), new Guid("0d13b6d7-d4ec-4ffc-ab2a-d59ae1774e77") },
                    { new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2"), new Guid("78ffef69-d0b8-48d8-a14a-a0dd01ec679d") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052"), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("56be0aa4-db65-4b88-9046-12ea002068e0"), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de"), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83"), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("b5bab9c2-5558-4728-b491-90475d7e226b"), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a"), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0"), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2"), new Guid("34e11b96-420c-4853-99ca-01b73be943b1") },
                    { new Guid("af3353d2-6917-4bf7-b41c-7a8cf647cead"), new Guid("5373cd3d-96a5-4bc0-a4ed-b2aab8f563d1") },
                    { new Guid("f9b9dde8-554c-4e9d-b0da-a38d850a698d"), new Guid("5373cd3d-96a5-4bc0-a4ed-b2aab8f563d1") },
                    { new Guid("bca36ab3-45e9-4526-bea7-9f69efe8b756"), new Guid("e86bab50-4d0d-438b-a1a3-f706c08c1d66") },
                    { new Guid("d1569b4f-8fa0-4764-9838-09d86096347e"), new Guid("e86bab50-4d0d-438b-a1a3-f706c08c1d66") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "AcceptableTickets", "Date", "Description", "LocationId", "PictureLink", "TeamId" },
                values: new object[,]
                {
                    { new Guid("2584365b-8c11-442e-b239-195fc18ac2e5"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6837), "Training6", new Guid("bdf1d6db-3227-4fde-9932-e69e9939bf9c"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg", new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("61efd86d-fd7e-4190-b2cc-5b4458ecee58"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6828), "Training2", new Guid("21c59515-54f8-4dcd-92e1-afcd15548e37"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg", new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83") },
                    { new Guid("8cadf95f-5dc9-429c-987b-4594bb3a0a66"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6832), "Training4", new Guid("0ee0f7ae-3e29-4d0d-bf03-e50f8ebbc282"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg", new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("a7c24677-3177-471a-b266-0f12c3591ac3"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6840), "Training7", new Guid("7b1265ec-82ea-40d4-b2ab-b3cbec98f971"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg", new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("ba08c5db-e916-4ffc-bb31-f7ab454ad01e"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6847), "Training10", new Guid("11a213ee-89c5-4d40-8c89-65761ba758f0"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg", new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2") },
                    { new Guid("c466f828-ed78-4d3d-8eed-9c834f10eaed"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6830), "Training3", new Guid("0ee0f7ae-3e29-4d0d-bf03-e50f8ebbc282"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg", new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("d74909cc-a655-414a-aeff-a5f705c62240"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6842), "Training8", new Guid("9e6979c4-57d0-4ad7-be1c-5999259f9e56"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg", new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("dc9837ce-2674-4f06-88ac-fc757fb1da72"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6835), "Training5", new Guid("5fc64673-a3ca-44dd-983e-63cf5738ace2"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg", new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("e81b2ce8-7a28-43c5-9202-0498dd4c799e"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6844), "Training9", new Guid("cfe4ca86-2e2a-40e0-899b-604be88fce39"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg", new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2") },
                    { new Guid("fa5d4c63-49c8-4d5a-a867-756694708b0c"), 5, new DateTime(2025, 5, 6, 22, 19, 13, 418, DateTimeKind.Local).AddTicks(6824), "Training1", new Guid("a54965c5-3914-49a4-a1ee-1b727dcd0d30"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg", new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("fa5d4c63-49c8-4d5a-a867-756694708b0c"), new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("016da2ba-c425-4d14-b0bc-771e8d1a070c"), new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a") },
                    { new Guid("016da2ba-c425-4d14-b0bc-771e8d1a070c"), new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2") },
                    { new Guid("092e4455-83b7-4e21-9747-5b8dfee2a356"), new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de") },
                    { new Guid("092e4455-83b7-4e21-9747-5b8dfee2a356"), new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a") },
                    { new Guid("1629bbd8-2ac5-416f-a653-89a733644010"), new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("1629bbd8-2ac5-416f-a653-89a733644010"), new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de") },
                    { new Guid("1a8cec36-5db8-4bdf-8c24-56740bd92efc"), new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("1a8cec36-5db8-4bdf-8c24-56740bd92efc"), new Guid("b5bab9c2-5558-4728-b491-90475d7e226b") },
                    { new Guid("1da10b48-f537-4428-a8a4-45151e5ed2bb"), new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("1da10b48-f537-4428-a8a4-45151e5ed2bb"), new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83") },
                    { new Guid("241b3542-fe36-4e9e-86c4-837448c24783"), new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de") },
                    { new Guid("241b3542-fe36-4e9e-86c4-837448c24783"), new Guid("b5bab9c2-5558-4728-b491-90475d7e226b") },
                    { new Guid("291515fe-9c65-41e1-ae42-131adbd14171"), new Guid("b5bab9c2-5558-4728-b491-90475d7e226b") },
                    { new Guid("291515fe-9c65-41e1-ae42-131adbd14171"), new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0") },
                    { new Guid("3266e415-be71-40ae-84b8-b075ecca7379"), new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de") },
                    { new Guid("3266e415-be71-40ae-84b8-b075ecca7379"), new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2") },
                    { new Guid("335dfe70-a521-4c1f-a33e-21a91a36173a"), new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de") },
                    { new Guid("335dfe70-a521-4c1f-a33e-21a91a36173a"), new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83") },
                    { new Guid("344a101e-4435-4f55-9f23-9e161d5883cb"), new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("344a101e-4435-4f55-9f23-9e161d5883cb"), new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("4fc5cc31-72d3-4aa7-b3e6-728be8ac6aa8"), new Guid("b5bab9c2-5558-4728-b491-90475d7e226b") },
                    { new Guid("4fc5cc31-72d3-4aa7-b3e6-728be8ac6aa8"), new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a") },
                    { new Guid("610c2b55-5af5-40b4-98e6-9047be14b787"), new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de") },
                    { new Guid("610c2b55-5af5-40b4-98e6-9047be14b787"), new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0") },
                    { new Guid("648c76d1-32a4-4a53-8893-e14d6ee4942b"), new Guid("bca36ab3-45e9-4526-bea7-9f69efe8b756") },
                    { new Guid("648c76d1-32a4-4a53-8893-e14d6ee4942b"), new Guid("d1569b4f-8fa0-4764-9838-09d86096347e") },
                    { new Guid("67b79f6a-50f0-4f24-b50d-22e2e92b905a"), new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83") },
                    { new Guid("67b79f6a-50f0-4f24-b50d-22e2e92b905a"), new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0") },
                    { new Guid("6dc00010-2011-4b7d-af96-6c285314dc4c"), new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("6dc00010-2011-4b7d-af96-6c285314dc4c"), new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0") },
                    { new Guid("76cb5fea-2d10-4208-b5ae-a00a1acec9b4"), new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("76cb5fea-2d10-4208-b5ae-a00a1acec9b4"), new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83") },
                    { new Guid("77b0dbda-0682-472d-bba8-1a73489658a8"), new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("77b0dbda-0682-472d-bba8-1a73489658a8"), new Guid("5b58e0d7-8f7f-4398-9cfa-235799d908de") },
                    { new Guid("8cf15dc8-bd93-4bc1-ac38-46326615c926"), new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("8cf15dc8-bd93-4bc1-ac38-46326615c926"), new Guid("b5bab9c2-5558-4728-b491-90475d7e226b") },
                    { new Guid("8f604272-9941-46af-a6e9-7e746c2204a8"), new Guid("af3353d2-6917-4bf7-b41c-7a8cf647cead") },
                    { new Guid("8f604272-9941-46af-a6e9-7e746c2204a8"), new Guid("f9b9dde8-554c-4e9d-b0da-a38d850a698d") },
                    { new Guid("93ebf610-c2d1-4163-a0e2-a145d9b3c6f8"), new Guid("b5bab9c2-5558-4728-b491-90475d7e226b") },
                    { new Guid("93ebf610-c2d1-4163-a0e2-a145d9b3c6f8"), new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2") },
                    { new Guid("aa800f65-5d63-4cf1-8856-5b0cbebaaebb"), new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0") },
                    { new Guid("aa800f65-5d63-4cf1-8856-5b0cbebaaebb"), new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2") },
                    { new Guid("abf9d241-9110-45ab-9d1e-cc0dcfd0cd06"), new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83") },
                    { new Guid("abf9d241-9110-45ab-9d1e-cc0dcfd0cd06"), new Guid("b5bab9c2-5558-4728-b491-90475d7e226b") },
                    { new Guid("ad0557b3-8ef0-4e87-bf3e-f697e10919e6"), new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("ad0557b3-8ef0-4e87-bf3e-f697e10919e6"), new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0") },
                    { new Guid("b7ebd0fc-231c-4593-b626-2ff7ed232607"), new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a") },
                    { new Guid("b7ebd0fc-231c-4593-b626-2ff7ed232607"), new Guid("b7aa910a-851d-4198-822d-eb43ce2f81d0") },
                    { new Guid("df47e31a-1b47-4513-9d57-72baa5a9fb8b"), new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("df47e31a-1b47-4513-9d57-72baa5a9fb8b"), new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2") },
                    { new Guid("e175d1f9-5c43-4f72-aab6-87d5d30cb831"), new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83") },
                    { new Guid("e175d1f9-5c43-4f72-aab6-87d5d30cb831"), new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2") },
                    { new Guid("e4911308-658c-4fa4-9c01-54a80c7cd2bd"), new Guid("0c8dce11-4a7e-49ea-a1d3-d523a36c5052") },
                    { new Guid("e4911308-658c-4fa4-9c01-54a80c7cd2bd"), new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a") },
                    { new Guid("f7b8f141-034f-43b8-bb5e-f88b967c617e"), new Guid("9137dac2-41f8-41e6-b5a8-375a4494ed83") },
                    { new Guid("f7b8f141-034f-43b8-bb5e-f88b967c617e"), new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a") },
                    { new Guid("f9f2ff1a-23cd-4760-a14e-b9f3bc991de5"), new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("f9f2ff1a-23cd-4760-a14e-b9f3bc991de5"), new Guid("b61b0a6b-7ef2-40c1-942f-9d1618a26b0a") },
                    { new Guid("fb61c5d5-1513-475b-9e1c-cc002fa14501"), new Guid("56be0aa4-db65-4b88-9046-12ea002068e0") },
                    { new Guid("fb61c5d5-1513-475b-9e1c-cc002fa14501"), new Guid("de3dd0c8-ce59-481a-967c-add0c79801c2") }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e81b2ce8-7a28-43c5-9202-0498dd4c799e"), new Guid("0d13b6d7-d4ec-4ffc-ab2a-d59ae1774e77") },
                    { new Guid("dc9837ce-2674-4f06-88ac-fc757fb1da72"), new Guid("41d18784-2066-40a6-9aca-25c57ad94cf7") },
                    { new Guid("a7c24677-3177-471a-b266-0f12c3591ac3"), new Guid("5cdda27c-de07-4092-9ead-43fa45aa7fc0") },
                    { new Guid("ba08c5db-e916-4ffc-bb31-f7ab454ad01e"), new Guid("78ffef69-d0b8-48d8-a14a-a0dd01ec679d") },
                    { new Guid("8cadf95f-5dc9-429c-987b-4594bb3a0a66"), new Guid("85f1ac4f-1927-4f2e-b071-dd5cf8f22009") },
                    { new Guid("d74909cc-a655-414a-aeff-a5f705c62240"), new Guid("a35a3bee-8d57-4e50-8cc9-8c77b66ac488") },
                    { new Guid("61efd86d-fd7e-4190-b2cc-5b4458ecee58"), new Guid("ba63f9c1-f700-438b-bb95-44119038a9cf") },
                    { new Guid("fa5d4c63-49c8-4d5a-a867-756694708b0c"), new Guid("e045f223-30f3-4d3c-ba3b-964ccb1b2400") },
                    { new Guid("2584365b-8c11-442e-b239-195fc18ac2e5"), new Guid("e26e1d69-523a-4564-b7c9-1c64bf4eca5d") },
                    { new Guid("c466f828-ed78-4d3d-8eed-9c834f10eaed"), new Guid("fff56dce-bd08-4889-be77-3a8ab228cd84") }
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
