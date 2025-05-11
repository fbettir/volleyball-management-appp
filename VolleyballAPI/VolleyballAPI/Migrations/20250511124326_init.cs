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
                    { new Guid("241987e7-0b7c-41f6-ad4a-809ea0cc84ad"), "Location Addr 8", "Location8" },
                    { new Guid("3fd23669-78be-4072-b29e-1fc3b400ce82"), "Location Addr 10", "Location10" },
                    { new Guid("6806bb10-2ffe-4219-88fc-57ecab29d73c"), "Location Addr 6", "Location6" },
                    { new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), "1114 Budapest, Villányi út 27.", "Budai Ciszterci Szent Imre Gimnázium Tornacsarnok" },
                    { new Guid("942ae304-836a-4146-a8b2-281c1d4fb3fe"), "Location Addr 4", "Location4" },
                    { new Guid("9a41ff6e-2b56-48a7-8a24-75ea849b8d00"), "Location Addr 7", "Location7" },
                    { new Guid("a9a16085-6ccf-4939-a502-d290a7be17f6"), "Location Addr 9", "Location9" },
                    { new Guid("b033c21f-c192-4570-8b7c-b47b3046e967"), "Location Addr 5", "Location5" },
                    { new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), "Budapest, Bogdánfy u. 12, 1117", "BME Sporttelep" },
                    { new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), "Budapest, Bertalan Lajos u. 4-6, 1111", "BME Sportközpont" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Gender", "Name", "Password", "Phone", "PictureLink", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("01274628-e60b-4e40-a02a-1b002dfe9269"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6310), "user8@user.com", 0, "Name 8", "pass8", "893935", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("0ea213f4-8aea-4ed1-876f-40257227b232"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6313), "user9@user.com", 0, "Name 9", "pass9", "2716717", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("42be8eb2-a27d-47c2-91f0-5bf5826fb4e1"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6299), "user5@user.com", 0, "Lajos", "pass5", "54337", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 4, 2 },
                    { new Guid("56a54392-10b1-43de-b805-c4c1fc89370d"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6303), "user6@user.com", 0, "Péter", "pass6", "4221", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("6e34dec9-0bca-4274-aee3-f068bb3af978"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6295), "user4@user.com", 0, "Kristóf", "pass4", "83568", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("86d598d5-1bb2-4b22-b198-3b3bfe53ce8f"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6286), "user2@user.com", 1, "Aranka", "pass2", "965463", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("88c5a449-aa9d-46ff-a033-e0b94ad9434a"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6307), "user7@user.com", 1, "Felícia", "pass7", "32134", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 2 },
                    { new Guid("93303dce-8c67-4254-aa98-c40b4515e10c"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6280), "user1@user.com", 0, "Jancsi", "pass1", "34214124", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 2, 3 },
                    { new Guid("b4c9bf4b-20a7-4b1c-93b4-d21901e47577"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6316), "user10@user.com", 0, "Name 10", "pass10", "13556", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("bc6a65f4-54e1-440e-815a-a1ba26e172ec"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6290), "user3@user.com", 0, "Dani", "pass3", "123555", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId", "PictureLink" },
                values: new object[,]
                {
                    { new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), "Description Team 7", new Guid("9a41ff6e-2b56-48a7-8a24-75ea849b8d00"), "Team 7", new Guid("88c5a449-aa9d-46ff-a033-e0b94ad9434a"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                    { new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), "Description Team 11", new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), "Team 11", new Guid("93303dce-8c67-4254-aa98-c40b4515e10c"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" },
                    { new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), "Description Team 15", new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), "Team 15", new Guid("56a54392-10b1-43de-b805-c4c1fc89370d"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), "Description Team 4", new Guid("942ae304-836a-4146-a8b2-281c1d4fb3fe"), "Team 4", new Guid("6e34dec9-0bca-4274-aee3-f068bb3af978"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                    { new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), "Description Team 12", new Guid("942ae304-836a-4146-a8b2-281c1d4fb3fe"), "Team 12", new Guid("bc6a65f4-54e1-440e-815a-a1ba26e172ec"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), "Description Team 10", new Guid("942ae304-836a-4146-a8b2-281c1d4fb3fe"), "Team 10", new Guid("93303dce-8c67-4254-aa98-c40b4515e10c"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" },
                    { new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), "Description Team 2", new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), "Team 2", new Guid("86d598d5-1bb2-4b22-b198-3b3bfe53ce8f"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" },
                    { new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), "Description Team 16", new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), "Team 16", new Guid("88c5a449-aa9d-46ff-a033-e0b94ad9434a"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), "Description Team 5", new Guid("b033c21f-c192-4570-8b7c-b47b3046e967"), "Team 5", new Guid("bc6a65f4-54e1-440e-815a-a1ba26e172ec"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" },
                    { new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), "Description Team 17", new Guid("942ae304-836a-4146-a8b2-281c1d4fb3fe"), "Team 17", new Guid("01274628-e60b-4e40-a02a-1b002dfe9269"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), "Description Team 9", new Guid("a9a16085-6ccf-4939-a502-d290a7be17f6"), "Team 9", new Guid("0ea213f4-8aea-4ed1-876f-40257227b232"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" },
                    { new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), "Description Team 6", new Guid("6806bb10-2ffe-4219-88fc-57ecab29d73c"), "Team 6", new Guid("56a54392-10b1-43de-b805-c4c1fc89370d"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                    { new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), "Description Team 3", new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), "Team 3", new Guid("bc6a65f4-54e1-440e-815a-a1ba26e172ec"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                    { new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), "Description Team 13", new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), "Team 13", new Guid("6e34dec9-0bca-4274-aee3-f068bb3af978"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), "Description Team 14", new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), "Team 14", new Guid("42be8eb2-a27d-47c2-91f0-5bf5826fb4e1"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), "Description Team 8", new Guid("241987e7-0b7c-41f6-ad4a-809ea0cc84ad"), "Team 8", new Guid("01274628-e60b-4e40-a02a-1b002dfe9269"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                    { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), "Description Team 1", new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), "Team 1", new Guid("93303dce-8c67-4254-aa98-c40b4515e10c"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Courts", "Date", "Description", "EntryDeadline", "LocationId", "MaxTeamsPerLevel", "Name", "Organizer", "PictureLink", "PriceType", "RegistrationPolicy", "TeamPolicy", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a"), 5, 3, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), "[10,7]", "Műegyetemi röplabda torna A10 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 1 },
                    { new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d"), 5, 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), "[9,7]", "Műegyetemi röplabda torna A9 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 2 },
                    { new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5"), 2, 2, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6042), "Description Tournament 1", new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6050), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), "[8]", "Fanatics 8 csapat körbejátszás", "Organizer 1", "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg", 16, "Registration Policy 1", "Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 0 }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new Guid("93303dce-8c67-4254-aa98-c40b4515e10c") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d"), new Guid("93303dce-8c67-4254-aa98-c40b4515e10c") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "MatchState", "Points", "RefereeId", "StartTime", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("0012336f-d9e5-412f-b13d-48764b2a1504"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("0115e9c9-3fed-4db3-a2dd-b990d0c515f6"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4983), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("0194329a-c250-4890-83fc-39866967318d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("01e35a23-9144-4a0f-930b-39f964ab7a37"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4973), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("03b84ba3-eded-485a-b189-91f46762db6e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("052b3c1f-f70c-41f8-9e31-d908c1d9509a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("09d4cf2f-c719-498e-a06a-b451e22b6c9e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("0b915929-4993-4c8c-927a-ed6f04074974"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("0c098606-8720-477c-8d5d-9a0629a6fc07"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5072), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("0e7e0432-f913-4806-bf4e-e27bec1e3f4c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("0f1c26d6-f882-4142-b814-60559d79344d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("0ff88281-28c0-4c43-aa36-c6a1ae32e444"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5058), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("138abb6c-7ad5-4caa-ba54-f02279b4cb48"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5075), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("1642b068-16d5-4f19-ae9c-cb62c8b74cb1"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4993), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("18b6f9b6-9513-46ce-811f-52556e0abc43"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("19c42dd7-8adc-476f-b3f4-ea058f56aeaf"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("1d5e56d5-028d-47e1-ae44-f78e7ef9f22c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("207dcf94-849c-4b1d-b531-0ffe1bb53dd6"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("217936f2-d8f9-496c-bcd6-b76eb665ccd8"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("22992a45-3c13-45fd-9a23-9e084a82f680"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("29a44ff4-10c9-4863-a3ab-9f7fbea95ba1"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("2b67c2fd-71fb-4740-8fe5-e849248c57ff"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("2be44dca-9424-4fcb-8d90-808336c4a4cc"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("2ddc8092-1288-48e2-a148-45abfb4c1216"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("2f689e14-2783-45fe-92d9-1c243f0cf28b"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4977), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("3174221c-ae4e-4800-a028-a3d449634362"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("369547da-3785-4eeb-8ca1-4452c9201837"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("37d3cce0-d60f-41ac-8745-ff92e9c19423"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("3855d7f4-f07d-4e0f-94fb-3ad46c741b4d"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("3b0caee4-518e-43d0-a57b-923f45f6c63b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("3b941eed-6c10-43b2-862b-cd4c62048b69"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("3be9e8bb-946f-4330-a39d-4a76b669dfea"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("3cc92bf9-dddb-4a01-8173-53e164bbaef4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("3f2f2a7e-e6a8-4d02-a208-563c53024235"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("40c26489-7860-4598-98e6-4edec2583408"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5068), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("4454f832-59ff-4628-bf85-402d09bbb513"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("44d7274e-06ce-47d5-a6cc-b1d26171c79b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("483e639a-e0da-40f7-b1d6-e40d68fab4ca"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("49eccfbd-e329-4b27-b2f4-945c180ff845"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5000), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("49f3def1-6475-4d06-aa4b-b0f7bac6211e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("4ecf6565-de89-44c4-9cf3-29e1350bb0aa"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("4f26cc80-d4af-4b87-b2ca-ac5da8d9b0a6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("51ce7407-f301-421d-8267-ec577d88e1e6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("53e32e83-5d13-45a6-a4a5-e575990d325f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("5441eef8-6aa2-4412-8a06-91e0dc201033"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("551bcd80-5187-4b61-b14e-0cc68722f00e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("55ac8c5c-c509-4fc0-a6b7-c77e58150be2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("5647a2da-1b98-4044-a7bd-6a14dcb452cd"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("57c5d9a4-fd58-42ae-b283-bf2d090791e8"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("582dc92f-48e5-44e1-883b-626c31f3d99c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("58aabff4-0cd8-454a-8ca7-26fc58316417"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5045), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("5a378b6e-186c-4fa7-bf3e-e4ff9d3b19fb"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5065), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("5b82385a-d9f8-40ab-b449-b56621077f6b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("5e1cabe6-f008-424a-9a43-dec162aae4a7"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("5e58a47c-ee1d-437d-9179-eaff518c1e2c"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5003), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("5e9c4651-dfac-4d4d-b98a-29fbc32096b4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("6399977a-6971-4ee8-b97d-d38ab0f0158c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("63eb12e2-72d0-4e62-919e-637ef7f9b17b"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4990), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("64e93332-cf93-4dc9-a2c4-b24a1243ead9"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("6552d004-86c2-420b-8552-a57d9ffc1183"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4986), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("68d8ee34-a867-44c6-bed8-8f5659b1232c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("68e95076-bf4f-45e1-848d-01ed095a9c70"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("6c1629b2-1c51-4cbc-8a89-bbe11c1723a5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("6e0e93ad-0a5f-48ee-9add-fddf784cf5bb"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("6e234133-3a94-48a8-8981-1031e3f6373b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("6e277139-3be5-4847-b907-1e99989cb020"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("6f8ac81e-8b14-46ac-86bc-e377e6dab1e5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("70d4ab08-af22-4d9e-966f-69e73e3d54c4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("70e2cb88-e310-417d-9710-db71f63b2651"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("736c663e-72c5-47b0-a47d-75296667b196"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("771fb0fb-3da0-4328-a5b0-924a1a3771d1"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("7ac762c2-c0a9-412d-bdb4-0d5160edd5b7"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("7c9cb3be-50aa-4406-be0f-fde49fe09b96"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("7dcb3607-cedf-42b5-b64c-bac97ff47336"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("7dfafc20-0218-4256-b5d6-adc905b3f9d6"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("7f337f17-95e4-4a8a-ba1c-660a833021a4"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("8316bc42-baf1-425e-a782-fdad1aaff9fa"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("844abb3d-6162-45e6-b325-f553be1eb101"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("85450ef2-9057-4c3e-876a-527e2a77032b"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5034), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("85e5ff45-1138-4043-a369-63c7f189226b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("85e91d15-517a-4fcd-8007-ebe888f5d4d3"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("862890e5-2166-4ed3-8520-347760b32e84"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("86579a2d-bad5-42f1-afad-8c3113c96da9"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("87e04155-3d69-4044-b3a4-4ddd34f2dcda"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("89e5299f-c331-4a63-8043-33e8e1598c4d"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5055), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("8db6ed63-b73f-4024-8e54-717036c00671"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("8e818925-a339-4caf-9f5c-33894be06900"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("9037f98d-b732-447b-b396-f37d0efb59c6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("9199f126-714f-4b43-96d0-08c61b8db494"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5052), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("929abeee-8f82-48cd-95f5-28277ede007f"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5078), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("93e7289f-bfa1-4ff0-a691-583c180fd7b7"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("9cc197b3-9246-4ab0-818a-484d1c7ba608"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("9e515387-1e48-4175-ad89-3e2f0d523df4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("a1c43b0e-de7f-4ca9-a8bc-043e5d7177fe"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("a374ca69-a541-483f-a080-41a8b196389f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("a56e9dd4-bae7-48f7-a24f-6e05520bce1c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("a7b5adce-3365-4193-8539-961f21aaec39"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("aa3bcee8-856f-4e3d-9fe7-1d71beb926b6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("afd5967a-b4c1-4074-843c-86c86f09702b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("b0103244-ec56-40ec-9f50-53ea3dec5df7"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("b01df229-005e-4885-a4b5-23c01a97be8a"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4970), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("b06e5d16-bfaf-48ed-bb69-d953901ce141"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("b0718492-aabc-4557-bf9d-ed3c4b43dbb4"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("b225d0a8-ebb0-4864-8d8c-2e8c852cb977"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("b3224525-e551-4678-8596-0d9417b70439"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5048), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("b5b49581-f6b2-4609-9ca1-8bba2c55a77b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("b643e305-6b8d-470c-9e15-93fec0dfbbec"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("ba191dfe-af84-43e9-bb61-d06483dcb5bc"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5042), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("ba5636e1-bd89-496c-9081-d5203479c657"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("bb5e4208-0f3b-4ab5-8d32-c7f62328ed6a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("bc5ac868-15e6-4202-aa75-53332c8b3e17"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("c2951d5a-475a-40e3-9c7a-dcfb4cd9a0c0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("c3ade6af-f31e-4ebc-9671-c673ea48ff72"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("c4558c69-7d40-43bc-9012-27ded175fc9b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("c690ad22-8933-4e72-9a09-89113c9877ac"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5038), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("c718ffe0-4b03-4001-9648-939115fbb7e1"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("c752761b-717a-4c37-811e-4891a2b46548"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("c758de75-7283-44db-900b-82d7cecea5f5"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("c9da744c-53e3-4b2c-835a-7ac024c0777f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("c9df233c-21f5-49a4-aade-c4c32fba7234"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("c9e3c44b-860b-4649-a6b6-f498b9910bc2"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5082), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("c9f42894-435a-4324-a5ba-a03d721a1d50"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("ca02878d-0a01-45ff-8184-e58e15375080"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("cb2355e1-562d-4664-a625-6a9659342eed"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4967), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("d0c13817-1fc8-4347-86e6-d21638b55a3f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("d1bd9397-23c0-4dbd-a688-d29715dda594"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("d1ce8dcb-7e07-4675-83b4-0b4e3a6be901"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("d1cfb9e8-a561-4eff-8e5c-47fc0d90a736"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("d599af33-f4d1-43ca-ae1e-145b2be9ccdb"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("dd40d4b6-8e7a-49ce-a242-239304778e4b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("ddd73f27-c643-4cba-84f2-872fbf1549bc"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4996), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("df598ba2-1d47-47ab-a5e8-afc389bc5c61"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4916), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("e149dfb1-50d2-4011-aa4a-d2762d3ee0b2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("e1e2bb25-5a0f-43bd-b8c7-270b662400d0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("e4e66fe3-a104-4178-879e-d7fb7d692eed"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("e776bd55-3d23-4470-bddc-28588fc6dece"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("e8b7d22d-f22f-4ffb-b5e5-21dda2f8c868"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("e95c5c9c-bcc0-4be1-be9e-8b4d54063789"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("e960ff78-2b1e-4ca6-90ca-02dd2b8f37c6"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("ea063f97-df4b-4871-b32b-0871d008788e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("ead07634-fe16-45df-b612-5d5d21109ca2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("eed50d58-3ab8-4283-a1ae-966e8b1f6604"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("ef0d6ef3-af09-4936-8bce-af22fcbfa856"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("efed9868-9e74-4553-b555-b8409a17ce20"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("f2e427e8-d875-4789-8055-c600766d7c12"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("f5db6793-96a0-4f2a-8a9d-81c2657d8d37"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("f7f65be5-d6fb-477b-842e-d6be6f8ac26e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("fa7ae8d6-ece4-4c6f-a70e-3118e368940f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("fb3c4b69-a42f-4cc1-830e-d57d65020828"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(5062), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("fd03d2e9-ec8e-47c2-a6e2-a9d0a030ea4a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), 0, "[0,0]", new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("ffea9158-96c5-4349-bc70-2732e43daf23"), new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(4980), new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), 0, "[0,0]", new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new Guid("01274628-e60b-4e40-a02a-1b002dfe9269") },
                    { new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), new Guid("42be8eb2-a27d-47c2-91f0-5bf5826fb4e1") },
                    { new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), new Guid("bc6a65f4-54e1-440e-815a-a1ba26e172ec") },
                    { new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new Guid("42be8eb2-a27d-47c2-91f0-5bf5826fb4e1") },
                    { new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), new Guid("93303dce-8c67-4254-aa98-c40b4515e10c") },
                    { new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), new Guid("b4c9bf4b-20a7-4b1c-93b4-d21901e47577") },
                    { new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new Guid("bc6a65f4-54e1-440e-815a-a1ba26e172ec") },
                    { new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), new Guid("6e34dec9-0bca-4274-aee3-f068bb3af978") },
                    { new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new Guid("56a54392-10b1-43de-b805-c4c1fc89370d") },
                    { new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), new Guid("42be8eb2-a27d-47c2-91f0-5bf5826fb4e1") },
                    { new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new Guid("b4c9bf4b-20a7-4b1c-93b4-d21901e47577") },
                    { new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new Guid("88c5a449-aa9d-46ff-a033-e0b94ad9434a") },
                    { new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new Guid("6e34dec9-0bca-4274-aee3-f068bb3af978") },
                    { new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), new Guid("93303dce-8c67-4254-aa98-c40b4515e10c") },
                    { new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), new Guid("86d598d5-1bb2-4b22-b198-3b3bfe53ce8f") },
                    { new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new Guid("0ea213f4-8aea-4ed1-876f-40257227b232") },
                    { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new Guid("86d598d5-1bb2-4b22-b198-3b3bfe53ce8f") },
                    { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new Guid("93303dce-8c67-4254-aa98-c40b4515e10c") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new Guid("0ea213f4-8aea-4ed1-876f-40257227b232") },
                    { new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new Guid("b4c9bf4b-20a7-4b1c-93b4-d21901e47577") },
                    { new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new Guid("6e34dec9-0bca-4274-aee3-f068bb3af978") },
                    { new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new Guid("86d598d5-1bb2-4b22-b198-3b3bfe53ce8f") },
                    { new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new Guid("01274628-e60b-4e40-a02a-1b002dfe9269") },
                    { new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new Guid("56a54392-10b1-43de-b805-c4c1fc89370d") },
                    { new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new Guid("88c5a449-aa9d-46ff-a033-e0b94ad9434a") },
                    { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new Guid("42be8eb2-a27d-47c2-91f0-5bf5826fb4e1") },
                    { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new Guid("93303dce-8c67-4254-aa98-c40b4515e10c") },
                    { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new Guid("bc6a65f4-54e1-440e-815a-a1ba26e172ec") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new Guid("331bae05-0a5b-4b7d-a880-02df26e75a4a") },
                    { new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new Guid("414bd087-c2a9-4fca-ae8b-fd8abc567a8d") },
                    { new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") },
                    { new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), new Guid("d0d64090-61ab-4f5b-9bdc-7b551fa3b5b5") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "AcceptableTickets", "Date", "Description", "LocationId", "PictureLink", "TeamId" },
                values: new object[,]
                {
                    { new Guid("135d4e2f-1592-4960-86b7-a4ffb2b9f399"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6143), "Training3", new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0") },
                    { new Guid("29f93fdc-4763-4eea-8227-4f96b5dd54b9"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6137), "Training1", new Guid("90eb8751-8cd8-4a06-9ac3-be4e8d28ef27"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507") },
                    { new Guid("3b544e54-7fa2-4ef2-b2fb-d4d267cff777"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6157), "Training9", new Guid("a9a16085-6ccf-4939-a502-d290a7be17f6"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e") },
                    { new Guid("40a6bd3a-ad51-4598-a544-a33950409479"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6145), "Training4", new Guid("fc0fbd8f-f416-4885-972a-93aa61056624"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f") },
                    { new Guid("4af100cd-4b27-47f0-ba9a-db091fd9a41d"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6155), "Training8", new Guid("241987e7-0b7c-41f6-ad4a-809ea0cc84ad"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0") },
                    { new Guid("7d06385b-5454-43a8-a02e-13fe936b6f11"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6160), "Training10", new Guid("3fd23669-78be-4072-b29e-1fc3b400ce82"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg", new Guid("3299280b-8d83-4961-adf5-0bc666efd89e") },
                    { new Guid("ab8125cc-37f2-4873-b142-425f44c399c4"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6148), "Training5", new Guid("b033c21f-c192-4570-8b7c-b47b3046e967"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f") },
                    { new Guid("b48fe0bd-282e-441b-872f-85ec090abd3f"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6150), "Training6", new Guid("6806bb10-2ffe-4219-88fc-57ecab29d73c"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg", new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0") },
                    { new Guid("bdca6249-d8e2-4f08-87d7-66debe322e79"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6153), "Training7", new Guid("9a41ff6e-2b56-48a7-8a24-75ea849b8d00"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg", new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f") },
                    { new Guid("d047a105-8946-448c-b452-1f18fcf4f37c"), 5, new DateTime(2025, 5, 11, 14, 43, 25, 358, DateTimeKind.Local).AddTicks(6141), "Training2", new Guid("fc3239e4-21c9-483d-a04c-65c8c56f9453"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg", new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("29f93fdc-4763-4eea-8227-4f96b5dd54b9"), new Guid("93303dce-8c67-4254-aa98-c40b4515e10c") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("0012336f-d9e5-412f-b13d-48764b2a1504"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("0012336f-d9e5-412f-b13d-48764b2a1504"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("0115e9c9-3fed-4db3-a2dd-b990d0c515f6"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("0115e9c9-3fed-4db3-a2dd-b990d0c515f6"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("0194329a-c250-4890-83fc-39866967318d"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("0194329a-c250-4890-83fc-39866967318d"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("01e35a23-9144-4a0f-930b-39f964ab7a37"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("01e35a23-9144-4a0f-930b-39f964ab7a37"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("03b84ba3-eded-485a-b189-91f46762db6e"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("03b84ba3-eded-485a-b189-91f46762db6e"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("052b3c1f-f70c-41f8-9e31-d908c1d9509a"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("052b3c1f-f70c-41f8-9e31-d908c1d9509a"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("09d4cf2f-c719-498e-a06a-b451e22b6c9e"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("09d4cf2f-c719-498e-a06a-b451e22b6c9e"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("0b915929-4993-4c8c-927a-ed6f04074974"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("0b915929-4993-4c8c-927a-ed6f04074974"), new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), null },
                    { new Guid("0c098606-8720-477c-8d5d-9a0629a6fc07"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("0c098606-8720-477c-8d5d-9a0629a6fc07"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("0e7e0432-f913-4806-bf4e-e27bec1e3f4c"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("0e7e0432-f913-4806-bf4e-e27bec1e3f4c"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("0f1c26d6-f882-4142-b814-60559d79344d"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("0f1c26d6-f882-4142-b814-60559d79344d"), new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), null },
                    { new Guid("0ff88281-28c0-4c43-aa36-c6a1ae32e444"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("0ff88281-28c0-4c43-aa36-c6a1ae32e444"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("138abb6c-7ad5-4caa-ba54-f02279b4cb48"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("138abb6c-7ad5-4caa-ba54-f02279b4cb48"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("1642b068-16d5-4f19-ae9c-cb62c8b74cb1"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("1642b068-16d5-4f19-ae9c-cb62c8b74cb1"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("18b6f9b6-9513-46ce-811f-52556e0abc43"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("18b6f9b6-9513-46ce-811f-52556e0abc43"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("19c42dd7-8adc-476f-b3f4-ea058f56aeaf"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("19c42dd7-8adc-476f-b3f4-ea058f56aeaf"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("1d5e56d5-028d-47e1-ae44-f78e7ef9f22c"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("1d5e56d5-028d-47e1-ae44-f78e7ef9f22c"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("207dcf94-849c-4b1d-b531-0ffe1bb53dd6"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("207dcf94-849c-4b1d-b531-0ffe1bb53dd6"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("217936f2-d8f9-496c-bcd6-b76eb665ccd8"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("217936f2-d8f9-496c-bcd6-b76eb665ccd8"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("22992a45-3c13-45fd-9a23-9e084a82f680"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("22992a45-3c13-45fd-9a23-9e084a82f680"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("29a44ff4-10c9-4863-a3ab-9f7fbea95ba1"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("29a44ff4-10c9-4863-a3ab-9f7fbea95ba1"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("2b67c2fd-71fb-4740-8fe5-e849248c57ff"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("2b67c2fd-71fb-4740-8fe5-e849248c57ff"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("2be44dca-9424-4fcb-8d90-808336c4a4cc"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("2be44dca-9424-4fcb-8d90-808336c4a4cc"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("2ddc8092-1288-48e2-a148-45abfb4c1216"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("2ddc8092-1288-48e2-a148-45abfb4c1216"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("2f689e14-2783-45fe-92d9-1c243f0cf28b"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("2f689e14-2783-45fe-92d9-1c243f0cf28b"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("3174221c-ae4e-4800-a028-a3d449634362"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("3174221c-ae4e-4800-a028-a3d449634362"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("369547da-3785-4eeb-8ca1-4452c9201837"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("369547da-3785-4eeb-8ca1-4452c9201837"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("37d3cce0-d60f-41ac-8745-ff92e9c19423"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("37d3cce0-d60f-41ac-8745-ff92e9c19423"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("3855d7f4-f07d-4e0f-94fb-3ad46c741b4d"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("3855d7f4-f07d-4e0f-94fb-3ad46c741b4d"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("3b0caee4-518e-43d0-a57b-923f45f6c63b"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("3b0caee4-518e-43d0-a57b-923f45f6c63b"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("3b941eed-6c10-43b2-862b-cd4c62048b69"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("3b941eed-6c10-43b2-862b-cd4c62048b69"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("3be9e8bb-946f-4330-a39d-4a76b669dfea"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("3be9e8bb-946f-4330-a39d-4a76b669dfea"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("3cc92bf9-dddb-4a01-8173-53e164bbaef4"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("3cc92bf9-dddb-4a01-8173-53e164bbaef4"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("3f2f2a7e-e6a8-4d02-a208-563c53024235"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("3f2f2a7e-e6a8-4d02-a208-563c53024235"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("40c26489-7860-4598-98e6-4edec2583408"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("40c26489-7860-4598-98e6-4edec2583408"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("4454f832-59ff-4628-bf85-402d09bbb513"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("4454f832-59ff-4628-bf85-402d09bbb513"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("44d7274e-06ce-47d5-a6cc-b1d26171c79b"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("44d7274e-06ce-47d5-a6cc-b1d26171c79b"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("483e639a-e0da-40f7-b1d6-e40d68fab4ca"), new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), null },
                    { new Guid("483e639a-e0da-40f7-b1d6-e40d68fab4ca"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("49eccfbd-e329-4b27-b2f4-945c180ff845"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("49eccfbd-e329-4b27-b2f4-945c180ff845"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("49f3def1-6475-4d06-aa4b-b0f7bac6211e"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("49f3def1-6475-4d06-aa4b-b0f7bac6211e"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("4ecf6565-de89-44c4-9cf3-29e1350bb0aa"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("4ecf6565-de89-44c4-9cf3-29e1350bb0aa"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("4f26cc80-d4af-4b87-b2ca-ac5da8d9b0a6"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("4f26cc80-d4af-4b87-b2ca-ac5da8d9b0a6"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("51ce7407-f301-421d-8267-ec577d88e1e6"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("51ce7407-f301-421d-8267-ec577d88e1e6"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("53e32e83-5d13-45a6-a4a5-e575990d325f"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("53e32e83-5d13-45a6-a4a5-e575990d325f"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("5441eef8-6aa2-4412-8a06-91e0dc201033"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("5441eef8-6aa2-4412-8a06-91e0dc201033"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("551bcd80-5187-4b61-b14e-0cc68722f00e"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("551bcd80-5187-4b61-b14e-0cc68722f00e"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("55ac8c5c-c509-4fc0-a6b7-c77e58150be2"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("55ac8c5c-c509-4fc0-a6b7-c77e58150be2"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("5647a2da-1b98-4044-a7bd-6a14dcb452cd"), new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), null },
                    { new Guid("5647a2da-1b98-4044-a7bd-6a14dcb452cd"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("57c5d9a4-fd58-42ae-b283-bf2d090791e8"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("57c5d9a4-fd58-42ae-b283-bf2d090791e8"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("582dc92f-48e5-44e1-883b-626c31f3d99c"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("582dc92f-48e5-44e1-883b-626c31f3d99c"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("58aabff4-0cd8-454a-8ca7-26fc58316417"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("58aabff4-0cd8-454a-8ca7-26fc58316417"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("5a378b6e-186c-4fa7-bf3e-e4ff9d3b19fb"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("5a378b6e-186c-4fa7-bf3e-e4ff9d3b19fb"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("5b82385a-d9f8-40ab-b449-b56621077f6b"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("5b82385a-d9f8-40ab-b449-b56621077f6b"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("5e1cabe6-f008-424a-9a43-dec162aae4a7"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("5e1cabe6-f008-424a-9a43-dec162aae4a7"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("5e58a47c-ee1d-437d-9179-eaff518c1e2c"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("5e58a47c-ee1d-437d-9179-eaff518c1e2c"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("5e9c4651-dfac-4d4d-b98a-29fbc32096b4"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("5e9c4651-dfac-4d4d-b98a-29fbc32096b4"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("6399977a-6971-4ee8-b97d-d38ab0f0158c"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("6399977a-6971-4ee8-b97d-d38ab0f0158c"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("63eb12e2-72d0-4e62-919e-637ef7f9b17b"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("63eb12e2-72d0-4e62-919e-637ef7f9b17b"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("64e93332-cf93-4dc9-a2c4-b24a1243ead9"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("64e93332-cf93-4dc9-a2c4-b24a1243ead9"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("6552d004-86c2-420b-8552-a57d9ffc1183"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("6552d004-86c2-420b-8552-a57d9ffc1183"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("68d8ee34-a867-44c6-bed8-8f5659b1232c"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("68d8ee34-a867-44c6-bed8-8f5659b1232c"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("68e95076-bf4f-45e1-848d-01ed095a9c70"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("68e95076-bf4f-45e1-848d-01ed095a9c70"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("6c1629b2-1c51-4cbc-8a89-bbe11c1723a5"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("6c1629b2-1c51-4cbc-8a89-bbe11c1723a5"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("6e0e93ad-0a5f-48ee-9add-fddf784cf5bb"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("6e0e93ad-0a5f-48ee-9add-fddf784cf5bb"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("6e234133-3a94-48a8-8981-1031e3f6373b"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("6e234133-3a94-48a8-8981-1031e3f6373b"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("6e277139-3be5-4847-b907-1e99989cb020"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("6e277139-3be5-4847-b907-1e99989cb020"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("6f8ac81e-8b14-46ac-86bc-e377e6dab1e5"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("6f8ac81e-8b14-46ac-86bc-e377e6dab1e5"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("70d4ab08-af22-4d9e-966f-69e73e3d54c4"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("70d4ab08-af22-4d9e-966f-69e73e3d54c4"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("70e2cb88-e310-417d-9710-db71f63b2651"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("70e2cb88-e310-417d-9710-db71f63b2651"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("736c663e-72c5-47b0-a47d-75296667b196"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("736c663e-72c5-47b0-a47d-75296667b196"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("771fb0fb-3da0-4328-a5b0-924a1a3771d1"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("771fb0fb-3da0-4328-a5b0-924a1a3771d1"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("7ac762c2-c0a9-412d-bdb4-0d5160edd5b7"), new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), null },
                    { new Guid("7ac762c2-c0a9-412d-bdb4-0d5160edd5b7"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("7c9cb3be-50aa-4406-be0f-fde49fe09b96"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("7c9cb3be-50aa-4406-be0f-fde49fe09b96"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("7dcb3607-cedf-42b5-b64c-bac97ff47336"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("7dcb3607-cedf-42b5-b64c-bac97ff47336"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("7dfafc20-0218-4256-b5d6-adc905b3f9d6"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("7dfafc20-0218-4256-b5d6-adc905b3f9d6"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("7f337f17-95e4-4a8a-ba1c-660a833021a4"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("7f337f17-95e4-4a8a-ba1c-660a833021a4"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("8316bc42-baf1-425e-a782-fdad1aaff9fa"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("8316bc42-baf1-425e-a782-fdad1aaff9fa"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("844abb3d-6162-45e6-b325-f553be1eb101"), new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), null },
                    { new Guid("844abb3d-6162-45e6-b325-f553be1eb101"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("85450ef2-9057-4c3e-876a-527e2a77032b"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("85450ef2-9057-4c3e-876a-527e2a77032b"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("85e5ff45-1138-4043-a369-63c7f189226b"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("85e5ff45-1138-4043-a369-63c7f189226b"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("85e91d15-517a-4fcd-8007-ebe888f5d4d3"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("85e91d15-517a-4fcd-8007-ebe888f5d4d3"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("862890e5-2166-4ed3-8520-347760b32e84"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("862890e5-2166-4ed3-8520-347760b32e84"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("86579a2d-bad5-42f1-afad-8c3113c96da9"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("86579a2d-bad5-42f1-afad-8c3113c96da9"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("87e04155-3d69-4044-b3a4-4ddd34f2dcda"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("87e04155-3d69-4044-b3a4-4ddd34f2dcda"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("89e5299f-c331-4a63-8043-33e8e1598c4d"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("89e5299f-c331-4a63-8043-33e8e1598c4d"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("8db6ed63-b73f-4024-8e54-717036c00671"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("8db6ed63-b73f-4024-8e54-717036c00671"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("8e818925-a339-4caf-9f5c-33894be06900"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("8e818925-a339-4caf-9f5c-33894be06900"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("9037f98d-b732-447b-b396-f37d0efb59c6"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("9037f98d-b732-447b-b396-f37d0efb59c6"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("9199f126-714f-4b43-96d0-08c61b8db494"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("9199f126-714f-4b43-96d0-08c61b8db494"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("929abeee-8f82-48cd-95f5-28277ede007f"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("929abeee-8f82-48cd-95f5-28277ede007f"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("93e7289f-bfa1-4ff0-a691-583c180fd7b7"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("93e7289f-bfa1-4ff0-a691-583c180fd7b7"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("9cc197b3-9246-4ab0-818a-484d1c7ba608"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("9cc197b3-9246-4ab0-818a-484d1c7ba608"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("9e515387-1e48-4175-ad89-3e2f0d523df4"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("9e515387-1e48-4175-ad89-3e2f0d523df4"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("a1c43b0e-de7f-4ca9-a8bc-043e5d7177fe"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("a1c43b0e-de7f-4ca9-a8bc-043e5d7177fe"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("a374ca69-a541-483f-a080-41a8b196389f"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("a374ca69-a541-483f-a080-41a8b196389f"), new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), null },
                    { new Guid("a56e9dd4-bae7-48f7-a24f-6e05520bce1c"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("a56e9dd4-bae7-48f7-a24f-6e05520bce1c"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("a7b5adce-3365-4193-8539-961f21aaec39"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("a7b5adce-3365-4193-8539-961f21aaec39"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("aa3bcee8-856f-4e3d-9fe7-1d71beb926b6"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("aa3bcee8-856f-4e3d-9fe7-1d71beb926b6"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("afd5967a-b4c1-4074-843c-86c86f09702b"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("afd5967a-b4c1-4074-843c-86c86f09702b"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("b0103244-ec56-40ec-9f50-53ea3dec5df7"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("b0103244-ec56-40ec-9f50-53ea3dec5df7"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("b01df229-005e-4885-a4b5-23c01a97be8a"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("b01df229-005e-4885-a4b5-23c01a97be8a"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("b06e5d16-bfaf-48ed-bb69-d953901ce141"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("b06e5d16-bfaf-48ed-bb69-d953901ce141"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("b0718492-aabc-4557-bf9d-ed3c4b43dbb4"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("b0718492-aabc-4557-bf9d-ed3c4b43dbb4"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("b225d0a8-ebb0-4864-8d8c-2e8c852cb977"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("b225d0a8-ebb0-4864-8d8c-2e8c852cb977"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("b3224525-e551-4678-8596-0d9417b70439"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("b3224525-e551-4678-8596-0d9417b70439"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("b5b49581-f6b2-4609-9ca1-8bba2c55a77b"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("b5b49581-f6b2-4609-9ca1-8bba2c55a77b"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("b643e305-6b8d-470c-9e15-93fec0dfbbec"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("b643e305-6b8d-470c-9e15-93fec0dfbbec"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("ba191dfe-af84-43e9-bb61-d06483dcb5bc"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("ba191dfe-af84-43e9-bb61-d06483dcb5bc"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("ba5636e1-bd89-496c-9081-d5203479c657"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("ba5636e1-bd89-496c-9081-d5203479c657"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("bb5e4208-0f3b-4ab5-8d32-c7f62328ed6a"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("bb5e4208-0f3b-4ab5-8d32-c7f62328ed6a"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("bc5ac868-15e6-4202-aa75-53332c8b3e17"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("bc5ac868-15e6-4202-aa75-53332c8b3e17"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("c2951d5a-475a-40e3-9c7a-dcfb4cd9a0c0"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("c2951d5a-475a-40e3-9c7a-dcfb4cd9a0c0"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("c3ade6af-f31e-4ebc-9671-c673ea48ff72"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("c3ade6af-f31e-4ebc-9671-c673ea48ff72"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("c4558c69-7d40-43bc-9012-27ded175fc9b"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("c4558c69-7d40-43bc-9012-27ded175fc9b"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("c690ad22-8933-4e72-9a09-89113c9877ac"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("c690ad22-8933-4e72-9a09-89113c9877ac"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("c718ffe0-4b03-4001-9648-939115fbb7e1"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("c718ffe0-4b03-4001-9648-939115fbb7e1"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("c752761b-717a-4c37-811e-4891a2b46548"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("c752761b-717a-4c37-811e-4891a2b46548"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("c758de75-7283-44db-900b-82d7cecea5f5"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("c758de75-7283-44db-900b-82d7cecea5f5"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("c9da744c-53e3-4b2c-835a-7ac024c0777f"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("c9da744c-53e3-4b2c-835a-7ac024c0777f"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("c9df233c-21f5-49a4-aade-c4c32fba7234"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("c9df233c-21f5-49a4-aade-c4c32fba7234"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("c9e3c44b-860b-4649-a6b6-f498b9910bc2"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("c9e3c44b-860b-4649-a6b6-f498b9910bc2"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("c9f42894-435a-4324-a5ba-a03d721a1d50"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("c9f42894-435a-4324-a5ba-a03d721a1d50"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("ca02878d-0a01-45ff-8184-e58e15375080"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("ca02878d-0a01-45ff-8184-e58e15375080"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("cb2355e1-562d-4664-a625-6a9659342eed"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("cb2355e1-562d-4664-a625-6a9659342eed"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("d0c13817-1fc8-4347-86e6-d21638b55a3f"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("d0c13817-1fc8-4347-86e6-d21638b55a3f"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("d1bd9397-23c0-4dbd-a688-d29715dda594"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("d1bd9397-23c0-4dbd-a688-d29715dda594"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("d1ce8dcb-7e07-4675-83b4-0b4e3a6be901"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("d1ce8dcb-7e07-4675-83b4-0b4e3a6be901"), new Guid("8b81ce88-3810-46f6-9c1f-27c3993a900c"), null },
                    { new Guid("d1cfb9e8-a561-4eff-8e5c-47fc0d90a736"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("d1cfb9e8-a561-4eff-8e5c-47fc0d90a736"), new Guid("50d5c96c-d821-436c-9e42-d22f00e0b690"), null },
                    { new Guid("d599af33-f4d1-43ca-ae1e-145b2be9ccdb"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("d599af33-f4d1-43ca-ae1e-145b2be9ccdb"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("dd40d4b6-8e7a-49ce-a242-239304778e4b"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("dd40d4b6-8e7a-49ce-a242-239304778e4b"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("ddd73f27-c643-4cba-84f2-872fbf1549bc"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("ddd73f27-c643-4cba-84f2-872fbf1549bc"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("df598ba2-1d47-47ab-a5e8-afc389bc5c61"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("df598ba2-1d47-47ab-a5e8-afc389bc5c61"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("e149dfb1-50d2-4011-aa4a-d2762d3ee0b2"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("e149dfb1-50d2-4011-aa4a-d2762d3ee0b2"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("e1e2bb25-5a0f-43bd-b8c7-270b662400d0"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("e1e2bb25-5a0f-43bd-b8c7-270b662400d0"), new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), null },
                    { new Guid("e4e66fe3-a104-4178-879e-d7fb7d692eed"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("e4e66fe3-a104-4178-879e-d7fb7d692eed"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("e776bd55-3d23-4470-bddc-28588fc6dece"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("e776bd55-3d23-4470-bddc-28588fc6dece"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("e8b7d22d-f22f-4ffb-b5e5-21dda2f8c868"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("e8b7d22d-f22f-4ffb-b5e5-21dda2f8c868"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("e95c5c9c-bcc0-4be1-be9e-8b4d54063789"), new Guid("925a19d7-797d-4ca6-b0bf-9796fbe5fb0e"), null },
                    { new Guid("e95c5c9c-bcc0-4be1-be9e-8b4d54063789"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("e960ff78-2b1e-4ca6-90ca-02dd2b8f37c6"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("e960ff78-2b1e-4ca6-90ca-02dd2b8f37c6"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("ea063f97-df4b-4871-b32b-0871d008788e"), new Guid("1d1fd882-f140-495c-a895-324a3d9fa7f8"), null },
                    { new Guid("ea063f97-df4b-4871-b32b-0871d008788e"), new Guid("d7ab6cd4-8a5d-4213-b3c8-51e6fc6d9ac5"), null },
                    { new Guid("ead07634-fe16-45df-b612-5d5d21109ca2"), new Guid("8dfa2fad-3122-49b7-8fc6-585929069073"), null },
                    { new Guid("ead07634-fe16-45df-b612-5d5d21109ca2"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("eed50d58-3ab8-4283-a1ae-966e8b1f6604"), new Guid("6ab8e897-8a44-4771-a8f2-37f9fef98c6d"), null },
                    { new Guid("eed50d58-3ab8-4283-a1ae-966e8b1f6604"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("ef0d6ef3-af09-4936-8bce-af22fcbfa856"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("ef0d6ef3-af09-4936-8bce-af22fcbfa856"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("efed9868-9e74-4553-b555-b8409a17ce20"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("efed9868-9e74-4553-b555-b8409a17ce20"), new Guid("ec5eede9-f429-45e8-9fda-578efb3cf3a6"), null },
                    { new Guid("f2e427e8-d875-4789-8055-c600766d7c12"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("f2e427e8-d875-4789-8055-c600766d7c12"), new Guid("ad9ab416-9d10-49a1-b212-508b622e04ee"), null },
                    { new Guid("f5db6793-96a0-4f2a-8a9d-81c2657d8d37"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("f5db6793-96a0-4f2a-8a9d-81c2657d8d37"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null },
                    { new Guid("f7f65be5-d6fb-477b-842e-d6be6f8ac26e"), new Guid("3299280b-8d83-4961-adf5-0bc666efd89e"), null },
                    { new Guid("f7f65be5-d6fb-477b-842e-d6be6f8ac26e"), new Guid("c469b6e6-3e49-4ffa-9ebf-01b89630f33f"), null },
                    { new Guid("fa7ae8d6-ece4-4c6f-a70e-3118e368940f"), new Guid("187855a5-5ff7-41ce-8534-1d006112a4f5"), null },
                    { new Guid("fa7ae8d6-ece4-4c6f-a70e-3118e368940f"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("fb3c4b69-a42f-4cc1-830e-d57d65020828"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("fb3c4b69-a42f-4cc1-830e-d57d65020828"), new Guid("f9f98420-505b-4883-bc57-3cb9d52b1507"), null },
                    { new Guid("fd03d2e9-ec8e-47c2-a6e2-a9d0a030ea4a"), new Guid("1b9125b1-2f8f-4780-a41c-5e6450417034"), null },
                    { new Guid("fd03d2e9-ec8e-47c2-a6e2-a9d0a030ea4a"), new Guid("ca1a1c51-d89b-4827-b62f-125ff194837a"), null },
                    { new Guid("ffea9158-96c5-4349-bc70-2732e43daf23"), new Guid("83264ec8-1692-4868-a8a5-7d30a14016e0"), null },
                    { new Guid("ffea9158-96c5-4349-bc70-2732e43daf23"), new Guid("b25cfb80-426d-44c9-8f50-955e96bb7ad1"), null }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4af100cd-4b27-47f0-ba9a-db091fd9a41d"), new Guid("01274628-e60b-4e40-a02a-1b002dfe9269") },
                    { new Guid("3b544e54-7fa2-4ef2-b2fb-d4d267cff777"), new Guid("0ea213f4-8aea-4ed1-876f-40257227b232") },
                    { new Guid("ab8125cc-37f2-4873-b142-425f44c399c4"), new Guid("42be8eb2-a27d-47c2-91f0-5bf5826fb4e1") },
                    { new Guid("b48fe0bd-282e-441b-872f-85ec090abd3f"), new Guid("56a54392-10b1-43de-b805-c4c1fc89370d") },
                    { new Guid("40a6bd3a-ad51-4598-a544-a33950409479"), new Guid("6e34dec9-0bca-4274-aee3-f068bb3af978") },
                    { new Guid("d047a105-8946-448c-b452-1f18fcf4f37c"), new Guid("86d598d5-1bb2-4b22-b198-3b3bfe53ce8f") },
                    { new Guid("bdca6249-d8e2-4f08-87d7-66debe322e79"), new Guid("88c5a449-aa9d-46ff-a033-e0b94ad9434a") },
                    { new Guid("29f93fdc-4763-4eea-8227-4f96b5dd54b9"), new Guid("93303dce-8c67-4254-aa98-c40b4515e10c") },
                    { new Guid("7d06385b-5454-43a8-a02e-13fe936b6f11"), new Guid("b4c9bf4b-20a7-4b1c-93b4-d21901e47577") },
                    { new Guid("135d4e2f-1592-4960-86b7-a4ffb2b9f399"), new Guid("bc6a65f4-54e1-440e-815a-a1ba26e172ec") }
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
