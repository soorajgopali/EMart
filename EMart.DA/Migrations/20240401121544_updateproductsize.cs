using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMart.DA.Migrations
{
    /// <inheritdoc />
    public partial class updateproductsize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_SizesId",
                table: "ProductSizes");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Sizes_SizesId",
                table: "ProductSizes",
                column: "SizesId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Sizes_SizesId",
                table: "ProductSizes");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_SizesId",
                table: "ProductSizes",
                column: "SizesId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
