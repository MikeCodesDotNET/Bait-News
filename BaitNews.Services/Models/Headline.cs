using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BaitNews.Models
{
    public class Headline : BaseModel
    {
		[JsonProperty("text")]
		[DataType(DataType.MultilineText)]
		[StringLength(360, MinimumLength = 10)]
        [Display(Name ="Headline")]
		public string Text { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("isTrue")]
		[Display(Name = "Is True")]
		public bool IsTrue { get; set; }

		[JsonProperty("isNSFW")]
		[Display(Name = "NSFW")]
		public bool IsNSFW { get; set; }

		[JsonProperty("mainImageUrl")]
		[Display(Name = "Image URL")]
		public string ImageUrl { get; set; }

		[JsonProperty("commentCount")]
		[Display(Name = "Comment Count")]
		public int CommentCount { get; set; }

		[JsonProperty("likeCount")]
		[Display(Name = "Like Count")]
		public int LikeCount { get; set; }
    }
}
