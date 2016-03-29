using System;

namespace DailyFail.Shared.Models
{
	public class Headline
	{
		[Newtonsoft.Json.JsonProperty("Id")]
		public string Id { get; set; }

		[Microsoft.WindowsAzure.MobileServices.Version]
		public string AzureVersion { get; set; }

		public bool IsTrue { get; set;}
		public string Text { get; set;}
		public string Source { get; set;}
		public string Url { get; set; }
	}
}

