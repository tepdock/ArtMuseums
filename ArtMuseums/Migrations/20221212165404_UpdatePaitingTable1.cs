using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtMuseums.Migrations
{
    public partial class UpdatePaitingTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b84b9db6-0721-4cba-a511-deb0e04c0e39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd8cc381-935a-4b0f-be04-f2e696e3ccbc");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Paintings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d992e200-ddd1-4cdd-b74e-697c71605665", "a57561ad-c9bd-47d2-aac7-55406a36b762", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4e5dc43-1ea6-4eb3-bb97-ca13535565ef", "ec68f419-fb4d-4468-bcde-4ea7c76974f8", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d992e200-ddd1-4cdd-b74e-697c71605665");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4e5dc43-1ea6-4eb3-bb97-ca13535565ef");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Paintings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b84b9db6-0721-4cba-a511-deb0e04c0e39", "9ddf91e9-7e78-4dfe-8c15-ad49d5b7bbc9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd8cc381-935a-4b0f-be04-f2e696e3ccbc", "4e06700e-41b0-4590-b036-9565bd777366", "User", "USER" });
        }
    }
}
