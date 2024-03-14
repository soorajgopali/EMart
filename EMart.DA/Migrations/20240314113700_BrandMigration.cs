using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMart.DA.Migrations
{
    /// <inheritdoc />
    public partial class BrandMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_specifics",
                table: "specifics");

            migrationBuilder.RenameTable(
                name: "specifics",
                newName: "Specifics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specifics",
                table: "Specifics",
                column: "Id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specifics",
                table: "Specifics");

            migrationBuilder.RenameTable(
                name: "Specifics",
                newName: "specifics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_specifics",
                table: "specifics",
                column: "Id");
        }
    }
}
