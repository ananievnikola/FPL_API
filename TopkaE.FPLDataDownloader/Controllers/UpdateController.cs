using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TopkaE.FPLDataDownloader.DBContext;
using TopkaE.FPLDataDownloader.HttpRequests.Requesters;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Utilities;

namespace TopkaE.FPLDataDownloader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IRequester _playerRequester;
        private readonly IRequester _playerSummaryRequester;
        private readonly TopkaEContext _context;
        private HttpClient _client;
        private readonly RequesterFactory _requesterFactory;
        private readonly string _connectionString;

        public UpdateController(TopkaEContext context, IHttpClientFactory clientFactory, IConfiguration config)
        {
            _client = clientFactory.CreateClient();
            _requesterFactory = new RequesterFactory();
            _playerRequester = _requesterFactory.CreaterRequester(EBasicRequestType.GeneralDataRequester, _client);
            _playerSummaryRequester = _requesterFactory.CreaterRequester(EBasicRequestType.PlayerSummaryRequester, _client);
            _context = context;
            _connectionString = config["MariaDBConnection"];
            //    Configuration = config;
            //_connectionString = Configuration["MariaDBConnection"];
        }

        [HttpGet]
        [Route("")]
        [Route("UpdateAll")]
        public async Task<bool> UpdateAll()
        {
            bool result = await UpdatePlayersNew();

            //Dictionary<string, bool> aggregateResults = new Dictionary<string, bool>();
            //bool playersResult = await UpdatePlayers();
            //aggregateResults.Add("players", playersResult);
            //result = !aggregateResults.ContainsValue(false);

            return result;
        }

        private async Task<bool> UpdatePlayersNew()
        {
            bool result = true;
            string resp = await _playerRequester.ExecuteRequest();
            if (!string.IsNullOrEmpty(resp))
            {
                GeneralDataModelNew gdm = JsonConvert.DeserializeObject<GeneralDataModelNew>(resp);
                if (gdm == null || gdm.Players == null)
                {
                    //log ex
                    result = false;
                }
                else
                {
                    //things to do before insert
                    //NowCost, last updated, team name
                    List<Player> players = gdm.Players;
                    StringBuilder sCommand = new StringBuilder("INSERT INTO PLAYERS ( ChanceOfPlayingNextRound\r\n    , ChanceOfPlayingThisRound\r\n    , Code\r\n    , CostChangeEvent\r\n    , CostChangeEventFall\r\n    , CostChangeStart\r\n    , CostChangeStartFall\r\n    , DreamteamCount\r\n    , ElementType\r\n    , EpNext\r\n    , EpThis\r\n    , EventPoints\r\n    , FirstName\r\n    , Form\r\n    , InDreamteam\r\n    , News\r\n    , NewsAdded\r\n    , NowCost\r\n    , Photo\r\n    , PointsPerGame\r\n    , SecondName\r\n    , SelectedByPercent\r\n    , Special\r\n    , Status\r\n    , Team\r\n    , TeamCode\r\n    , TotalPoints\r\n    , TransfersIn\r\n    , TransfersInEvent\r\n    , TransfersOut\r\n    , TransfersOutEvent\r\n    , ValueForm\r\n    , ValueSeason\r\n    , WebName\r\n    , Minutes\r\n    , GoalsScored\r\n    , Assists\r\n    , CleanSheets\r\n    , GoalsConceded\r\n    , OwnGoals\r\n    , PenaltiesSaved\r\n    , PenaltiesMissed\r\n    , YellowCards\r\n    , RedCards\r\n    , Saves\r\n    , Bonus\r\n    , Bps\r\n    , Influence\r\n    , Creativity\r\n    , Threat\r\n    , IctIndex\r\n    , LastUpdated\r\n    , TeamName) ");

                    string test = BuildInsertQuery(players);
                    using (var mConnection = new MySqlConnection(_connectionString))
                    {
                        List<string> Rows = new List<string>();
                        for (int i = 0; i < players.Count; i++)
                        {
                            Rows.Add(string.Format("('{0}','{1}')", MySqlHelper.EscapeString("test"), MySqlHelper.EscapeString("test")));
                        }
                        sCommand.Append(string.Join(",", Rows));
                        sCommand.Append(";");
                        mConnection.Open();
                        using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), mConnection))
                        {
                            myCmd.CommandType = CommandType.Text;
                            myCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            return result;
        }

        private string BuildInsertQuery (List<Player> players)
        {
            StringBuilder sbMain = new StringBuilder();
            string[] playerDbFields = PlayersUtilities.GetAllPlayerDBFields();
            foreach (var player in players)
            {
                StringBuilder sb = new StringBuilder("INSERT INTO PLAYERS ( ");
                sb.Append(string.Join(", ", playerDbFields));
                sb.Append(" ) VALUES (");
                for (int i = 0; i < playerDbFields.Length; i++)
                {
                    if (i == 2 )
                    {
                        break;
                    }
                    //sb.Append();
                }
                sb.Append(" )");
            }
            return sbMain.ToString();
        }

        private async Task<bool> UpdatePlayers()
        {
            bool result = true;
            string resp = await _playerRequester.ExecuteRequest();
            if (!string.IsNullOrEmpty(resp))
            {
                GeneralDataModel gdm = JsonConvert.DeserializeObject<GeneralDataModel>(resp);
                if (gdm == null || gdm.Players == null)
                {
                    //log ex
                    result = false;
                }
                else
                {
                    List<Element> players = gdm.Players;
                    //List<int> ids = new List<int>();
                    if (players != null && players.Count > 0) //
                    {
                        List<Element> playersFromDB = await _context.Elements?.AsNoTracking()?.ToListAsync();
                        if (playersFromDB == null || playersFromDB.Count == 0)
                        {
                            DateTime time = DateTime.Now;
                            foreach (var player in players)
                            {
                                player.LastUpdated = time;
                                player.TeamName = PlayersUtilities.GetTeamName(player.TeamCode);
                            }                           
                            _context.AddRange(players);
                            List<HistoryAndFixtures> historyAndFixtures = await this.DownloadFixturesAndResults(players);
                            foreach (var fixOrRes in historyAndFixtures)
                            {
                                fixOrRes.Fixtures.ForEach(i => i.ElementId = fixOrRes.Id);
                                fixOrRes.History.ForEach(i => i.ElementId = fixOrRes.Id);
                                _context.AddRange(fixOrRes.Fixtures);
                                _context.AddRange(fixOrRes.History);
                            }
                            _context.SaveChanges();
                            result = true;
                        }
                        else if (playersFromDB != null)
                        {
                            foreach (var player in players)
                            {
                                player.LastUpdated = DateTime.Now;
                                player.TeamName = PlayersUtilities.GetTeamName(player.TeamCode);
                                Element currentDbPlayer = playersFromDB.FirstOrDefault(p => p.Id == player.Id);
                                if (currentDbPlayer != null)
                                {
                                    _context.Update(player);
                                }
                                else
                                {
                                    _context.Add(player);
                                }
                                _context.SaveChanges();
                                await this.DownloadFixturesAndResults(players);
                                result = true;
                            }
                        }
                        _context.SaveChanges();
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        private async Task<List<HistoryAndFixtures>> DownloadFixturesAndResults(List<Element> players)
        {
            List<Task<string>> responses = new List<Task<string>>();
            List<int> ids = players.Select(p => p.Id).ToList();
            foreach (var id in ids)
            {
                int loopId = id;
                PlayerSummaryRequester psr = new PlayerSummaryRequester(_client);
                responses.Add(psr.ExecuteRequest(loopId));
            }
            string[] res = await Task.WhenAll(responses);
            List<HistoryAndFixtures> resAsList = new List<HistoryAndFixtures>();
            foreach (var item in res)
            {
                HistoryAndFixtures currentFixture = JsonConvert.DeserializeObject<HistoryAndFixtures>(item);
                foreach (var fixture in currentFixture.Fixtures)
                {
                    fixture.ElementId = currentFixture.Id;
                }
                foreach (var history in currentFixture.History)
                {
                    history.ElementId = currentFixture.Id;
                }
                resAsList.Add(JsonConvert.DeserializeObject<HistoryAndFixtures>(item));

            }
            return resAsList;
        }

        private class HistoryAndFixtures
        {
            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }
            public List<History> History { get; set; }
            public List<Fixture> Fixtures { get; set; }
        }
    }
}