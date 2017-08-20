using System;
using Newtonsoft.Json;

namespace BaitNews.Models
{
    public class Answer : BaseModel
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
