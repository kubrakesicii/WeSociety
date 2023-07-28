using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeSociety.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TableColsModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_UserProfiles_ProfileId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Articles",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_ProfileId",
                table: "Articles",
                newName: "IX_Articles_UserProfileId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "UserProfiles",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_UserProfiles_UserProfileId",
                table: "Articles",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_UserProfiles_UserProfileId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Articles",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_UserProfileId",
                table: "Articles",
                newName: "IX_Articles_ProfileId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "UserProfiles",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_UserProfiles_ProfileId",
                table: "Articles",
                column: "ProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
