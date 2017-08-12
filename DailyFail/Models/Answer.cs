using System;
using AppServiceHelpers.Models;
using Newtonsoft.Json;

namespace BaitNews.Models
{
    public class Answer : EntityData
    {
        [JsonIgnore]
        public Headline Headline;

		[JsonProperty("headlineId")]
		public string HeadlineId { get; set; }

		[JsonProperty("correctAnswer")]
		public bool CorrectAnswer;

		[JsonProperty("userId")]
		public string UserId { get; set; } 
    }
}

