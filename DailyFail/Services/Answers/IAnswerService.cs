using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Fusillade;
using BaitNews.Models;

namespace BaitNews.Services.Answers.Abstractions
{
	public interface IAnswerService
	{
		Task<List<Answer>> GetAnswers(Priority priority);
		Task<Answer> GetAnswer (Priority priority, string id);
	}
}
