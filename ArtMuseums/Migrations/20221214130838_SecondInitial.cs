using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtMuseums.Migrations
{
    public partial class SecondInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    ArtMuseumId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMuseums", x => x.ArtMuseumId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                columns: table => new
                {
                    ExpositionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtMuseumId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.ExpositionId);
                    table.ForeignKey(
                        name: "FK_Exhibitions_ArtMuseums_ArtMuseumId",
                        column: x => x.ArtMuseumId,
                        principalTable: "ArtMuseums",
                        principalColumn: "ArtMuseumId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    PaintingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExhibitionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.PaintingId);
                    table.ForeignKey(
                        name: "FK_Paintings_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId");
                    table.ForeignKey(
                        name: "FK_Paintings_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "ExpositionId");
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TourPlaces = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExhibitionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                    table.ForeignKey(
                        name: "FK_Tours_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "ExpositionId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketCost = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    TourId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId");
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        principalColumn: "TicketId");
                });

            migrationBuilder.InsertData(
                table: "ArtMuseums",
                columns: new[] { "ArtMuseumId", "Adress", "Name" },
                values: new object[,]
                {
                    { "033c8277-9be5-451b-9936-87f4b07caae7", "st qwerty, 34", "General art museum" },
                    { "df77f745-2310-4bba-b157-c4f3434ff749", "street yung, 25", "Museum of modern arts" }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Country", "Name" },
                values: new object[,]
                {
                    { "3afac7d0-c751-4fc6-9f3d-b6c8e22fb05f", "France", "Van Gogh" },
                    { "e528467c-2dfe-48fa-9e1a-739d2d0c0cd2", "Russia", "Ivan Aivazovski" },
                    { "ffb62ca6-0c3e-4a64-9b22-5af9d79c08ab", "Belarus", "Mark Shagal" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ec6d27b-275f-4c07-af36-831614e49e21", "b5709be8-126b-4b8a-b7e5-334844ce6549", "Administrator", "ADMINISTRATOR" },
                    { "78761a06-d74e-405f-9bf3-b3ac42284f9a", "f42aaefa-87e2-4ae6-8eba-66e0b1375f9d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Exhibitions",
                columns: new[] { "ExpositionId", "ArtMuseumId", "Description", "Name", "Picture" },
                values: new object[] { "e177f248-6517-449c-9200-16b673c5beff", "df77f745-2310-4bba-b157-c4f3434ff749", "exhibition of famous paintings from different times", "arts of world", null });

            migrationBuilder.InsertData(
                table: "Exhibitions",
                columns: new[] { "ExpositionId", "ArtMuseumId", "Description", "Name", "Picture" },
                values: new object[] { "e5368172-b396-4960-8e67-ddffceefc98b", "033c8277-9be5-451b-9936-87f4b07caae7", null, "exhibition of belarusian artists", null });

            migrationBuilder.InsertData(
                table: "Paintings",
                columns: new[] { "PaintingId", "ArtistId", "Category", "Description", "ExhibitionId", "Name", "Picture", "Year" },
                values: new object[,]
                {
                    { "07ba5109-8aec-48ee-b7d9-21e2ce4f3312", "ffb62ca6-0c3e-4a64-9b22-5af9d79c08ab", "Abstract", "Прогулка - Марк Захарович Шагал. 1917-1918. Холст, масло 169,6x163,4 см", "e5368172-b396-4960-8e67-ddffceefc98b", "a walk", "https://res.cloudinary.com/dkt2qwk4f/image/upload/v1670924106/progulka-shagal_d0mxfj.jpg", "1918" },
                    { "58bde6fc-74f6-41ba-8d60-39424211cfc6", "3afac7d0-c751-4fc6-9f3d-b6c8e22fb05f", "Expresionism", "The Starry Night (Dutch: De sterrennacht) is an oil-on-canvas painting by the Dutch Post-Impressionist painter Vincent van Gogh. Painted in June 1889, it depicts the view from the east-facing window of his asylum room at Saint-Rémy-de-Provence, just before sunrise, with the addition of an imaginary village.", "e5368172-b396-4960-8e67-ddffceefc98b", "Starry Night", "https://res.cloudinary.com/dkt2qwk4f/image/upload/v1670873513/VanGogh-starry_night_ballance1_dj6w1i.jpg", "1889" },
                    { "9d944131-b6ee-4b76-825b-fa6163a27787", "ffb62ca6-0c3e-4a64-9b22-5af9d79c08ab", "Modern", "Прогулка - Марк Захарович Шагал. 1917-1918. Холст, масло 169,6x163,4 см", "e177f248-6517-449c-9200-16b673c5beff", "Three Candles", "https://res.cloudinary.com/dkt2qwk4f/image/upload/v1670924115/triCvechiShagal_bvnhcf.jpg", "1940" }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "TourId", "Description", "ExhibitionId", "TourPlaces" },
                values: new object[,]
                {
                    { "579acbef-ffbe-42fe-b26d-5f8befa41889", null, "e5368172-b396-4960-8e67-ddffceefc98b", 5 },
                    { "769a5cb1-9b03-447f-a2d9-c8589a0c901d", null, "e177f248-6517-449c-9200-16b673c5beff", 20 },
                    { "805ed4d2-bcf3-48cf-a722-94db044d43ac", null, "e5368172-b396-4960-8e67-ddffceefc98b", 20 },
                    { "b177f615-4df7-4aa8-9f98-21f7a9a18f32", null, "e177f248-6517-449c-9200-16b673c5beff", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Purchases_TicketId",
                table: "Purchases",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TourId",
                table: "Tickets",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_ExhibitionId",
                table: "Tours",
                column: "ExhibitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Exhibitions");

            migrationBuilder.DropTable(
                name: "ArtMuseums");
        }
    }
}
