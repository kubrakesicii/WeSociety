using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeSociety.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EntityColsModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadingListArticles",
                table: "ReadingListArticles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReadingListArticles");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ReadingLists",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReadingListArticles",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadingListArticles",
                table: "ReadingListArticles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingListArticles_ArticleId",
                table: "ReadingListArticles",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadingListArticles",
                table: "ReadingListArticles");

            migrationBuilder.DropIndex(
                name: "IX_ReadingListArticles_ArticleId",
                table: "ReadingListArticles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ReadingLists");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ReadingListArticles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadingListArticles",
                table: "ReadingListArticles",
                columns: new[] { "ArticleId", "ReadingListId" });
        }
    }
}
