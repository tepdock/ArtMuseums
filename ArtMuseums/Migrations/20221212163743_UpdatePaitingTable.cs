using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtMuseums.Migrations
{
    public partial class UpdatePaitingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7519dcb4-de8b-44ff-a9b6-374d4ea08ddb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5926e27-0ec5-4a81-bad9-87e68ac669ee");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Paintings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b84b9db6-0721-4cba-a511-deb0e04c0e39", "9ddf91e9-7e78-4dfe-8c15-ad49d5b7bbc9", "Administrator", "ADMINISTRATOR" },
                    { "fd8cc381-935a-4b0f-be04-f2e696e3ccbc", "4e06700e-41b0-4590-b036-9565bd777366", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "PaintingId",
                keyValue: new Guid("07ba5109-8aec-48ee-b7d9-21e2ce4f3312"),
                column: "Category",
                value: "Abstract");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "PaintingId",
                keyValue: new Guid("58bde6fc-74f6-41ba-8d60-39424211cfc6"),
                column: "Category",
                value: "Expresionism");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "PaintingId",
                keyValue: new Guid("9d944131-b6ee-4b76-825b-fa6163a27787"),
                column: "Category",
                value: "Modern");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b84b9db6-0721-4cba-a511-deb0e04c0e39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd8cc381-935a-4b0f-be04-f2e696e3ccbc");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Paintings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7519dcb4-de8b-44ff-a9b6-374d4ea08ddb", "c290e282-4d00-448a-b2e2-72cd7cf5e961", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5926e27-0ec5-4a81-bad9-87e68ac669ee", "6a746c7e-2d64-4846-911c-066b37a21c3e", "Administrator", "ADMINISTRATOR" });
        }
    }
}
