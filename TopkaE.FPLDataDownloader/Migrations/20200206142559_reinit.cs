using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopkaE.FPLDataDownloader.Migrations
{
    public partial class reinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChanceOfPlayingNextRound = table.Column<int>(nullable: true),
                    ChanceOfPlayingThisRound = table.Column<int>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    CostChangeEvent = table.Column<int>(nullable: false),
                    CostChangeEventFall = table.Column<int>(nullable: false),
                    CostChangeStart = table.Column<int>(nullable: false),
                    CostChangeStartFall = table.Column<int>(nullable: false),
                    DreamteamCount = table.Column<int>(nullable: false),
                    ElementType = table.Column<int>(nullable: false),
                    EpNext = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    EpThis = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    EventPoints = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    Form = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    InDreamteam = table.Column<bool>(nullable: false),
                    News = table.Column<string>(type: "VARCHAR(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    NewsAdded = table.Column<DateTime>(nullable: true),
                    NowCost = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(type: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    PointsPerGame = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    SecondName = table.Column<string>(type: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    SelectedByPercent = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    Special = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    Team = table.Column<string>(type: "VARCHAR(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: false),
                    TeamCode = table.Column<int>(nullable: false),
                    TotalPoints = table.Column<int>(nullable: false),
                    TransfersIn = table.Column<int>(nullable: false),
                    TransfersInEvent = table.Column<int>(nullable: false),
                    TransfersOut = table.Column<int>(nullable: false),
                    TransfersOutEvent = table.Column<int>(nullable: false),
                    ValueForm = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    ValueSeason = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    WebName = table.Column<string>(type: "VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    Minutes = table.Column<int>(nullable: false),
                    GoalsScored = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    CleanSheets = table.Column<int>(nullable: false),
                    GoalsConceded = table.Column<int>(nullable: false),
                    OwnGoals = table.Column<int>(nullable: false),
                    PenaltiesSaved = table.Column<int>(nullable: false),
                    PenaltiesMissed = table.Column<int>(nullable: false),
                    YellowCards = table.Column<int>(nullable: false),
                    RedCards = table.Column<int>(nullable: false),
                    Saves = table.Column<int>(nullable: false),
                    Bonus = table.Column<int>(nullable: false),
                    Bps = table.Column<int>(nullable: false),
                    Influence = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    Creativity = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    Threat = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    IctIndex = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    TeamName = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ElementId = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    TeamH = table.Column<int>(nullable: false),
                    TeamHScore = table.Column<int>(nullable: true),
                    TeamA = table.Column<int>(nullable: false),
                    TeamAScore = table.Column<int>(nullable: true),
                    Event = table.Column<int>(nullable: true),
                    Finished = table.Column<bool>(nullable: false),
                    Minutes = table.Column<int>(nullable: false),
                    ProvisionalStartTime = table.Column<bool>(nullable: false),
                    KickoffTime = table.Column<DateTime>(nullable: true),
                    EventName = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    IsHome = table.Column<bool>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixtures_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ElementId = table.Column<int>(nullable: false),
                    Element = table.Column<int>(nullable: false),
                    Fixture = table.Column<int>(nullable: false),
                    OpponentTeam = table.Column<int>(nullable: false),
                    TotalPoints = table.Column<int>(nullable: false),
                    WasHome = table.Column<bool>(nullable: false),
                    KickoffTime = table.Column<DateTime>(nullable: true),
                    TeamHScore = table.Column<int>(nullable: true),
                    TeamAScore = table.Column<int>(nullable: true),
                    Round = table.Column<int>(nullable: false),
                    Minutes = table.Column<int>(nullable: false),
                    GoalsScored = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    CleanSheets = table.Column<int>(nullable: false),
                    GoalsConceded = table.Column<int>(nullable: false),
                    OwnGoals = table.Column<int>(nullable: false),
                    PenaltiesSaved = table.Column<int>(nullable: false),
                    PenaltiesMissed = table.Column<int>(nullable: false),
                    YellowCards = table.Column<int>(nullable: false),
                    RedCards = table.Column<int>(nullable: false),
                    Saves = table.Column<int>(nullable: false),
                    Bonus = table.Column<int>(nullable: false),
                    BPS = table.Column<int>(nullable: false),
                    Influence = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    Creativity = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    Threat = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    ICTndex = table.Column<string>(type: "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", nullable: true),
                    Value = table.Column<int>(nullable: false),
                    TransfersBalance = table.Column<int>(nullable: false),
                    Selected = table.Column<int>(nullable: false),
                    TransfersIn = table.Column<int>(nullable: false),
                    TransfersOut = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_ElementId",
                table: "Fixtures",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_ElementId",
                table: "Histories",
                column: "ElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Elements");
        }
    }
}
