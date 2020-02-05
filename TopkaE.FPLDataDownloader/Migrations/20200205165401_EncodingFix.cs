using Microsoft.EntityFrameworkCore.Migrations;

namespace TopkaE.FPLDataDownloader.Migrations
{
    public partial class EncodingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Threat",
                table: "Histories",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Influence",
                table: "Histories",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ICTndex",
                table: "Histories",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Creativity",
                table: "Histories",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Fixtures",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WebName",
                table: "Elements",
                type: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ValueSeason",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ValueForm",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Threat",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Team",
                table: "Elements",
                type: "VARCHAR(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SelectedByPercent",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PointsPerGame",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Elements",
                type: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "News",
                table: "Elements",
                type: "VARCHAR(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Influence",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IctIndex",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Form",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EpThis",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EpNext",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Creativity",
                table: "Elements",
                type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Threat",
                table: "Histories",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Influence",
                table: "Histories",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ICTndex",
                table: "Histories",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Creativity",
                table: "Histories",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Fixtures",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WebName",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ValueSeason",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ValueForm",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Threat",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Team",
                table: "Elements",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SelectedByPercent",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PointsPerGame",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "News",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Influence",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IctIndex",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Form",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EpThis",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EpNext",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Creativity",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci",
                oldNullable: true);
        }
    }
}
