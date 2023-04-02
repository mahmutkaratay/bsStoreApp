using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "216b73be-ad70-48f3-b004-e823dfc77efb", "88cf1ff9-1707-4be4-b9eb-8069121b6d9b", "User", "USER" },
                    { "88763347-d2bd-43eb-9e6e-1e04ac6dec40", "2031452a-0bd5-4a44-94e6-c898653e7a4b", "Admin", "ADMIN" },
                    { "f196014e-3735-4837-abf5-f2dcf9661256", "677c4138-dbfd-4d5a-95fa-6d47d57ca934", "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "216b73be-ad70-48f3-b004-e823dfc77efb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88763347-d2bd-43eb-9e6e-1e04ac6dec40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f196014e-3735-4837-abf5-f2dcf9661256");
        }
    }
}
