using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtMuseums.Migrations
{
    public partial class RenamingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Baskets_BasketId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Baskets_BasketId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BasketId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BasketId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1847cb4c-896f-4cfb-9582-6e3769ce43be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e3b84a2-fdad-4d84-a73e-29f50ee3bfdb");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Purchases_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "071333c6-5c14-49dc-a3c8-4dece7094512", "aa5bc247-8adf-4af1-9f2b-ed505ca10e23", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bad2074f-291b-4ee5-bd10-9292b2365a99", "399ad5cb-d9cb-4232-a50d-585531d2f870", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_TicketId",
                table: "Purchases",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "071333c6-5c14-49dc-a3c8-4dece7094512");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bad2074f-291b-4ee5-bd10-9292b2365a99");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    PurchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.PurchaseId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1847cb4c-896f-4cfb-9582-6e3769ce43be", "8b78a81a-19db-40ac-b7b3-289e3b09a0f0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e3b84a2-fdad-4d84-a73e-29f50ee3bfdb", "b6a5110f-163e-4485-ab2e-a8f2ce12ba46", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BasketId",
                table: "Tickets",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BasketId",
                table: "AspNetUsers",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Baskets_BasketId",
                table: "AspNetUsers",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Baskets_BasketId",
                table: "Tickets",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
