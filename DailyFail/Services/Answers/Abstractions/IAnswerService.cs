using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Fusillade;
using BaitNews.Models;

namespace BaitNews.Services.Answers.Abstractions
{
	public interface IAnswerService
	{
		Task<List<Headline>> GetAnswers(Priority priority);
		Task<Headline> GetAnswer (Priority priority, string id);
	}
}
