using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.OutputModels;

namespace TopkaE.FPLDataDownloader.Repository
{
    public interface IPlayerRepository
    {
        //maybe a mapper between Element and another entity (Player) so I need output models only????
        IEnumerable<Element> GetAll(int? points, string team);
        Element GetById(int id);
        IEnumerable<EventTransfers> GetMostTransferedIn(int? top);
        IEnumerable<EventTransfers> GetMostTransferedOut(int? top);
        IEnumerable<MostGoals> GetMostGoals(int? top);
    }
}
