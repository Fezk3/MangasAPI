using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangasAPI.Migrations
{
    /// <inheritdoc />
    public partial class modelsrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MangaPosts_Id",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "MangaPosts");

            migrationBuilder.DropColumn(
                name: "FeaturedImage",
                table: "MangaPosts");

            migrationBuilder.DropColumn(
                name: "UrlHandle",
                table: "MangaPosts");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "MangaPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryMangaPost",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MangaPostsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMangaPost", x => new { x.CategoriesId, x.MangaPostsId });
                    table.ForeignKey(
                        name: "FK_CategoryMangaPost_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMangaPost_MangaPosts_MangaPostsId",
                        column: x => x.MangaPostsId,
                        principalTable: "MangaPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MangaPosts_AuthorId",
                table: "MangaPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMangaPost_MangaPostsId",
                table: "CategoryMangaPost",
                column: "MangaPostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MangaPosts_Authors_AuthorId",
                table: "MangaPosts",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaPosts_Authors_AuthorId",
                table: "MangaPosts");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "CategoryMangaPost");

            migrationBuilder.DropIndex(
                name: "IX_MangaPosts_AuthorId",
                table: "MangaPosts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "MangaPosts");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "MangaPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeaturedImage",
                table: "MangaPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlHandle",
                table: "MangaPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MangaPosts_Id",
                table: "Categories",
                column: "Id",
                principalTable: "MangaPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
