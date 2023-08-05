using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeSociety.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ArticleTableModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "MainImage",
                table: "Articles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValueSql: "0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Articles");
        }
    }
}
