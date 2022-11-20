using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtMuseums.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd6c42d0-611c-42ce-8b1e-1a706ef9024d", "55267a94-8219-4f80-bb65-5370facd375f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2519000-dae3-45d5-8b5c-bedcab7eeb11", "14bd9dd3-9aa0-4834-abe0-4d4cc4231386", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd6c42d0-611c-42ce-8b1e-1a706ef9024d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2519000-dae3-45d5-8b5c-bedcab7eeb11");
        }
    }
}
