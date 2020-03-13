using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public class GeneralDataModel : IFPLModel
    {
        //[JsonProperty(PropertyName = "events")]
        //public List<Event> Events { get; set; }
        //[JsonProperty(PropertyName = "game_settings")]
        //public GameSettings GameSettings { get; set; }
        //[JsonProperty(PropertyName = "phases")]
        //public List<Phase> Phases { get; set; }
        //[JsonProperty(PropertyName = "teams")]
        //public List<Team> Teams { get; set; }
        //[JsonProperty(PropertyName = "total_players")]
        //public int TotalPlayers { get; set; }
        [JsonProperty(PropertyName = "elements")]
        public List<Element> Players { get; set; }
        //[JsonProperty(PropertyName = "element_stats")]
        //public List<ElementStat> PlayerStats { get; set; }
        ////TODO: check this
        //[JsonProperty(PropertyName = "element_types")]
        //public List<ElementType> element_types { get; set; }

        public DateTime? LastUpdated { get; set; }
    }

    public class GeneralDataModelNew : IFPLModel
    {
        //[JsonProperty(PropertyName = "events")]
        //public List<Event> Events { get; set; }
        //[JsonProperty(PropertyName = "game_settings")]
        //public GameSettings GameSettings { get; set; }
        //[JsonProperty(PropertyName = "phases")]
        //public List<Phase> Phases { get; set; }
        //[JsonProperty(PropertyName = "teams")]
        //public List<Team> Teams { get; set; }
        //[JsonProperty(PropertyName = "total_players")]
        //public int TotalPlayers { get; set; }
        [JsonProperty(PropertyName = "elements")]
        public List<Player> Players { get; set; }
        //[JsonProperty(PropertyName = "element_stats")]
        //public List<ElementStat> PlayerStats { get; set; }
        ////TODO: check this
        //[JsonProperty(PropertyName = "element_types")]
        //public List<ElementType> element_types { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
