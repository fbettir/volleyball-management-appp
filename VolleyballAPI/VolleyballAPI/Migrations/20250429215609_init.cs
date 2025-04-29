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
                    { new Guid("2926a721-1d9f-4d7a-9ecf-0cec67376be0"), "Location Addr 2", "Location2" },
                    { new Guid("30718d43-4ad8-4c28-9332-9fa9b39521fb"), "Location Addr 8", "Location8" },
                    { new Guid("32f27976-6c64-4cd2-ab05-b1ae065e201a"), "Location Addr 7", "Location7" },
                    { new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), "Location Addr 1", "Location1" },
                    { new Guid("40558881-5e32-473e-b8de-010294eda58b"), "Location Addr 3", "Location3" },
                    { new Guid("b6ad4acc-15bc-4b0e-96f5-d0e2f722454d"), "Location Addr 5", "Location5" },
                    { new Guid("be3bbc99-98a8-47ca-966a-216b7da2d5ca"), "Location Addr 4", "Location4" },
                    { new Guid("c07ec20e-497e-4551-afd1-83d61c4bfa08"), "Location Addr 6", "Location6" },
                    { new Guid("c18751ef-e3f4-4c0a-bf77-99b4783458e2"), "Location Addr 9", "Location9" },
                    { new Guid("c1b5cde8-b146-457e-b3ce-f5d7114cf1da"), "Location Addr 10", "Location10" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Gender", "Name", "Password", "Phone", "PictureLink", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("0306f5d2-225b-4919-88d8-f0feea3076ad"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8497), "user4@user.com", 0, "Kristóf", "pass4", "83568", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("080cdd79-5e80-40cf-8cb3-56eac9ebe870"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8490), "user2@user.com", 1, "Aranka", "pass2", "965463", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("230b36f0-7772-41cc-ae5d-98e788dc07f6"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8501), "user5@user.com", 0, "Lajos", "pass5", "54337", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 4, 2 },
                    { new Guid("26cad1ba-8bcd-41e9-be44-df5c6d334a55"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8494), "user3@user.com", 0, "Dani", "pass3", "123555", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("2d3a884f-9fd4-4350-97f4-f8d1b80d3d6b"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8513), "user8@user.com", 0, "Name 8", "pass8", "893935", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 5 },
                    { new Guid("abb71323-a353-4b98-a76f-42cfee560596"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8483), "user1@user.com", 0, "Jancsi", "pass1", "34214124", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 2, 3 },
                    { new Guid("b977e43c-69ad-4349-b22b-de1ff681609d"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8509), "user7@user.com", 1, "Felícia", "pass7", "32134", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 2 },
                    { new Guid("ec8ac721-9ae0-4215-8ced-3ab6e44d6721"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8516), "user9@user.com", 0, "Name 9", "pass9", "2716717", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("f3eb28cc-30a1-44d7-a1db-3535ad9ed385"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8505), "user6@user.com", 0, "Péter", "pass6", "4221", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 },
                    { new Guid("fb5ec3c3-cc36-42f7-a5b3-2ccb932cbaaf"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8520), "user10@user.com", 0, "Name 10", "pass10", "13556", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg", 3, 20, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId", "PictureLink" },
                values: new object[,]
                {
                    { new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d"), "Description Team 8", new Guid("30718d43-4ad8-4c28-9332-9fa9b39521fb"), "Team 8", new Guid("2d3a884f-9fd4-4350-97f4-f8d1b80d3d6b"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                    { new Guid("5baef5be-962f-4ffe-8066-d14258ad9c7a"), "Description Team 10", new Guid("be3bbc99-98a8-47ca-966a-216b7da2d5ca"), "Team 10", new Guid("abb71323-a353-4b98-a76f-42cfee560596"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" },
                    { new Guid("64f6135e-0392-4f34-8c36-c5c32327870c"), "Description Team 3", new Guid("40558881-5e32-473e-b8de-010294eda58b"), "Team 3", new Guid("26cad1ba-8bcd-41e9-be44-df5c6d334a55"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                    { new Guid("7a4d3e9f-4b73-4166-b07d-e1760feee279"), "Description Team 9", new Guid("c18751ef-e3f4-4c0a-bf77-99b4783458e2"), "Team 9", new Guid("ec8ac721-9ae0-4215-8ced-3ab6e44d6721"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" },
                    { new Guid("82fa73e5-4c9d-452a-83a6-b54b09433bce"), "Description Team 12", new Guid("be3bbc99-98a8-47ca-966a-216b7da2d5ca"), "Team 12", new Guid("26cad1ba-8bcd-41e9-be44-df5c6d334a55"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), "Description Team 1", new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), "Team 1", new Guid("abb71323-a353-4b98-a76f-42cfee560596"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" },
                    { new Guid("9526754c-9bcb-48b7-ab82-e33fa480d73c"), "Description Team 11", new Guid("40558881-5e32-473e-b8de-010294eda58b"), "Team 11", new Guid("abb71323-a353-4b98-a76f-42cfee560596"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" },
                    { new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1"), "Description Team 4", new Guid("be3bbc99-98a8-47ca-966a-216b7da2d5ca"), "Team 4", new Guid("0306f5d2-225b-4919-88d8-f0feea3076ad"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                    { new Guid("b747efb4-e130-44c5-8370-392376cd9711"), "Description Team 2", new Guid("2926a721-1d9f-4d7a-9ecf-0cec67376be0"), "Team 2", new Guid("080cdd79-5e80-40cf-8cb3-56eac9ebe870"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" },
                    { new Guid("e5bea32d-ae57-4315-99f7-09e57a580143"), "Description Team 7", new Guid("32f27976-6c64-4cd2-ab05-b1ae065e201a"), "Team 7", new Guid("b977e43c-69ad-4349-b22b-de1ff681609d"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                    { new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae"), "Description Team 6", new Guid("c07ec20e-497e-4551-afd1-83d61c4bfa08"), "Team 6", new Guid("f3eb28cc-30a1-44d7-a1db-3535ad9ed385"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                    { new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366"), "Description Team 5", new Guid("b6ad4acc-15bc-4b0e-96f5-d0e2f722454d"), "Team 5", new Guid("26cad1ba-8bcd-41e9-be44-df5c6d334a55"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Date", "Description", "EntryDeadline", "LocationId", "Name", "Organizer", "PictureLink", "PriceType", "RegistrationPolicy", "TeamPolicy" },
                values: new object[,]
                {
                    { new Guid("67bc7627-99fb-4668-9e23-c5d22c2090cc"), 4, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8261), "Description Tournament 2", new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8264), new Guid("40558881-5e32-473e-b8de-010294eda58b"), "Tournament 2", "Organizer 2", "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg", 16, "Registration Policy 2", "Team Policy 2" },
                    { new Guid("a5c8681e-8e23-4eea-a540-50f96681c217"), 1, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8267), "Description Tournament 3", new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8270), new Guid("be3bbc99-98a8-47ca-966a-216b7da2d5ca"), "Tournament 3", "Organizer 3", "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg", 16, "Registration Policy 3", "Team Policy 3" },
                    { new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8248), "Description Tournament 1", new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8257), new Guid("2926a721-1d9f-4d7a-9ecf-0cec67376be0"), "Tournament 1", "Organizer 1", "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg", 16, "Registration Policy 1", "Team Policy 1" }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new Guid("abb71323-a353-4b98-a76f-42cfee560596") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("67bc7627-99fb-4668-9e23-c5d22c2090cc"), new Guid("abb71323-a353-4b98-a76f-42cfee560596") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "RefereeId", "StartTime", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("08d07e14-35dd-43c3-b1ae-6d2dddf9e535"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7562), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("090d612c-daae-494c-b180-fefb739dc192"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7714), new Guid("40558881-5e32-473e-b8de-010294eda58b"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new DateTime(2024, 4, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a5c8681e-8e23-4eea-a540-50f96681c217") },
                    { new Guid("11988845-a79b-425b-ad08-1a4077081b9c"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7565), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("13c11f44-9140-4fba-af21-52aa5288348c"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7579), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("b747efb4-e130-44c5-8370-392376cd9711"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("172e18e2-9ef4-4ac0-b678-a213ada24264"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7642), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("36f62e0f-af9b-452f-b159-b2d48080af7b"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7646), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("411a601a-c2fd-46ae-b927-d22aa19def2d"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7671), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("51e0e4ae-033a-4ad2-9d7e-5459adc0806d"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7657), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("658213cc-bc38-4715-9e82-9dbcf2953870"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7678), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("6a4b8367-98bf-4bfe-b029-c0308dfa5f27"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7575), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("71b3a0a4-14e7-447c-84f4-d0d9a5ca9f43"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7686), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("723352fb-481f-4fa8-bc07-d40b2ec5dfe3"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7663), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("79899040-283e-4138-ae80-729d4bb97e51"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7653), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("7c6e46a3-541a-45b2-b293-ff9ab81f0b05"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7582), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("7cca3f8a-fc8f-4795-aba6-6c6dbe854aa6"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7572), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("7ecaf8ed-21fb-4ded-a51b-bcf93743f454"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7675), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("b747efb4-e130-44c5-8370-392376cd9711"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("8ecddc55-7a81-4db7-aa53-9d307d4822c9"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7568), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("93f2e203-b14a-497a-9f23-926aa7bc8368"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7660), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("b747efb4-e130-44c5-8370-392376cd9711"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("974b7eb7-e231-45fe-9f4d-1f86c9f4bad1"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7650), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("acc5af21-aa66-4ee4-ab34-33f0a4c31d51"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7700), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("bd324064-6fbf-4c6a-8901-1140d7ace4c1"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7693), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("c2ba3c08-31ba-431c-aa74-4f8ffc681f0d"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7667), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("c3d8f603-5109-442e-a0d5-c7414e8ab11c"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7696), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("cb71f7ce-8a35-43d5-a373-3a1445f4957a"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7703), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("ce904a40-747f-4663-8fad-d83964203c74"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7505), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("d5b8f3fb-0a85-4767-8821-f61a763435b8"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7689), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("dd83d8a1-9f6d-451f-bba6-591be02de993"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7710), new Guid("2926a721-1d9f-4d7a-9ecf-0cec67376be0"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new DateTime(2024, 4, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("67bc7627-99fb-4668-9e23-c5d22c2090cc") },
                    { new Guid("f5f8a506-8a42-4968-9cb5-f3d6d5f927c3"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7707), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("f74807f1-ffa4-4259-a1e1-efdc64bc0cf5"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7585), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("b747efb4-e130-44c5-8370-392376cd9711"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("f85ca4ac-221d-4249-a4b4-1cc4bcf65c27"), new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(7682), new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d"), new Guid("ec8ac721-9ae0-4215-8ced-3ab6e44d6721") },
                    { new Guid("5baef5be-962f-4ffe-8066-d14258ad9c7a"), new Guid("fb5ec3c3-cc36-42f7-a5b3-2ccb932cbaaf") },
                    { new Guid("64f6135e-0392-4f34-8c36-c5c32327870c"), new Guid("0306f5d2-225b-4919-88d8-f0feea3076ad") },
                    { new Guid("7a4d3e9f-4b73-4166-b07d-e1760feee279"), new Guid("fb5ec3c3-cc36-42f7-a5b3-2ccb932cbaaf") },
                    { new Guid("82fa73e5-4c9d-452a-83a6-b54b09433bce"), new Guid("2d3a884f-9fd4-4350-97f4-f8d1b80d3d6b") },
                    { new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new Guid("080cdd79-5e80-40cf-8cb3-56eac9ebe870") },
                    { new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new Guid("abb71323-a353-4b98-a76f-42cfee560596") },
                    { new Guid("9526754c-9bcb-48b7-ab82-e33fa480d73c"), new Guid("230b36f0-7772-41cc-ae5d-98e788dc07f6") },
                    { new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1"), new Guid("230b36f0-7772-41cc-ae5d-98e788dc07f6") },
                    { new Guid("b747efb4-e130-44c5-8370-392376cd9711"), new Guid("26cad1ba-8bcd-41e9-be44-df5c6d334a55") },
                    { new Guid("e5bea32d-ae57-4315-99f7-09e57a580143"), new Guid("2d3a884f-9fd4-4350-97f4-f8d1b80d3d6b") },
                    { new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae"), new Guid("b977e43c-69ad-4349-b22b-de1ff681609d") },
                    { new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366"), new Guid("f3eb28cc-30a1-44d7-a1db-3535ad9ed385") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("64f6135e-0392-4f34-8c36-c5c32327870c"), new Guid("2d3a884f-9fd4-4350-97f4-f8d1b80d3d6b") },
                    { new Guid("64f6135e-0392-4f34-8c36-c5c32327870c"), new Guid("b977e43c-69ad-4349-b22b-de1ff681609d") },
                    { new Guid("64f6135e-0392-4f34-8c36-c5c32327870c"), new Guid("f3eb28cc-30a1-44d7-a1db-3535ad9ed385") },
                    { new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new Guid("230b36f0-7772-41cc-ae5d-98e788dc07f6") },
                    { new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new Guid("26cad1ba-8bcd-41e9-be44-df5c6d334a55") },
                    { new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new Guid("abb71323-a353-4b98-a76f-42cfee560596") },
                    { new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1"), new Guid("ec8ac721-9ae0-4215-8ced-3ab6e44d6721") },
                    { new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1"), new Guid("fb5ec3c3-cc36-42f7-a5b3-2ccb932cbaaf") },
                    { new Guid("b747efb4-e130-44c5-8370-392376cd9711"), new Guid("0306f5d2-225b-4919-88d8-f0feea3076ad") },
                    { new Guid("b747efb4-e130-44c5-8370-392376cd9711"), new Guid("080cdd79-5e80-40cf-8cb3-56eac9ebe870") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("5baef5be-962f-4ffe-8066-d14258ad9c7a"), new Guid("67bc7627-99fb-4668-9e23-c5d22c2090cc") },
                    { new Guid("7a4d3e9f-4b73-4166-b07d-e1760feee279"), new Guid("67bc7627-99fb-4668-9e23-c5d22c2090cc") },
                    { new Guid("82fa73e5-4c9d-452a-83a6-b54b09433bce"), new Guid("a5c8681e-8e23-4eea-a540-50f96681c217") },
                    { new Guid("9526754c-9bcb-48b7-ab82-e33fa480d73c"), new Guid("a5c8681e-8e23-4eea-a540-50f96681c217") },
                    { new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d"), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("64f6135e-0392-4f34-8c36-c5c32327870c"), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("8bddfdc7-0276-4460-b553-d789a707974a"), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1"), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("b747efb4-e130-44c5-8370-392376cd9711"), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("e5bea32d-ae57-4315-99f7-09e57a580143"), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae"), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") },
                    { new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366"), new Guid("b34b3ba6-8124-4889-bd97-d8ea74e556e8") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "AcceptableTickets", "Date", "Description", "LocationId", "PictureLink", "TeamId" },
                values: new object[,]
                {
                    { new Guid("03638c09-e23c-4541-a6c5-e1839497a67d"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8396), "Training5", new Guid("b6ad4acc-15bc-4b0e-96f5-d0e2f722454d"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg", new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("0cc5e353-b7cb-4e8d-b43d-a61380dbbc31"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8406), "Training8", new Guid("30718d43-4ad8-4c28-9332-9fa9b39521fb"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg", new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("429051bb-91e2-49b0-a97c-56cb79d16491"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8390), "Training3", new Guid("40558881-5e32-473e-b8de-010294eda58b"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg", new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("42be052f-e266-412c-a32a-e5fb4c1eb281"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8387), "Training2", new Guid("2926a721-1d9f-4d7a-9ecf-0cec67376be0"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg", new Guid("8bddfdc7-0276-4460-b553-d789a707974a") },
                    { new Guid("45223753-06eb-4028-9ec3-7271d57107fb"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8399), "Training6", new Guid("c07ec20e-497e-4551-afd1-83d61c4bfa08"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg", new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("5381d6e0-5219-4b30-9a5e-8fa53d14b3bd"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8412), "Training10", new Guid("c1b5cde8-b146-457e-b3ce-f5d7114cf1da"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg", new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1") },
                    { new Guid("9ae01dc7-1cd1-4509-8f0a-dee4f9ed5ebb"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8403), "Training7", new Guid("32f27976-6c64-4cd2-ab05-b1ae065e201a"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg", new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("aa22a8b4-9651-42b5-ae58-8b70f31aa8dc"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8393), "Training4", new Guid("40558881-5e32-473e-b8de-010294eda58b"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg", new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("c7621b5c-3e83-4be2-a052-1b9f2f7f3729"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8409), "Training9", new Guid("c18751ef-e3f4-4c0a-bf77-99b4783458e2"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg", new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1") },
                    { new Guid("fafc4ba3-f94b-4474-839a-0833fb1ed0ef"), 5, new DateTime(2025, 4, 29, 23, 56, 8, 200, DateTimeKind.Local).AddTicks(8382), "Training1", new Guid("3f425e29-41d7-4a03-b608-bed683d91510"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg", new Guid("8bddfdc7-0276-4460-b553-d789a707974a") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("fafc4ba3-f94b-4474-839a-0833fb1ed0ef"), new Guid("abb71323-a353-4b98-a76f-42cfee560596") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("08d07e14-35dd-43c3-b1ae-6d2dddf9e535"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d") },
                    { new Guid("08d07e14-35dd-43c3-b1ae-6d2dddf9e535"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("090d612c-daae-494c-b180-fefb739dc192"), new Guid("82fa73e5-4c9d-452a-83a6-b54b09433bce") },
                    { new Guid("090d612c-daae-494c-b180-fefb739dc192"), new Guid("9526754c-9bcb-48b7-ab82-e33fa480d73c") },
                    { new Guid("11988845-a79b-425b-ad08-1a4077081b9c"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143") },
                    { new Guid("11988845-a79b-425b-ad08-1a4077081b9c"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae") },
                    { new Guid("13c11f44-9140-4fba-af21-52aa5288348c"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("13c11f44-9140-4fba-af21-52aa5288348c"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae") },
                    { new Guid("172e18e2-9ef4-4ac0-b678-a213ada24264"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d") },
                    { new Guid("172e18e2-9ef4-4ac0-b678-a213ada24264"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae") },
                    { new Guid("36f62e0f-af9b-452f-b159-b2d48080af7b"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("36f62e0f-af9b-452f-b159-b2d48080af7b"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1") },
                    { new Guid("411a601a-c2fd-46ae-b927-d22aa19def2d"), new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("411a601a-c2fd-46ae-b927-d22aa19def2d"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143") },
                    { new Guid("51e0e4ae-033a-4ad2-9d7e-5459adc0806d"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d") },
                    { new Guid("51e0e4ae-033a-4ad2-9d7e-5459adc0806d"), new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("658213cc-bc38-4715-9e82-9dbcf2953870"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1") },
                    { new Guid("658213cc-bc38-4715-9e82-9dbcf2953870"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143") },
                    { new Guid("6a4b8367-98bf-4bfe-b029-c0308dfa5f27"), new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("6a4b8367-98bf-4bfe-b029-c0308dfa5f27"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae") },
                    { new Guid("71b3a0a4-14e7-447c-84f4-d0d9a5ca9f43"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a") },
                    { new Guid("71b3a0a4-14e7-447c-84f4-d0d9a5ca9f43"), new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("723352fb-481f-4fa8-bc07-d40b2ec5dfe3"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a") },
                    { new Guid("723352fb-481f-4fa8-bc07-d40b2ec5dfe3"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366") },
                    { new Guid("79899040-283e-4138-ae80-729d4bb97e51"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("79899040-283e-4138-ae80-729d4bb97e51"), new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("7c6e46a3-541a-45b2-b293-ff9ab81f0b05"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d") },
                    { new Guid("7c6e46a3-541a-45b2-b293-ff9ab81f0b05"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1") },
                    { new Guid("7cca3f8a-fc8f-4795-aba6-6c6dbe854aa6"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("7cca3f8a-fc8f-4795-aba6-6c6dbe854aa6"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a") },
                    { new Guid("7ecaf8ed-21fb-4ded-a51b-bcf93743f454"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d") },
                    { new Guid("7ecaf8ed-21fb-4ded-a51b-bcf93743f454"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366") },
                    { new Guid("8ecddc55-7a81-4db7-aa53-9d307d4822c9"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1") },
                    { new Guid("8ecddc55-7a81-4db7-aa53-9d307d4822c9"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae") },
                    { new Guid("93f2e203-b14a-497a-9f23-926aa7bc8368"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d") },
                    { new Guid("93f2e203-b14a-497a-9f23-926aa7bc8368"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a") },
                    { new Guid("974b7eb7-e231-45fe-9f4d-1f86c9f4bad1"), new Guid("192dd49b-2342-4f72-8bf6-e9fd35d2de5d") },
                    { new Guid("974b7eb7-e231-45fe-9f4d-1f86c9f4bad1"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143") },
                    { new Guid("acc5af21-aa66-4ee4-ab34-33f0a4c31d51"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a") },
                    { new Guid("acc5af21-aa66-4ee4-ab34-33f0a4c31d51"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1") },
                    { new Guid("bd324064-6fbf-4c6a-8901-1140d7ace4c1"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a") },
                    { new Guid("bd324064-6fbf-4c6a-8901-1140d7ace4c1"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143") },
                    { new Guid("c2ba3c08-31ba-431c-aa74-4f8ffc681f0d"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1") },
                    { new Guid("c2ba3c08-31ba-431c-aa74-4f8ffc681f0d"), new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("c3d8f603-5109-442e-a0d5-c7414e8ab11c"), new Guid("b747efb4-e130-44c5-8370-392376cd9711") },
                    { new Guid("c3d8f603-5109-442e-a0d5-c7414e8ab11c"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366") },
                    { new Guid("cb71f7ce-8a35-43d5-a373-3a1445f4957a"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae") },
                    { new Guid("cb71f7ce-8a35-43d5-a373-3a1445f4957a"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366") },
                    { new Guid("ce904a40-747f-4663-8fad-d83964203c74"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("ce904a40-747f-4663-8fad-d83964203c74"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366") },
                    { new Guid("d5b8f3fb-0a85-4767-8821-f61a763435b8"), new Guid("b6f032a0-0f30-4d47-83d4-6b0edefeb8a1") },
                    { new Guid("d5b8f3fb-0a85-4767-8821-f61a763435b8"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366") },
                    { new Guid("dd83d8a1-9f6d-451f-bba6-591be02de993"), new Guid("5baef5be-962f-4ffe-8066-d14258ad9c7a") },
                    { new Guid("dd83d8a1-9f6d-451f-bba6-591be02de993"), new Guid("7a4d3e9f-4b73-4166-b07d-e1760feee279") },
                    { new Guid("f5f8a506-8a42-4968-9cb5-f3d6d5f927c3"), new Guid("8bddfdc7-0276-4460-b553-d789a707974a") },
                    { new Guid("f5f8a506-8a42-4968-9cb5-f3d6d5f927c3"), new Guid("ecb06a9a-1c64-43eb-a4b2-4b8eed8645ae") },
                    { new Guid("f74807f1-ffa4-4259-a1e1-efdc64bc0cf5"), new Guid("64f6135e-0392-4f34-8c36-c5c32327870c") },
                    { new Guid("f74807f1-ffa4-4259-a1e1-efdc64bc0cf5"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143") },
                    { new Guid("f85ca4ac-221d-4249-a4b4-1cc4bcf65c27"), new Guid("e5bea32d-ae57-4315-99f7-09e57a580143") },
                    { new Guid("f85ca4ac-221d-4249-a4b4-1cc4bcf65c27"), new Guid("ee447fc5-eff5-486c-a2e8-09fe33607366") }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("aa22a8b4-9651-42b5-ae58-8b70f31aa8dc"), new Guid("0306f5d2-225b-4919-88d8-f0feea3076ad") },
                    { new Guid("42be052f-e266-412c-a32a-e5fb4c1eb281"), new Guid("080cdd79-5e80-40cf-8cb3-56eac9ebe870") },
                    { new Guid("03638c09-e23c-4541-a6c5-e1839497a67d"), new Guid("230b36f0-7772-41cc-ae5d-98e788dc07f6") },
                    { new Guid("429051bb-91e2-49b0-a97c-56cb79d16491"), new Guid("26cad1ba-8bcd-41e9-be44-df5c6d334a55") },
                    { new Guid("0cc5e353-b7cb-4e8d-b43d-a61380dbbc31"), new Guid("2d3a884f-9fd4-4350-97f4-f8d1b80d3d6b") },
                    { new Guid("fafc4ba3-f94b-4474-839a-0833fb1ed0ef"), new Guid("abb71323-a353-4b98-a76f-42cfee560596") },
                    { new Guid("9ae01dc7-1cd1-4509-8f0a-dee4f9ed5ebb"), new Guid("b977e43c-69ad-4349-b22b-de1ff681609d") },
                    { new Guid("c7621b5c-3e83-4be2-a052-1b9f2f7f3729"), new Guid("ec8ac721-9ae0-4215-8ced-3ab6e44d6721") },
                    { new Guid("45223753-06eb-4028-9ec3-7271d57107fb"), new Guid("f3eb28cc-30a1-44d7-a1db-3535ad9ed385") },
                    { new Guid("5381d6e0-5219-4b30-9a5e-8fa53d14b3bd"), new Guid("fb5ec3c3-cc36-42f7-a5b3-2ccb932cbaaf") }
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
