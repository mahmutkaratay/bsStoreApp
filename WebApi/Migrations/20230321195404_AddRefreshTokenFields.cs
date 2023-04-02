using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1bc7860-c912-4796-826b-c32b0acf0102", "5e2033d2-4231-485a-ab34-97a4c3a76fba", "Admin", "ADMIN" },
                    { "f11c4e15-0ad4-469e-b556-29dddae1dfd9", "dd59d008-dbbc-4a98-8469-5c43247c20c4", "User", "USER" },
                    { "fdfa4673-0826-49c5-9f1e-2b342cfcb32b", "030ccb18-9e8b-4ee0-9a81-6094f6143146", "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1bc7860-c912-4796-826b-c32b0acf0102");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f11c4e15-0ad4-469e-b556-29dddae1dfd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdfa4673-0826-49c5-9f1e-2b342cfcb32b");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireTime",
                table: "AspNetUsers");

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
    }
}
