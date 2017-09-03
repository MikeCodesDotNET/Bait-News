﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BaitNews.Models;
using Refit;

//This is for Refit
namespace BaitNews.Services.Headlines
{
	[Headers("Accept: application/json")]
	public interface IHeadlineRefit
	{
		[Get("/headline")]
		Task<List<Headline>> GetHeadlines();

		[Get("/headline?id={id}")]
		Task<Headline> GetHeadline(string id);

		[Post("/headline")]
		Task<Headline> PutHeadline(Headline headline);
	}
}
