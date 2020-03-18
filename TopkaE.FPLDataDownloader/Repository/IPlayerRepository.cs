using System.Collections.Generic;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.OutputModels;

namespace TopkaE.FPLDataDownloader.Repository
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll(int? points);
        Player GetById(int id);
        IEnumerable<EventTransfers> GetMostTransferedIn(int? top);
        IEnumerable<EventTransfers> GetMostTransferedOut(int? top);
        IEnumerable<MostGoals> GetMostGoals(int? top);
        IEnumerable<MostGoals> GetMostGoalsForTeam();
        IEnumerable<MostGoals> GetMostGoalsInvovement(int? top);
    }
}
