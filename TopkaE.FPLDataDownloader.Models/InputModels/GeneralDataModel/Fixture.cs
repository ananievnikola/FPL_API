using Newtonsoft.Json;
using System;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public class Fixture
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "team_h")]
        public byte TeamH { get; set; }

        [JsonProperty(PropertyName = "team_h_score")]
        public byte? TeamHScore { get; set; }

        [JsonProperty(PropertyName = "team_a")]
        public byte TeamA { get; set; }

        [JsonProperty(PropertyName = "team_a_score")]
        public byte? TeamAScore { get; set; }

        [JsonProperty(PropertyName = "event")]
        public byte? Event { get; set; }

        [JsonProperty(PropertyName = "finished")]
        public bool Finished { get; set; }

        [JsonProperty(PropertyName = "minutes")]
        public byte Minutes { get; set; }

        [JsonProperty(PropertyName = "provisional_start_time")]
        public bool ProvisionalStartTime { get; set; }

        [JsonProperty(PropertyName = "kickoff_time")]
        public DateTime? KickoffTime { get; set; }

        [JsonProperty(PropertyName = "event_name")]
        public string EventName { get; set; }

        [JsonProperty(PropertyName = "is_home")]
        public bool IsHome { get; set; }

        [JsonProperty(PropertyName = "difficulty")]
        public byte Difficulty { get; set; }
    }
}
