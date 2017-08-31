using System;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.ContentModerator;

namespace BaitNews.Services
{
    public class Moderation
    {
		public async Task<bool> IsCivil(string content)
		{
			var client = new Microsoft.ProjectOxford.ContentModerator.ModeratorClient("a6403ab2136243809264e687d52ced2b");
			var result = await client.ScreenTextAsync("hello world", Constants.MediaType.Plain, "", true, false, true, "");
			return result.IsMatch;
		}
    }

   
}
