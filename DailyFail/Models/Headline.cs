using AppServiceHelpers.Models;
using Newtonsoft.Json;

namespace BaitNews.Models
{
    public class Headline : EntityData
    {
		[JsonProperty("text")]
		public string Text { get; set;}

		[JsonProperty("url")]
		public string Url { get; set;}

		[JsonProperty("isTrue")]
		public bool IsTrue { get; set;}

		[JsonProperty("isNSFW")]
		public bool IsNSFW { get; set; }

		[JsonProperty("publisher")]
        public string Publisher { get; set; }
	}
}

