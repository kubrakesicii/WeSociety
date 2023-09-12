using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeSociety.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BooleanColumnsConverted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserProfiles",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ReadingLists",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ReadingListArticles",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "FollowRelationships",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Articles",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Articles",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ArticleComments",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ArticleClaps",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1,
                oldDefaultValueSql: "1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "UserProfiles",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "ReadingLists",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "ReadingListArticles",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "FollowRelationships",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Categories",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsPublished",
                table: "Articles",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Articles",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "ArticleComments",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "ArticleClaps",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1,
                oldDefaultValue: true);
        }
    }
}
