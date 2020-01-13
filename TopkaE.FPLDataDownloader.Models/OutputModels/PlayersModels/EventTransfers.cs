using System;
using System.Collections.Generic;
using System.Text;
using TopkaE.FPLDataDownloader.Models.InputModels;

namespace TopkaE.FPLDataDownloader.Models.OutputModels
{
    public class EventTransfers : PlayerModelBase, IOutputModel
    {
        public EventTransfers(Element inputModel)
        {
            this.Map(inputModel);
        }
        public int TransfersInEvent { get; set; }
        public int TransfersOutEvent { get; set; }

        public void Map(IFPLModel inputModel)
        {
            Element inputModelAsElement = inputModel as Element;
            this.FirstName = inputModelAsElement.FirstName;
            this.SecondName = inputModelAsElement.SecondName;
            this.TeamName = inputModelAsElement.TeamName;
            this.TransfersInEvent = inputModelAsElement.TransfersInEvent;
            this.TransfersOutEvent = inputModelAsElement.TransfersOutEvent;
        }

        public static List<EventTransfers> MapList(List<Element> players)
        {
            List<EventTransfers> result = new List<EventTransfers>();
            foreach (var player in players)
            {
                result.Add(new EventTransfers(player));
            }
            return result;
        }
    }
}
