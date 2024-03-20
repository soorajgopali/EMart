using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMart.DA.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Leagues_LeagueId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "Products",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_LeagueId",
                table: "Products",
                newName: "IX_Products_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Teams_TeamId",
                table: "Products",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Teams_TeamId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Products",
                newName: "LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TeamId",
                table: "Products",
                newName: "IX_Products_LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Leagues_LeagueId",
                table: "Products",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
