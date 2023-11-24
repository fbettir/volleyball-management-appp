using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VolleyballAPI.Migrations
{
    /// <inheritdoc />
    public partial class addOneTeamPlayerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerDetails",
                keyColumn: "Id",
                keyValue: new Guid("156f18e4-e93a-4e89-8208-0a2b7a3954f9"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("06949113-90fc-4e8c-b807-4db9f1364fa6"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("2eb13b08-a59a-4f5d-9be8-8a11f8bb8ff3"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("ce2ffad2-7f79-490f-af3e-5c5fc409df04"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("d4de02d6-7213-46ee-a6f8-a2886cef8d27"));

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("32104bf3-ec4c-4100-8130-d760c28c3912"));

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("d4e2e40d-16d0-4730-9e62-166946833429"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1e028f6d-108a-4aa3-a92e-3b6c8afa697c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("33454b33-0597-4121-bd6c-fbae5dc7dcb7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c044fbb9-73d0-49ce-89b0-c1450ad8b33a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e9e4bbfe-69bd-4a9d-8eb6-b1e978b2f2d0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ae413c76-f8f8-4705-9f3a-c37df8673794"));

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("65391f78-4359-43a7-bcab-3806517461ba"), "Description Team 2", "Team 2", "pic2" },
                    { new Guid("735fa8ba-935a-4809-82cf-7c3f1d94a493"), "Description Team 3", "Team 3", "pic3" },
                    { new Guid("84535fec-2d14-4ced-ab21-c2117f272367"), "Description Team 1", "Team 1", "pic1" },
                    { new Guid("9e50c7bd-c9f6-475b-8aaa-1b5196bb078f"), "Description Team 4", "Team 4", "pic4" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "Location", "Name", "Picture", "TeamId" },
                values: new object[,]
                {
                    { new Guid("6dd66133-9bf7-485a-b8b9-6203f80ae95e"), new DateTime(2023, 11, 22, 13, 24, 57, 66, DateTimeKind.Local).AddTicks(4195), "Description Team 1", "Location tournament 1", "Tournament 1", "pic4", null },
                    { new Guid("a6a60656-24de-47ef-b0d8-7726814a3056"), new DateTime(2023, 11, 22, 13, 24, 57, 66, DateTimeKind.Local).AddTicks(4242), "Description Tournament 2", "Location tournament 2", "Tournament 2", "pic2", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password", "Roles", "TeamId" },
                values: new object[,]
                {
                    { new Guid("0abf78b9-a84d-4827-8950-b65dc1fdcaf7"), "user1@user.com", "Name 1", "pass1", "Coach,BasicUser", null },
                    { new Guid("7698fb6c-c41a-472b-a088-68aecf275b9b"), "user3@user.com", "Name 3", "pass3", "BasicUser", null },
                    { new Guid("d2dcf26d-eda2-4ff2-905a-fddf9e1e1343"), "user2@user.com", "Name 2", "pass2", "Administrator,BasicUser", null },
                    { new Guid("f78a8aad-40e3-4da0-a89e-3cc1c10edf20"), "user4@user.com", "Name 4", "pass4", "BasicUser", null },
                    { new Guid("fc8cf60e-a4e9-4c56-a577-1d2eff37244d"), "user5@user.com", "Name 5", "pass5", "Coach", null }
                });

            migrationBuilder.InsertData(
                table: "PlayerDetails",
                columns: new[] { "Id", "Birthday", "Gender", "Phone", "PlayerNumber", "Posts", "TicketPass", "UserId" },
                values: new object[] { new Guid("4a82d691-d00c-4237-b022-e56ad19ce334"), new DateTime(2023, 11, 22, 13, 24, 57, 66, DateTimeKind.Local).AddTicks(4348), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("0abf78b9-a84d-4827-8950-b65dc1fdcaf7") });

            migrationBuilder.InsertData(
                table: "TeamPlayer",
                columns: new[] { "PlayerId", "TeamId" },
                values: new object[] { new Guid("4a82d691-d00c-4237-b022-e56ad19ce334"), new Guid("84535fec-2d14-4ced-ab21-c2117f272367") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeamPlayer",
                keyColumns: new[] { "PlayerId", "TeamId" },
                keyValues: new object[] { new Guid("4a82d691-d00c-4237-b022-e56ad19ce334"), new Guid("84535fec-2d14-4ced-ab21-c2117f272367") });

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("65391f78-4359-43a7-bcab-3806517461ba"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("735fa8ba-935a-4809-82cf-7c3f1d94a493"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("9e50c7bd-c9f6-475b-8aaa-1b5196bb078f"));

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("6dd66133-9bf7-485a-b8b9-6203f80ae95e"));

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("a6a60656-24de-47ef-b0d8-7726814a3056"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7698fb6c-c41a-472b-a088-68aecf275b9b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d2dcf26d-eda2-4ff2-905a-fddf9e1e1343"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f78a8aad-40e3-4da0-a89e-3cc1c10edf20"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fc8cf60e-a4e9-4c56-a577-1d2eff37244d"));

            migrationBuilder.DeleteData(
                table: "PlayerDetails",
                keyColumn: "Id",
                keyValue: new Guid("4a82d691-d00c-4237-b022-e56ad19ce334"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("84535fec-2d14-4ced-ab21-c2117f272367"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0abf78b9-a84d-4827-8950-b65dc1fdcaf7"));

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("06949113-90fc-4e8c-b807-4db9f1364fa6"), "Description Team 1", "Team 1", "pic1" },
                    { new Guid("2eb13b08-a59a-4f5d-9be8-8a11f8bb8ff3"), "Description Team 2", "Team 2", "pic2" },
                    { new Guid("ce2ffad2-7f79-490f-af3e-5c5fc409df04"), "Description Team 4", "Team 4", "pic4" },
                    { new Guid("d4de02d6-7213-46ee-a6f8-a2886cef8d27"), "Description Team 3", "Team 3", "pic3" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "Location", "Name", "Picture", "TeamId" },
                values: new object[,]
                {
                    { new Guid("32104bf3-ec4c-4100-8130-d760c28c3912"), new DateTime(2023, 11, 22, 13, 9, 37, 905, DateTimeKind.Local).AddTicks(5423), "Description Team 1", "Location tournament 1", "Tournament 1", "pic4", null },
                    { new Guid("d4e2e40d-16d0-4730-9e62-166946833429"), new DateTime(2023, 11, 22, 13, 9, 37, 905, DateTimeKind.Local).AddTicks(5467), "Description Tournament 2", "Location tournament 2", "Tournament 2", "pic2", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password", "Roles", "TeamId" },
                values: new object[,]
                {
                    { new Guid("1e028f6d-108a-4aa3-a92e-3b6c8afa697c"), "user4@user.com", "Name 4", "pass4", "BasicUser", null },
                    { new Guid("33454b33-0597-4121-bd6c-fbae5dc7dcb7"), "user2@user.com", "Name 2", "pass2", "Administrator,BasicUser", null },
                    { new Guid("ae413c76-f8f8-4705-9f3a-c37df8673794"), "user1@user.com", "Name 1", "pass1", "Coach,BasicUser", null },
                    { new Guid("c044fbb9-73d0-49ce-89b0-c1450ad8b33a"), "user3@user.com", "Name 3", "pass3", "BasicUser", null },
                    { new Guid("e9e4bbfe-69bd-4a9d-8eb6-b1e978b2f2d0"), "user5@user.com", "Name 5", "pass5", "Coach", null }
                });

            migrationBuilder.InsertData(
                table: "PlayerDetails",
                columns: new[] { "Id", "Birthday", "Gender", "Phone", "PlayerNumber", "Posts", "TicketPass", "UserId" },
                values: new object[] { new Guid("156f18e4-e93a-4e89-8208-0a2b7a3954f9"), new DateTime(2023, 11, 22, 13, 9, 37, 905, DateTimeKind.Local).AddTicks(5566), 0, "", 0, "Libero,Hitter,Receiver", 0, new Guid("ae413c76-f8f8-4705-9f3a-c37df8673794") });
        }
    }
}
