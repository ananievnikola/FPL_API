using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public class Element : IFPLModel
    {
        [JsonProperty(PropertyName = "chance_of_playing_next_round")]
        public int? ChanceOfPlayingNextRound { get; set; }
        [JsonProperty(PropertyName = "chance_of_playing_this_round")]
        public int? ChanceOfPlayingThisRound { get; set; }
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "cost_change_event")]
        public int CostChangeEvent { get; set; }
        [JsonProperty(PropertyName = "cost_change_event_fall")]
        public int CostChangeEventFall { get; set; }
        [JsonProperty(PropertyName = "cost_change_start")]
        public int CostChangeStart { get; set; }
        [JsonProperty(PropertyName = "cost_change_start_fall")]
        public int CostChangeStartFall { get; set; }
        [JsonProperty(PropertyName = "dreamteam_count")]
        public int DreamteamCount { get; set; }
        [JsonProperty(PropertyName = "element_type")]
        public int ElementType { get; set; }
        [JsonProperty(PropertyName = "ep_next")]
        public string EpNext { get; set; }
        [JsonProperty(PropertyName = "ep_this")]
        public string EpThis { get; set; }
        [JsonProperty(PropertyName = "event_points")]
        public int EventPoints { get; set; }
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "form")]
        public string Form { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "in_dreamteam")]
        public bool InDreamteam { get; set; }
        [JsonProperty(PropertyName = "news")]
        public string News { get; set; }
        [JsonProperty(PropertyName = "news_added")]
        public DateTime? NewsAdded { get; set; }
        [JsonProperty(PropertyName = "now_cost")]
        public int NowCost { get; set; }
        [JsonProperty(PropertyName = "photo")]
        public string Photo { get; set; }
        [JsonProperty(PropertyName = "points_per_game")]
        public string PointsPerGame { get; set; }
        [JsonProperty(PropertyName = "second_name")]
        public string SecondName { get; set; }
        [JsonProperty(PropertyName = "selected_by_percent")]
        public string SelectedByPercent { get; set; }
        [JsonProperty(PropertyName = "special")]
        public bool Special { get; set; }
        //public object squad_number { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "team")]
        public int Team { get; set; }
        [JsonProperty(PropertyName = "team_code")]
        public int TeamCode { get; set; }
        [JsonProperty(PropertyName = "total_points")]
        public int TotalPoints { get; set; }
        [JsonProperty(PropertyName = "transfers_in")]
        public int TransfersIn { get; set; }
        [JsonProperty(PropertyName = "transfers_in_event")]
        public int TransfersInEvent { get; set; }
        [JsonProperty(PropertyName = "transfers_out")]
        public int TransfersOut { get; set; }
        [JsonProperty(PropertyName = "transfers_out_event")]
        public int TransfersOutEvent { get; set; }
        [JsonProperty(PropertyName = "value_form")]
        public string ValueForm { get; set; }
        [JsonProperty(PropertyName = "value_season")]
        public string ValueSeason { get; set; }
        [JsonProperty(PropertyName = "web_name")]
        public string WebName { get; set; }
        [JsonProperty(PropertyName = "minutes")]
        public int Minutes { get; set; }
        [JsonProperty(PropertyName = "goals_scored")]
        public int GoalsScored { get; set; }
        [JsonProperty(PropertyName = "assists")]
        public int Assists { get; set; }
        [JsonProperty(PropertyName = "clean_sheets")]
        public int CleanSheets { get; set; }
        [JsonProperty(PropertyName = "goals_conceded")]
        public int GoalsConceded { get; set; }
        [JsonProperty(PropertyName = "own_goals")]
        public int OwnGoals { get; set; }
        [JsonProperty(PropertyName = "penalties_saved")]
        public int PenaltiesSaved { get; set; }
        [JsonProperty(PropertyName = "penalties_missed")]
        public int PenaltiesMissed { get; set; }
        [JsonProperty(PropertyName = "yellow_cards")]
        public int YellowCards { get; set; }
        [JsonProperty(PropertyName = "red_cards")]
        public int RedCards { get; set; }
        [JsonProperty(PropertyName = "saves")]
        public int Saves { get; set; }
        [JsonProperty(PropertyName = "bonus")]
        public int Bonus { get; set; }
        [JsonProperty(PropertyName = "bps")]
        public int Bps { get; set; }
        [JsonProperty(PropertyName = "influence")]
        public string Influence { get; set; }
        [JsonProperty(PropertyName = "creativity")]
        public string Creativity { get; set; }
        [JsonProperty(PropertyName = "threat")]
        public string Threat { get; set; }
        [JsonProperty(PropertyName = "ict_index")]
        public string IctIndex { get; set; }
        //Additional properties
        public DateTime? LastUpdated { get; set; }
        public string TeamName { get; set; }

        //Navigation properties
        public List<Fixture> Fixtures { get; set; }
        public List<History> Histories { get; set; }


        //public double PointsPerPrice { get; set; }
        //public double MinutesPerPoint { get; set; }
    }
}
