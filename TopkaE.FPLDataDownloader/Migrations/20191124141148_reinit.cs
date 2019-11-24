using System;
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
                        .Annotation("Sqlite:Autoincrement", true),
                    ChanceOfPlayingNextRound = table.Column<int>(nullable: true),
                    ChanceOfPlayingThisRound = table.Column<int>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    CostChangeEvent = table.Column<int>(nullable: false),
                    CostChangeEventFall = table.Column<int>(nullable: false),
                    CostChangeStart = table.Column<int>(nullable: false),
                    CostChangeStartFall = table.Column<int>(nullable: false),
                    DreamteamCount = table.Column<int>(nullable: false),
                    ElementType = table.Column<int>(nullable: false),
                    EpNext = table.Column<string>(nullable: true),
                    EpThis = table.Column<string>(nullable: true),
                    EventPoints = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Form = table.Column<string>(nullable: true),
                    InDreamteam = table.Column<bool>(nullable: false),
                    News = table.Column<string>(nullable: true),
                    NewsAdded = table.Column<DateTime>(nullable: true),
                    NowCost = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    PointsPerGame = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    SelectedByPercent = table.Column<string>(nullable: true),
                    Special = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Team = table.Column<int>(nullable: false),
                    TeamCode = table.Column<int>(nullable: false),
                    TotalPoints = table.Column<int>(nullable: false),
                    TransfersIn = table.Column<int>(nullable: false),
                    TransfersInEvent = table.Column<int>(nullable: false),
                    TransfersOut = table.Column<int>(nullable: false),
                    TransfersOutEvent = table.Column<int>(nullable: false),
                    ValueForm = table.Column<string>(nullable: true),
                    ValueSeason = table.Column<string>(nullable: true),
                    WebName = table.Column<string>(nullable: true),
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
                    Influence = table.Column<string>(nullable: true),
                    Creativity = table.Column<string>(nullable: true),
                    Threat = table.Column<string>(nullable: true),
                    IctIndex = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    TeamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayersSummary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersSummary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fixture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    EventName = table.Column<string>(nullable: true),
                    IsHome = table.Column<bool>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false),
                    PlayerSummaryDataModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixture_PlayersSummary_PlayerSummaryDataModelId",
                        column: x => x.PlayerSummaryDataModelId,
                        principalTable: "PlayersSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    Influence = table.Column<string>(nullable: true),
                    Creativity = table.Column<string>(nullable: true),
                    Threat = table.Column<string>(nullable: true),
                    ICTndex = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    TransfersBalance = table.Column<int>(nullable: false),
                    Selected = table.Column<int>(nullable: false),
                    TransfersIn = table.Column<int>(nullable: false),
                    TransfersOut = table.Column<int>(nullable: false),
                    PlayerSummaryDataModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_PlayersSummary_PlayerSummaryDataModelId",
                        column: x => x.PlayerSummaryDataModelId,
                        principalTable: "PlayersSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixture_PlayerSummaryDataModelId",
                table: "Fixture",
                column: "PlayerSummaryDataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_History_PlayerSummaryDataModelId",
                table: "History",
                column: "PlayerSummaryDataModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Fixture");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "PlayersSummary");
        }
    }
}
