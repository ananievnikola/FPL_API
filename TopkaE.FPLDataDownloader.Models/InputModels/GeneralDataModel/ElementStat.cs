using System;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public class ElementStat : IFPLModel
    {
        public int Id { get; set; }
        public string label { get; set; }
        public string name { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}

