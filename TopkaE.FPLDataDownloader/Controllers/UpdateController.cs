using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TopkaE.FPLDataDownloader.DBContext;
using TopkaE.FPLDataDownloader.HttpRequests.Requesters;
using TopkaE.FPLDataDownloader.Models.InputModels;
using System.Net.Http;
using TopkaE.FPLDataDownloader.Utilities;

namespace TopkaE.FPLDataDownloader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IRequester _playerRequester;
        private readonly TopkaEContext _context;
        private HttpClient _client;
        private readonly RequesterFactory _requesterFactory;

        public UpdateController(TopkaEContext context, IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient();
            _requesterFactory = new RequesterFactory();
            _playerRequester = _requesterFactory.CreaterRequester(EBasicRequestType.GeneralDataRequester, _client);
            _context = context;           
        }

        [HttpGet]
        [Route("")]
        [Route("UpdateAll")]
        public async Task<bool> UpdateAllNew()
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
                            }
                            _context.Elements.AddRange(players);
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

        //[HttpGet]
        //[Route("")]
        //[Route("UpdateAll")]
        //public async Task<bool> UpdateAll()//pass array of leagueIds here
        //{
        //    //Hardcoded temp
        //    int leagueId = 373269;
        //    int page = 1;

        //    bool result = false;
        //    Dictionary<string, bool> aggregateResults = new Dictionary<string, bool>();

        //    //bool playersResult = await UpdatePlayers();
        //    //aggregateResults.Add("players", playersResult);
        //    //bool leagueResult = await UpdateLeagues(leagueId, page);
        //    result = !aggregateResults.ContainsValue(false);
        //    return result;
        //}



        //private async Task<bool> UpdatePlayers()
        //{
        //    bool result = true;
        //    string resp = await _playerRequester.ExecuteRequest();
        //    if (!string.IsNullOrEmpty(resp))
        //    {
        //        GeneralDataModel gdm = JsonConvert.DeserializeObject<GeneralDataModel>(resp);
        //        if (gdm == null || gdm.Players == null)
        //        {
        //            //log ex
        //            result = false;
        //        }
        //        else
        //        {
        //            List<Element> players = gdm.Players;
        //            if (players != null && players.Count > 0) //
        //            {
        //                List<Element> playersFromDB = await _context.Elements.AsNoTracking().ToListAsync();
        //                if (playersFromDB == null)
        //                {
        //                    DateTime time = DateTime.Now;
        //                    foreach (var player in players)
        //                    {
        //                        player.LastUpdated = time;
        //                    }
        //                    _context.Elements.AddRange(players);
        //                    result = true;
        //                }
        //                else if (playersFromDB != null)
        //                {
        //                    foreach (var player in players)
        //                    {
        //                        player.LastUpdated = DateTime.Now;
        //                        Element currentDbPlayer = playersFromDB.FirstOrDefault(p => p.Id == player.Id);
        //                        if (currentDbPlayer != null)
        //                        {
        //                            _context.Update(player);
        //                        }
        //                        else
        //                        {
        //                            _context.Add(player);
        //                        }
        //                        result = true;
        //                    }
        //                }
        //                _context.SaveChanges();
        //            }
        //            else
        //            {
        //                result = false;
        //                //add log
        //            }
        //        } 
        //    }
        //    return result;
        //}

        //private async Task<bool> UpdateLeagues(int leagueId, int page)
        //{
        //    GeneralLeagueModel glm = null;
        //    bool hasCookie = CookieContainerSingleton.GetInstance.HasAuthCookie();//_leagueRequester.HasAuthCookie();
        //    if (!hasCookie)
        //    {
        //        Console.WriteLine("Get the cookie");
        //        var authRes = await _authRequester.ExecuteRequest();
        //    }
        //    string resp = await _leagueRequester.ExecuteRequest(leagueId, page);
        //    glm = JsonConvert.DeserializeObject<GeneralLeagueModel>(resp);

        //    while (true)
        //    {
        //        if (glm.standings.has_next)
        //        {
        //            page += page;
        //            resp = await _leagueRequester.ExecuteRequest(leagueId, page);
        //            GeneralLeagueModel newResult = JsonConvert.DeserializeObject<GeneralLeagueModel>(resp);
        //            Standings standings = newResult.standings;
        //            List<Result2> pageToAdd = newResult.standings.results;
        //            glm.standings.has_next = standings.has_next;
        //            glm.standings.results.AddRange(pageToAdd);
        //        }
        //        else
        //        {
        //            break;
        //        }

        //    }

        //    return false;
        //}
    }
}