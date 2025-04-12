using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VolleyballAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    AcceptableTickets = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("026827c9-455b-41e1-9c49-47ee9b94fbe4"), "Location Addr 8", "Location8" },
                    { new Guid("2397ecf9-b477-44bd-81b2-430a03ff8c0e"), "Location Addr 2", "Location2" },
                    { new Guid("38a33e6f-5bef-4f94-8315-3c43e479956e"), "Location Addr 4", "Location4" },
                    { new Guid("3b6c1d4c-f00e-4881-9a8f-607ccdc5bbff"), "Location Addr 3", "Location3" },
                    { new Guid("45429076-7d5b-4e61-a9f0-252122a9bdf9"), "Location Addr 6", "Location6" },
                    { new Guid("97bf836d-b00d-48ce-99fd-3fe15c16590a"), "Location Addr 10", "Location10" },
                    { new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), "Location Addr 1", "Location1" },
                    { new Guid("e520731c-c5a2-4016-a5af-90a2b5175091"), "Location Addr 5", "Location5" },
                    { new Guid("f2aca153-19d8-4a19-bc79-5f2ea7a002df"), "Location Addr 7", "Location7" },
                    { new Guid("f526a593-f96d-4483-aaa6-efd22363898d"), "Location Addr 9", "Location9" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Gender", "Name", "Password", "Phone", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("0dc5b29b-62f8-4bca-9967-b74477911383"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8905), "user4@user.com", 0, "Kristóf", "pass4", "83568", 3, 20, 1, 4 },
                    { new Guid("121fed86-9e75-4120-803c-6de5db37ad0c"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8896), "user1@user.com", 0, "Jancsi", "pass1", "34214124", 3, 20, 2, 3 },
                    { new Guid("3ccc86b5-abc6-4bd6-be56-f0b65ca52878"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8908), "user5@user.com", 0, "Lajos", "pass5", "54337", 3, 20, 4, 2 },
                    { new Guid("535cb10a-dffe-4193-8164-ddc255ddfd11"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8900), "user2@user.com", 1, "Aranka", "pass2", "965463", 3, 20, 1, 5 },
                    { new Guid("a8a384ba-d547-4da5-8a36-38237c1ff968"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8914), "user7@user.com", 1, "Felícia", "pass7", "32134", 3, 20, 1, 2 },
                    { new Guid("c53689c4-6e14-49fc-bae3-763809134015"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8919), "user9@user.com", 0, "Name 9", "pass9", "2716717", 3, 20, 1, 4 },
                    { new Guid("c9dbd45a-e340-4b6d-8a44-842110a728ea"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8911), "user6@user.com", 0, "Péter", "pass6", "4221", 3, 20, 1, 4 },
                    { new Guid("cc3da156-9749-45a2-a96e-cbf991b773d5"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8916), "user8@user.com", 0, "Name 8", "pass8", "893935", 3, 20, 1, 5 },
                    { new Guid("d735490e-7a63-4eeb-a542-624822f95cc2"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8903), "user3@user.com", 0, "Dani", "pass3", "123555", 3, 20, 1, 4 },
                    { new Guid("ec53ced4-af8e-4774-ab00-a5b78de3967c"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8922), "user10@user.com", 0, "Name 10", "pass10", "13556", 3, 20, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc"), "Description Team 6", new Guid("45429076-7d5b-4e61-a9f0-252122a9bdf9"), "Team 6", new Guid("c9dbd45a-e340-4b6d-8a44-842110a728ea") },
                    { new Guid("1ea3d5a1-3741-488d-bd01-64ebf9c5b856"), "Description Team 10", new Guid("38a33e6f-5bef-4f94-8315-3c43e479956e"), "Team 10", new Guid("121fed86-9e75-4120-803c-6de5db37ad0c") },
                    { new Guid("2b9a6169-9fa4-47c8-b5dd-facc82a9c498"), "Description Team 12", new Guid("38a33e6f-5bef-4f94-8315-3c43e479956e"), "Team 12", new Guid("d735490e-7a63-4eeb-a542-624822f95cc2") },
                    { new Guid("338d2ca5-9406-419a-97fc-523df4c221ba"), "Description Team 11", new Guid("3b6c1d4c-f00e-4881-9a8f-607ccdc5bbff"), "Team 11", new Guid("121fed86-9e75-4120-803c-6de5db37ad0c") },
                    { new Guid("3deb03e7-89b0-448e-a5dd-f571a3bf7700"), "Description Team 9", new Guid("f526a593-f96d-4483-aaa6-efd22363898d"), "Team 9", new Guid("c53689c4-6e14-49fc-bae3-763809134015") },
                    { new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), "Description Team 1", new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), "Team 1", new Guid("121fed86-9e75-4120-803c-6de5db37ad0c") },
                    { new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac"), "Description Team 8", new Guid("026827c9-455b-41e1-9c49-47ee9b94fbe4"), "Team 8", new Guid("cc3da156-9749-45a2-a96e-cbf991b773d5") },
                    { new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d"), "Description Team 4", new Guid("38a33e6f-5bef-4f94-8315-3c43e479956e"), "Team 4", new Guid("0dc5b29b-62f8-4bca-9967-b74477911383") },
                    { new Guid("98c17d74-c56e-4169-a67d-f1103679c92f"), "Description Team 2", new Guid("2397ecf9-b477-44bd-81b2-430a03ff8c0e"), "Team 2", new Guid("535cb10a-dffe-4193-8164-ddc255ddfd11") },
                    { new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a"), "Description Team 3", new Guid("3b6c1d4c-f00e-4881-9a8f-607ccdc5bbff"), "Team 3", new Guid("d735490e-7a63-4eeb-a542-624822f95cc2") },
                    { new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9"), "Description Team 7", new Guid("f2aca153-19d8-4a19-bc79-5f2ea7a002df"), "Team 7", new Guid("a8a384ba-d547-4da5-8a36-38237c1ff968") },
                    { new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284"), "Description Team 5", new Guid("e520731c-c5a2-4016-a5af-90a2b5175091"), "Team 5", new Guid("d735490e-7a63-4eeb-a542-624822f95cc2") }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Date", "Description", "EntryDeadline", "LocationId", "Name", "Organizer", "PriceType", "RegistrationPolicy", "TeamPolicy" },
                values: new object[,]
                {
                    { new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8733), "Description Tournament 1", new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8737), new Guid("2397ecf9-b477-44bd-81b2-430a03ff8c0e"), "Tournament 1", "Organizer 1", 16, "Registration Policy 1", "Team Policy 1" },
                    { new Guid("9d27e154-666f-43f9-9bf6-eebbeab3d033"), 4, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8740), "Description Tournament 2", new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8741), new Guid("3b6c1d4c-f00e-4881-9a8f-607ccdc5bbff"), "Tournament 2", "Organizer 2", 16, "Registration Policy 2", "Team Policy 2" },
                    { new Guid("e71df8fa-c3c7-4e54-afb9-b45bc89aaa83"), 1, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8744), "Description Tournament 3", new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8746), new Guid("38a33e6f-5bef-4f94-8315-3c43e479956e"), "Tournament 3", "Organizer 3", 16, "Registration Policy 3", "Team Policy 3" }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new Guid("121fed86-9e75-4120-803c-6de5db37ad0c") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("9d27e154-666f-43f9-9bf6-eebbeab3d033"), new Guid("121fed86-9e75-4120-803c-6de5db37ad0c") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "RefereeId", "StartTime", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("02e30203-2aaa-4901-a951-c1b1484e2417"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8433), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("0cfa28be-7215-4681-a6e4-ae6278806760"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8472), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("23688b2a-9e10-4b44-98c5-a3d52c0850d2"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8436), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("298ebacf-3ef8-4e3a-a15f-d49f02916ad0"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8431), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("2d85f559-f6cb-4131-9e25-0f74dabc6f82"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8485), new Guid("2397ecf9-b477-44bd-81b2-430a03ff8c0e"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new DateTime(2024, 4, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9d27e154-666f-43f9-9bf6-eebbeab3d033") },
                    { new Guid("2fd55261-70c8-48b4-a83c-33624348cb7f"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8475), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("302aea8b-910d-4ea3-877b-a4f0b2d87ae1"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8444), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("42d4cd9b-983b-4425-8043-3f2dfa9ffc36"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8426), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("4e93b254-6014-414f-82a8-ef3b9df8036e"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8467), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("4f44a42f-a458-45ab-a4df-8cc86e177dee"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8488), new Guid("3b6c1d4c-f00e-4881-9a8f-607ccdc5bbff"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new DateTime(2024, 4, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e71df8fa-c3c7-4e54-afb9-b45bc89aaa83") },
                    { new Guid("6fcc7d85-bf86-426c-92f7-a7689a1dd3da"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8483), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("792b671b-71b7-4efa-ad0f-8bef0e81bbfc"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8449), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("7bdd24a6-f282-42e3-91a9-9457fb542c0f"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8456), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("827a3c49-db6a-4500-b235-f3ea6cbe2c9f"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8451), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("8b317c1c-e855-4657-bd2d-299052ef658e"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8454), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("8c1dc2c5-a2ee-432a-bb59-5ac750b6b996"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8439), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("96146330-381c-4de0-84f0-90021558bb4d"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8480), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("b0819c98-4299-409d-9040-a39164fc482c"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8418), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("b459bf29-84c5-4cef-8095-7f2eec19bd89"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8415), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("c2d51539-e23d-4860-b935-937fdc9c99ae"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8428), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("c2d7841f-8566-42d8-b426-77040e21f477"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8421), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("c50d63b4-398e-496f-a60e-e9859e9a54c5"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8441), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("ca3f7acf-f221-4d5f-845e-485243da9e8e"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8470), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("e184b843-d09c-42c1-971a-dc327874a993"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8478), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("e8a7660e-0ffd-4de1-bbdb-27b77e6ec9e8"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8376), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("f6d7916f-1674-4dbc-8177-4183a1b27545"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8446), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("f74428f4-e959-4729-901e-76ce190ee510"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8423), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("f7bf5b28-6cfd-473c-ada0-35ffef1d189c"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8462), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("f9dbde9a-d578-47dc-b1f2-b4d7e66c484e"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8465), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("fb6eb16c-1b0a-41b3-bfd8-f1a8b8f204fe"), new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8459), new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc"), new Guid("a8a384ba-d547-4da5-8a36-38237c1ff968") },
                    { new Guid("1ea3d5a1-3741-488d-bd01-64ebf9c5b856"), new Guid("ec53ced4-af8e-4774-ab00-a5b78de3967c") },
                    { new Guid("2b9a6169-9fa4-47c8-b5dd-facc82a9c498"), new Guid("cc3da156-9749-45a2-a96e-cbf991b773d5") },
                    { new Guid("338d2ca5-9406-419a-97fc-523df4c221ba"), new Guid("3ccc86b5-abc6-4bd6-be56-f0b65ca52878") },
                    { new Guid("3deb03e7-89b0-448e-a5dd-f571a3bf7700"), new Guid("ec53ced4-af8e-4774-ab00-a5b78de3967c") },
                    { new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new Guid("121fed86-9e75-4120-803c-6de5db37ad0c") },
                    { new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new Guid("535cb10a-dffe-4193-8164-ddc255ddfd11") },
                    { new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac"), new Guid("c53689c4-6e14-49fc-bae3-763809134015") },
                    { new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d"), new Guid("3ccc86b5-abc6-4bd6-be56-f0b65ca52878") },
                    { new Guid("98c17d74-c56e-4169-a67d-f1103679c92f"), new Guid("d735490e-7a63-4eeb-a542-624822f95cc2") },
                    { new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a"), new Guid("0dc5b29b-62f8-4bca-9967-b74477911383") },
                    { new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9"), new Guid("cc3da156-9749-45a2-a96e-cbf991b773d5") },
                    { new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284"), new Guid("c9dbd45a-e340-4b6d-8a44-842110a728ea") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new Guid("121fed86-9e75-4120-803c-6de5db37ad0c") },
                    { new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new Guid("3ccc86b5-abc6-4bd6-be56-f0b65ca52878") },
                    { new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new Guid("d735490e-7a63-4eeb-a542-624822f95cc2") },
                    { new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d"), new Guid("c53689c4-6e14-49fc-bae3-763809134015") },
                    { new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d"), new Guid("ec53ced4-af8e-4774-ab00-a5b78de3967c") },
                    { new Guid("98c17d74-c56e-4169-a67d-f1103679c92f"), new Guid("0dc5b29b-62f8-4bca-9967-b74477911383") },
                    { new Guid("98c17d74-c56e-4169-a67d-f1103679c92f"), new Guid("535cb10a-dffe-4193-8164-ddc255ddfd11") },
                    { new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a"), new Guid("a8a384ba-d547-4da5-8a36-38237c1ff968") },
                    { new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a"), new Guid("c9dbd45a-e340-4b6d-8a44-842110a728ea") },
                    { new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a"), new Guid("cc3da156-9749-45a2-a96e-cbf991b773d5") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc"), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989"), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac"), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d"), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("98c17d74-c56e-4169-a67d-f1103679c92f"), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a"), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9"), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284"), new Guid("66259d31-92cb-41d7-970e-3adf2a688b0e") },
                    { new Guid("1ea3d5a1-3741-488d-bd01-64ebf9c5b856"), new Guid("9d27e154-666f-43f9-9bf6-eebbeab3d033") },
                    { new Guid("3deb03e7-89b0-448e-a5dd-f571a3bf7700"), new Guid("9d27e154-666f-43f9-9bf6-eebbeab3d033") },
                    { new Guid("2b9a6169-9fa4-47c8-b5dd-facc82a9c498"), new Guid("e71df8fa-c3c7-4e54-afb9-b45bc89aaa83") },
                    { new Guid("338d2ca5-9406-419a-97fc-523df4c221ba"), new Guid("e71df8fa-c3c7-4e54-afb9-b45bc89aaa83") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "AcceptableTickets", "Date", "Description", "LocationId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("090e1e3d-acab-4a8a-94b9-40ae7da1a25c"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8807), "Training6", new Guid("45429076-7d5b-4e61-a9f0-252122a9bdf9"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") },
                    { new Guid("0ad874a5-8143-42e8-8978-fbd0282bef18"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8816), "Training10", new Guid("97bf836d-b00d-48ce-99fd-3fe15c16590a"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d") },
                    { new Guid("21eb950f-7f6f-44c5-aab0-4033c8404e06"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8795), "Training1", new Guid("de0248b6-478a-4a38-a439-3406e05db0ad"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989") },
                    { new Guid("28777504-68ae-4cb9-ba58-8ea366a12023"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8803), "Training4", new Guid("3b6c1d4c-f00e-4881-9a8f-607ccdc5bbff"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("31062b1b-9d40-4fca-8b41-1251ed96f89d"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8814), "Training9", new Guid("f526a593-f96d-4483-aaa6-efd22363898d"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d") },
                    { new Guid("3997e2dc-5c2e-470f-86cc-725d0c920ec8"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8805), "Training5", new Guid("e520731c-c5a2-4016-a5af-90a2b5175091"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("6ef6a777-f45e-4295-ba6c-f8001c029c46"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8810), "Training7", new Guid("f2aca153-19d8-4a19-bc79-5f2ea7a002df"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("87b596b3-07f7-4b41-af6c-4d6fe2a2130d"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8798), "Training2", new Guid("2397ecf9-b477-44bd-81b2-430a03ff8c0e"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989") },
                    { new Guid("d0c0e488-2b11-4b6a-98ec-dcda0d5da3ce"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8801), "Training3", new Guid("3b6c1d4c-f00e-4881-9a8f-607ccdc5bbff"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") },
                    { new Guid("fa0de668-80db-4c3a-a25c-4998a04f6838"), 5, new DateTime(2025, 4, 3, 10, 28, 37, 862, DateTimeKind.Local).AddTicks(8812), "Training8", new Guid("026827c9-455b-41e1-9c49-47ee9b94fbe4"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("21eb950f-7f6f-44c5-aab0-4033c8404e06"), new Guid("121fed86-9e75-4120-803c-6de5db37ad0c") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("02e30203-2aaa-4901-a951-c1b1484e2417"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("02e30203-2aaa-4901-a951-c1b1484e2417"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9") },
                    { new Guid("0cfa28be-7215-4681-a6e4-ae6278806760"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989") },
                    { new Guid("0cfa28be-7215-4681-a6e4-ae6278806760"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9") },
                    { new Guid("23688b2a-9e10-4b44-98c5-a3d52c0850d2"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc") },
                    { new Guid("23688b2a-9e10-4b44-98c5-a3d52c0850d2"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac") },
                    { new Guid("298ebacf-3ef8-4e3a-a15f-d49f02916ad0"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac") },
                    { new Guid("298ebacf-3ef8-4e3a-a15f-d49f02916ad0"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d") },
                    { new Guid("2d85f559-f6cb-4131-9e25-0f74dabc6f82"), new Guid("1ea3d5a1-3741-488d-bd01-64ebf9c5b856") },
                    { new Guid("2d85f559-f6cb-4131-9e25-0f74dabc6f82"), new Guid("3deb03e7-89b0-448e-a5dd-f571a3bf7700") },
                    { new Guid("2fd55261-70c8-48b4-a83c-33624348cb7f"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") },
                    { new Guid("2fd55261-70c8-48b4-a83c-33624348cb7f"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284") },
                    { new Guid("302aea8b-910d-4ea3-877b-a4f0b2d87ae1"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") },
                    { new Guid("302aea8b-910d-4ea3-877b-a4f0b2d87ae1"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("42d4cd9b-983b-4425-8043-3f2dfa9ffc36"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc") },
                    { new Guid("42d4cd9b-983b-4425-8043-3f2dfa9ffc36"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") },
                    { new Guid("4e93b254-6014-414f-82a8-ef3b9df8036e"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989") },
                    { new Guid("4e93b254-6014-414f-82a8-ef3b9df8036e"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") },
                    { new Guid("4f44a42f-a458-45ab-a4df-8cc86e177dee"), new Guid("2b9a6169-9fa4-47c8-b5dd-facc82a9c498") },
                    { new Guid("4f44a42f-a458-45ab-a4df-8cc86e177dee"), new Guid("338d2ca5-9406-419a-97fc-523df4c221ba") },
                    { new Guid("6fcc7d85-bf86-426c-92f7-a7689a1dd3da"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc") },
                    { new Guid("6fcc7d85-bf86-426c-92f7-a7689a1dd3da"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989") },
                    { new Guid("792b671b-71b7-4efa-ad0f-8bef0e81bbfc"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989") },
                    { new Guid("792b671b-71b7-4efa-ad0f-8bef0e81bbfc"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac") },
                    { new Guid("7bdd24a6-f282-42e3-91a9-9457fb542c0f"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") },
                    { new Guid("7bdd24a6-f282-42e3-91a9-9457fb542c0f"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9") },
                    { new Guid("827a3c49-db6a-4500-b235-f3ea6cbe2c9f"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989") },
                    { new Guid("827a3c49-db6a-4500-b235-f3ea6cbe2c9f"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284") },
                    { new Guid("8b317c1c-e855-4657-bd2d-299052ef658e"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d") },
                    { new Guid("8b317c1c-e855-4657-bd2d-299052ef658e"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") },
                    { new Guid("8c1dc2c5-a2ee-432a-bb59-5ac750b6b996"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d") },
                    { new Guid("8c1dc2c5-a2ee-432a-bb59-5ac750b6b996"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("96146330-381c-4de0-84f0-90021558bb4d"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc") },
                    { new Guid("96146330-381c-4de0-84f0-90021558bb4d"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284") },
                    { new Guid("b0819c98-4299-409d-9040-a39164fc482c"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc") },
                    { new Guid("b0819c98-4299-409d-9040-a39164fc482c"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9") },
                    { new Guid("b459bf29-84c5-4cef-8095-7f2eec19bd89"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac") },
                    { new Guid("b459bf29-84c5-4cef-8095-7f2eec19bd89"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("c2d51539-e23d-4860-b935-937fdc9c99ae"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc") },
                    { new Guid("c2d51539-e23d-4860-b935-937fdc9c99ae"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("c2d7841f-8566-42d8-b426-77040e21f477"), new Guid("05ef517d-6936-48c7-a8eb-f3893611fbbc") },
                    { new Guid("c2d7841f-8566-42d8-b426-77040e21f477"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d") },
                    { new Guid("c50d63b4-398e-496f-a60e-e9859e9a54c5"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac") },
                    { new Guid("c50d63b4-398e-496f-a60e-e9859e9a54c5"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9") },
                    { new Guid("ca3f7acf-f221-4d5f-845e-485243da9e8e"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d") },
                    { new Guid("ca3f7acf-f221-4d5f-845e-485243da9e8e"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284") },
                    { new Guid("e184b843-d09c-42c1-971a-dc327874a993"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989") },
                    { new Guid("e184b843-d09c-42c1-971a-dc327874a993"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d") },
                    { new Guid("e8a7660e-0ffd-4de1-bbdb-27b77e6ec9e8"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("e8a7660e-0ffd-4de1-bbdb-27b77e6ec9e8"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284") },
                    { new Guid("f6d7916f-1674-4dbc-8177-4183a1b27545"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac") },
                    { new Guid("f6d7916f-1674-4dbc-8177-4183a1b27545"), new Guid("98c17d74-c56e-4169-a67d-f1103679c92f") },
                    { new Guid("f74428f4-e959-4729-901e-76ce190ee510"), new Guid("4ef0537f-1c2d-4693-b3de-d35a9e602989") },
                    { new Guid("f74428f4-e959-4729-901e-76ce190ee510"), new Guid("b9c68cac-dbe7-4a99-8aab-e078c677671a") },
                    { new Guid("f7bf5b28-6cfd-473c-ada0-35ffef1d189c"), new Guid("8587f984-6df3-49a7-ae08-6fdf6ee54d9d") },
                    { new Guid("f7bf5b28-6cfd-473c-ada0-35ffef1d189c"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9") },
                    { new Guid("f9dbde9a-d578-47dc-b1f2-b4d7e66c484e"), new Guid("e4c7401a-d05c-4bdd-9531-75530422a8c9") },
                    { new Guid("f9dbde9a-d578-47dc-b1f2-b4d7e66c484e"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284") },
                    { new Guid("fb6eb16c-1b0a-41b3-bfd8-f1a8b8f204fe"), new Guid("77eb1c32-5b8f-4af7-bc8b-e63bfc3192ac") },
                    { new Guid("fb6eb16c-1b0a-41b3-bfd8-f1a8b8f204fe"), new Guid("e5f835f4-e651-41a3-9076-fd40a6d0f284") }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("28777504-68ae-4cb9-ba58-8ea366a12023"), new Guid("0dc5b29b-62f8-4bca-9967-b74477911383") },
                    { new Guid("21eb950f-7f6f-44c5-aab0-4033c8404e06"), new Guid("121fed86-9e75-4120-803c-6de5db37ad0c") },
                    { new Guid("3997e2dc-5c2e-470f-86cc-725d0c920ec8"), new Guid("3ccc86b5-abc6-4bd6-be56-f0b65ca52878") },
                    { new Guid("87b596b3-07f7-4b41-af6c-4d6fe2a2130d"), new Guid("535cb10a-dffe-4193-8164-ddc255ddfd11") },
                    { new Guid("6ef6a777-f45e-4295-ba6c-f8001c029c46"), new Guid("a8a384ba-d547-4da5-8a36-38237c1ff968") },
                    { new Guid("31062b1b-9d40-4fca-8b41-1251ed96f89d"), new Guid("c53689c4-6e14-49fc-bae3-763809134015") },
                    { new Guid("090e1e3d-acab-4a8a-94b9-40ae7da1a25c"), new Guid("c9dbd45a-e340-4b6d-8a44-842110a728ea") },
                    { new Guid("fa0de668-80db-4c3a-a25c-4998a04f6838"), new Guid("cc3da156-9749-45a2-a96e-cbf991b773d5") },
                    { new Guid("d0c0e488-2b11-4b6a-98ec-dcda0d5da3ce"), new Guid("d735490e-7a63-4eeb-a542-624822f95cc2") },
                    { new Guid("0ad874a5-8143-42e8-8978-fbd0282bef18"), new Guid("ec53ced4-af8e-4774-ab00-a5b78de3967c") }
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
