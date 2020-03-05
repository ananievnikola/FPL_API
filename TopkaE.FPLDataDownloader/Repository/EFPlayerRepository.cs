using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopkaE.FPLDataDownloader.DBContext;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.OutputModels;

namespace TopkaE.FPLDataDownloader.Repository
{
    public class EFPlayerRepository : IPlayerRepository
    {
        private readonly TopkaEContext _context;
        public EFPlayerRepository(TopkaEContext context)
        {
            _context = context;
        }
        public IEnumerable<Element> GetAll(int? points, string team)
        {
            IEnumerable<Element> players = _context.Elements;
            if (points != null)
            {
                players = players.Where(p => p.TotalPoints > points).ToList();
            }
            if (!string.IsNullOrEmpty(team))
            {
                team = team.Replace("_", " ");
                players = players.Where(p => p.TeamName.Equals(team, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            return players;
        }

        public Element GetById(int id)
        {
            var player = _context.Elements.Find(id);
            return player;
        }

        public IEnumerable<EventTransfers> GetMostTransferedIn()
        {
            throw new NotImplementedException();
        }
    }
}
