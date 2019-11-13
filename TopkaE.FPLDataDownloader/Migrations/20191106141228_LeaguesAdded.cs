using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopkaE.FPLDataDownloader.Migrations
{
    public partial class LeaguesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    closed = table.Column<bool>(nullable: false),
                    league_type = table.Column<string>(nullable: true),
                    scoring = table.Column<string>(nullable: true),
                    admin_entry = table.Column<int>(nullable: false),
                    start_event = table.Column<int>(nullable: false),
                    code_privacy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    has_next = table.Column<bool>(nullable: false),
                    page = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    leagueid = table.Column<int>(nullable: true),
                    standingsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leagues_League_leagueid",
                        column: x => x.leagueid,
                        principalTable: "League",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leagues_Standings_standingsId",
                        column: x => x.standingsId,
                        principalTable: "Standings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Result2",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    event_total = table.Column<int>(nullable: false),
                    player_name = table.Column<string>(nullable: true),
                    rank = table.Column<int>(nullable: false),
                    last_rank = table.Column<int>(nullable: false),
                    rank_sort = table.Column<int>(nullable: false),
                    total = table.Column<int>(nullable: false),
                    entry = table.Column<int>(nullable: false),
                    entry_name = table.Column<string>(nullable: true),
                    StandingsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result2", x => x.id);
                    table.ForeignKey(
                        name: "FK_Result2_Standings_StandingsId",
                        column: x => x.StandingsId,
                        principalTable: "Standings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_leagueid",
                table: "Leagues",
                column: "leagueid");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_standingsId",
                table: "Leagues",
                column: "standingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Result2_StandingsId",
                table: "Result2",
                column: "StandingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Result2");

            migrationBuilder.DropTable(
                name: "League");

            migrationBuilder.DropTable(
                name: "Standings");
        }
    }
}
