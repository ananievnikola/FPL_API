using Microsoft.EntityFrameworkCore.Migrations;

namespace TopkaE.FPLDataDownloader.Migrations
{
    public partial class CharSetFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "Elements",
                type: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);
        }
    }
}
