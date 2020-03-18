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

        //public int ElementId { get; set; }

        [JsonProperty(PropertyName = "element")]
        public int PlayerId { get; set; }

        [JsonProperty(PropertyName = "fixture")]
        public int Fixture { get; set; }

        [JsonProperty(PropertyName = "opponent_team")]
        public byte OpponentTeam { get; set; }

        [JsonProperty(PropertyName = "total_points")]
        public sbyte TotalPoints { get; set; }

        [JsonProperty(PropertyName = "was_home")]
        public bool WasHome { get; set; }

        [JsonProperty(PropertyName = "kickoff_time")]
        public DateTime? KickoffTime { get; set; }

        [JsonProperty(PropertyName = "team_h_score")]
        public byte? TeamHScore { get; set; }

        [JsonProperty(PropertyName = "team_a_score")]
        public byte? TeamAScore { get; set; }

        [JsonProperty(PropertyName = "round")]
        public byte Round { get; set; }

        [JsonProperty(PropertyName = "minutes")]
        public byte Minutes { get; set; }

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
        public byte Saves { get; set; }

        [JsonProperty(PropertyName = "bonus")]
        public byte Bonus { get; set; }

        [JsonProperty(PropertyName = "bps")]
        public sbyte BPS { get; set; }

        //[Column(TypeName = "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci")]
        [JsonProperty(PropertyName = "influence")]
        public float Influence { get; set; }

        //[Column(TypeName = "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci")]
        [JsonProperty(PropertyName = "Creativity")]
        public float Creativity { get; set; }

        //[Column(TypeName = "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci")]
        [JsonProperty(PropertyName = "threat")]
        public float Threat { get; set; }

        //[Column(TypeName = "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci")]
        [JsonProperty(PropertyName = "ict_index")]
        public float ICTndex { get; set; }
        [JsonProperty(PropertyName = "value")]
        public float Price { get; set; }

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
