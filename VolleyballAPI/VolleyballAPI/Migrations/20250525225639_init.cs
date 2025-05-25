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
                    Auth0Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), "Budapest, Bogdánfy u. 12, 1117", "BME Sporttelep" },
                    { new Guid("23e0dda0-cc35-4006-9e80-756234d00257"), "Location Addr 9", "Location9" },
                    { new Guid("402334bd-18a2-4130-a526-c9df6301c8da"), "Location Addr 10", "Location10" },
                    { new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), "Budapest, Bertalan Lajos u. 4-6, 1111", "BME Sportközpont" },
                    { new Guid("8cf00373-8c73-4f76-8cb2-78a4433c8d15"), "Location Addr 7", "Location7" },
                    { new Guid("92cbe71d-d92a-4412-9171-eb51107eb32f"), "Location Addr 8", "Location8" },
                    { new Guid("ae4b0360-b679-4d51-8a24-9d288884ba6c"), "Location Addr 6", "Location6" },
                    { new Guid("c8f57911-dd60-4ff5-9e6f-9b67e02ed18d"), "Location Addr 4", "Location4" },
                    { new Guid("cfaf4961-2b92-4108-903d-31053993a84c"), "Location Addr 5", "Location5" },
                    { new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), "1114 Budapest, Villányi út 27.", "Budai Ciszterci Szent Imre Gimnázium Tornacsarnok" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Auth0Id", "Birthday", "Email", "Gender", "Name", "Phone", "PictureLink", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("43ebbdc5-7075-4460-9356-5fd206c5aa16"), "auth0|mockuser8", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(2011), "user8@user.com", 0, "Name 8", "893935", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("4d9ddbb7-15d7-4e51-bb46-136364d9ddab"), "auth0|mockuser2", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1994), "user2@user.com", 1, "Aranka", "965463", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("5e1099ac-c8ea-41bc-8103-a62e3ea347f7"), "auth0|mockuser10", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(2017), "user10@user.com", 0, "Name 10", "13556", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("6b19c72a-7879-4f7a-89f7-034a924f8905"), "auth0|mockuser7", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(2008), "user7@user.com", 1, "Felícia", "32134", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 2 },
                    { new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), "auth0|mockuser1", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1989), "user1@user.com", 0, "Jancsi", "34214124", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 2, 3 },
                    { new Guid("87bd32d4-4dee-448d-bdba-2f716d83c7ff"), "auth0|mockuser4", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1999), "user4@user.com", 0, "Kristóf", "83568", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("8e6cfa8a-e53e-438b-91ff-db102a4cc412"), "auth0|mockuser9", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(2014), "user9@user.com", 0, "Name 9", "2716717", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("936b28a3-ae9b-446f-9ac6-b33c98c716ce"), "auth0|mockuser5", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(2002), "user5@user.com", 0, "Lajos", "54337", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 4, 2 },
                    { new Guid("e7bcc845-be79-4ee5-b541-fdbb15afbd46"), "auth0|mockuser6", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(2005), "user6@user.com", 0, "Péter", "4221", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("f448a680-4563-46f9-acb3-e63fd391f5c8"), "auth0|mockuser3", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1997), "user3@user.com", 0, "Dani", "123555", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId", "PictureLink" },
                values: new object[,]
                {
                    { new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), "Description Team 5", new Guid("cfaf4961-2b92-4108-903d-31053993a84c"), "Team 5", new Guid("f448a680-4563-46f9-acb3-e63fd391f5c8"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" },
                    { new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), "Description Team 15", new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), "Team 15", new Guid("e7bcc845-be79-4ee5-b541-fdbb15afbd46"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), "Description Team 4", new Guid("c8f57911-dd60-4ff5-9e6f-9b67e02ed18d"), "Team 4", new Guid("87bd32d4-4dee-448d-bdba-2f716d83c7ff"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                    { new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), "Description Team 8", new Guid("92cbe71d-d92a-4412-9171-eb51107eb32f"), "Team 8", new Guid("43ebbdc5-7075-4460-9356-5fd206c5aa16"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                    { new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4"), "Description Team 12", new Guid("c8f57911-dd60-4ff5-9e6f-9b67e02ed18d"), "Team 12", new Guid("f448a680-4563-46f9-acb3-e63fd391f5c8"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), "Description Team 14", new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), "Team 14", new Guid("936b28a3-ae9b-446f-9ac6-b33c98c716ce"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), "Description Team 9", new Guid("23e0dda0-cc35-4006-9e80-756234d00257"), "Team 9", new Guid("8e6cfa8a-e53e-438b-91ff-db102a4cc412"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" },
                    { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), "Description Team 1", new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), "Team 1", new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" },
                    { new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), "Description Team 16", new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), "Team 16", new Guid("6b19c72a-7879-4f7a-89f7-034a924f8905"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), "Description Team 10", new Guid("c8f57911-dd60-4ff5-9e6f-9b67e02ed18d"), "Team 10", new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" },
                    { new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), "Description Team 7", new Guid("8cf00373-8c73-4f76-8cb2-78a4433c8d15"), "Team 7", new Guid("6b19c72a-7879-4f7a-89f7-034a924f8905"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                    { new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71"), "Description Team 17", new Guid("c8f57911-dd60-4ff5-9e6f-9b67e02ed18d"), "Team 17", new Guid("43ebbdc5-7075-4460-9356-5fd206c5aa16"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b"), "Description Team 13", new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), "Team 13", new Guid("87bd32d4-4dee-448d-bdba-2f716d83c7ff"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), "Description Team 11", new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), "Team 11", new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" },
                    { new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), "Description Team 3", new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), "Team 3", new Guid("f448a680-4563-46f9-acb3-e63fd391f5c8"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                    { new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), "Description Team 6", new Guid("ae4b0360-b679-4d51-8a24-9d288884ba6c"), "Team 6", new Guid("e7bcc845-be79-4ee5-b541-fdbb15afbd46"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                    { new Guid("f50566e5-393d-4758-8422-a59261184b56"), "Description Team 2", new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), "Team 2", new Guid("4d9ddbb7-15d7-4e51-bb46-136364d9ddab"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Courts", "Date", "Description", "EntryDeadline", "LocationId", "MaxTeamsPerLevel", "Name", "Organizer", "PictureLink", "PriceType", "RegistrationPolicy", "TeamPolicy", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 2, 2, new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1783), "Description Tournament 1", new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1792), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), "[8]", "Fanatics 8 csapat körbejátszás", "Organizer 1", "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg", 16, "Registration Policy 1", "Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 0 },
                    { new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 5, 3, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), "[10,7]", "Műegyetemi röplabda torna A10 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 1 },
                    { new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 5, 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szeretettel várunk titeket a MűEgyetemi Röplabda Tornánk következő eseményén. A torna sorozat havonta 1 alkalommal kerül megrendezésre az őszi félévben.\r\nA torna célja a MűEgyetemi és általánosságban a röplabda sport népszerűsítése, minél szélesebb körben.\r\nHa szeretnétek részt venni egy kiváló hangulatú, egésznapos röplabda élményben, akkor itt a helyetek!\r\nAmire számíthattok:\r\n- Minden tornán az első 4 csapatot (kategóriánként) díjazzuk külnféle ajándékokkal!\r\n- Minden kategória első 3 helyezett egyedi érmet, az első helyezett csapat pedig egyedi kupát is kap.\r\n- A tornán minden kategóriában a csapatok szavazatai alapján megválasztjuk a legjobb ütő, mezőny és feladó játékost, akik különdíjban részesülnek.\r\n- A torna hangulatának megalapozásához az egész csarnokot behangosítjuk.\r\n- A tornán a mérkőzések eredményeit online követheted majd.", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), "[9,7]", "Műegyetemi röplabda torna A9 B7 ", "MŰER szervező csapata", "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg", 16, "Nevezési díj:\r\nTeljes ár: 33 000 HUF/csapat\r\nKedvezményes ár: 30 000 HUF/csapat\r\n\r\nA kedvezményes ár az alábbi csapatokra érvényes:\r\n\r\nHallgatói csapat:\r\nA csapatban legalább 6 aktív hallgató van (bármely felsőoktatási intézmény) és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nBME csapat:\r\nA csapatban legalább 5 aktív BME hallgató van és a csapat a nevezés leadásakor feltüntette a hallgatók intézményeit.\r\n\r\nA csapat tagok a tornán tudják igazolni a hallgatói jogviszonyt (érvényes diákigazolvánnyal vagy hallgatói jogviszony igazolással)\r\n\r\nHa valamelyik csapatról kiderül, hogy mégsem jogosult a kedvezményre, abban az esetben a teljes árat ki kell fizetni!", "Egy csapat minimum 6, maximum 8 játékosból állhat. A csapatok és kategóriák között NINCS átjátszás. (Ez alól kivételt képeznek a vis-major esetek, melyeknél az ellenfelek és rendező közös beleegyezése szükséges az átjátszáshoz.) Az aktuális idényre érvényes játékengedéllyel rendelkező NBI.-es játékos nem vehet részt az eseményen játékosként. A mérkőzéseket az érvényben lévő teremröplabda verseny-szabályai szerint kell játszani. Minden csapatban legalább 3 fő női játékosnak folyamatosan a pályán kell lennie.", 2 }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "MatchState", "Points", "RefereeId", "StartTime", "TournamentId", "TournamentType" },
                values: new object[,]
                {
                    { new Guid("01ff7d42-e59b-432d-8dfe-8f9297000192"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("0752f361-e4d7-4300-9b20-ecf938f801cb"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(581), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("0998440e-7ec7-4832-afe1-1a353caa3dc3"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(625), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("09e3b679-c4d6-4997-800c-1c422b098985"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(446), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("0abd0e86-7185-4a25-89dc-abb4c4f80fc2"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(537), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("0e14e7f4-fe98-4540-abd1-d6c9bad2bb6f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("0fbd023c-b20d-41cf-9ab6-bef3c8c83d19"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("134cb2cc-5c6f-467b-a493-f88a9912e8b7"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("14a87ec0-de74-4e01-b9e4-d44e531660c7"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("14e4a3e9-ba24-4b5f-a65f-55380727140e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("168cf034-f74b-4cfe-8b8e-05648baf5eb5"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(516), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("16d4847d-3135-4307-a776-03fa8c0520d2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("17ad785d-a61b-4bd9-9c73-9c53d52fa5d2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("1a910021-d661-4d0c-b4d3-ac2fdbb6ab34"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(562), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("1b05fe95-0802-4585-8b99-0e61fae99ee7"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("1c045f48-db37-497d-8e17-8b06c1478b6e"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(642), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("1e40e51e-243d-43c9-9ec3-a90237055381"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("25b74a54-89be-4ba7-8f04-c4218f9bd767"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("27732bee-723f-471e-980b-f35a67874f6f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("2c879b1d-c59f-4f29-9ab6-4641c1ce567c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("2ceb1e8d-1a32-40b0-b2f2-bc2a5fce4f00"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("315f85be-8402-435f-9046-34a938e1858f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("32dfd9dc-7377-4253-8fbc-29354beb9d71"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("348c958b-cf9d-4772-a29e-880408123c5e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("35c9ba80-3c8b-4bdf-a653-3c79874b765b"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("35e7a776-e886-4f0c-84f0-75ec9bac160a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("36a84ddb-97af-405e-86fe-e64dac71aa65"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("3790469f-c374-4ec7-a27b-0aed9ace4703"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("38141ac7-0209-43be-a537-ca28890e3c91"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("3881d141-e3c7-4429-8c02-41e0a82184a8"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("39ca315c-389a-462f-921b-beb093b40b5d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("3b12593a-682f-4b76-91ae-2ccc6716e3e5"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("3b9555cf-5920-4600-9e34-5fcb0f9ac4dd"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4"), new DateTime(2024, 5, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("3e188074-cbf1-46e7-80a7-ad0931d523f6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("3f3e53ac-13eb-4c77-ab65-58fad84da956"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("3f5dc0aa-2771-4197-b3fa-e4fdd1532397"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("416f2e5f-44e8-4d6d-972f-22323b0cafa7"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("42b10c25-3ed3-4fa6-8170-9612af0fef58"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("4378d9ca-d054-4a11-ae3e-b45cbebd842e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("45c3b283-472e-4f4b-8751-9f0817422b18"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("465f84d5-dbbc-41e4-b68e-ea790e97cbb8"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("4e48691e-6c46-411e-a09f-686b11e5cd96"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("51f4822e-6508-496c-9e3e-61210eeec5ba"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(609), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("51f5fcd3-a3f6-4386-9887-080e50a43f2c"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(571), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("5337882b-27fa-4a8e-81cb-1883204998e0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("5354d7d7-a429-474d-a70e-f3e92b08de25"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("53be045d-3689-429f-9104-31dfbd72c7c9"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(587), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("5651801d-8218-4de9-a4f1-cf3d50e10cf0"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("57276e2a-a1ba-424a-8127-e02a3f1cb1a1"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("5affee00-84d2-42df-be1f-973eca9b0559"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("5c190e64-2248-47fa-aeb2-db923768536c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("5caaf593-8c39-41dc-84fe-0e432bf5ba69"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("5e32c141-7c61-4f0c-b75c-1a64afe8eead"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(552), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("5f46bd97-2a1f-4ce0-a023-d794568652e9"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("62c494cf-7ea3-46d9-a9a1-54e34df2f439"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(598), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("63a749af-2bf8-443b-ab2c-4faa8cf1b702"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("649c9a5b-18cd-40e9-a3af-dfe4f35e2ea6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("64d0338a-d745-40c0-aaf0-8799e83a9a5b"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(452), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("67ed6658-d9a2-4d33-8d9c-f33f005d04a3"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("68692381-293d-4aca-883b-70ca8b80207c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("6952292f-e85b-4399-93a9-4931d9a37cf7"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("6e8db7f1-3b21-46fe-beaf-fb2c49c79ce3"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("709c6b8b-66c4-462f-9275-44ae7e6e99db"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2025, 4, 26, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("743358f1-72d5-4cb5-83c9-570dcbbc44b1"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2024, 5, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("74407694-f7f4-4c4d-a29a-47b151b388e2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("7449804a-7c49-458b-8943-fdd3842ae64c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("74f33371-971d-40ce-8600-744b5dafecb4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), new DateTime(2024, 5, 18, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("7572f3f0-56bb-4223-923d-8b4e95b670d9"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2024, 5, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("7864f1d5-0c04-4fcc-9486-cf1ac3593fa6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("79c78b33-dfae-46af-b1fa-2bed3c23e662"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("7a77d39a-00be-4397-9896-4ec436420122"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("7adb32e1-0356-4939-97c4-b69057b307d6"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("7b741fc2-5b29-4f83-bf91-95c2323c625b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), new DateTime(2025, 4, 26, 14, 10, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("7cbe7172-d34a-4e3f-bb40-907e10878982"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2024, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("7e7cc446-a264-4cf7-a4b7-7f89b147ff9b"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(542), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("8129c7d8-a196-4045-b6a5-47dd416a7f29"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("872748e0-7dde-47b4-bd03-29aff326903b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("878448c6-ef13-4cb5-865d-61247eabdb86"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("87e68fbe-34cf-49e8-a62c-ae50a0a5ec2c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("8831c45c-0f9b-4282-9b30-ab03de143b5e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("8a3642a1-5edd-4ef6-ab28-fdfb5723cb7e"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("8bc58efd-481c-48b3-ab4e-6ddc72a3b161"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("8bcf7a98-47e6-4b6e-9ec6-f837bfcb93ab"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(577), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("8ec52ca6-1152-48d9-8c86-3f9bf18d9df4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), new DateTime(2024, 5, 18, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("8f8caaa4-87d8-430c-90fa-2fcc4e285a89"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(527), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("90f9eff1-7462-4460-abf0-fd58c639a3f2"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(532), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("9266f906-e224-4955-a923-9ab1c2f8f9e0"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(522), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("930e8e9d-3801-40ed-95b2-8c6f6e8ad74b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("96250265-201d-43db-8701-5598417b7869"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("9a4f701e-5b5c-42e3-8c2b-ba257224593f"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("9b22aa0c-b144-4cbe-bd86-34fdeee75969"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(595), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("9d2ab844-c8c5-4a4a-ac97-864ed20e301e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2025, 4, 26, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("9f77f20b-99a7-4655-aff3-5f28610f7aef"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("a4c289ed-4ee0-46b9-85d9-dfffe6c1cb72"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("a6dc3fb1-ff35-4ac1-bd80-e109f5315bad"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("af56809e-a400-42e5-84eb-7fa1354bf84e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("b008b5f9-8c04-4cf8-87e5-cfa090eee183"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4"), new DateTime(2025, 4, 26, 13, 10, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("bcbf1db6-8f2a-4522-a64c-55d80941d1c2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("bd126757-3d4b-4884-bfda-cf9368aac839"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("be984221-017f-4606-a9c5-77db824ec4f8"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("bfede7c6-62fa-4815-955d-df6f0432d3ee"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("c099e989-35c7-48d2-b4e0-84db5075708f"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("c38a9715-b20c-4ce2-86ed-97602cf43e10"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("c61a97cd-f197-486c-a564-fbbf98fa58a3"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), new DateTime(2024, 5, 18, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("c62bcd16-4588-4488-a9b2-4dba6c689ab5"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(634), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("c6a87a97-b426-4558-95fd-00f3922c1552"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2024, 5, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("c70bd1a7-5eb0-48c8-8576-228300c50d7f"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(370), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("c9379f5b-313b-4f8d-a2b8-d476c34b0190"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), new DateTime(2024, 5, 18, 14, 25, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("c9569e0a-1790-4050-8e74-8ad9ff60c991"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("c965b174-36ee-482c-b0f8-f4ea80d080c4"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2024, 5, 18, 15, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("ca48ff03-b5fb-452a-b98c-4ace2e98f1e2"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("cd470026-b4b3-41b5-9932-d7444e6d1cc1"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("ce60fca5-5085-4393-8d97-3a291797f0e2"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(567), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("ceaba111-2f8b-4cf6-afdf-ff2919df5220"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), new DateTime(2025, 4, 26, 9, 50, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("cebcba4f-b44e-433f-84e7-ed1a0ff3a136"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(604), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("d14f0cc5-e7cd-42f9-bd74-12b58a4c5349"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("d383a201-9eb6-4fef-b44d-5fe79927f511"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), new DateTime(2025, 4, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("d778f622-9f8b-4696-a045-728f13930a5b"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2025, 4, 26, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("d7a0c5d7-f267-4280-a571-b42e7696a256"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71"), new DateTime(2025, 4, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("d8cadc4b-b69e-43a6-8e50-212ab2c368d6"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2024, 5, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("d90f25e7-866d-4ce4-b400-b368a04f265c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71"), new DateTime(2025, 4, 26, 10, 15, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("da82020c-b2d5-4941-903d-85d6601c6b8a"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("df854b01-0e0a-4b8b-a9d4-29631669fc8c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), new DateTime(2024, 5, 18, 16, 55, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("e0eca0ba-5754-48cc-801f-2f5614fbea1c"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2024, 5, 18, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("e1a0ffca-c61b-4543-b477-510fa9fddf78"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2024, 5, 18, 16, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("e2d8f2b5-ad68-4d21-9cba-1509bb329548"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), new DateTime(2025, 4, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("e484f52a-7550-4449-af60-6540dffaab70"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("e590c84d-69ea-4140-b0ed-a6d39a5b18ee"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4"), new DateTime(2025, 4, 26, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("e5c573b9-3abc-4049-91be-412c76a5216e"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2025, 4, 26, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("e62c40a7-1cc8-4e2e-809d-5efbac3e3bf0"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("e64cea8c-46c0-4f8d-8a95-1554cd29aee3"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), new DateTime(2024, 5, 18, 10, 40, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("eaa41f4a-94ef-4072-b84b-21eab78bb8c9"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), new DateTime(2025, 4, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("eb6d5541-c5dc-4ac1-9807-5f1445ad09dc"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), new DateTime(2025, 4, 26, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("ed99c3b8-b3d4-4e30-a5f6-ac0bde09e0f9"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4"), new DateTime(2024, 5, 18, 14, 50, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("f24e2664-2e8a-44f4-9e7a-7697d14d05aa"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("f37d0750-9516-498d-888a-99c2bfc684da"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new DateTime(2025, 4, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("f423afea-b3e2-425d-8d90-912d832a69e7"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(557), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("f6a06e42-11dd-44fc-bccf-004811a42544"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), new DateTime(2025, 4, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("f70874c1-0aca-4b3c-92e6-7bd5f774fb1c"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2025, 4, 26, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("f729c0bf-3876-41d3-9ba3-1d15e7156de3"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2024, 5, 18, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("f7665911-0a79-4d7e-b065-7b47262ff0a1"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(617), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("f7a36c59-46a3-42ba-8b8f-b4e5e222abb2"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), new DateTime(2024, 5, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("f7c14063-f759-4eb5-ae40-03053cd2c014"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), new DateTime(2025, 4, 26, 11, 5, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("f7e00ce2-734a-4fdb-95df-ed2a8058eccd"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new DateTime(2025, 4, 26, 14, 35, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("f85634a2-0eb2-4a45-b626-eb4f5f2a1e31"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(591), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("f8b01f0d-8854-4942-a306-a245b83d07f8"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("f50566e5-393d-4758-8422-a59261184b56"), new DateTime(2025, 4, 26, 13, 35, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("f9450df7-fc63-49f7-bfb8-3a5960d49aff"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b"), new DateTime(2025, 4, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("fa525ae7-1723-4f17-a6f6-2ce63a5c11ae"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(547), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 },
                    { new Guid("fd457554-4ed2-48c8-98c3-079cc6c67c0a"), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), 0, "[0,0]", new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new DateTime(2025, 4, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21"), 1 },
                    { new Guid("fe332971-e229-41ec-b806-94bc5bbc974d"), new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), 0, "[0,0]", new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), new DateTime(2024, 5, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6"), 2 },
                    { new Guid("ffd1d3eb-b5e2-4ec7-8dba-cbae0e188273"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(638), new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), 0, "[0,0]", new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b"), 0 }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new Guid("e7bcc845-be79-4ee5-b541-fdbb15afbd46") },
                    { new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), new Guid("f448a680-4563-46f9-acb3-e63fd391f5c8") },
                    { new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new Guid("936b28a3-ae9b-446f-9ac6-b33c98c716ce") },
                    { new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new Guid("8e6cfa8a-e53e-438b-91ff-db102a4cc412") },
                    { new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044") },
                    { new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), new Guid("4d9ddbb7-15d7-4e51-bb46-136364d9ddab") },
                    { new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new Guid("5e1099ac-c8ea-41bc-8103-a62e3ea347f7") },
                    { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new Guid("4d9ddbb7-15d7-4e51-bb46-136364d9ddab") },
                    { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044") },
                    { new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), new Guid("87bd32d4-4dee-448d-bdba-2f716d83c7ff") },
                    { new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), new Guid("5e1099ac-c8ea-41bc-8103-a62e3ea347f7") },
                    { new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new Guid("43ebbdc5-7075-4460-9356-5fd206c5aa16") },
                    { new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71"), new Guid("936b28a3-ae9b-446f-9ac6-b33c98c716ce") },
                    { new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044") },
                    { new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), new Guid("936b28a3-ae9b-446f-9ac6-b33c98c716ce") },
                    { new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new Guid("87bd32d4-4dee-448d-bdba-2f716d83c7ff") },
                    { new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new Guid("6b19c72a-7879-4f7a-89f7-034a924f8905") },
                    { new Guid("f50566e5-393d-4758-8422-a59261184b56"), new Guid("f448a680-4563-46f9-acb3-e63fd391f5c8") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new Guid("5e1099ac-c8ea-41bc-8103-a62e3ea347f7") },
                    { new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new Guid("8e6cfa8a-e53e-438b-91ff-db102a4cc412") },
                    { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044") },
                    { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new Guid("936b28a3-ae9b-446f-9ac6-b33c98c716ce") },
                    { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new Guid("f448a680-4563-46f9-acb3-e63fd391f5c8") },
                    { new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new Guid("43ebbdc5-7075-4460-9356-5fd206c5aa16") },
                    { new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new Guid("6b19c72a-7879-4f7a-89f7-034a924f8905") },
                    { new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new Guid("e7bcc845-be79-4ee5-b541-fdbb15afbd46") },
                    { new Guid("f50566e5-393d-4758-8422-a59261184b56"), new Guid("4d9ddbb7-15d7-4e51-bb46-136364d9ddab") },
                    { new Guid("f50566e5-393d-4758-8422-a59261184b56"), new Guid("87bd32d4-4dee-448d-bdba-2f716d83c7ff") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b") },
                    { new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b") },
                    { new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b") },
                    { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b") },
                    { new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b") },
                    { new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b") },
                    { new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b") },
                    { new Guid("f50566e5-393d-4758-8422-a59261184b56"), new Guid("21f72e4b-8535-4c20-a222-9b0a42396d9b") },
                    { new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("f50566e5-393d-4758-8422-a59261184b56"), new Guid("ab3d23d0-96c6-4a28-9f97-c302c1ae3c21") },
                    { new Guid("230843a7-3291-4a71-a745-c095f697f8ac"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("ece42f76-9175-4a22-8300-ea325a5727aa"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") },
                    { new Guid("f50566e5-393d-4758-8422-a59261184b56"), new Guid("d90c8606-7424-4fa8-910c-d3b70125fdf6") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "CoachId", "Date", "Description", "LocationId", "PictureLink", "PriceType", "TeamId" },
                values: new object[,]
                {
                    { new Guid("1c486dbb-7ca2-4c64-9054-df4ce5f46e6f"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1890), "Training5", new Guid("cfaf4961-2b92-4108-903d-31053993a84c"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg", 5, new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("4111eb95-42c4-4b39-a7a5-5098375bd978"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1934), "Training10", new Guid("402334bd-18a2-4130-a526-c9df6301c8da"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg", 5, new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("577149ff-5d35-4bfe-a13d-390dfb4c1ce6"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1892), "Training6", new Guid("ae4b0360-b679-4d51-8a24-9d288884ba6c"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg", 5, new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("81cacf8b-a5a9-4a31-b8a0-a95ceef8f570"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1897), "Training8", new Guid("92cbe71d-d92a-4412-9171-eb51107eb32f"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg", 5, new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("94c4e751-87af-4642-aec9-0fe57c7f02ea"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1887), "Training4", new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg", 5, new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("b51b154e-921d-4821-9018-34a72490f747"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1885), "Training3", new Guid("04cdb48f-a449-4db4-99ff-4207297fd1fb"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg", 5, new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("bb6df820-ed3c-4853-a70a-096557b36284"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1931), "Training9", new Guid("23e0dda0-cc35-4006-9e80-756234d00257"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg", 5, new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("c4097d86-a05e-41e5-918d-b121617e9753"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1878), "Training1", new Guid("e69f0f5b-b112-4aa2-8a64-12c9caea1c54"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg", 5, new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("e692565d-a6cb-4deb-a340-8fa7ef73276a"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1882), "Training2", new Guid("72e6412e-dc37-4b4c-bf39-05fd8c023da7"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg", 5, new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("f0819aa6-d394-47d5-a88b-68aba94422f3"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044"), new DateTime(2025, 5, 26, 0, 56, 38, 84, DateTimeKind.Local).AddTicks(1895), "Training7", new Guid("8cf00373-8c73-4f76-8cb2-78a4433c8d15"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg", 5, new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("c4097d86-a05e-41e5-918d-b121617e9753"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("01ff7d42-e59b-432d-8dfe-8f9297000192"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("01ff7d42-e59b-432d-8dfe-8f9297000192"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("0752f361-e4d7-4300-9b20-ecf938f801cb"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("0752f361-e4d7-4300-9b20-ecf938f801cb"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("0998440e-7ec7-4832-afe1-1a353caa3dc3"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("0998440e-7ec7-4832-afe1-1a353caa3dc3"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("09e3b679-c4d6-4997-800c-1c422b098985"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("09e3b679-c4d6-4997-800c-1c422b098985"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("0abd0e86-7185-4a25-89dc-abb4c4f80fc2"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("0abd0e86-7185-4a25-89dc-abb4c4f80fc2"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("0e14e7f4-fe98-4540-abd1-d6c9bad2bb6f"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("0e14e7f4-fe98-4540-abd1-d6c9bad2bb6f"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("0fbd023c-b20d-41cf-9ab6-bef3c8c83d19"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("0fbd023c-b20d-41cf-9ab6-bef3c8c83d19"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("134cb2cc-5c6f-467b-a493-f88a9912e8b7"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("134cb2cc-5c6f-467b-a493-f88a9912e8b7"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("14a87ec0-de74-4e01-b9e4-d44e531660c7"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("14a87ec0-de74-4e01-b9e4-d44e531660c7"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("14e4a3e9-ba24-4b5f-a65f-55380727140e"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("14e4a3e9-ba24-4b5f-a65f-55380727140e"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("168cf034-f74b-4cfe-8b8e-05648baf5eb5"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("168cf034-f74b-4cfe-8b8e-05648baf5eb5"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("16d4847d-3135-4307-a776-03fa8c0520d2"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("16d4847d-3135-4307-a776-03fa8c0520d2"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("17ad785d-a61b-4bd9-9c73-9c53d52fa5d2"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("17ad785d-a61b-4bd9-9c73-9c53d52fa5d2"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("1a910021-d661-4d0c-b4d3-ac2fdbb6ab34"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("1a910021-d661-4d0c-b4d3-ac2fdbb6ab34"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("1b05fe95-0802-4585-8b99-0e61fae99ee7"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("1b05fe95-0802-4585-8b99-0e61fae99ee7"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("1c045f48-db37-497d-8e17-8b06c1478b6e"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("1c045f48-db37-497d-8e17-8b06c1478b6e"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("1e40e51e-243d-43c9-9ec3-a90237055381"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("1e40e51e-243d-43c9-9ec3-a90237055381"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("25b74a54-89be-4ba7-8f04-c4218f9bd767"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("25b74a54-89be-4ba7-8f04-c4218f9bd767"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("27732bee-723f-471e-980b-f35a67874f6f"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("27732bee-723f-471e-980b-f35a67874f6f"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("2c879b1d-c59f-4f29-9ab6-4641c1ce567c"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("2c879b1d-c59f-4f29-9ab6-4641c1ce567c"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("2ceb1e8d-1a32-40b0-b2f2-bc2a5fce4f00"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("2ceb1e8d-1a32-40b0-b2f2-bc2a5fce4f00"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("315f85be-8402-435f-9046-34a938e1858f"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("315f85be-8402-435f-9046-34a938e1858f"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("32dfd9dc-7377-4253-8fbc-29354beb9d71"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("32dfd9dc-7377-4253-8fbc-29354beb9d71"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("348c958b-cf9d-4772-a29e-880408123c5e"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("348c958b-cf9d-4772-a29e-880408123c5e"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("35c9ba80-3c8b-4bdf-a653-3c79874b765b"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("35c9ba80-3c8b-4bdf-a653-3c79874b765b"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("35e7a776-e886-4f0c-84f0-75ec9bac160a"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("35e7a776-e886-4f0c-84f0-75ec9bac160a"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("36a84ddb-97af-405e-86fe-e64dac71aa65"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("36a84ddb-97af-405e-86fe-e64dac71aa65"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("3790469f-c374-4ec7-a27b-0aed9ace4703"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("3790469f-c374-4ec7-a27b-0aed9ace4703"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("38141ac7-0209-43be-a537-ca28890e3c91"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("38141ac7-0209-43be-a537-ca28890e3c91"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("3881d141-e3c7-4429-8c02-41e0a82184a8"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("3881d141-e3c7-4429-8c02-41e0a82184a8"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("39ca315c-389a-462f-921b-beb093b40b5d"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("39ca315c-389a-462f-921b-beb093b40b5d"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("3b12593a-682f-4b76-91ae-2ccc6716e3e5"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("3b12593a-682f-4b76-91ae-2ccc6716e3e5"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("3b9555cf-5920-4600-9e34-5fcb0f9ac4dd"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("3b9555cf-5920-4600-9e34-5fcb0f9ac4dd"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("3e188074-cbf1-46e7-80a7-ad0931d523f6"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("3e188074-cbf1-46e7-80a7-ad0931d523f6"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("3f3e53ac-13eb-4c77-ab65-58fad84da956"), new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71") },
                    { new Guid("3f3e53ac-13eb-4c77-ab65-58fad84da956"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("3f5dc0aa-2771-4197-b3fa-e4fdd1532397"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("3f5dc0aa-2771-4197-b3fa-e4fdd1532397"), new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71") },
                    { new Guid("416f2e5f-44e8-4d6d-972f-22323b0cafa7"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("416f2e5f-44e8-4d6d-972f-22323b0cafa7"), new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71") },
                    { new Guid("42b10c25-3ed3-4fa6-8170-9612af0fef58"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("42b10c25-3ed3-4fa6-8170-9612af0fef58"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("4378d9ca-d054-4a11-ae3e-b45cbebd842e"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("4378d9ca-d054-4a11-ae3e-b45cbebd842e"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("45c3b283-472e-4f4b-8751-9f0817422b18"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("45c3b283-472e-4f4b-8751-9f0817422b18"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("465f84d5-dbbc-41e4-b68e-ea790e97cbb8"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("465f84d5-dbbc-41e4-b68e-ea790e97cbb8"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("4e48691e-6c46-411e-a09f-686b11e5cd96"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("4e48691e-6c46-411e-a09f-686b11e5cd96"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("51f4822e-6508-496c-9e3e-61210eeec5ba"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("51f4822e-6508-496c-9e3e-61210eeec5ba"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("51f5fcd3-a3f6-4386-9887-080e50a43f2c"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("51f5fcd3-a3f6-4386-9887-080e50a43f2c"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("5337882b-27fa-4a8e-81cb-1883204998e0"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("5337882b-27fa-4a8e-81cb-1883204998e0"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("5354d7d7-a429-474d-a70e-f3e92b08de25"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("5354d7d7-a429-474d-a70e-f3e92b08de25"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("53be045d-3689-429f-9104-31dfbd72c7c9"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("53be045d-3689-429f-9104-31dfbd72c7c9"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("5651801d-8218-4de9-a4f1-cf3d50e10cf0"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("5651801d-8218-4de9-a4f1-cf3d50e10cf0"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("57276e2a-a1ba-424a-8127-e02a3f1cb1a1"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("57276e2a-a1ba-424a-8127-e02a3f1cb1a1"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("5affee00-84d2-42df-be1f-973eca9b0559"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("5affee00-84d2-42df-be1f-973eca9b0559"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("5c190e64-2248-47fa-aeb2-db923768536c"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("5c190e64-2248-47fa-aeb2-db923768536c"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("5caaf593-8c39-41dc-84fe-0e432bf5ba69"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("5caaf593-8c39-41dc-84fe-0e432bf5ba69"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("5e32c141-7c61-4f0c-b75c-1a64afe8eead"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("5e32c141-7c61-4f0c-b75c-1a64afe8eead"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("5f46bd97-2a1f-4ce0-a023-d794568652e9"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("5f46bd97-2a1f-4ce0-a023-d794568652e9"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("62c494cf-7ea3-46d9-a9a1-54e34df2f439"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("62c494cf-7ea3-46d9-a9a1-54e34df2f439"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("63a749af-2bf8-443b-ab2c-4faa8cf1b702"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("63a749af-2bf8-443b-ab2c-4faa8cf1b702"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("649c9a5b-18cd-40e9-a3af-dfe4f35e2ea6"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("649c9a5b-18cd-40e9-a3af-dfe4f35e2ea6"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("64d0338a-d745-40c0-aaf0-8799e83a9a5b"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("64d0338a-d745-40c0-aaf0-8799e83a9a5b"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("67ed6658-d9a2-4d33-8d9c-f33f005d04a3"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("67ed6658-d9a2-4d33-8d9c-f33f005d04a3"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("68692381-293d-4aca-883b-70ca8b80207c"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("68692381-293d-4aca-883b-70ca8b80207c"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("6952292f-e85b-4399-93a9-4931d9a37cf7"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("6952292f-e85b-4399-93a9-4931d9a37cf7"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("6e8db7f1-3b21-46fe-beaf-fb2c49c79ce3"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("6e8db7f1-3b21-46fe-beaf-fb2c49c79ce3"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("709c6b8b-66c4-462f-9275-44ae7e6e99db"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("709c6b8b-66c4-462f-9275-44ae7e6e99db"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("743358f1-72d5-4cb5-83c9-570dcbbc44b1"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("743358f1-72d5-4cb5-83c9-570dcbbc44b1"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("74407694-f7f4-4c4d-a29a-47b151b388e2"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("74407694-f7f4-4c4d-a29a-47b151b388e2"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("7449804a-7c49-458b-8943-fdd3842ae64c"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("7449804a-7c49-458b-8943-fdd3842ae64c"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("74f33371-971d-40ce-8600-744b5dafecb4"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("74f33371-971d-40ce-8600-744b5dafecb4"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("7572f3f0-56bb-4223-923d-8b4e95b670d9"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("7572f3f0-56bb-4223-923d-8b4e95b670d9"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("7864f1d5-0c04-4fcc-9486-cf1ac3593fa6"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("7864f1d5-0c04-4fcc-9486-cf1ac3593fa6"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("79c78b33-dfae-46af-b1fa-2bed3c23e662"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("79c78b33-dfae-46af-b1fa-2bed3c23e662"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("7a77d39a-00be-4397-9896-4ec436420122"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("7a77d39a-00be-4397-9896-4ec436420122"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("7adb32e1-0356-4939-97c4-b69057b307d6"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("7adb32e1-0356-4939-97c4-b69057b307d6"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("7b741fc2-5b29-4f83-bf91-95c2323c625b"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("7b741fc2-5b29-4f83-bf91-95c2323c625b"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("7cbe7172-d34a-4e3f-bb40-907e10878982"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("7cbe7172-d34a-4e3f-bb40-907e10878982"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("7e7cc446-a264-4cf7-a4b7-7f89b147ff9b"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("7e7cc446-a264-4cf7-a4b7-7f89b147ff9b"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("8129c7d8-a196-4045-b6a5-47dd416a7f29"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("8129c7d8-a196-4045-b6a5-47dd416a7f29"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("872748e0-7dde-47b4-bd03-29aff326903b"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("872748e0-7dde-47b4-bd03-29aff326903b"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("878448c6-ef13-4cb5-865d-61247eabdb86"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("878448c6-ef13-4cb5-865d-61247eabdb86"), new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71") },
                    { new Guid("87e68fbe-34cf-49e8-a62c-ae50a0a5ec2c"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("87e68fbe-34cf-49e8-a62c-ae50a0a5ec2c"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("8831c45c-0f9b-4282-9b30-ab03de143b5e"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("8831c45c-0f9b-4282-9b30-ab03de143b5e"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("8a3642a1-5edd-4ef6-ab28-fdfb5723cb7e"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("8a3642a1-5edd-4ef6-ab28-fdfb5723cb7e"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("8bc58efd-481c-48b3-ab4e-6ddc72a3b161"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("8bc58efd-481c-48b3-ab4e-6ddc72a3b161"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("8bcf7a98-47e6-4b6e-9ec6-f837bfcb93ab"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("8bcf7a98-47e6-4b6e-9ec6-f837bfcb93ab"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("8ec52ca6-1152-48d9-8c86-3f9bf18d9df4"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("8ec52ca6-1152-48d9-8c86-3f9bf18d9df4"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("8f8caaa4-87d8-430c-90fa-2fcc4e285a89"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("8f8caaa4-87d8-430c-90fa-2fcc4e285a89"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("90f9eff1-7462-4460-abf0-fd58c639a3f2"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("90f9eff1-7462-4460-abf0-fd58c639a3f2"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("9266f906-e224-4955-a923-9ab1c2f8f9e0"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("9266f906-e224-4955-a923-9ab1c2f8f9e0"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("930e8e9d-3801-40ed-95b2-8c6f6e8ad74b"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("930e8e9d-3801-40ed-95b2-8c6f6e8ad74b"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("96250265-201d-43db-8701-5598417b7869"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("96250265-201d-43db-8701-5598417b7869"), new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71") },
                    { new Guid("9a4f701e-5b5c-42e3-8c2b-ba257224593f"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("9a4f701e-5b5c-42e3-8c2b-ba257224593f"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("9b22aa0c-b144-4cbe-bd86-34fdeee75969"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("9b22aa0c-b144-4cbe-bd86-34fdeee75969"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("9d2ab844-c8c5-4a4a-ac97-864ed20e301e"), new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71") },
                    { new Guid("9d2ab844-c8c5-4a4a-ac97-864ed20e301e"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("9f77f20b-99a7-4655-aff3-5f28610f7aef"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("9f77f20b-99a7-4655-aff3-5f28610f7aef"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("a4c289ed-4ee0-46b9-85d9-dfffe6c1cb72"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("a4c289ed-4ee0-46b9-85d9-dfffe6c1cb72"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("a6dc3fb1-ff35-4ac1-bd80-e109f5315bad"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("a6dc3fb1-ff35-4ac1-bd80-e109f5315bad"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("af56809e-a400-42e5-84eb-7fa1354bf84e"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("af56809e-a400-42e5-84eb-7fa1354bf84e"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("b008b5f9-8c04-4cf8-87e5-cfa090eee183"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("b008b5f9-8c04-4cf8-87e5-cfa090eee183"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("bcbf1db6-8f2a-4522-a64c-55d80941d1c2"), new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71") },
                    { new Guid("bcbf1db6-8f2a-4522-a64c-55d80941d1c2"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("bd126757-3d4b-4884-bfda-cf9368aac839"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("bd126757-3d4b-4884-bfda-cf9368aac839"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("be984221-017f-4606-a9c5-77db824ec4f8"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("be984221-017f-4606-a9c5-77db824ec4f8"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("bfede7c6-62fa-4815-955d-df6f0432d3ee"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("bfede7c6-62fa-4815-955d-df6f0432d3ee"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("c099e989-35c7-48d2-b4e0-84db5075708f"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("c099e989-35c7-48d2-b4e0-84db5075708f"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("c38a9715-b20c-4ce2-86ed-97602cf43e10"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("c38a9715-b20c-4ce2-86ed-97602cf43e10"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("c61a97cd-f197-486c-a564-fbbf98fa58a3"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("c61a97cd-f197-486c-a564-fbbf98fa58a3"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("c62bcd16-4588-4488-a9b2-4dba6c689ab5"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("c62bcd16-4588-4488-a9b2-4dba6c689ab5"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("c6a87a97-b426-4558-95fd-00f3922c1552"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("c6a87a97-b426-4558-95fd-00f3922c1552"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("c70bd1a7-5eb0-48c8-8576-228300c50d7f"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("c70bd1a7-5eb0-48c8-8576-228300c50d7f"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("c9379f5b-313b-4f8d-a2b8-d476c34b0190"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("c9379f5b-313b-4f8d-a2b8-d476c34b0190"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("c9569e0a-1790-4050-8e74-8ad9ff60c991"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("c9569e0a-1790-4050-8e74-8ad9ff60c991"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("c965b174-36ee-482c-b0f8-f4ea80d080c4"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("c965b174-36ee-482c-b0f8-f4ea80d080c4"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("ca48ff03-b5fb-452a-b98c-4ace2e98f1e2"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("ca48ff03-b5fb-452a-b98c-4ace2e98f1e2"), new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71") },
                    { new Guid("cd470026-b4b3-41b5-9932-d7444e6d1cc1"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("cd470026-b4b3-41b5-9932-d7444e6d1cc1"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("ce60fca5-5085-4393-8d97-3a291797f0e2"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("ce60fca5-5085-4393-8d97-3a291797f0e2"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("ceaba111-2f8b-4cf6-afdf-ff2919df5220"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("ceaba111-2f8b-4cf6-afdf-ff2919df5220"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("cebcba4f-b44e-433f-84e7-ed1a0ff3a136"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("cebcba4f-b44e-433f-84e7-ed1a0ff3a136"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("d14f0cc5-e7cd-42f9-bd74-12b58a4c5349"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("d14f0cc5-e7cd-42f9-bd74-12b58a4c5349"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("d383a201-9eb6-4fef-b44d-5fe79927f511"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("d383a201-9eb6-4fef-b44d-5fe79927f511"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("d778f622-9f8b-4696-a045-728f13930a5b"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("d778f622-9f8b-4696-a045-728f13930a5b"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("d7a0c5d7-f267-4280-a571-b42e7696a256"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("d7a0c5d7-f267-4280-a571-b42e7696a256"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("d8cadc4b-b69e-43a6-8e50-212ab2c368d6"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("d8cadc4b-b69e-43a6-8e50-212ab2c368d6"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("d90f25e7-866d-4ce4-b400-b368a04f265c"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("d90f25e7-866d-4ce4-b400-b368a04f265c"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("da82020c-b2d5-4941-903d-85d6601c6b8a"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("da82020c-b2d5-4941-903d-85d6601c6b8a"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("df854b01-0e0a-4b8b-a9d4-29631669fc8c"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("df854b01-0e0a-4b8b-a9d4-29631669fc8c"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("e0eca0ba-5754-48cc-801f-2f5614fbea1c"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("e0eca0ba-5754-48cc-801f-2f5614fbea1c"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("e1a0ffca-c61b-4543-b477-510fa9fddf78"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("e1a0ffca-c61b-4543-b477-510fa9fddf78"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("e2d8f2b5-ad68-4d21-9cba-1509bb329548"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("e2d8f2b5-ad68-4d21-9cba-1509bb329548"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("e484f52a-7550-4449-af60-6540dffaab70"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("e484f52a-7550-4449-af60-6540dffaab70"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("e590c84d-69ea-4140-b0ed-a6d39a5b18ee"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("e590c84d-69ea-4140-b0ed-a6d39a5b18ee"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("e5c573b9-3abc-4049-91be-412c76a5216e"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("e5c573b9-3abc-4049-91be-412c76a5216e"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("e62c40a7-1cc8-4e2e-809d-5efbac3e3bf0"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("e62c40a7-1cc8-4e2e-809d-5efbac3e3bf0"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("e64cea8c-46c0-4f8d-8a95-1554cd29aee3"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("e64cea8c-46c0-4f8d-8a95-1554cd29aee3"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("eaa41f4a-94ef-4072-b84b-21eab78bb8c9"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("eaa41f4a-94ef-4072-b84b-21eab78bb8c9"), new Guid("3b3bc298-7381-4f81-a582-dd12dccc5b0a") },
                    { new Guid("eb6d5541-c5dc-4ac1-9807-5f1445ad09dc"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("eb6d5541-c5dc-4ac1-9807-5f1445ad09dc"), new Guid("387b91cd-5a9f-4fd9-9ff4-c0074f2514d4") },
                    { new Guid("ed99c3b8-b3d4-4e30-a5f6-ac0bde09e0f9"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("ed99c3b8-b3d4-4e30-a5f6-ac0bde09e0f9"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("f24e2664-2e8a-44f4-9e7a-7697d14d05aa"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("f24e2664-2e8a-44f4-9e7a-7697d14d05aa"), new Guid("f50566e5-393d-4758-8422-a59261184b56") },
                    { new Guid("f37d0750-9516-498d-888a-99c2bfc684da"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("f37d0750-9516-498d-888a-99c2bfc684da"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("f423afea-b3e2-425d-8d90-912d832a69e7"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("f423afea-b3e2-425d-8d90-912d832a69e7"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("f6a06e42-11dd-44fc-bccf-004811a42544"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("f6a06e42-11dd-44fc-bccf-004811a42544"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("f70874c1-0aca-4b3c-92e6-7bd5f774fb1c"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("f70874c1-0aca-4b3c-92e6-7bd5f774fb1c"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("f729c0bf-3876-41d3-9ba3-1d15e7156de3"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("f729c0bf-3876-41d3-9ba3-1d15e7156de3"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("f7665911-0a79-4d7e-b065-7b47262ff0a1"), new Guid("6c90c5b4-49f7-4582-a446-3b499b301e45") },
                    { new Guid("f7665911-0a79-4d7e-b065-7b47262ff0a1"), new Guid("a6d2e16e-e50d-452d-9da9-1183eab00931") },
                    { new Guid("f7a36c59-46a3-42ba-8b8f-b4e5e222abb2"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("f7a36c59-46a3-42ba-8b8f-b4e5e222abb2"), new Guid("b1a33950-5e7d-4a5e-8645-455878c1c15b") },
                    { new Guid("f7c14063-f759-4eb5-ae40-03053cd2c014"), new Guid("7398add0-abf0-41e8-ad73-405bb2457cd9") },
                    { new Guid("f7c14063-f759-4eb5-ae40-03053cd2c014"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("f7e00ce2-734a-4fdb-95df-ed2a8058eccd"), new Guid("2c6b948c-37f6-4eff-8311-6488d2140c81") },
                    { new Guid("f7e00ce2-734a-4fdb-95df-ed2a8058eccd"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("f85634a2-0eb2-4a45-b626-eb4f5f2a1e31"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("f85634a2-0eb2-4a45-b626-eb4f5f2a1e31"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("f8b01f0d-8854-4942-a306-a245b83d07f8"), new Guid("48145305-ad4c-4044-b3e3-2dbc204ecadf") },
                    { new Guid("f8b01f0d-8854-4942-a306-a245b83d07f8"), new Guid("a8121a72-e2ca-4720-8bb3-8aa14600af71") },
                    { new Guid("f9450df7-fc63-49f7-bfb8-3a5960d49aff"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("f9450df7-fc63-49f7-bfb8-3a5960d49aff"), new Guid("be959a6e-80be-4c8e-971d-45d5ca9b066d") },
                    { new Guid("fa525ae7-1723-4f17-a6f6-2ce63a5c11ae"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("fa525ae7-1723-4f17-a6f6-2ce63a5c11ae"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") },
                    { new Guid("fd457554-4ed2-48c8-98c3-079cc6c67c0a"), new Guid("2f055e8d-cba1-4687-a41b-46939ece41b2") },
                    { new Guid("fd457554-4ed2-48c8-98c3-079cc6c67c0a"), new Guid("e3a68fcd-914f-4103-9475-a80c51c6a744") },
                    { new Guid("fe332971-e229-41ec-b806-94bc5bbc974d"), new Guid("28f3b969-1cb2-4aaa-ba5c-7516696a1dc0") },
                    { new Guid("fe332971-e229-41ec-b806-94bc5bbc974d"), new Guid("8078e993-9f74-46e4-acac-c04c8969bdf4") },
                    { new Guid("ffd1d3eb-b5e2-4ec7-8dba-cbae0e188273"), new Guid("230843a7-3291-4a71-a745-c095f697f8ac") },
                    { new Guid("ffd1d3eb-b5e2-4ec7-8dba-cbae0e188273"), new Guid("ece42f76-9175-4a22-8300-ea325a5727aa") }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("81cacf8b-a5a9-4a31-b8a0-a95ceef8f570"), new Guid("43ebbdc5-7075-4460-9356-5fd206c5aa16") },
                    { new Guid("e692565d-a6cb-4deb-a340-8fa7ef73276a"), new Guid("4d9ddbb7-15d7-4e51-bb46-136364d9ddab") },
                    { new Guid("4111eb95-42c4-4b39-a7a5-5098375bd978"), new Guid("5e1099ac-c8ea-41bc-8103-a62e3ea347f7") },
                    { new Guid("f0819aa6-d394-47d5-a88b-68aba94422f3"), new Guid("6b19c72a-7879-4f7a-89f7-034a924f8905") },
                    { new Guid("c4097d86-a05e-41e5-918d-b121617e9753"), new Guid("7af5962a-323d-4c4a-9aab-aa39f4055044") },
                    { new Guid("94c4e751-87af-4642-aec9-0fe57c7f02ea"), new Guid("87bd32d4-4dee-448d-bdba-2f716d83c7ff") },
                    { new Guid("bb6df820-ed3c-4853-a70a-096557b36284"), new Guid("8e6cfa8a-e53e-438b-91ff-db102a4cc412") },
                    { new Guid("1c486dbb-7ca2-4c64-9054-df4ce5f46e6f"), new Guid("936b28a3-ae9b-446f-9ac6-b33c98c716ce") },
                    { new Guid("577149ff-5d35-4bfe-a13d-390dfb4c1ce6"), new Guid("e7bcc845-be79-4ee5-b541-fdbb15afbd46") },
                    { new Guid("b51b154e-921d-4821-9018-34a72490f747"), new Guid("f448a680-4563-46f9-acb3-e63fd391f5c8") }
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
