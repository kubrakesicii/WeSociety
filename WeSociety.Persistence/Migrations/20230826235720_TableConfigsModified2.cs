using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeSociety.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TableConfigsModified2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingListArticles_Articles_ArticleId",
                table: "ReadingListArticles");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingListArticles_Articles_ArticleId",
                table: "ReadingListArticles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingListArticles_Articles_ArticleId",
                table: "ReadingListArticles");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingListArticles_Articles_ArticleId",
                table: "ReadingListArticles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }
    }
}
