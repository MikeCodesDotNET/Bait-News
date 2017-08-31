using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Fusillade;
using BaitNews.Models;

namespace BaitNews.Services.Headlines.Abstractions
{
	public interface IHeadlineService
	{
		Task<List<Headline>> GetHeadlines(Priority priority);
		Task<Headline> GetHeadline (Priority priority, string id);
	}
}
