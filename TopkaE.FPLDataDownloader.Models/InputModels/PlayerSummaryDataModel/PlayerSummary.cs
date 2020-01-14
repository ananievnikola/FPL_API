using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    //public class Fixture
    //{
    //    public int Id { get; set; }
    //    public int PlayerSummaryId { get; set; }
    //    [JsonProperty(PropertyName = "code")]
    //    public int Code { get; set; }
    //    [JsonProperty(PropertyName = "team_h")]
    //    public int TeamH { get; set; }
    //    [JsonProperty(PropertyName = "team_h_score")]
    //    public int? TeamHScore { get; set; }
    //    [JsonProperty(PropertyName = "team_a")]
    //    public int TeamA { get; set; }
    //    [JsonProperty(PropertyName = "team_a_score")]
    //    public int? TeamAScore { get; set; }
    //    [JsonProperty(PropertyName = "event")]
    //    public int? Event { get; set; }
    //    [JsonProperty(PropertyName = "finished")]
    //    public bool Finished { get; set; }
    //    [JsonProperty(PropertyName = "minutes")]
    //    public int Minutes { get; set; }
    //    [JsonProperty(PropertyName = "provisional_start_time")]
    //    public bool ProvisionalStartTime { get; set; }
    //    [JsonProperty(PropertyName = "kickoff_time")]
    //    public DateTime? KickoffTime { get; set; }
    //    [JsonProperty(PropertyName = "event_name")]
    //    public string EventName { get; set; }
    //    [JsonProperty(PropertyName = "is_home")]
    //    public bool IsHome { get; set; }
    //    [JsonProperty(PropertyName = "difficulty")]
    //    public int Difficulty { get; set; }
    //}

    //public class History
    //{
    //    public int Id { get; set; }
    //    public int PlayerSummaryId { get; set; }
    //    [JsonProperty(PropertyName = "element")]
    //    public int Element { get; set; }
    //    [JsonProperty(PropertyName = "fixture")]
    //    public int Fixture { get; set; }
    //    [JsonProperty(PropertyName = "opponent_team")]
    //    public int OpponentTeam { get; set; }
    //    [JsonProperty(PropertyName = "total_points")]
    //    public int TotalPoints { get; set; }
    //    [JsonProperty(PropertyName = "was_home")]
    //    public bool WasHome { get; set; }
    //    [JsonProperty(PropertyName = "kickoff_time")]
    //    public DateTime? KickoffTime { get; set; }
    //    [JsonProperty(PropertyName = "team_h_score")]
    //    public int? TeamHScore { get; set; }
    //    [JsonProperty(PropertyName = "team_a_score")]
    //    public int? TeamAScore { get; set; }
    //    [JsonProperty(PropertyName = "round")]
    //    public int Round { get; set; }
    //    [JsonProperty(PropertyName = "minutes")]
    //    public int Minutes { get; set; }
    //    [JsonProperty(PropertyName = "goals_scored")]
    //    public int GoalsScored { get; set; }
    //    [JsonProperty(PropertyName = "assists")]
    //    public int Assists { get; set; }
    //    [JsonProperty(PropertyName = "clean_sheets")]
    //    public int CleanSheets { get; set; }
    //    [JsonProperty(PropertyName = "goals_conceded")]
    //    public int GoalsConceded { get; set; }
    //    [JsonProperty(PropertyName = "own_goals")]
    //    public int OwnGoals { get; set; }
    //    [JsonProperty(PropertyName = "penalties_saved")]
    //    public int PenaltiesSaved { get; set; }
    //    [JsonProperty(PropertyName = "penalties_missed")]
    //    public int PenaltiesMissed { get; set; }
    //    [JsonProperty(PropertyName = "yellow_cards")]
    //    public int YellowCards { get; set; }
    //    [JsonProperty(PropertyName = "red_cards")]
    //    public int RedCards { get; set; }
    //    [JsonProperty(PropertyName = "saves")]
    //    public int Saves { get; set; }
    //    [JsonProperty(PropertyName = "bonus")]
    //    public int Bonus { get; set; }
    //    [JsonProperty(PropertyName = "bps")]
    //    public int BPS { get; set; }
    //    [JsonProperty(PropertyName = "influence")]
    //    public string Influence { get; set; }
    //    [JsonProperty(PropertyName = "Creativity")]
    //    public string Creativity { get; set; }
    //    [JsonProperty(PropertyName = "threat")]
    //    public string Threat { get; set; }
    //    [JsonProperty(PropertyName = "ict_index")]
    //    public string ICTndex { get; set; }
    //    [JsonProperty(PropertyName = "value")]
    //    public int Value { get; set; }
    //    [JsonProperty(PropertyName = "transfers_balance")]
    //    public int TransfersBalance { get; set; }
    //    [JsonProperty(PropertyName = "selected")]
    //    public int Selected { get; set; }
    //    [JsonProperty(PropertyName = "transfers_in")]
    //    public int TransfersIn { get; set; }
    //    [JsonProperty(PropertyName = "transfers_out")]
    //    public int TransfersOut { get; set; }
    //}

    //public class HistoryPast
    //{
    //    public string season_name { get; set; }
    //    public int element_code { get; set; }
    //    public int start_cost { get; set; }
    //    public int end_cost { get; set; }
    //    public int total_points { get; set; }
    //    public int minutes { get; set; }
    //    public int goals_scored { get; set; }
    //    public int assists { get; set; }
    //    public int clean_sheets { get; set; }
    //    public int goals_conceded { get; set; }
    //    public int own_goals { get; set; }
    //    public int penalties_saved { get; set; }
    //    public int penalties_missed { get; set; }
    //    public int yellow_cards { get; set; }
    //    public int red_cards { get; set; }
    //    public int saves { get; set; }
    //    public int bonus { get; set; }
    //    public int bps { get; set; }
    //    public string influence { get; set; }
    //    public string creativity { get; set; }
    //    public string threat { get; set; }
    //    public string ict_index { get; set; }
    //}

    public class PlayerSummary
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "fixtures")]
        public List<Fixture> Fixtures { get; set; }
        [JsonProperty(PropertyName = "history")]
        public List<History> History { get; set; }
        //public List<HistoryPast> history_past { get; set; }
    }
}
