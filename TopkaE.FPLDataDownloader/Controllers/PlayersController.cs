using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using TopkaE.FPLDataDownloader.DBContext;
using TopkaE.FPLDataDownloader.HttpRequests.Requesters;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Utilities;

namespace TopkaE.FPLDataDownloader.Controllers
{
    [Route("api/Players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly TopkaEContext _context;       
        private readonly OutputCamelCaseSerializer _serializer;
        private readonly CSVConverter _csvConv;

        public PlayersController(TopkaEContext context, IHttpClientFactory clientFactory)
        {
            _serializer = new OutputCamelCaseSerializer();
            _context = context;
            _csvConv = new CSVConverter();
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
            //List<Element> players = await _context.Elements.ToListAsync();
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

            return _serializer.Serialize(player, this); //player;
        }

        private bool ElementExists(int id)
        {
            return _context.Elements.Any(e => e.Id == id);
        }
    }
}
