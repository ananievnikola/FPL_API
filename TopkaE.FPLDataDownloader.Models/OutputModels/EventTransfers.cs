using System;
using System.Collections.Generic;
using System.Text;
using TopkaE.FPLDataDownloader.Models.InputModels;

namespace TopkaE.FPLDataDownloader.Models.OutputModels
{
    public class EventTransfers : IOutputModel
    {
        public EventTransfers(Element inputModel)
        {
            this.Map(inputModel);
        }

        public string FirstName { get; set; }
        public string TeamName { get; set; }
        public string SecondName { get; set; }
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
    }
}
