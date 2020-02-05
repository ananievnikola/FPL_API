using Microsoft.EntityFrameworkCore.Migrations;

namespace TopkaE.FPLDataDownloader.Migrations
{
    public partial class FirstNameLenghtFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Elements",
                type: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);
        }
    }
}
