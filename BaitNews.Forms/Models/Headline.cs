using System;
using Newtonsoft.Json;

namespace BaitNews.Forms.Models
{
    public class Headline
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("isTrue")]
        public bool IsTrue { get; set; }

        [JsonProperty("isNSFW")]
        public bool IsNSFW { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("mainImageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("commentCount")]
        public int CommentCount { get; set; }

        [JsonProperty("likeCount")]
        public int LikeCount { get; set; }
    }
}
