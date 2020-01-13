﻿using System;
using System.Collections.Generic;
using System.Text;
using TopkaE.FPLDataDownloader.Models.InputModels;

namespace TopkaE.FPLDataDownloader.Models.OutputModels
{
    public class MostGoals : PlayerModelBase, IOutputModel
    {
        public MostGoals()
        {

        }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}
