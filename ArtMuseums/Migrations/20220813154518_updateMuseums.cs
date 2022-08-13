using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtMuseums.Migrations
{
    public partial class updateMuseums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArtMuseums",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ArtMuseums",
                keyColumn: "ArtMuseumId",
                keyValue: new Guid("033c8277-9be5-451b-9936-87f4b07caae7"),
                columns: new[] { "Adress", "Name" },
                values: new object[] { "st qwerty, 34", "General art museum" });

            migrationBuilder.UpdateData(
                table: "ArtMuseums",
                keyColumn: "ArtMuseumId",
                keyValue: new Guid("df77f745-2310-4bba-b157-c4f3434ff749"),
                columns: new[] { "Adress", "Name" },
                values: new object[] { "street yung, 25", "Museum of modern arts" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArtMuseums");

            migrationBuilder.UpdateData(
                table: "ArtMuseums",
                keyColumn: "ArtMuseumId",
                keyValue: new Guid("033c8277-9be5-451b-9936-87f4b07caae7"),
                column: "Adress",
                value: "General art museum, st qwerty, 34");

            migrationBuilder.UpdateData(
                table: "ArtMuseums",
                keyColumn: "ArtMuseumId",
                keyValue: new Guid("df77f745-2310-4bba-b157-c4f3434ff749"),
                column: "Adress",
                value: "Museum of modern arts, street yung, 25");
        }
    }
}
