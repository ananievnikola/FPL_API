using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public class Player : IFPLModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "chance_of_playing_next_round")]
        public sbyte? ChanceOfPlayingNextRound { get; set; }

        [JsonProperty(PropertyName = "chance_of_playing_this_round")]
        public sbyte? ChanceOfPlayingThisRound { get; set; }

        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "cost_change_event")]
        public short CostChangeEvent { get; set; }

        [JsonProperty(PropertyName = "cost_change_event_fall")]
        public short CostChangeEventFall { get; set; }

        [JsonProperty(PropertyName = "cost_change_start")]
        public short CostChangeStart { get; set; }

        [JsonProperty(PropertyName = "cost_change_start_fall")]
        public short CostChangeStartFall { get; set; }

        [JsonProperty(PropertyName = "dreamteam_count")]
        public byte DreamteamCount { get; set; }

        [JsonProperty(PropertyName = "element_type")]
        public byte ElementType { get; set; }

        [JsonProperty(PropertyName = "ep_next")]
        public float EpNext { get; set; }

        [JsonProperty(PropertyName = "ep_this")]
        public float EpThis { get; set; }

        [JsonProperty(PropertyName = "event_points")]
        public sbyte EventPoints { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "form")]
        public float Form { get; set; }

        [JsonProperty(PropertyName = "in_dreamteam")]
        public bool InDreamteam { get; set; }

        [JsonProperty(PropertyName = "news")]
        public string News { get; set; }

        [JsonProperty(PropertyName = "news_added")]
        public DateTime? NewsAdded { get; set; }

        [JsonProperty(PropertyName = "now_cost")]
        public float NowCost { get; set; }

        [JsonProperty(PropertyName = "photo")]
        public string Photo { get; set; }

        [JsonProperty(PropertyName = "points_per_game")]
        public float PointsPerGame { get; set; }

        [JsonProperty(PropertyName = "second_name")]
        public string SecondName { get; set; }

        [JsonProperty(PropertyName = "selected_by_percent")]
        public float SelectedByPercent { get; set; }

        [JsonProperty(PropertyName = "special")]
        public bool Special { get; set; }

        //public object squad_number { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "team")]
        public string Team { get; set; }

        [JsonProperty(PropertyName = "team_code")]
        public byte TeamCode { get; set; }

        [JsonProperty(PropertyName = "total_points")]
        public short TotalPoints { get; set; }

        [JsonProperty(PropertyName = "transfers_in")]
        public int TransfersIn { get; set; }

        [JsonProperty(PropertyName = "transfers_in_event")]
        public int TransfersInEvent { get; set; }

        [JsonProperty(PropertyName = "transfers_out")]
        public int TransfersOut { get; set; }

        [JsonProperty(PropertyName = "transfers_out_event")]
        public int TransfersOutEvent { get; set; }

        [JsonProperty(PropertyName = "value_form")]
        public float ValueForm { get; set; }
        [JsonProperty(PropertyName = "value_season")]
        public float ValueSeason { get; set; }

        [JsonProperty(PropertyName = "web_name")]
        public string WebName { get; set; }

        [JsonProperty(PropertyName = "minutes")]
        public short Minutes { get; set; }

        [JsonProperty(PropertyName = "goals_scored")]
        public byte GoalsScored { get; set; }

        [JsonProperty(PropertyName = "assists")]
        public byte Assists { get; set; }

        [JsonProperty(PropertyName = "clean_sheets")]
        public byte CleanSheets { get; set; }

        [JsonProperty(PropertyName = "goals_conceded")]
        public byte GoalsConceded { get; set; }

        [JsonProperty(PropertyName = "own_goals")]
        public byte OwnGoals { get; set; }

        [JsonProperty(PropertyName = "penalties_saved")]
        public byte PenaltiesSaved { get; set; }

        [JsonProperty(PropertyName = "penalties_missed")]
        public byte PenaltiesMissed { get; set; }

        [JsonProperty(PropertyName = "yellow_cards")]
        public byte YellowCards { get; set; }

        [JsonProperty(PropertyName = "red_cards")]
        public byte RedCards { get; set; }

        [JsonProperty(PropertyName = "saves")]
        public short Saves { get; set; }

        [JsonProperty(PropertyName = "bonus")]
        public short Bonus { get; set; }

        [JsonProperty(PropertyName = "bps")]
        public int Bps { get; set; }

        [JsonProperty(PropertyName = "influence")]
        public float Influence { get; set; }

        [JsonProperty(PropertyName = "creativity")]
        public float Creativity { get; set; }

        [JsonProperty(PropertyName = "threat")]
        public float Threat { get; set; }

        [JsonProperty(PropertyName = "ict_index")]
        public float IctIndex { get; set; }

        //Additional properties
        public DateTime? LastUpdated { get; set; }

        public string TeamName { get; set; }

        //Navigation properties
        public List<Fixture> Fixtures { get; set; }
        public List<History> Histories { get; set; }
    }
}
