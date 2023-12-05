using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VolleyballAPI.Migrations
{
    /// <inheritdoc />
    public partial class initData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerNumber = table.Column<int>(type: "int", nullable: false),
                    TicketPass = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Posts = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamCoach",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCoach", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TeamCoach_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCoach_Users_UserId",
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

            migrationBuilder.CreateTable(
                name: "TeamPlayers",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayers", x => new { x.TeamId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_TeamPlayers_PlayerDetails_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("2fa58dda-a85c-4033-906f-e8102a8350ad"), "Description Team 1", "Team 1", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_095029_opeter.jpg" },
                    { new Guid("3b83dd1c-9539-4387-93d2-b6a0632f97ef"), "Description Team 2", "Team 2", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" },
                    { new Guid("4368df9f-73e3-444f-b36c-1ae864f346b0"), "Description Team 4", "Team 4", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" },
                    { new Guid("65d07961-c4c4-43d4-a815-e47bb8ecc17a"), "Description Team 3", "Team 3", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_114305_adam.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "Location", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("194a7716-a54f-45c5-a757-671750ea2e23"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7497), "Description Team 1", "Location tournament 1", "Tournament 1", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" },
                    { new Guid("1db4a9f3-3372-491e-9b9d-4cd4375d564e"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7539), "Description Tournament 2", "Location tournament 2", "Tournament 2", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Roles" },
                values: new object[,]
                {
                    { new Guid("024008fe-419d-4ae8-a74a-c96d330825ef"), "user10@user.com", "Name 10", "pass10", "BasicUser" },
                    { new Guid("04e8cb77-d7b5-49ca-9465-7d29fed071c4"), "user6@user.com", "Name 6", "pass6", "BasicUser" },
                    { new Guid("0d630cb0-6725-4b79-b451-c9f25b2392d1"), "user5@user.com", "Name 5", "pass5", "Coach" },
                    { new Guid("4c2b8d87-058f-479e-b39f-06ab2408a2eb"), "user9@user.com", "Name 9", "pass9", "BasicUser" },
                    { new Guid("6a305261-0d89-44a4-a306-086862a3da0f"), "user2@user.com", "Name 2", "pass2", "Administrator,BasicUser" },
                    { new Guid("6e4aa48f-5fce-4c78-b418-1dc1afd0bbd3"), "user8@user.com", "Name 8", "pass8", "Administrator,BasicUser" },
                    { new Guid("7f7fbd19-79c1-41cc-8217-36307aa439f9"), "user1@user.com", "Name 1", "pass1", "Coach,BasicUser" },
                    { new Guid("8e2f88d7-1aa6-4cea-88d1-1adeeb83f1e5"), "user4@user.com", "Name 4", "pass4", "BasicUser" },
                    { new Guid("8ee4fdb8-6765-4994-9580-77c65c34380b"), "user7@user.com", "Name 7", "pass7", "Coach" },
                    { new Guid("eeb0d723-4361-4577-87fc-c00561f6f0f8"), "user3@user.com", "Name 3", "pass3", "BasicUser" }
                });

            migrationBuilder.InsertData(
                table: "PlayerDetails",
                columns: new[] { "Id", "Birthday", "Gender", "Phone", "PlayerNumber", "Posts", "TicketPass", "UserId" },
                values: new object[,]
                {
                    { new Guid("13b117cb-d899-4f9c-88d2-c7b496a996fa"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7597), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("eeb0d723-4361-4577-87fc-c00561f6f0f8") },
                    { new Guid("14352a50-0f76-4365-a11c-ef28cc99f265"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7605), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("04e8cb77-d7b5-49ca-9465-7d29fed071c4") },
                    { new Guid("1a20e7b2-1e03-40d2-b078-838e8b6e09c4"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7608), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("8ee4fdb8-6765-4994-9580-77c65c34380b") },
                    { new Guid("1ca9e487-ae63-40ca-b933-818a7488f9fc"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7611), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("6e4aa48f-5fce-4c78-b418-1dc1afd0bbd3") },
                    { new Guid("1dad849b-347d-498d-af1e-3600be123747"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7617), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("024008fe-419d-4ae8-a74a-c96d330825ef") },
                    { new Guid("3b948752-a418-4b3c-aefc-70204ea141ef"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7602), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("0d630cb0-6725-4b79-b451-c9f25b2392d1") },
                    { new Guid("99ed4212-2526-46f8-8a70-11d5c30d7c43"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7614), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("4c2b8d87-058f-479e-b39f-06ab2408a2eb") },
                    { new Guid("bc754730-52bb-4687-9a82-42ad875ff8e6"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7594), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("6a305261-0d89-44a4-a306-086862a3da0f") },
                    { new Guid("df08cbff-86a3-4fce-b3f7-0c794ad9ad32"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7599), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("8e2f88d7-1aa6-4cea-88d1-1adeeb83f1e5") },
                    { new Guid("dff0053b-82af-4a9f-9677-31f211793556"), new DateTime(2023, 12, 5, 11, 20, 20, 306, DateTimeKind.Local).AddTicks(7585), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("7f7fbd19-79c1-41cc-8217-36307aa439f9") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "PlayerId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("13b117cb-d899-4f9c-88d2-c7b496a996fa"), new Guid("2fa58dda-a85c-4033-906f-e8102a8350ad") },
                    { new Guid("3b948752-a418-4b3c-aefc-70204ea141ef"), new Guid("2fa58dda-a85c-4033-906f-e8102a8350ad") },
                    { new Guid("bc754730-52bb-4687-9a82-42ad875ff8e6"), new Guid("2fa58dda-a85c-4033-906f-e8102a8350ad") },
                    { new Guid("df08cbff-86a3-4fce-b3f7-0c794ad9ad32"), new Guid("2fa58dda-a85c-4033-906f-e8102a8350ad") },
                    { new Guid("dff0053b-82af-4a9f-9677-31f211793556"), new Guid("2fa58dda-a85c-4033-906f-e8102a8350ad") },
                    { new Guid("14352a50-0f76-4365-a11c-ef28cc99f265"), new Guid("3b83dd1c-9539-4387-93d2-b6a0632f97ef") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDetails_UserId",
                table: "PlayerDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCoach_UserId",
                table: "TeamCoach",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayers_PlayerId",
                table: "TeamPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentCompetitors_TeamId",
                table: "TournamentCompetitors",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingParticipants_TrainingId",
                table: "TrainingParticipants",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TeamId",
                table: "Trainings",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamCoach");

            migrationBuilder.DropTable(
                name: "TeamPlayers");

            migrationBuilder.DropTable(
                name: "TournamentCompetitors");

            migrationBuilder.DropTable(
                name: "TrainingParticipants");

            migrationBuilder.DropTable(
                name: "PlayerDetails");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
