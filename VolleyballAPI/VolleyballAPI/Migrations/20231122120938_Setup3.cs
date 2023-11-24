using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VolleyballAPI.Migrations
{
    /// <inheritdoc />
    public partial class Setup3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("6b45e8d5-b985-458f-bb9e-a9e3ff6809c1"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("76f8bac4-7445-445e-9a13-6e80bd77528a"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("a510ffad-6b82-4b48-82da-3b6f07f15eb0"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("acb9cffe-8787-4d45-a638-648ff0235c7a"));

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("c3d833ac-b4ad-458b-a529-3fb55e56137d"));

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("e1c8db3c-b13b-4471-b326-c21ede466d60"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0ed27cf3-31a7-4a0f-b44c-f0ef8fc8c81f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("98e108b8-dbe2-4252-981b-85ce02f552b5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a50c4e2f-2ad9-4b2a-be8d-d3ecee1f8584"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ca225db5-46b5-47a9-a8c8-84e28bb1cd5e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ff12942f-fabb-41f0-ab88-30b6b50a95fb"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("6b45e8d5-b985-458f-bb9e-a9e3ff6809c1"), "Description Team 2", "Team 2", "pic2" },
                    { new Guid("76f8bac4-7445-445e-9a13-6e80bd77528a"), "Description Team 1", "Team 1", "pic1" },
                    { new Guid("a510ffad-6b82-4b48-82da-3b6f07f15eb0"), "Description Team 3", "Team 3", "pic3" },
                    { new Guid("acb9cffe-8787-4d45-a638-648ff0235c7a"), "Description Team 4", "Team 4", "pic4" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "Location", "Name", "Picture", "TeamId" },
                values: new object[,]
                {
                    { new Guid("c3d833ac-b4ad-458b-a529-3fb55e56137d"), new DateTime(2023, 11, 22, 12, 48, 5, 34, DateTimeKind.Local).AddTicks(4425), "Description Team 1", "Location tournament 1", "Tournament 1", "pic4", null },
                    { new Guid("e1c8db3c-b13b-4471-b326-c21ede466d60"), new DateTime(2023, 11, 22, 12, 48, 5, 34, DateTimeKind.Local).AddTicks(4484), "Description Tournament 2", "Location tournament 2", "Tournament 2", "pic2", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password", "Roles", "TeamId" },
                values: new object[,]
                {
                    { new Guid("0ed27cf3-31a7-4a0f-b44c-f0ef8fc8c81f"), "user1@user.com", "Name 1", "pass1", "Coach,BasicUser", null },
                    { new Guid("98e108b8-dbe2-4252-981b-85ce02f552b5"), "user5@user.com", "Name 5", "pass5", "Coach", null },
                    { new Guid("a50c4e2f-2ad9-4b2a-be8d-d3ecee1f8584"), "user3@user.com", "Name 3", "pass3", "BasicUser", null },
                    { new Guid("ca225db5-46b5-47a9-a8c8-84e28bb1cd5e"), "user2@user.com", "Name 2", "pass2", "Administrator,BasicUser", null },
                    { new Guid("ff12942f-fabb-41f0-ab88-30b6b50a95fb"), "user4@user.com", "Name 4", "pass4", "BasicUser", null }
                });
        }
    }
}
