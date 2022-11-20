using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtMuseums.Migrations
{
    public partial class EditedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd6c42d0-611c-42ce-8b1e-1a706ef9024d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2519000-dae3-45d5-8b5c-bedcab7eeb11");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1847cb4c-896f-4cfb-9582-6e3769ce43be", "8b78a81a-19db-40ac-b7b3-289e3b09a0f0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e3b84a2-fdad-4d84-a73e-29f50ee3bfdb", "b6a5110f-163e-4485-ab2e-a8f2ce12ba46", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1847cb4c-896f-4cfb-9582-6e3769ce43be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e3b84a2-fdad-4d84-a73e-29f50ee3bfdb");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd6c42d0-611c-42ce-8b1e-1a706ef9024d", "55267a94-8219-4f80-bb65-5370facd375f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2519000-dae3-45d5-8b5c-bedcab7eeb11", "14bd9dd3-9aa0-4834-abe0-4d4cc4231386", "Administrator", "ADMINISTRATOR" });
        }
    }
}
