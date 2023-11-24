using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VolleyballAPI.Migrations
{
    /// <inheritdoc />
    public partial class Setup2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tournaments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
