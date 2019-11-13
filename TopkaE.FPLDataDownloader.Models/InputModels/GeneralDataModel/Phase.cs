using System;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public class Phase : IFPLModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int start_event { get; set; }
        public int stop_event { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}

