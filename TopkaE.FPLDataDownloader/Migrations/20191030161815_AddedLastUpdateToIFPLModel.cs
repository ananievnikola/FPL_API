using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopkaE.FPLDataDownloader.Migrations
{
    public partial class AddedLastUpdateToIFPLModel : Migration
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
                    LastUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");
        }
    }
}
