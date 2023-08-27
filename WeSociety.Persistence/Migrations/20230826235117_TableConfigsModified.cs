using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeSociety.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TableConfigsModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleClaps_Articles_ArticleId",
                table: "ArticleClaps");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleClaps_Articles_ArticleId",
                table: "ArticleClaps",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleClaps_Articles_ArticleId",
                table: "ArticleClaps");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleClaps_Articles_ArticleId",
                table: "ArticleClaps",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }
    }
}
