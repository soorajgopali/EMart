using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMart.DA.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specifics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leagues_TeamTypes_TeamTypeId",
                        column: x => x.TeamTypeId,
                        principalTable: "TeamTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adidas" },
                    { 2, "Nike" },
                    { 3, "Puma" },
                    { 4, "Under Armour" },
                    { 5, "New Balance" }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "World Cup" },
                    { 2, "Champions League" },
                    { 3, "New Collection" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lionel Messi" },
                    { 2, "Cristiano Ronaldo" },
                    { 3, "Neymar Jr" },
                    { 4, "Kylian Mbappé" },
                    { 5, "Robert Lewandowski" },
                    { 6, "Kevin De Bruyne" },
                    { 7, "Mohamed Salah" },
                    { 8, "Sadio Mané" },
                    { 9, "Sergio Ramos" },
                    { 10, "Luka Modrić" },
                    { 11, "Virgil van Dijk" },
                    { 12, "Harry Kane" },
                    { 13, "Antoine Griezmann" },
                    { 14, "Eden Hazard" },
                    { 15, "Raheem Sterling" },
                    { 16, "Manuel Neuer" },
                    { 17, "Trent Alexander-Arnold" },
                    { 18, "Marc-André ter Stegen" },
                    { 19, "Son Heung-min" },
                    { 20, "Alisson Becker" },
                    { 21, "Frenkie de Jong" },
                    { 22, "Bernardo Silva" },
                    { 23, "João Félix" },
                    { 24, "Paul Pogba" },
                    { 25, "Jan Oblak" },
                    { 26, "Sergio Agüero" },
                    { 27, "Bruno Fernandes" },
                    { 28, "Edinson Cavani" },
                    { 29, "Thiago Alcântara" },
                    { 30, "Timo Werner" },
                    { 31, "Romelu Lukaku" },
                    { 32, "Joshua Kimmich" },
                    { 33, "Jamie Vardy" },
                    { 34, "Vinícius Júnior" },
                    { 35, "Riyad Mahrez" },
                    { 36, "Thibaut Courtois" },
                    { 37, "Kalidou Koulibaly" },
                    { 38, "Jadon Sancho" },
                    { 39, "Ciro Immobile" },
                    { 40, "Miralem Pjanić" },
                    { 41, "Sergio Busquets" },
                    { 42, "Dries Mertens" },
                    { 43, "Gianluigi Donnarumma" },
                    { 44, "N'Golo Kanté" },
                    { 45, "Andy Robertson" },
                    { 46, "Hakim Ziyech" },
                    { 47, "Angel Di Maria" },
                    { 48, "Alex Telles" },
                    { 49, "Marquinhos" },
                    { 50, "Gerard Piqué" }
                });

            migrationBuilder.InsertData(
                table: "Specifics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vintage" },
                    { 2, "Legend" },
                    { 3, "Hero" }
                });

            migrationBuilder.InsertData(
                table: "TeamTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Club" },
                    { 2, "Country" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_TeamTypeId",
                table: "Leagues",
                column: "TeamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Specifics");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "TeamTypes");
        }
    }
}
