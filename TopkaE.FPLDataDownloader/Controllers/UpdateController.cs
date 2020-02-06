using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

        public UpdateController(TopkaEContext context, IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient();
            _requesterFactory = new RequesterFactory();
            _playerRequester = _requesterFactory.CreaterRequester(EBasicRequestType.GeneralDataRequester, _client);
            _playerSummaryRequester = _requesterFactory.CreaterRequester(EBasicRequestType.PlayerSummaryRequester, _client);
            _context = context;

        }

        [HttpGet]
        [Route("")]
        [Route("UpdateAll")]
        public async Task<bool> UpdateAll()
        {
            Stopwatch stopwatch = new Stopwatch();
            bool result = false;

            Dictionary<string, bool> aggregateResults = new Dictionary<string, bool>();
            bool playersResult = await UpdatePlayers();
            aggregateResults.Add("players", playersResult);
            result = !aggregateResults.ContainsValue(false);
            stopwatch.Stop();
            Console.WriteLine(">>>>>>>>>>>>>>>>>" + stopwatch.Elapsed.Seconds + "<<<<<<<<<<<<<<<<");
            return result;
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
                    List<int> ids = new List<int>();
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
                            _context.SaveChanges();
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

        //private async Task<List<HistoryAndFixtures>> UpdateFixturesAndHistory(List<int> ids)
        //{
        //    List<Task<string>> responses = new List<Task<string>>();
        //    foreach (var id in ids)
        //    {
        //        int loopId = id;
        //        PlayerSummaryRequester psr = new PlayerSummaryRequester(_client);
        //        responses.Add(psr.ExecuteRequest(loopId));
        //    }
        //    string[] res = await Task.WhenAll(responses);
        //    List<HistoryAndFixtures> resAsList = new List<HistoryAndFixtures>();
        //    foreach (var item in res)
        //    {
        //        //HistoryAndFixtures currentFixture = JsonConvert.DeserializeObject<HistoryAndFixtures>(item);
        //        //currentFixture.History.Ele
        //        resAsList.Add(JsonConvert.DeserializeObject<HistoryAndFixtures>(item));
                
        //    }
        //    return resAsList;
        //}

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
            
            //var summaries = await UpdateFixturesAndHistory(ids);
            //foreach (var summary in summaries)
            //{
            //    Element currentElement = players.FirstOrDefault(p => p.Id == summary.Id);
            //    currentElement.Histories = summary.History;
            //    currentElement.Fixtures = summary.Fixtures;
            //    //foreach (var historyEntry in currentElement.Histories)
            //    //{
            //    //    historyEntry.ElementId = currentElement.Id;
            //    //}
            //    //foreach (var fixtureEntry in currentElement.Fixtures)
            //    //{
            //    //    fixtureEntry.ElementId = currentElement.Id;
            //    //}
            //}
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