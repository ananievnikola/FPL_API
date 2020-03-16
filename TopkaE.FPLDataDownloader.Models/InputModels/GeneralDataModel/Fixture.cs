﻿using Newtonsoft.Json;
using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public class Fixture
    {
        //[Key]
        public int Id { get; set; }

        public int ElementId { get; set; }

        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "team_h")]
        public int TeamH { get; set; }

        [JsonProperty(PropertyName = "team_h_score")]
        public int? TeamHScore { get; set; }

        [JsonProperty(PropertyName = "team_a")]
        public int TeamA { get; set; }

        [JsonProperty(PropertyName = "team_a_score")]
        public int? TeamAScore { get; set; }

        [JsonProperty(PropertyName = "event")]
        public int? Event { get; set; }

        [JsonProperty(PropertyName = "finished")]
        public bool Finished { get; set; }

        [JsonProperty(PropertyName = "minutes")]
        public int Minutes { get; set; }

        [JsonProperty(PropertyName = "provisional_start_time")]
        public bool ProvisionalStartTime { get; set; }

        [JsonProperty(PropertyName = "kickoff_time")]
        public DateTime? KickoffTime { get; set; }

        //[Column(TypeName = "VARCHAR(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci")]
        [JsonProperty(PropertyName = "event_name")]
        public string EventName { get; set; }

        [JsonProperty(PropertyName = "is_home")]
        public bool IsHome { get; set; }

        [JsonProperty(PropertyName = "difficulty")]
        public int Difficulty { get; set; }
    }
}
