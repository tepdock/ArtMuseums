using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtMuseums.Migrations
{
    public partial class databaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "ArtMuseums",
                columns: table => new
                {
                    ArtMuseumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMuseums", x => x.ArtMuseumId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                columns: table => new
                {
                    ExpositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtMuseumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.ExpositionId);
                    table.ForeignKey(
                        name: "FK_Exhibitions_ArtMuseums_ArtMuseumId",
                        column: x => x.ArtMuseumId,
                        principalTable: "ArtMuseums",
                        principalColumn: "ArtMuseumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    PaintingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExhibitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.PaintingId);
                    table.ForeignKey(
                        name: "FK_Paintings_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paintings_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "ExpositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourPlaces = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExhibitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                    table.ForeignKey(
                        name: "FK_Tours_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "ExpositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketCost = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArtMuseums",
                columns: new[] { "ArtMuseumId", "Adress" },
                values: new object[,]
                {
                    { new Guid("033c8277-9be5-451b-9936-87f4b07caae7"), "General art museum, st qwerty, 34" },
                    { new Guid("df77f745-2310-4bba-b157-c4f3434ff749"), "Museum of modern arts, street yung, 25" }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3afac7d0-c751-4fc6-9f3d-b6c8e22fb05f"), "France", "Van Gogh" },
                    { new Guid("e528467c-2dfe-48fa-9e1a-739d2d0c0cd2"), "Russia", "Ivan Aivazovski" },
                    { new Guid("ffb62ca6-0c3e-4a64-9b22-5af9d79c08ab"), "Belarus", "Mark Shagal" }
                });

            migrationBuilder.InsertData(
                table: "Exhibitions",
                columns: new[] { "ExpositionId", "ArtMuseumId", "Description", "Name", "Picture" },
                values: new object[] { new Guid("e177f248-6517-449c-9200-16b673c5beff"), new Guid("df77f745-2310-4bba-b157-c4f3434ff749"), "exhibition of famous paintings from different times", "arts of world", null });

            migrationBuilder.InsertData(
                table: "Exhibitions",
                columns: new[] { "ExpositionId", "ArtMuseumId", "Description", "Name", "Picture" },
                values: new object[] { new Guid("e5368172-b396-4960-8e67-ddffceefc98b"), new Guid("033c8277-9be5-451b-9936-87f4b07caae7"), null, "exhibition of belarusian artists", null });

            migrationBuilder.InsertData(
                table: "Paintings",
                columns: new[] { "PaintingId", "ArtistId", "Description", "ExhibitionId", "Name", "Picture", "Year" },
                values: new object[,]
                {
                    { new Guid("07ba5109-8aec-48ee-b7d9-21e2ce4f3312"), new Guid("ffb62ca6-0c3e-4a64-9b22-5af9d79c08ab"), "Прогулка - Марк Захарович Шагал. 1917-1918. Холст, масло 169,6x163,4 см", new Guid("e5368172-b396-4960-8e67-ddffceefc98b"), "a walk", "D:/asp.net core/pictures/progulka-shagal+.jpg", 1918 },
                    { new Guid("58bde6fc-74f6-41ba-8d60-39424211cfc6"), new Guid("3afac7d0-c751-4fc6-9f3d-b6c8e22fb05f"), null, new Guid("e5368172-b396-4960-8e67-ddffceefc98b"), "Starry Night", "D:/asp.net core/pictures/VanGogh-starry_night_ballance1.jpg", 1889 },
                    { new Guid("9d944131-b6ee-4b76-825b-fa6163a27787"), new Guid("ffb62ca6-0c3e-4a64-9b22-5af9d79c08ab"), null, new Guid("e177f248-6517-449c-9200-16b673c5beff"), "Three Candles", "D:/asp.net core/pictures/triCvechiShagal.jpg", 1940 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "TourId", "Description", "ExhibitionId", "TourPlaces" },
                values: new object[,]
                {
                    { new Guid("579acbef-ffbe-42fe-b26d-5f8befa41889"), null, new Guid("e5368172-b396-4960-8e67-ddffceefc98b"), 5 },
                    { new Guid("769a5cb1-9b03-447f-a2d9-c8589a0c901d"), null, new Guid("e177f248-6517-449c-9200-16b673c5beff"), 20 },
                    { new Guid("805ed4d2-bcf3-48cf-a722-94db044d43ac"), null, new Guid("e5368172-b396-4960-8e67-ddffceefc98b"), 20 },
                    { new Guid("b177f615-4df7-4aa8-9f98-21f7a9a18f32"), null, new Guid("e177f248-6517-449c-9200-16b673c5beff"), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exhibitions_ArtMuseumId",
                table: "Exhibitions",
                column: "ArtMuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_ArtistId",
                table: "Paintings",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_ExhibitionId",
                table: "Paintings",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TourId",
                table: "Tickets",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_ExhibitionId",
                table: "Tours",
                column: "ExhibitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Exhibitions");

            migrationBuilder.DropTable(
                name: "ArtMuseums");
        }
    }
}
