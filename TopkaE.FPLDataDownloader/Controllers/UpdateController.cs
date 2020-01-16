using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        //private readonly LeagueRequester _leagueRequester;
        //private readonly AuthenticationRequester _authRequester;
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
            bool result = false;

            Dictionary<string, bool> aggregateResults = new Dictionary<string, bool>();
            bool playersResult = await UpdatePlayers();
            aggregateResults.Add("players", playersResult);
            result = !aggregateResults.ContainsValue(false);
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
                        List<Element> playersFromDB = await _context.Elements.AsNoTracking().ToListAsync();
                        if (playersFromDB == null)
                        {
                            DateTime time = DateTime.Now;
                            foreach (var player in players)
                            {
                                player.LastUpdated = time;
                                player.TeamName = PlayersUtilities.GetTeamName(player.TeamCode);
                                //var a = await this.UpdateFixturesAndHistory(player.Id);
                                //Update Fixtures
                                //Update History
                            }
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
                                result = true;
                            }
                        }

                        foreach (var p in players)
                        {
                            ids.Add(p.Id);
                        }
                        var summary = await UpdateFixturesAndHistory(ids);//57 sec
                        //I need to optimize it more
                        foreach (var fixAndHistory in summary)
                        {
                        }
                        _context.SaveChanges();
                    }
                    else
                    {
                        result = false;
                        //add log
                    }
                }
            }
            return result;
        }

        private async Task<string[]> UpdateFixturesAndHistory(List<int> ids)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<Task<string>> responses = new List<Task<string>>();
            foreach (var id in ids)
            {
                int loopId = id;
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("id", id);
                PlayerSummaryRequester psr = new PlayerSummaryRequester(_client);
                responses.Add(psr.ExecuteRequest(loopId));
            }
            string[] res = await Task.WhenAll(responses);
            foreach (var item in res)
            {
                HistoryAndFixtures fAndH = JsonConvert.DeserializeObject<HistoryAndFixtures>(item);
            }
            watch.Stop();
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>NEW: " + watch.ElapsedMilliseconds / 1000);
            return res;
        }

        private class HistoryAndFixtures
        {
            public List<History> History { get; set; }
            public List<Fixture> Fixtures { get; set; }
        }
    }
}