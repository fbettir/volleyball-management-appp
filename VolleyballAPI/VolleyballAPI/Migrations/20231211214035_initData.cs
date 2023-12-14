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

            migrationBuilder.CreateTable(
                name: "TrainingParticipants",
                columns: table => new
                {
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingParticipants", x => new { x.PlayerDetailsId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_TrainingParticipants_PlayerDetails_PlayerDetailsId",
                        column: x => x.PlayerDetailsId,
                        principalTable: "PlayerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingParticipants_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("2ea2d390-72c2-4081-a706-a54d73e99f9e"), "Description Team 3", "Team 3", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_114305_adam.jpg" },
                    { new Guid("63c8f8eb-1067-489e-ad14-52777ffbda39"), "Description Team 2", "Team 2", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" },
                    { new Guid("74faaddc-c386-4fc2-a0b4-9dae1981dec0"), "Description Team 1", "Team 1", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_095029_opeter.jpg" },
                    { new Guid("df9aa13e-2818-4d18-b15e-8d903a0220e8"), "Description Team 4", "Team 4", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "Location", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("3cad46e7-e901-4d6a-aa85-58bb13f4338e"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2308), "Description Tournament 3", "Location tournament 3", "Tournament 3", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" },
                    { new Guid("a2764122-1831-4c8b-835b-b63717d3deb6"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2261), "Description Team 1", "Location tournament 1", "Tournament 1", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" },
                    { new Guid("fa74e37d-fb20-468a-ba1a-5a040ca8afd9"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2305), "Description Tournament 2", "Location tournament 2", "Tournament 2", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Roles" },
                values: new object[,]
                {
                    { new Guid("02441339-97aa-49b0-9ae6-04ea07573451"), "user2@user.com", "Name 2", "pass2", "Administrator,BasicUser" },
                    { new Guid("0480f9a0-2946-471d-811c-be3e90e8b333"), "user8@user.com", "Name 8", "pass8", "Administrator,BasicUser" },
                    { new Guid("4be5fa8f-cf32-445d-95e5-b3dad4e501c2"), "user6@user.com", "Name 6", "pass6", "BasicUser" },
                    { new Guid("539dfaf7-81d2-425f-869f-d4b4afbe13e1"), "user5@user.com", "Name 5", "pass5", "Coach" },
                    { new Guid("733c187c-3554-4b56-904c-aa35d5d17588"), "user4@user.com", "Name 4", "pass4", "BasicUser" },
                    { new Guid("a43d8788-5c29-4f4c-85e0-590d54be197c"), "user10@user.com", "Name 10", "pass10", "BasicUser" },
                    { new Guid("b9cc6f90-c98b-445b-82fb-ccbda9d4beb6"), "user9@user.com", "Name 9", "pass9", "BasicUser" },
                    { new Guid("c2c3c86b-da9e-4d19-b45f-a4cee5bf7736"), "user7@user.com", "Name 7", "pass7", "Coach" },
                    { new Guid("cdc0a936-3687-4799-8991-00bf5c64bd3e"), "user1@user.com", "Name 1", "pass1", "Coach,BasicUser" },
                    { new Guid("ea89d17a-92fc-491a-971b-b0cc9b995539"), "user3@user.com", "Name 3", "pass3", "BasicUser" }
                });

            migrationBuilder.InsertData(
                table: "PlayerDetails",
                columns: new[] { "Id", "Birthday", "Gender", "Phone", "PlayerNumber", "Posts", "TicketPass", "UserId" },
                values: new object[,]
                {
                    { new Guid("16df8456-3386-4833-8296-ebff0c1cd1a8"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2388), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("a43d8788-5c29-4f4c-85e0-590d54be197c") },
                    { new Guid("2105dd07-dfb6-49df-8c2e-cfbb1aeccaa5"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2374), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("539dfaf7-81d2-425f-869f-d4b4afbe13e1") },
                    { new Guid("4ce50b70-c4c5-4037-b519-59df4afdd96b"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2379), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("c2c3c86b-da9e-4d19-b45f-a4cee5bf7736") },
                    { new Guid("a8869498-a428-4446-ad95-a810744bd035"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2358), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("cdc0a936-3687-4799-8991-00bf5c64bd3e") },
                    { new Guid("b5b938d3-9491-49b7-93fa-20ee5a09f31b"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2385), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("b9cc6f90-c98b-445b-82fb-ccbda9d4beb6") },
                    { new Guid("b76d79d7-80c0-4baa-bad8-8c8c0f929c90"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2382), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("0480f9a0-2946-471d-811c-be3e90e8b333") },
                    { new Guid("bd24906d-9c5f-485c-9d68-785708af1e49"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2365), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("02441339-97aa-49b0-9ae6-04ea07573451") },
                    { new Guid("d503c33c-56c7-4a56-b6a9-908f8386515e"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2368), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("ea89d17a-92fc-491a-971b-b0cc9b995539") },
                    { new Guid("ee50ae98-2644-494f-a00c-ad500b60a1f3"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2376), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("4be5fa8f-cf32-445d-95e5-b3dad4e501c2") },
                    { new Guid("f450060b-2a10-4aa4-bc2c-e11fab94a2df"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2371), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("733c187c-3554-4b56-904c-aa35d5d17588") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("2ea2d390-72c2-4081-a706-a54d73e99f9e"), new Guid("3cad46e7-e901-4d6a-aa85-58bb13f4338e") },
                    { new Guid("74faaddc-c386-4fc2-a0b4-9dae1981dec0"), new Guid("a2764122-1831-4c8b-835b-b63717d3deb6") },
                    { new Guid("63c8f8eb-1067-489e-ad14-52777ffbda39"), new Guid("fa74e37d-fb20-468a-ba1a-5a040ca8afd9") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Date", "Description", "Location", "TeamId" },
                values: new object[,]
                {
                    { new Guid("009ca0f7-49ad-42ba-828a-77b76f3e005b"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2470), "Training8", "Training court 8", new Guid("63c8f8eb-1067-489e-ad14-52777ffbda39") },
                    { new Guid("65e1a184-4d2d-4c62-bdfc-a92e29b76fe0"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2472), "Training9", "Training court 9", new Guid("df9aa13e-2818-4d18-b15e-8d903a0220e8") },
                    { new Guid("7107045c-ca72-4c9c-83f2-675dd631b271"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2462), "Training4", "Training court 4", new Guid("2ea2d390-72c2-4081-a706-a54d73e99f9e") },
                    { new Guid("97cb3b48-fbc6-4a2d-a829-e3606a651331"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2468), "Training7", "Training court 7", new Guid("2ea2d390-72c2-4081-a706-a54d73e99f9e") },
                    { new Guid("a02eec8f-c563-47a6-a804-a68da4bf014f"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2475), "Training10", "Training court 10", new Guid("df9aa13e-2818-4d18-b15e-8d903a0220e8") },
                    { new Guid("a6e4f1a5-0865-42c3-9e8d-6a556d89b1d9"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2455), "Training1", "Training court 1", new Guid("74faaddc-c386-4fc2-a0b4-9dae1981dec0") },
                    { new Guid("b0f7ca61-7594-4e68-a95b-96d27e48f8d3"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2458), "Training2", "Training court 2", new Guid("74faaddc-c386-4fc2-a0b4-9dae1981dec0") },
                    { new Guid("bfbeceae-dc69-456d-9e81-742de3889606"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2460), "Training1", "Training court 3", new Guid("63c8f8eb-1067-489e-ad14-52777ffbda39") },
                    { new Guid("cadac11d-da6c-4687-b587-49fa2458a7d2"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2464), "Training5", "Training court 5", new Guid("2ea2d390-72c2-4081-a706-a54d73e99f9e") },
                    { new Guid("eeba3b02-48da-46bb-bd40-f382890ee942"), new DateTime(2023, 12, 11, 22, 40, 35, 186, DateTimeKind.Local).AddTicks(2466), "Training6", "Training court 6", new Guid("63c8f8eb-1067-489e-ad14-52777ffbda39") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "PlayerId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("ee50ae98-2644-494f-a00c-ad500b60a1f3"), new Guid("63c8f8eb-1067-489e-ad14-52777ffbda39") },
                    { new Guid("2105dd07-dfb6-49df-8c2e-cfbb1aeccaa5"), new Guid("74faaddc-c386-4fc2-a0b4-9dae1981dec0") },
                    { new Guid("a8869498-a428-4446-ad95-a810744bd035"), new Guid("74faaddc-c386-4fc2-a0b4-9dae1981dec0") },
                    { new Guid("bd24906d-9c5f-485c-9d68-785708af1e49"), new Guid("74faaddc-c386-4fc2-a0b4-9dae1981dec0") },
                    { new Guid("d503c33c-56c7-4a56-b6a9-908f8386515e"), new Guid("74faaddc-c386-4fc2-a0b4-9dae1981dec0") },
                    { new Guid("f450060b-2a10-4aa4-bc2c-e11fab94a2df"), new Guid("74faaddc-c386-4fc2-a0b4-9dae1981dec0") }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "PlayerDetailsId", "TrainingId" },
                values: new object[,]
                {
                    { new Guid("16df8456-3386-4833-8296-ebff0c1cd1a8"), new Guid("cadac11d-da6c-4687-b587-49fa2458a7d2") },
                    { new Guid("2105dd07-dfb6-49df-8c2e-cfbb1aeccaa5"), new Guid("b0f7ca61-7594-4e68-a95b-96d27e48f8d3") },
                    { new Guid("4ce50b70-c4c5-4037-b519-59df4afdd96b"), new Guid("bfbeceae-dc69-456d-9e81-742de3889606") },
                    { new Guid("a8869498-a428-4446-ad95-a810744bd035"), new Guid("a6e4f1a5-0865-42c3-9e8d-6a556d89b1d9") },
                    { new Guid("b5b938d3-9491-49b7-93fa-20ee5a09f31b"), new Guid("cadac11d-da6c-4687-b587-49fa2458a7d2") },
                    { new Guid("b76d79d7-80c0-4baa-bad8-8c8c0f929c90"), new Guid("7107045c-ca72-4c9c-83f2-675dd631b271") },
                    { new Guid("bd24906d-9c5f-485c-9d68-785708af1e49"), new Guid("a6e4f1a5-0865-42c3-9e8d-6a556d89b1d9") },
                    { new Guid("d503c33c-56c7-4a56-b6a9-908f8386515e"), new Guid("a6e4f1a5-0865-42c3-9e8d-6a556d89b1d9") },
                    { new Guid("ee50ae98-2644-494f-a00c-ad500b60a1f3"), new Guid("bfbeceae-dc69-456d-9e81-742de3889606") },
                    { new Guid("f450060b-2a10-4aa4-bc2c-e11fab94a2df"), new Guid("b0f7ca61-7594-4e68-a95b-96d27e48f8d3") }
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
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "PlayerDetails");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
