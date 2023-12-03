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
                name: "User",
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
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
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
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentCompetitor",
                columns: table => new
                {
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentCompetitor", x => new { x.TournamentId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TournamentCompetitor_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentCompetitor_Tournaments_TournamentId",
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
                        name: "FK_PlayerDetails_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                        name: "FK_TeamCoach_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingParticipant",
                columns: table => new
                {
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingParticipant", x => new { x.UserId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_TrainingParticipant_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingParticipant_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayer",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayer", x => new { x.TeamId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_TeamPlayer_PlayerDetails_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPlayer_Teams_TeamId",
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
                    { new Guid("232c7086-dae5-4d03-8b30-f11ebf738326"), "Description Team 2", "Team 2", "pic2" },
                    { new Guid("25ff1a11-cd5a-430d-9e3b-a179cb18c8f8"), "Description Team 4", "Team 4", "pic4" },
                    { new Guid("99ac56c3-bd0b-4a57-baf0-40e8201840c9"), "Description Team 3", "Team 3", "pic3" },
                    { new Guid("ef063a74-5423-4967-9e4c-8a422885f2bc"), "Description Team 1", "Team 1", "pic1" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "Location", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("33356da5-aa7f-417e-90ff-a0819d96ec71"), new DateTime(2023, 11, 27, 12, 1, 5, 701, DateTimeKind.Local).AddTicks(2665), "Description Team 1", "Location tournament 1", "Tournament 1", "pic4" },
                    { new Guid("46021cfa-1c20-4169-9dee-2a38cb719c61"), new DateTime(2023, 11, 27, 12, 1, 5, 701, DateTimeKind.Local).AddTicks(2789), "Description Tournament 2", "Location tournament 2", "Tournament 2", "pic2" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password", "Roles" },
                values: new object[,]
                {
                    { new Guid("0f944250-9f76-497d-9206-a87d8542814e"), "user4@user.com", "Name 4", "pass4", "BasicUser" },
                    { new Guid("1e79d4af-855e-49db-a0f4-48c82b1fe7c7"), "user3@user.com", "Name 3", "pass3", "BasicUser" },
                    { new Guid("a73ea236-5afd-4425-8345-e6f14755b1e3"), "user2@user.com", "Name 2", "pass2", "Administrator,BasicUser" },
                    { new Guid("adaeb173-cdb0-468c-81f1-1ed8dd6a45fe"), "user1@user.com", "Name 1", "pass1", "Coach,BasicUser" },
                    { new Guid("ba97cc4f-d884-4d19-888e-de4b68a53624"), "user5@user.com", "Name 5", "pass5", "Coach" }
                });

            migrationBuilder.InsertData(
                table: "PlayerDetails",
                columns: new[] { "Id", "Birthday", "Gender", "Phone", "PlayerNumber", "Posts", "TicketPass", "UserId" },
                values: new object[] { new Guid("562050d2-c16c-4aa4-b416-b893b6650471"), new DateTime(2023, 11, 27, 12, 1, 5, 701, DateTimeKind.Local).AddTicks(2939), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("adaeb173-cdb0-468c-81f1-1ed8dd6a45fe") });

            migrationBuilder.InsertData(
                table: "TeamPlayer",
                columns: new[] { "PlayerId", "TeamId" },
                values: new object[] { new Guid("562050d2-c16c-4aa4-b416-b893b6650471"), new Guid("ef063a74-5423-4967-9e4c-8a422885f2bc") });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDetails_UserId",
                table: "PlayerDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCoach_UserId",
                table: "TeamCoach",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayer_PlayerId",
                table: "TeamPlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentCompetitor_TeamId",
                table: "TournamentCompetitor",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TeamId",
                table: "Training",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingParticipant_TrainingId",
                table: "TrainingParticipant",
                column: "TrainingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamCoach");

            migrationBuilder.DropTable(
                name: "TeamPlayer");

            migrationBuilder.DropTable(
                name: "TournamentCompetitor");

            migrationBuilder.DropTable(
                name: "TrainingParticipant");

            migrationBuilder.DropTable(
                name: "PlayerDetails");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
