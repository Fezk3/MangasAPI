using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangasAPI.Migrations
{
    /// <inheritdoc />
    public partial class modelsrelationONEtoONE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MangaPosts_Id",
                table: "Categories",
                column: "Id",
                principalTable: "MangaPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MangaPosts_Id",
                table: "Categories");
        }
    }
}
