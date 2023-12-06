using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VolleyballAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
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
                    { new Guid("079a0da8-655d-4efe-bd34-69da68dde141"), "Description Team 1", "Team 1", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_095029_opeter.jpg" },
                    { new Guid("1a25a6e6-4088-4ce2-b9a0-d7fcb302109c"), "Description Team 4", "Team 4", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" },
                    { new Guid("4a026287-1915-4b42-b347-6d55e8393fe0"), "Description Team 3", "Team 3", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_114305_adam.jpg" },
                    { new Guid("cbde14f0-47c2-4f54-8c55-93cfce61fbec"), "Description Team 2", "Team 2", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "Location", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("015b6668-118e-4bdf-8031-b00f73186967"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1099), "Description Team 1", "Location tournament 1", "Tournament 1", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" },
                    { new Guid("86b07c3e-15da-4bcd-a627-083a72e706dc"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1141), "Description Tournament 3", "Location tournament 3", "Tournament 3", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" },
                    { new Guid("b94b8ad5-4b73-4340-9379-bb4dc652aeee"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1138), "Description Tournament 2", "Location tournament 2", "Tournament 2", "https://spot.sch.bme.hu/photos/2023/20230923_muegyetemi_roplabda/2048/20230923_100756_opeter.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Roles" },
                values: new object[,]
                {
                    { new Guid("00295d78-bf44-43d3-9786-17f43d279525"), "user5@user.com", "Name 5", "pass5", "Coach" },
                    { new Guid("05ae69cd-786c-4977-8607-716cf57b808b"), "user3@user.com", "Name 3", "pass3", "BasicUser" },
                    { new Guid("129106c7-8141-4b63-ba22-875034a91a0a"), "user1@user.com", "Name 1", "pass1", "Coach,BasicUser" },
                    { new Guid("3161794f-a4e2-401f-8e7f-936dc014bafe"), "user6@user.com", "Name 6", "pass6", "BasicUser" },
                    { new Guid("3df074c1-a41f-4047-937b-e953d12300ca"), "user7@user.com", "Name 7", "pass7", "Coach" },
                    { new Guid("4a406306-4799-486e-a0e5-5b97d88e2f54"), "user8@user.com", "Name 8", "pass8", "Administrator,BasicUser" },
                    { new Guid("86c293e5-d5d3-4f7a-9857-d39092aedf8f"), "user9@user.com", "Name 9", "pass9", "BasicUser" },
                    { new Guid("91e18d87-401c-46d0-a24a-cc345f7d5530"), "user4@user.com", "Name 4", "pass4", "BasicUser" },
                    { new Guid("96454bdb-6590-4579-a6e5-30c36159d11b"), "user2@user.com", "Name 2", "pass2", "Administrator,BasicUser" },
                    { new Guid("d58b1964-bf94-4db6-8ef9-30bd91a76be8"), "user10@user.com", "Name 10", "pass10", "BasicUser" }
                });

            migrationBuilder.InsertData(
                table: "PlayerDetails",
                columns: new[] { "Id", "Birthday", "Gender", "Phone", "PlayerNumber", "Posts", "TicketPass", "UserId" },
                values: new object[,]
                {
                    { new Guid("10d1a798-33b8-4d39-8fcc-dccec93b1f66"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1241), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("00295d78-bf44-43d3-9786-17f43d279525") },
                    { new Guid("17ed9499-f0c2-4280-9b32-dd2faadb82d2"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1238), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("91e18d87-401c-46d0-a24a-cc345f7d5530") },
                    { new Guid("6324393f-a649-4337-9d4f-bf2346155656"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1235), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("05ae69cd-786c-4977-8607-716cf57b808b") },
                    { new Guid("73086c94-627e-4ddf-8f9f-b1cd759fb510"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1247), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("3df074c1-a41f-4047-937b-e953d12300ca") },
                    { new Guid("735cbd52-39d7-4453-8dfe-194eaa00c351"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1256), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("d58b1964-bf94-4db6-8ef9-30bd91a76be8") },
                    { new Guid("760d027a-311c-4d24-86d9-f82d3bed8bb2"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1224), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("129106c7-8141-4b63-ba22-875034a91a0a") },
                    { new Guid("9f131d6d-f476-4b2e-a735-bd03487f164e"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1253), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("86c293e5-d5d3-4f7a-9857-d39092aedf8f") },
                    { new Guid("bc6809d9-58f1-4c32-908d-c9e151587cad"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1232), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("96454bdb-6590-4579-a6e5-30c36159d11b") },
                    { new Guid("c43e9bd8-fc58-443d-a013-d49447452f9d"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1244), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("3161794f-a4e2-401f-8e7f-936dc014bafe") },
                    { new Guid("ede1a65a-8137-49f1-b58e-82819086db1d"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1250), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("4a406306-4799-486e-a0e5-5b97d88e2f54") }
                });

            migrationBuilder.InsertData(
                table: "TournamentCompetitors",
                columns: new[] { "TeamId", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("079a0da8-655d-4efe-bd34-69da68dde141"), new Guid("015b6668-118e-4bdf-8031-b00f73186967") },
                    { new Guid("4a026287-1915-4b42-b347-6d55e8393fe0"), new Guid("015b6668-118e-4bdf-8031-b00f73186967") },
                    { new Guid("cbde14f0-47c2-4f54-8c55-93cfce61fbec"), new Guid("015b6668-118e-4bdf-8031-b00f73186967") },
                    { new Guid("079a0da8-655d-4efe-bd34-69da68dde141"), new Guid("86b07c3e-15da-4bcd-a627-083a72e706dc") },
                    { new Guid("1a25a6e6-4088-4ce2-b9a0-d7fcb302109c"), new Guid("86b07c3e-15da-4bcd-a627-083a72e706dc") },
                    { new Guid("cbde14f0-47c2-4f54-8c55-93cfce61fbec"), new Guid("86b07c3e-15da-4bcd-a627-083a72e706dc") },
                    { new Guid("079a0da8-655d-4efe-bd34-69da68dde141"), new Guid("b94b8ad5-4b73-4340-9379-bb4dc652aeee") },
                    { new Guid("1a25a6e6-4088-4ce2-b9a0-d7fcb302109c"), new Guid("b94b8ad5-4b73-4340-9379-bb4dc652aeee") },
                    { new Guid("4a026287-1915-4b42-b347-6d55e8393fe0"), new Guid("b94b8ad5-4b73-4340-9379-bb4dc652aeee") },
                    { new Guid("cbde14f0-47c2-4f54-8c55-93cfce61fbec"), new Guid("b94b8ad5-4b73-4340-9379-bb4dc652aeee") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Date", "Description", "Location", "TeamId" },
                values: new object[,]
                {
                    { new Guid("24f57709-7b7c-492b-8583-1784678b0191"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1309), "Training8", "Training court 8", new Guid("cbde14f0-47c2-4f54-8c55-93cfce61fbec") },
                    { new Guid("372ed2a9-1f57-44c9-a352-366d1e77e2bd"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1304), "Training6", "Training court 6", new Guid("cbde14f0-47c2-4f54-8c55-93cfce61fbec") },
                    { new Guid("3eb31451-abc9-4641-9004-6ac8515d16be"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1311), "Training9", "Training court 9", new Guid("1a25a6e6-4088-4ce2-b9a0-d7fcb302109c") },
                    { new Guid("425fd650-7d3d-4be8-86a9-b8a7a63da9a8"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1295), "Training2", "Training court 2", new Guid("079a0da8-655d-4efe-bd34-69da68dde141") },
                    { new Guid("45cccf20-a236-4ceb-b267-c7824f6482f3"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1300), "Training4", "Training court 4", new Guid("4a026287-1915-4b42-b347-6d55e8393fe0") },
                    { new Guid("46770b38-0a30-4048-9b87-d05d484c9de1"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1306), "Training7", "Training court 7", new Guid("4a026287-1915-4b42-b347-6d55e8393fe0") },
                    { new Guid("773bbf26-feca-4cbc-96ef-c3e01f7cd52e"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1298), "Training1", "Training court 3", new Guid("cbde14f0-47c2-4f54-8c55-93cfce61fbec") },
                    { new Guid("bec0866c-1afa-4f8f-9410-9871f4ab7a48"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1302), "Training5", "Training court 5", new Guid("4a026287-1915-4b42-b347-6d55e8393fe0") },
                    { new Guid("bf520b5c-eda2-41aa-baa1-5f18e4561d74"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1292), "Training1", "Training court 1", new Guid("079a0da8-655d-4efe-bd34-69da68dde141") },
                    { new Guid("e0254e3e-6847-47e4-9285-354a20ba8f7a"), new DateTime(2023, 12, 6, 14, 37, 46, 49, DateTimeKind.Local).AddTicks(1313), "Training10", "Training court 10", new Guid("1a25a6e6-4088-4ce2-b9a0-d7fcb302109c") }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayers",
                columns: new[] { "PlayerId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("10d1a798-33b8-4d39-8fcc-dccec93b1f66"), new Guid("079a0da8-655d-4efe-bd34-69da68dde141") },
                    { new Guid("17ed9499-f0c2-4280-9b32-dd2faadb82d2"), new Guid("079a0da8-655d-4efe-bd34-69da68dde141") },
                    { new Guid("6324393f-a649-4337-9d4f-bf2346155656"), new Guid("079a0da8-655d-4efe-bd34-69da68dde141") },
                    { new Guid("760d027a-311c-4d24-86d9-f82d3bed8bb2"), new Guid("079a0da8-655d-4efe-bd34-69da68dde141") },
                    { new Guid("bc6809d9-58f1-4c32-908d-c9e151587cad"), new Guid("079a0da8-655d-4efe-bd34-69da68dde141") },
                    { new Guid("c43e9bd8-fc58-443d-a013-d49447452f9d"), new Guid("cbde14f0-47c2-4f54-8c55-93cfce61fbec") }
                });

            migrationBuilder.InsertData(
                table: "TrainingParticipants",
                columns: new[] { "PlayerDetailsId", "TrainingId" },
                values: new object[,]
                {
                    { new Guid("10d1a798-33b8-4d39-8fcc-dccec93b1f66"), new Guid("425fd650-7d3d-4be8-86a9-b8a7a63da9a8") },
                    { new Guid("17ed9499-f0c2-4280-9b32-dd2faadb82d2"), new Guid("425fd650-7d3d-4be8-86a9-b8a7a63da9a8") },
                    { new Guid("6324393f-a649-4337-9d4f-bf2346155656"), new Guid("bf520b5c-eda2-41aa-baa1-5f18e4561d74") },
                    { new Guid("73086c94-627e-4ddf-8f9f-b1cd759fb510"), new Guid("773bbf26-feca-4cbc-96ef-c3e01f7cd52e") },
                    { new Guid("735cbd52-39d7-4453-8dfe-194eaa00c351"), new Guid("bec0866c-1afa-4f8f-9410-9871f4ab7a48") },
                    { new Guid("760d027a-311c-4d24-86d9-f82d3bed8bb2"), new Guid("bf520b5c-eda2-41aa-baa1-5f18e4561d74") },
                    { new Guid("9f131d6d-f476-4b2e-a735-bd03487f164e"), new Guid("bec0866c-1afa-4f8f-9410-9871f4ab7a48") },
                    { new Guid("bc6809d9-58f1-4c32-908d-c9e151587cad"), new Guid("bf520b5c-eda2-41aa-baa1-5f18e4561d74") },
                    { new Guid("c43e9bd8-fc58-443d-a013-d49447452f9d"), new Guid("773bbf26-feca-4cbc-96ef-c3e01f7cd52e") },
                    { new Guid("ede1a65a-8137-49f1-b58e-82819086db1d"), new Guid("45cccf20-a236-4ceb-b267-c7824f6482f3") }
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
