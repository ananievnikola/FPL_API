using System;
using System.Collections.Generic;
using System.Text;

namespace TopkaE.FPLDataDownloader.Models.InputModels.LeagueDataModel
{
    public class GeneralLeagueModel
    {
        public int Id { get; set; }
        public League league { get; set; }
        //public NewEntries new_entries { get; set; }
        public Standings standings { get; set; }
    }
}
