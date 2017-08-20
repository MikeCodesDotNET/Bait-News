using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BaitNews.Models
{
    public class Headline : BaseModel
    {
		[JsonProperty("text")]
		[DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
		public string Text { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("isTrue")]
		public bool IsTrue { get; set; }

		[JsonProperty("isNSFW")]
		public bool IsNSFW { get; set; }

		[JsonProperty("mainImageUrl")]
		public string ImageUrl { get; set; }
    }
}
