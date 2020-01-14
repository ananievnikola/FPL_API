using System;
using System.Collections.Generic;
using System.Text;

namespace TopkaE.FPLDataDownloader.Models.OutputModels
{
    public class PlayerModelBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string TeamName { get; set; }
    }
}
