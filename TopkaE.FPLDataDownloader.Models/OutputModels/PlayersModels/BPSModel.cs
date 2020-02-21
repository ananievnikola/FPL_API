using System;
using System.Collections.Generic;
using System.Text;

namespace TopkaE.FPLDataDownloader.Models.OutputModels
{
    public class BPSModel
    {
        public int Round { get; set; }
        public int Minutes { get; set; }
        public int GoalsScored { get; set; }
        public int Assists { get; set; }
        public int Bonus { get; set; }
        public int BPS { get; set; }
    }
}
