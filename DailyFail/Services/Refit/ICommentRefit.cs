﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BaitNews.Models;
using Refit;

//This is for Refit
namespace BaitNews.Services.Headlines
{
	[Headers("Accept: application/json")]
	public interface IRefit
	{
		[Get("/comment?headlineId={headlineId}")]
		Task<List<Headline>> GetCommentsFor(string headlineId);

		[Get("/comment?id={id}")]
		Task<Headline> GetComment(string id);

		[Post("/comment")]
		Task<Headline> PutComment(Comment comment);
	}
}
