using System;
using System.Collections.Generic;
using System.Text;
using TopkaE.FPLDataDownloader.Models.InputModels;

namespace TopkaE.FPLDataDownloader.Models.OutputModels
{
    public class PlayerBPSHistory : PlayerModelBase
    {
        public List<BPSModel> Histories { get; set; }
    }
}
