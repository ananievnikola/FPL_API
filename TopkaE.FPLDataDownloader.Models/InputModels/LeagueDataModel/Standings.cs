using System;
using System.Collections.Generic;
using System.Text;

namespace TopkaE.FPLDataDownloader.Models.InputModels.LeagueDataModel
{
    public class Standings
    {
        public int Id { get; set; }
        public bool has_next { get; set; }
        public int page { get; set; }
        public List<Result2> results { get; set; }
    }

    public class Result2
    {
        public int id { get; set; }
        public int event_total { get; set; }
        public string player_name { get; set; }
        public int rank { get; set; }
        public int last_rank { get; set; }
        public int rank_sort { get; set; }
        public int total { get; set; }
        public int entry { get; set; }
        public string entry_name { get; set; }
    }
}
