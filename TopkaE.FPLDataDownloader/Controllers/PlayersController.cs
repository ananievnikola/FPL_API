using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopkaE.FPLDataDownloader.DBContext;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.OutputModels;
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

        public PlayersController(TopkaEContext context, IHttpClientFactory clientFactory, IMapper mapper)
        {
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
            //TODO: Optimize the ToList() calls
            List<Element> players = await _context.Elements.ToListAsync();
            if (points != null)
            {
                players = players.Where(p => p.TotalPoints > points).ToList();
            }
            if (!string.IsNullOrEmpty(team))
            {
                team = team.Replace("_", " ");
                players = players.Where(p => p.TeamName.Equals(team, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            return _serializer.Serialize(players, this);
        }

        [Route("GetCsv")]
        public async Task<ActionResult<IEnumerable<Element>>> GetPlayersCSV()
        {
            List<Element> players = await _context.Elements.ToListAsync();
            return File(Encoding.UTF8.GetBytes(_csvConv.ConvertToCSV(players)) , "text/csv", "allplayers.csv");
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Element>> GetElement(int id)
        {
            var player = await _context.Elements.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return _serializer.Serialize(player, this);
        }

        [HttpGet]
        [Route("MostTransferedIn")]
        public async Task<ActionResult<IEnumerable<EventTransfers>>> GetMostTransferedIn(int? top)
        {
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

        private bool ElementExists(int id)
        {
            return _context.Elements.Any(e => e.Id == id);
        }
    }
}
