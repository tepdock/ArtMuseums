using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtMuseums.Migrations
{
    public partial class FixingRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "071333c6-5c14-49dc-a3c8-4dece7094512");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bad2074f-291b-4ee5-bd10-9292b2365a99");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7519dcb4-de8b-44ff-a9b6-374d4ea08ddb", "c290e282-4d00-448a-b2e2-72cd7cf5e961", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5926e27-0ec5-4a81-bad9-87e68ac669ee", "6a746c7e-2d64-4846-911c-066b37a21c3e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7519dcb4-de8b-44ff-a9b6-374d4ea08ddb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5926e27-0ec5-4a81-bad9-87e68ac669ee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "071333c6-5c14-49dc-a3c8-4dece7094512", "aa5bc247-8adf-4af1-9f2b-ed505ca10e23", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bad2074f-291b-4ee5-bd10-9292b2365a99", "399ad5cb-d9cb-4232-a50d-585531d2f870", "Administrator", "ADMINISTRATOR" });
        }
    }
}
