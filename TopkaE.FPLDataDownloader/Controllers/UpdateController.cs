using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                    this.DeleteAllPlayers();
                    this.InsertPlayers(players);
                }
            }
            return result;
        }

        private void DeleteAllPlayers()
        {
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    MySqlCommand deleteCommand = new MySqlCommand("SP_Players_DeleteAll", sqlConnection);
                    deleteCommand.CommandType = CommandType.StoredProcedure;
                    MySqlTransaction deleteTransaction = sqlConnection.BeginTransaction();
                    deleteCommand.Transaction = deleteTransaction;
                    deleteCommand.ExecuteNonQuery();
                    deleteTransaction.Commit();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
                           
        }

        private void InsertPlayers(List<Player> players)
        {
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(_connectionString))
                {

                    sqlConnection.Open();
                    MySqlTransaction transaction = sqlConnection.BeginTransaction();
                    foreach (Player player in players)
                    {
                        MySqlCommand sqlCommand = new MySqlCommand("SP_Players_Insert", sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("ChanceOfPlayingNextRound", player.ChanceOfPlayingNextRound);
                        sqlCommand.Parameters.AddWithValue("ChanceOfPlayingThisRound", player.ChanceOfPlayingThisRound);
                        sqlCommand.Parameters.AddWithValue("Code", player.Code);
                        sqlCommand.Parameters.AddWithValue("CostChangeEvent", 1);
                        sqlCommand.Parameters.AddWithValue("CostChangeEventFall", player.CostChangeEventFall);
                        sqlCommand.Parameters.AddWithValue("CostChangeStart", player.CostChangeStart);
                        sqlCommand.Parameters.AddWithValue("CostChangeStartFall", player.CostChangeStartFall);
                        sqlCommand.Parameters.AddWithValue("DreamteamCount", player.DreamteamCount);
                        sqlCommand.Parameters.AddWithValue("ElementType", player.ElementType);
                        sqlCommand.Parameters.AddWithValue("EpNext", player.EpNext);
                        sqlCommand.Parameters.AddWithValue("EpThis", player.EpThis);
                        sqlCommand.Parameters.AddWithValue("EventPoints", player.EventPoints);
                        sqlCommand.Parameters.AddWithValue("FirstName", player.FirstName);
                        sqlCommand.Parameters.AddWithValue("Form", player.Form);
                        sqlCommand.Parameters.AddWithValue("InDreamteam", player.InDreamteam);
                        sqlCommand.Parameters.AddWithValue("News", player.News);
                        sqlCommand.Parameters.AddWithValue("NewsAdded", player.NewsAdded);
                        sqlCommand.Parameters.AddWithValue("NowCost", player.NowCost);
                        sqlCommand.Parameters.AddWithValue("Photo", player.Photo);
                        sqlCommand.Parameters.AddWithValue("PointsPerGame", player.PointsPerGame);
                        sqlCommand.Parameters.AddWithValue("SecondName", player.SecondName);
                        sqlCommand.Parameters.AddWithValue("SelectedByPercent", player.SelectedByPercent);
                        sqlCommand.Parameters.AddWithValue("Special", player.Special);
                        sqlCommand.Parameters.AddWithValue("Status", player.Status);
                        sqlCommand.Parameters.AddWithValue("Team", player.Team);
                        sqlCommand.Parameters.AddWithValue("TeamCode", player.TeamCode);
                        sqlCommand.Parameters.AddWithValue("TotalPoints", player.TotalPoints);
                        sqlCommand.Parameters.AddWithValue("TransfersIn", player.TransfersIn);
                        sqlCommand.Parameters.AddWithValue("TransfersInEvent", player.TransfersInEvent);
                        sqlCommand.Parameters.AddWithValue("TransfersOut", player.TransfersOut);
                        sqlCommand.Parameters.AddWithValue("TransfersOutEvent", player.TransfersOutEvent);
                        sqlCommand.Parameters.AddWithValue("ValueForm", player.ValueForm);
                        sqlCommand.Parameters.AddWithValue("ValueSeason", player.ValueSeason);
                        sqlCommand.Parameters.AddWithValue("WebName", player.WebName);
                        sqlCommand.Parameters.AddWithValue("Minutes", player.Minutes);
                        sqlCommand.Parameters.AddWithValue("GoalsScored", player.GoalsScored);
                        sqlCommand.Parameters.AddWithValue("Assists", player.Assists);
                        sqlCommand.Parameters.AddWithValue("CleanSheets", player.CleanSheets);
                        sqlCommand.Parameters.AddWithValue("GoalsConceded", player.GoalsConceded);
                        sqlCommand.Parameters.AddWithValue("OwnGoals", player.OwnGoals);
                        sqlCommand.Parameters.AddWithValue("PenaltiesSaved", player.PenaltiesSaved);
                        sqlCommand.Parameters.AddWithValue("PenaltiesMissed", player.PenaltiesMissed);
                        sqlCommand.Parameters.AddWithValue("YellowCards", player.YellowCards);
                        sqlCommand.Parameters.AddWithValue("RedCards", player.RedCards);
                        sqlCommand.Parameters.AddWithValue("Saves", player.Saves);
                        sqlCommand.Parameters.AddWithValue("Bonus", player.Bonus);
                        sqlCommand.Parameters.AddWithValue("Bps", 0);
                        sqlCommand.Parameters.AddWithValue("Influence", player.Influence);
                        sqlCommand.Parameters.AddWithValue("Creativity", player.Creativity);
                        sqlCommand.Parameters.AddWithValue("Threat", player.Threat);
                        sqlCommand.Parameters.AddWithValue("IctIndex", player.IctIndex);
                        sqlCommand.Parameters.AddWithValue("LastUpdated", player.LastUpdated);
                        sqlCommand.Parameters.AddWithValue("TeamName", player.TeamName);
                        sqlCommand.Transaction = transaction;
                        sqlCommand.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                //log ex
                throw;
            }

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