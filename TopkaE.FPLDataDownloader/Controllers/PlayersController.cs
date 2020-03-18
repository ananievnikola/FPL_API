using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.OutputModels;
using TopkaE.FPLDataDownloader.Repository;
using TopkaE.FPLDataDownloader.Utilities;

namespace TopkaE.FPLDataDownloader.Controllers
{
    [Route("api/Players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {   
        private readonly OutputCamelCaseSerializer _serializer;
        private readonly CSVConverter _csvConv;

        private readonly IPlayerRepository _repository;

        public PlayersController(IHttpClientFactory clientFactory, IPlayerRepository repository)
        {
            _repository = repository;
            _serializer = new OutputCamelCaseSerializer();
            _csvConv = new CSVConverter();
        }     

        [HttpGet]
        [Route("")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers(int? points)
        {
            IEnumerable<Player> players = await Task.Run(() => _repository.GetAll(points));
            bool isCSV = this.isCSV(this.HttpContext.Request.Headers);
            if (isCSV)
            {
                return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(players)), "text/csv", "allplayers.csv");
            }
            return _serializer.Serialize(players, this);
        }

        [HttpGet]
        [Route("GetPlayer")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            Player player = await Task.Run(() => _repository.GetById(id));

            if (player == null)
            {
                return NotFound();
            }
            bool isCSV = this.isCSV(this.HttpContext.Request.Headers);
            if (isCSV)
            {
                return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(player)), "text/csv", "player.csv");
            }
            return _serializer.Serialize(player, this);
        }

        [HttpGet]
        [Route("MostTransferedIn")]
        public async Task<ActionResult<IEnumerable<EventTransfers>>> GetMostTransferedIn(int? top)
        {
            List<EventTransfers> players = await Task.Run(() => _repository.GetMostTransferedIn(top).ToList());
            bool isCSV = this.isCSV(this.HttpContext.Request.Headers);
            if (isCSV)
            {
                return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(players)), "text/csv", "MostTransferedIn.csv");
            }
            return _serializer.Serialize(players, this);
        }

        [HttpGet]
        [Route("MostTransferedOut")]
        public async Task<ActionResult<IEnumerable<EventTransfers>>> GetMostTransferedOut(int? top)
        {
            List<EventTransfers> players = await Task.Run(() => _repository.GetMostTransferedOut(top).ToList());
            bool isCSV = this.isCSV(this.HttpContext.Request.Headers);
            if (isCSV)
            {
                return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(players)), "text/csv", "MostTransferedOut.csv");
            }
            return _serializer.Serialize(players, this);
        }

        [HttpGet]
        [Route("MostGoals")]
        public async Task<ActionResult<IEnumerable<MostGoals>>> GetMostGoals(int? top)
        {
            List<MostGoals> players = await Task.Run(() => _repository.GetMostGoals(top).ToList());
            bool isCSV = this.isCSV(this.HttpContext.Request.Headers);
            if (isCSV)
            {
                return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(players)), "text/csv", "GetMostGoalsForTeam.csv");
            }
            return _serializer.Serialize(players, this);
        }

        [HttpGet]
        [Route("MostGoalsForTeam")]
        public async Task<ActionResult<IEnumerable<MostGoals>>> GetMostGoalsForTeam()
        {
            List<MostGoals> players = await Task.Run(() => _repository.GetMostGoalsForTeam().ToList());
            bool isCSV = this.isCSV(this.HttpContext.Request.Headers);
            if (isCSV)
            {
                return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(players)), "text/csv", "GetMostGoalsForTeam.csv");
            }
            return _serializer.Serialize(players, this);
        }

        [HttpGet]
        [Route("MostGoalsInvolvement")]
        public async Task<ActionResult<IEnumerable<MostGoals>>> GetMostGoalsInvolvement(int? top)
        {
            List<MostGoals> players = await Task.Run(() => _repository.GetMostGoalsInvovement(top).ToList());
            bool isCSV = this.isCSV(this.HttpContext.Request.Headers);
            if (isCSV)
            {
                return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(players)), "text/csv", "GetMostGoalsForTeam.csv");
            }
            return _serializer.Serialize(players, this);
        }

        //TODO: Minutes goals with and without.. search for goal time stats

        //[HttpGet]
        //[Route("MostBPS")]
        //public async Task<ActionResult<IEnumerable<Element>>> GetMostBPS()
        //{
        //    List<Element> players = await _context.Elements.ToListAsync();
        //    List<Element> mostGoalsPlayers = new List<Element>();
        //    string[] allTeamNames = PlayersUtilities.GetAllTeamNames();
        //    foreach (var teamName in allTeamNames)
        //    {
        //        var allTeamPlayers = players.Where(p => p.TeamName == teamName);
        //        var maxGoalsAssists = allTeamPlayers.Max(p => p.GoalsScored + p.Assists);
        //        mostGoalsPlayers.AddRange(allTeamPlayers.Where(p => p.GoalsScored + p.Assists == maxGoalsAssists));
        //    }
        //    List<MostGoals> results = _mapper.Map<List<MostGoals>>(mostGoalsPlayers);
        //    return _serializer.Serialize(results, this);
        //}

        //[HttpGet]
        //[Route("PlayerBPS")]
        //public async Task<ActionResult<IEnumerable<Element>>> GetPlayerBPS(int id)
        //{
        //    //optimize
        //    Element player = await GetPlayerIncludeFixturesAndHistory(id);
        //    PlayerBPSHistory results = _mapper.Map<PlayerBPSHistory>(player);
        //    List<BPSModel> BPSModel = _mapper.Map<List<BPSModel>>(results.Histories);
        //    results.Histories = results.Histories.OrderBy(h => h.Round).ToList();
        //    return _serializer.Serialize(results, this);
        //}

        //private async Task<Element> GetPlayerIncludeFixturesAndHistory(int id)
        //{
        //    return await _context.Elements
        //        .Include(h => h.Histories)
        //        .Include(f => f.Fixtures)
        //        .FirstOrDefaultAsync(p => p.Id == id);
        //}

        private bool isCSV(IHeaderDictionary headers)
        {
            string contentType = headers["Content-Type"].FirstOrDefault();
            bool isCSV = contentType != null && contentType.Equals("text/csv", StringComparison.InvariantCultureIgnoreCase) ? true : false;
            return isCSV;
        }


        //private bool ElementExists(int id)
        //{
        //    return _context.Elements.Any(e => e.Id == id);
        //}
    }
}
