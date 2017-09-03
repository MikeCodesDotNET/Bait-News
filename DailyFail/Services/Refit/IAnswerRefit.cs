﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BaitNews.Models;
using Refit;

//This is for Refit
namespace BaitNews.Services.Answers
{
    [Headers("Accept: application/json")]
    public interface IAnswerRefit
	{
		[Get("/answer")]
		Task<List<Headline>> GetAnswers();

		[Get("/answer?id={id}")]
		Task<Headline> GetAnswer(string id);

		[Post("/answer")]
		Task<Headline> PutAnswer(Answer answer);
	}
}
