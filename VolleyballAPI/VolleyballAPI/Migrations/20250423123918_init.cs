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
                    { new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), "Location Addr 1", "Location1" },
                    { new Guid("34613a5f-77ba-4f88-af95-83a16a11a847"), "Location Addr 10", "Location10" },
                    { new Guid("49168dad-443c-45c7-ab54-d8765437ae41"), "Location Addr 7", "Location7" },
                    { new Guid("87ce73fb-ca09-40c0-968f-ea7d5faf6050"), "Location Addr 4", "Location4" },
                    { new Guid("93c67519-3e07-4626-917e-a83480c02efc"), "Location Addr 2", "Location2" },
                    { new Guid("97596a29-02f5-4379-a530-e507ef6eb5e6"), "Location Addr 5", "Location5" },
                    { new Guid("a41ea1cb-f961-4a79-a280-610ba5c4a440"), "Location Addr 8", "Location8" },
                    { new Guid("c7fed090-f154-4aa1-9208-ef6e5d709cba"), "Location Addr 6", "Location6" },
                    { new Guid("ddf42da6-05cd-447b-88be-928ba48088c2"), "Location Addr 3", "Location3" },
                    { new Guid("ecfc39e0-f5e1-4231-8cbc-a3ff7e97833d"), "Location Addr 9", "Location9" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Gender", "Name", "Password", "Phone", "PlayerNumber", "Posts", "PriceType", "Roles" },
                values: new object[,]
                {
                    { new Guid("0977f359-4c9a-4a97-b5e5-e483fdcfec6f"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1293), "user2@user.com", 1, "Aranka", "pass2", "965463", 3, 20, 1, 5 },
                    { new Guid("12c050a0-c322-4b74-803e-3471ea335e4e"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1315), "user10@user.com", 0, "Name 10", "pass10", "13556", 3, 20, 1, 4 },
                    { new Guid("1893a9d1-a4d4-4a63-96bf-fdbe599ac893"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1307), "user7@user.com", 1, "Felícia", "pass7", "32134", 3, 20, 1, 2 },
                    { new Guid("1f02cf69-07f6-46fe-aa62-fd8def0d72b5"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1301), "user5@user.com", 0, "Lajos", "pass5", "54337", 3, 20, 4, 2 },
                    { new Guid("3da7facd-ed9c-4b3c-9cc0-ca25a0676ce9"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1296), "user3@user.com", 0, "Dani", "pass3", "123555", 3, 20, 1, 4 },
                    { new Guid("5c08b0d7-7ada-4e74-9a0b-40a6beeecb87"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1304), "user6@user.com", 0, "Péter", "pass6", "4221", 3, 20, 1, 4 },
                    { new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1288), "user1@user.com", 0, "Jancsi", "pass1", "34214124", 3, 20, 2, 3 },
                    { new Guid("a93ba3f8-52ec-4968-91ee-5590c716a63b"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1298), "user4@user.com", 0, "Kristóf", "pass4", "83568", 3, 20, 1, 4 },
                    { new Guid("c8484dfc-1488-4eb9-8390-2aaacf72646c"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1310), "user8@user.com", 0, "Name 8", "pass8", "893935", 3, 20, 1, 5 },
                    { new Guid("dd5030eb-95d5-4a13-b0be-f159d2b09277"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1312), "user9@user.com", 0, "Name 9", "pass9", "2716717", 3, 20, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "LocationId", "Name", "OwnerId", "PictureLink" },
                values: new object[,]
                {
                    { new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3"), "Description Team 2", new Guid("93c67519-3e07-4626-917e-a83480c02efc"), "Team 2", new Guid("0977f359-4c9a-4a97-b5e5-e483fdcfec6f"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_210101_kendras.jpg" },
                    { new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf"), "Description Team 3", new Guid("ddf42da6-05cd-447b-88be-928ba48088c2"), "Team 3", new Guid("3da7facd-ed9c-4b3c-9cc0-ca25a0676ce9"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111756_adrian.jpg" },
                    { new Guid("45fbb4a3-2a39-48a7-844a-6b98c4f984ba"), "Description Team 12", new Guid("87ce73fb-ca09-40c0-968f-ea7d5faf6050"), "Team 12", new Guid("3da7facd-ed9c-4b3c-9cc0-ca25a0676ce9"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_203137_opeter.jpg" },
                    { new Guid("48aadb04-57be-46ff-9a37-14b891236c70"), "Description Team 6", new Guid("c7fed090-f154-4aa1-9208-ef6e5d709cba"), "Team 6", new Guid("5c08b0d7-7ada-4e74-9a0b-40a6beeecb87"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104459_david.jpg" },
                    { new Guid("516c8d4d-98d2-449b-9bd6-01a4f0657c78"), "Description Team 9", new Guid("ecfc39e0-f5e1-4231-8cbc-a3ff7e97833d"), "Team 9", new Guid("dd5030eb-95d5-4a13-b0be-f159d2b09277"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190507_opeter.jpg" },
                    { new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), "Description Team 1", new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), "Team 1", new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg" },
                    { new Guid("61c633b7-dee3-4798-a5c5-c664c53f6bee"), "Description Team 10", new Guid("87ce73fb-ca09-40c0-968f-ea7d5faf6050"), "Team 10", new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_165442_opeter.jpg" },
                    { new Guid("64e095fb-e61a-404b-898d-316b42043b4d"), "Description Team 5", new Guid("97596a29-02f5-4379-a530-e507ef6eb5e6"), "Team 5", new Guid("3da7facd-ed9c-4b3c-9cc0-ca25a0676ce9"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104618_david.jpg" },
                    { new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40"), "Description Team 7", new Guid("49168dad-443c-45c7-ab54-d8765437ae41"), "Team 7", new Guid("1893a9d1-a4d4-4a63-96bf-fdbe599ac893"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_111742_david.jpg" },
                    { new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3"), "Description Team 8", new Guid("a41ea1cb-f961-4a79-a280-610ba5c4a440"), "Team 8", new Guid("c8484dfc-1488-4eb9-8390-2aaacf72646c"), "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_190545_opeter.jpg" },
                    { new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b"), "Description Team 4", new Guid("87ce73fb-ca09-40c0-968f-ea7d5faf6050"), "Team 4", new Guid("a93ba3f8-52ec-4968-91ee-5590c716a63b"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_104600_adrian.jpg" },
                    { new Guid("bee42231-e07c-42a1-b4c0-9656aee53412"), "Description Team 11", new Guid("ddf42da6-05cd-447b-88be-928ba48088c2"), "Team 11", new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a"), "https://spot.sch.bme.hu/photos/2023/20231014_muegyetemi_roplabda/2048/20231014_134530_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Categories", "Date", "Description", "EntryDeadline", "LocationId", "Name", "Organizer", "PictureLink", "PriceType", "RegistrationPolicy", "TeamPolicy" },
                values: new object[,]
                {
                    { new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1128), "Description Tournament 1", new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1131), new Guid("93c67519-3e07-4626-917e-a83480c02efc"), "Tournament 1", "Organizer 1", "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_211740_barczy.jpg", 16, "Registration Policy 1", "Team Policy 1" },
                    { new Guid("6c30be59-a513-459e-ac57-89a2fcccbe20"), 4, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1134), "Description Tournament 2", new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1136), new Guid("ddf42da6-05cd-447b-88be-928ba48088c2"), "Tournament 2", "Organizer 2", "https://spot.sch.bme.hu/photos/2024/20241123_muegyetemi_roplabdatorna_november/2048/20241123_142046_kendras.jpg", 16, "Registration Policy 2", "Team Policy 2" },
                    { new Guid("8a1cc25a-e8c7-470e-aed2-e20c13e5a78a"), 1, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1138), "Description Tournament 3", new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1140), new Guid("87ce73fb-ca09-40c0-968f-ea7d5faf6050"), "Tournament 3", "Organizer 3", "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_145814_kendras.jpg", 16, "Registration Policy 3", "Team Policy 3" }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTeams",
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a") });

            migrationBuilder.InsertData(
                table: "FavouriteTournaments",
                columns: new[] { "TournamentId", "UserId" },
                values: new object[] { new Guid("6c30be59-a513-459e-ac57-89a2fcccbe20"), new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a") });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "LocationId", "RefereeId", "StartTime", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("001d73aa-3905-4351-b7d7-076b725af59d"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(863), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("02376867-f1e7-498c-b1a9-8a473d2482a5"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(917), new Guid("93c67519-3e07-4626-917e-a83480c02efc"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new DateTime(2024, 4, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6c30be59-a513-459e-ac57-89a2fcccbe20") },
                    { new Guid("05580d17-b0b2-4c0c-b11f-1ece166d548c"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(834), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("0de04e0b-500f-485e-a8fa-130d2a74351f"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(815), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("1dcac372-7624-4745-8d26-b47df7f0a002"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(820), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3"), new DateTime(2024, 4, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("25d9e577-cba3-4fc1-afd8-3a4eecadc48b"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(759), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("3746feab-72e9-4bf7-a18e-d8f8408192ca"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(909), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("3e8e9424-213e-4774-a810-3a95fdebe29b"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(919), new Guid("ddf42da6-05cd-447b-88be-928ba48088c2"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new DateTime(2024, 4, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a1cc25a-e8c7-470e-aed2-e20c13e5a78a") },
                    { new Guid("4500f53c-359a-432d-a16f-af749b53a9ba"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(848), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3"), new DateTime(2024, 4, 3, 13, 55, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("46dcea78-3ba1-40ae-b217-bfdc6fee9f95"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(807), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("474f7182-7594-4c08-899c-258e9b39d7e0"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(812), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("579addba-0604-4a34-a0a6-857cfb86e169"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(843), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("5ebfebf8-ad5b-40d3-a43c-878f240861fc"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(855), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40"), new DateTime(2024, 4, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("6a5a536d-0b98-4d55-9210-5f99d54eaa82"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(850), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b"), new DateTime(2024, 4, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("86e8af62-6706-4f23-80e9-80af55a1ef15"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(904), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("91435969-2be3-4763-9e51-0eef7b727cab"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(810), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("9e82cf89-c385-411f-bae9-ba1cda7a617e"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(865), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("a0c2a8d8-16d3-402a-b3f5-f4cbbe09b417"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(853), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d"), new DateTime(2024, 4, 3, 14, 40, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("a3ef2cad-8830-451b-808c-70cf444a9fbe"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(817), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("b09ef59a-c69a-4d3e-b903-447298362848"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(822), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70"), new DateTime(2024, 4, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("c2aaafa2-f543-49ac-9deb-3e3a5240d660"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(907), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40"), new DateTime(2024, 4, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("c6514e40-2889-4d20-8ade-8a85363eb778"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(914), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("d06f934d-00bf-421c-b5b9-f6da228b3944"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(901), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("d1030b00-61d8-4b97-8250-6c968774231d"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(845), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf"), new DateTime(2024, 4, 3, 19, 10, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("d2304a8c-da07-46cf-9efa-46f4e42225d5"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(860), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new DateTime(2024, 4, 3, 15, 50, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("d39423dd-1c36-4334-864b-8b07a7c81827"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(825), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3"), new DateTime(2024, 4, 3, 17, 5, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("d6d5d336-7dd3-494e-b3b2-c2a2e2801e28"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(829), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf"), new DateTime(2024, 4, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("db529179-9248-46ad-b2ab-45dff0292ce0"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(839), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d"), new DateTime(2024, 4, 3, 18, 20, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("e7b5b905-cdb2-45c7-b61b-077f52ad83fa"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(912), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new DateTime(2024, 4, 3, 18, 45, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("fe19c9dd-b593-48a1-a5ea-d90f62510ce0"), new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(858), new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3"), new DateTime(2024, 4, 3, 15, 25, 0, 0, DateTimeKind.Unspecified), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") }
                });

            migrationBuilder.InsertData(
                table: "TeamCoaches",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3"), new Guid("3da7facd-ed9c-4b3c-9cc0-ca25a0676ce9") },
                    { new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf"), new Guid("a93ba3f8-52ec-4968-91ee-5590c716a63b") },
                    { new Guid("45fbb4a3-2a39-48a7-844a-6b98c4f984ba"), new Guid("c8484dfc-1488-4eb9-8390-2aaacf72646c") },
                    { new Guid("48aadb04-57be-46ff-9a37-14b891236c70"), new Guid("1893a9d1-a4d4-4a63-96bf-fdbe599ac893") },
                    { new Guid("516c8d4d-98d2-449b-9bd6-01a4f0657c78"), new Guid("12c050a0-c322-4b74-803e-3471ea335e4e") },
                    { new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new Guid("0977f359-4c9a-4a97-b5e5-e483fdcfec6f") },
                    { new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a") },
                    { new Guid("61c633b7-dee3-4798-a5c5-c664c53f6bee"), new Guid("12c050a0-c322-4b74-803e-3471ea335e4e") },
                    { new Guid("64e095fb-e61a-404b-898d-316b42043b4d"), new Guid("5c08b0d7-7ada-4e74-9a0b-40a6beeecb87") },
                    { new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40"), new Guid("c8484dfc-1488-4eb9-8390-2aaacf72646c") },
                    { new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3"), new Guid("dd5030eb-95d5-4a13-b0be-f159d2b09277") },
                    { new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b"), new Guid("1f02cf69-07f6-46fe-aa62-fd8def0d72b5") },
                    { new Guid("bee42231-e07c-42a1-b4c0-9656aee53412"), new Guid("1f02cf69-07f6-46fe-aa62-fd8def0d72b5") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "TeamId", "UserId" },
                values: new object[,]
                {
                    { new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3"), new Guid("0977f359-4c9a-4a97-b5e5-e483fdcfec6f") },
                    { new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3"), new Guid("a93ba3f8-52ec-4968-91ee-5590c716a63b") },
                    { new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf"), new Guid("1893a9d1-a4d4-4a63-96bf-fdbe599ac893") },
                    { new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf"), new Guid("5c08b0d7-7ada-4e74-9a0b-40a6beeecb87") },
                    { new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf"), new Guid("c8484dfc-1488-4eb9-8390-2aaacf72646c") },
                    { new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new Guid("1f02cf69-07f6-46fe-aa62-fd8def0d72b5") },
                    { new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new Guid("3da7facd-ed9c-4b3c-9cc0-ca25a0676ce9") },
                    { new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a") },
                    { new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b"), new Guid("12c050a0-c322-4b74-803e-3471ea335e4e") },
                    { new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b"), new Guid("dd5030eb-95d5-4a13-b0be-f159d2b09277") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3"), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf"), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("48aadb04-57be-46ff-9a37-14b891236c70"), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e"), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("64e095fb-e61a-404b-898d-316b42043b4d"), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40"), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3"), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b"), new Guid("289ea6bd-bf44-4821-a2c0-b3e796e14389") },
                    { new Guid("516c8d4d-98d2-449b-9bd6-01a4f0657c78"), new Guid("6c30be59-a513-459e-ac57-89a2fcccbe20") },
                    { new Guid("61c633b7-dee3-4798-a5c5-c664c53f6bee"), new Guid("6c30be59-a513-459e-ac57-89a2fcccbe20") },
                    { new Guid("45fbb4a3-2a39-48a7-844a-6b98c4f984ba"), new Guid("8a1cc25a-e8c7-470e-aed2-e20c13e5a78a") },
                    { new Guid("bee42231-e07c-42a1-b4c0-9656aee53412"), new Guid("8a1cc25a-e8c7-470e-aed2-e20c13e5a78a") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "AcceptableTickets", "Date", "Description", "LocationId", "PictureLink", "TeamId" },
                values: new object[,]
                {
                    { new Guid("051060df-f83b-4017-acf1-4ed53fdef8b1"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1188), "Training1", new Guid("1541127a-87bd-42ec-a056-6717ab509c4a"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_152608_kendras.jpg", new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e") },
                    { new Guid("1dec75bf-a403-4c19-8dea-8234f4b1ddf4"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1196), "Training4", new Guid("ddf42da6-05cd-447b-88be-928ba48088c2"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_114846_adrian.jpg", new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("209fc838-d2ae-4915-8079-679df310ab88"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1194), "Training3", new Guid("ddf42da6-05cd-447b-88be-928ba48088c2"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_192702_kendras.jpg", new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") },
                    { new Guid("2874c054-099a-42c0-b0a0-1c9808b27dd5"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1199), "Training5", new Guid("97596a29-02f5-4379-a530-e507ef6eb5e6"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_121150_adrian.jpg", new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("2a1b4810-52c7-4b14-bf7c-d529781e482e"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1203), "Training7", new Guid("49168dad-443c-45c7-ab54-d8765437ae41"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_162113_adrian.jpg", new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("6fd3f09d-db56-425f-a936-4e15b1aa36e6"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1201), "Training6", new Guid("c7fed090-f154-4aa1-9208-ef6e5d709cba"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_130940_adrian.jpg", new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") },
                    { new Guid("725366b2-781c-4cd3-b38b-be7c5beb8ddd"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1208), "Training9", new Guid("ecfc39e0-f5e1-4231-8cbc-a3ff7e97833d"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_215753_gyongyi.jpg", new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b") },
                    { new Guid("9983e125-1253-4e99-8380-133e5e98fe70"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1192), "Training2", new Guid("93c67519-3e07-4626-917e-a83480c02efc"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_182542_kendras.jpg", new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e") },
                    { new Guid("dd1b2e5f-0122-4171-885c-1a0c9bb9d1a2"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1210), "Training10", new Guid("34613a5f-77ba-4f88-af95-83a16a11a847"), "https://spot.sch.bme.hu/photos/2024/20240921_muegyetemi_roplabda/2048/20240921_183319_kendras.jpg", new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b") },
                    { new Guid("ffbaa7e4-7c31-494a-9086-bbdcc78f707d"), 5, new DateTime(2025, 4, 23, 14, 39, 17, 379, DateTimeKind.Local).AddTicks(1206), "Training8", new Guid("a41ea1cb-f961-4a79-a280-610ba5c4a440"), "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_182355_gery.jpg", new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") }
                });

            migrationBuilder.InsertData(
                table: "FavouriteTrainings",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[] { new Guid("051060df-f83b-4017-acf1-4ed53fdef8b1"), new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a") });

            migrationBuilder.InsertData(
                table: "MatchTeams",
                columns: new[] { "MatchId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("001d73aa-3905-4351-b7d7-076b725af59d"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d") },
                    { new Guid("001d73aa-3905-4351-b7d7-076b725af59d"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40") },
                    { new Guid("02376867-f1e7-498c-b1a9-8a473d2482a5"), new Guid("516c8d4d-98d2-449b-9bd6-01a4f0657c78") },
                    { new Guid("02376867-f1e7-498c-b1a9-8a473d2482a5"), new Guid("61c633b7-dee3-4798-a5c5-c664c53f6bee") },
                    { new Guid("05580d17-b0b2-4c0c-b11f-1ece166d548c"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("05580d17-b0b2-4c0c-b11f-1ece166d548c"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b") },
                    { new Guid("0de04e0b-500f-485e-a8fa-130d2a74351f"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("0de04e0b-500f-485e-a8fa-130d2a74351f"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e") },
                    { new Guid("1dcac372-7624-4745-8d26-b47df7f0a002"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("1dcac372-7624-4745-8d26-b47df7f0a002"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70") },
                    { new Guid("25d9e577-cba3-4fc1-afd8-3a4eecadc48b"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("25d9e577-cba3-4fc1-afd8-3a4eecadc48b"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d") },
                    { new Guid("3746feab-72e9-4bf7-a18e-d8f8408192ca"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e") },
                    { new Guid("3746feab-72e9-4bf7-a18e-d8f8408192ca"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b") },
                    { new Guid("3e8e9424-213e-4774-a810-3a95fdebe29b"), new Guid("45fbb4a3-2a39-48a7-844a-6b98c4f984ba") },
                    { new Guid("3e8e9424-213e-4774-a810-3a95fdebe29b"), new Guid("bee42231-e07c-42a1-b4c0-9656aee53412") },
                    { new Guid("4500f53c-359a-432d-a16f-af749b53a9ba"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e") },
                    { new Guid("4500f53c-359a-432d-a16f-af749b53a9ba"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3") },
                    { new Guid("46dcea78-3ba1-40ae-b217-bfdc6fee9f95"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("46dcea78-3ba1-40ae-b217-bfdc6fee9f95"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3") },
                    { new Guid("474f7182-7594-4c08-899c-258e9b39d7e0"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70") },
                    { new Guid("474f7182-7594-4c08-899c-258e9b39d7e0"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b") },
                    { new Guid("579addba-0604-4a34-a0a6-857cfb86e169"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") },
                    { new Guid("579addba-0604-4a34-a0a6-857cfb86e169"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("5ebfebf8-ad5b-40d3-a43c-878f240861fc"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") },
                    { new Guid("5ebfebf8-ad5b-40d3-a43c-878f240861fc"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40") },
                    { new Guid("6a5a536d-0b98-4d55-9210-5f99d54eaa82"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e") },
                    { new Guid("6a5a536d-0b98-4d55-9210-5f99d54eaa82"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d") },
                    { new Guid("86e8af62-6706-4f23-80e9-80af55a1ef15"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e") },
                    { new Guid("86e8af62-6706-4f23-80e9-80af55a1ef15"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40") },
                    { new Guid("91435969-2be3-4763-9e51-0eef7b727cab"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70") },
                    { new Guid("91435969-2be3-4763-9e51-0eef7b727cab"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40") },
                    { new Guid("9e82cf89-c385-411f-bae9-ba1cda7a617e"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") },
                    { new Guid("9e82cf89-c385-411f-bae9-ba1cda7a617e"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e") },
                    { new Guid("a0c2a8d8-16d3-402a-b3f5-f4cbbe09b417"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") },
                    { new Guid("a0c2a8d8-16d3-402a-b3f5-f4cbbe09b417"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b") },
                    { new Guid("a3ef2cad-8830-451b-808c-70cf444a9fbe"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") },
                    { new Guid("a3ef2cad-8830-451b-808c-70cf444a9fbe"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70") },
                    { new Guid("b09ef59a-c69a-4d3e-b903-447298362848"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3") },
                    { new Guid("b09ef59a-c69a-4d3e-b903-447298362848"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b") },
                    { new Guid("c2aaafa2-f543-49ac-9deb-3e3a5240d660"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") },
                    { new Guid("c2aaafa2-f543-49ac-9deb-3e3a5240d660"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d") },
                    { new Guid("c6514e40-2889-4d20-8ade-8a85363eb778"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70") },
                    { new Guid("c6514e40-2889-4d20-8ade-8a85363eb778"), new Guid("5e906d5b-b95f-4cb4-be42-d73c8d9dd65e") },
                    { new Guid("d06f934d-00bf-421c-b5b9-f6da228b3944"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d") },
                    { new Guid("d06f934d-00bf-421c-b5b9-f6da228b3944"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b") },
                    { new Guid("d1030b00-61d8-4b97-8250-6c968774231d"), new Guid("05bdadca-e86d-4ac8-adf0-a2c55ce9afc3") },
                    { new Guid("d1030b00-61d8-4b97-8250-6c968774231d"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3") },
                    { new Guid("d2304a8c-da07-46cf-9efa-46f4e42225d5"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40") },
                    { new Guid("d2304a8c-da07-46cf-9efa-46f4e42225d5"), new Guid("8af48c6c-45bc-4214-9dae-628bd6c59d7b") },
                    { new Guid("d39423dd-1c36-4334-864b-8b07a7c81827"), new Guid("2b06f33b-d58f-4441-bb9d-672884afabaf") },
                    { new Guid("d39423dd-1c36-4334-864b-8b07a7c81827"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40") },
                    { new Guid("d6d5d336-7dd3-494e-b3b2-c2a2e2801e28"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70") },
                    { new Guid("d6d5d336-7dd3-494e-b3b2-c2a2e2801e28"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3") },
                    { new Guid("db529179-9248-46ad-b2ab-45dff0292ce0"), new Guid("66cb507b-bc94-4993-b0ad-4bfd7f4b2d40") },
                    { new Guid("db529179-9248-46ad-b2ab-45dff0292ce0"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3") },
                    { new Guid("e7b5b905-cdb2-45c7-b61b-077f52ad83fa"), new Guid("48aadb04-57be-46ff-9a37-14b891236c70") },
                    { new Guid("e7b5b905-cdb2-45c7-b61b-077f52ad83fa"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d") },
                    { new Guid("fe19c9dd-b593-48a1-a5ea-d90f62510ce0"), new Guid("64e095fb-e61a-404b-898d-316b42043b4d") },
                    { new Guid("fe19c9dd-b593-48a1-a5ea-d90f62510ce0"), new Guid("6afef8af-3050-4ce0-8d1f-e925387057f3") }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "TrainingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9983e125-1253-4e99-8380-133e5e98fe70"), new Guid("0977f359-4c9a-4a97-b5e5-e483fdcfec6f") },
                    { new Guid("dd1b2e5f-0122-4171-885c-1a0c9bb9d1a2"), new Guid("12c050a0-c322-4b74-803e-3471ea335e4e") },
                    { new Guid("2a1b4810-52c7-4b14-bf7c-d529781e482e"), new Guid("1893a9d1-a4d4-4a63-96bf-fdbe599ac893") },
                    { new Guid("2874c054-099a-42c0-b0a0-1c9808b27dd5"), new Guid("1f02cf69-07f6-46fe-aa62-fd8def0d72b5") },
                    { new Guid("209fc838-d2ae-4915-8079-679df310ab88"), new Guid("3da7facd-ed9c-4b3c-9cc0-ca25a0676ce9") },
                    { new Guid("6fd3f09d-db56-425f-a936-4e15b1aa36e6"), new Guid("5c08b0d7-7ada-4e74-9a0b-40a6beeecb87") },
                    { new Guid("051060df-f83b-4017-acf1-4ed53fdef8b1"), new Guid("6e012db5-3875-4db7-a6bb-ef511da54b3a") },
                    { new Guid("1dec75bf-a403-4c19-8dea-8234f4b1ddf4"), new Guid("a93ba3f8-52ec-4968-91ee-5590c716a63b") },
                    { new Guid("ffbaa7e4-7c31-494a-9086-bbdcc78f707d"), new Guid("c8484dfc-1488-4eb9-8390-2aaacf72646c") },
                    { new Guid("725366b2-781c-4cd3-b38b-be7c5beb8ddd"), new Guid("dd5030eb-95d5-4a13-b0be-f159d2b09277") }
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
