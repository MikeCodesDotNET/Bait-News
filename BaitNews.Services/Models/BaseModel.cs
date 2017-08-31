using System;
using Newtonsoft.Json;

namespace BaitNews.Models
{
    public class BaseModel
    {
		[JsonProperty("id")]
		public string Id { get; set; }
    }
}
