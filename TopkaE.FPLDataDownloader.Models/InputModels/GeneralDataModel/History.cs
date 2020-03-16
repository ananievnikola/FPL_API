using Newtonsoft.Json;
using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public class History
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ElementId { get; set; }

        [JsonProperty(PropertyName = "element")]
        public int Element { get; set; }

        [JsonProperty(PropertyName = "fixture")]
        public int Fixture { get; set; }

        [JsonProperty(PropertyName = "opponent_team")]
        public int OpponentTeam { get; set; }

        [JsonProperty(PropertyName = "total_points")]
        public int TotalPoints { get; set; }

        [JsonProperty(PropertyName = "was_home")]
        public bool WasHome { get; set; }

        [JsonProperty(PropertyName = "kickoff_time")]
        public DateTime? KickoffTime { get; set; }

        [JsonProperty(PropertyName = "team_h_score")]
        public int? TeamHScore { get; set; }

        [JsonProperty(PropertyName = "team_a_score")]
        public int? TeamAScore { get; set; }

        [JsonProperty(PropertyName = "round")]
        public int Round { get; set; }

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
        public int BPS { get; set; }

        //[Column(TypeName = "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci")]
        [JsonProperty(PropertyName = "influence")]
        public string Influence { get; set; }

        //[Column(TypeName = "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci")]
        [JsonProperty(PropertyName = "Creativity")]
        public string Creativity { get; set; }

        //[Column(TypeName = "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci")]
        [JsonProperty(PropertyName = "threat")]
        public string Threat { get; set; }

        //[Column(TypeName = "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci")]
        [JsonProperty(PropertyName = "ict_index")]
        public string ICTndex { get; set; }
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }

        [JsonProperty(PropertyName = "transfers_balance")]
        public int TransfersBalance { get; set; }

        [JsonProperty(PropertyName = "selected")]
        public int Selected { get; set; }

        [JsonProperty(PropertyName = "transfers_in")]
        public int TransfersIn { get; set; }

        [JsonProperty(PropertyName = "transfers_out")]
        public int TransfersOut { get; set; }
    }
}
