using System;
using System.Collections.Generic;
using System.Text;
using TopkaE.FPLDataDownloader.Models.InputModels;

namespace TopkaE.FPLDataDownloader.Models.OutputModels
{
    public class EventTransfers : PlayerModelBase, IOutputModel
    {
        public EventTransfers()
        {
        }
        public int TransfersInEvent { get; set; }
        public int TransfersOutEvent { get; set; }
    }
}
