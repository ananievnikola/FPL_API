using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopkaE.FPLDataDownloader.DBContext;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.OutputModels;
using TopkaE.FPLDataDownloader.Repository;
using TopkaE.FPLDataDownloader.Utilities;

namespace TopkaE.FPLDataDownloader.Controllers
{
    //TODO: CHECK FOR EMPTY TABLES BEFORE SELECTING!!!
    [Route("api/Players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly TopkaEContext _context;       
        private readonly OutputCamelCaseSerializer _serializer;
        private readonly CSVConverter _csvConv;
        private readonly IMapper _mapper;

        private readonly IPlayerRepository _repository;

        public PlayersController(TopkaEContext context, IHttpClientFactory clientFactory, IMapper mapper, IPlayerRepository repository)
        {
            _repository = repository;
            _serializer = new OutputCamelCaseSerializer();
            _context = context;
            _csvConv = new CSVConverter();
            _mapper = mapper;
        }

        

        // GET: api/Players
        [HttpGet]
        [Route("")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Element>>> GetPlayers(int? points, string team)
        {
            IEnumerable<Element> players = await Task.Run(() => _repository.GetAll(points, team));
            bool isCSV = this.isCSV(this.HttpContext.Request.Headers);
            if (isCSV)
            {
                return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(players)), "text/csv", "allplayers.csv");
            }
            return _serializer.Serialize(players, this);
        }

        [HttpGet]
        [Route("GetPlayer")]
        public async Task<ActionResult<Element>> GetPlayer(int id)
        {
            //GetById()
            var player = await Task.Run(() => _repository.GetById(id));

            if (player == null)
            {
                return NotFound();
            }
            bool isCSV = this.isCSV(this.HttpContext.Request.Headers);
            if (isCSV)
            {
                return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(player)), "text/csv", "allplayers.csv");
            }
            return _serializer.Serialize(player, this);
        }

        [HttpGet]
        [Route("MostTransferedIn")]
        public async Task<ActionResult<IEnumerable<EventTransfers>>> GetMostTransferedIn(int? top)
        {
            //GetMostTransferedIn()
            List<Element> players = await _context.Elements.ToListAsync();
            
            if (top != null || top != 0)
            {
                players = players.OrderByDescending(p => p.TransfersInEvent).Take(top.GetValueOrDefault()).ToList();
            }
            else
            {
                players = players.OrderByDescending(p => p.TransfersInEvent).ToList();
            }
            List<EventTransfers> results = _mapper.Map<List<EventTransfers>>(players);
            return _serializer.Serialize(results, this);
        }

        [HttpGet]
        [Route("MostTransferedOut")]
        public async Task<ActionResult<IEnumerable<Element>>> GetMostTransferedOut(int? top)
        {
            List<Element> players = await _context.Elements.ToListAsync();
            if (top != null || top != 0)
            {
                players = players.OrderByDescending(p => p.TransfersOutEvent).Take(top.GetValueOrDefault()).ToList();
            }
            else
            {
                players = players.OrderByDescending(p => p.TransfersOutEvent).ToList();
            }
            List<EventTransfers> results = _mapper.Map<List<EventTransfers>>(players);
            return _serializer.Serialize(results, this);
        }

        [HttpGet]
        [Route("MostGoals")]
        public async Task<ActionResult<IEnumerable<Element>>> GetMostGoals(int? top)
        {
            List<Element> players = await _context.Elements.ToListAsync();
            if (top != null && top != 0)
            {
                players = players.OrderByDescending(p => p.GoalsScored).Take(top.GetValueOrDefault()).ToList();
            }
            else
            {
                players = players.OrderByDescending(p => p.GoalsScored).ToList();
            }
            List<MostGoals> results = _mapper.Map<List<MostGoals>>(players);
            return _serializer.Serialize(results, this);
        }

        [HttpGet]
        [Route("MostGoalsForTeam")]
        public async Task<ActionResult<IEnumerable<Element>>> GetMostGoalsForTeam()
        {
            List<Element> players = await _context.Elements.ToListAsync();
            List<Element> mostGoalsPlayers = new List<Element>();
            string[] allTeamNames = PlayersUtilities.GetAllTeamNames();
            foreach (var teamName in allTeamNames)
            {
                var allTeamPlayers = players.Where(p => p.TeamName == teamName);
                var maxScoredGoals = allTeamPlayers.Max(p => p.GoalsScored);
                mostGoalsPlayers.AddRange(allTeamPlayers.Where(p => p.GoalsScored == maxScoredGoals));
            }
            List<MostGoals> results = _mapper.Map<List<MostGoals>>(mostGoalsPlayers);
            return _serializer.Serialize(mostGoalsPlayers, this);
        }

        [HttpGet]
        [Route("MostGoalsInvolvement")]
        public async Task<ActionResult<IEnumerable<Element>>> GetMostGoalsInvolvement()
        {
            List<Element> players = await _context.Elements.ToListAsync();
            List<Element> mostGoalsPlayers = new List<Element>();
            string[] allTeamNames = PlayersUtilities.GetAllTeamNames();
            foreach (var teamName in allTeamNames)
            {
                var allTeamPlayers = players.Where(p => p.TeamName == teamName);
                var maxGoalsAssists = allTeamPlayers.Max(p => p.GoalsScored + p.Assists);
                mostGoalsPlayers.AddRange(allTeamPlayers.Where(p => p.GoalsScored + p.Assists == maxGoalsAssists));
            }
            List<MostGoals> results = _mapper.Map<List<MostGoals>>(mostGoalsPlayers);
            return _serializer.Serialize(results, this);
        }

        [HttpGet]
        [Route("MostBPS")]
        public async Task<ActionResult<IEnumerable<Element>>> GetMostBPS()
        {
            List<Element> players = await _context.Elements.ToListAsync();
            List<Element> mostGoalsPlayers = new List<Element>();
            string[] allTeamNames = PlayersUtilities.GetAllTeamNames();
            foreach (var teamName in allTeamNames)
            {
                var allTeamPlayers = players.Where(p => p.TeamName == teamName);
                var maxGoalsAssists = allTeamPlayers.Max(p => p.GoalsScored + p.Assists);
                mostGoalsPlayers.AddRange(allTeamPlayers.Where(p => p.GoalsScored + p.Assists == maxGoalsAssists));
            }
            List<MostGoals> results = _mapper.Map<List<MostGoals>>(mostGoalsPlayers);
            return _serializer.Serialize(results, this);
        }

        [HttpGet]
        [Route("PlayerBPS")]
        public async Task<ActionResult<IEnumerable<Element>>> GetPlayerBPS(int id)
        {
            //optimize
            Element player = await GetPlayerIncludeFixturesAndHistory(id);
            PlayerBPSHistory results = _mapper.Map<PlayerBPSHistory>(player);
            List<BPSModel> BPSModel = _mapper.Map<List<BPSModel>>(results.Histories);
            results.Histories = results.Histories.OrderBy(h => h.Round).ToList();
            return _serializer.Serialize(results, this);
        }

        private async Task<Element> GetPlayerIncludeFixturesAndHistory(int id)
        {
            return await _context.Elements
                .Include(h => h.Histories)
                .Include(f => f.Fixtures)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        private bool isCSV(IHeaderDictionary headers)
        {
            string contentType = headers["Content-Type"].FirstOrDefault();
            bool isCSV = contentType != null && contentType.Equals("text/csv", StringComparison.InvariantCultureIgnoreCase) ? true : false;
            return isCSV;
        }


        private bool ElementExists(int id)
        {
            return _context.Elements.Any(e => e.Id == id);
        }
    }
}
