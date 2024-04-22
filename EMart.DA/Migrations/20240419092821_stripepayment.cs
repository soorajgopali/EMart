using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMart.DA.Migrations
{
    /// <inheritdoc />
    public partial class stripepayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Orders",
                newName: "SessionId");

            migrationBuilder.AddColumn<string>(
                name: "Player",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Player",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Orders",
                newName: "Country");
        }
    }
}
