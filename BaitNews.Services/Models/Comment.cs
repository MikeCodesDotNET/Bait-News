using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BaitNews.Models
{
    public class Comment : BaseModel
    {
		[JsonProperty("userId")]
		[Display(Name = "User Id")]
		public string UserId { get; set; }

		[JsonProperty("headlineId")]
		[Display(Name = "Headline Id")]
		public string HeadlineId { get; set; }

		[JsonProperty("commentContent")]
		[Display(Name = "commentContent")]
		public string Content { get; set; }
    }
}
