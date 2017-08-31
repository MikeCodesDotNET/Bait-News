﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BaitNews.Models;
using Refit;

//This is for Refit
namespace BaitNews.Services.Headlines
{
    [Headers("Accept: application/json", "Ocp-Apim-Subscription-Key: b5d8711fabd04837b55ed276b2adf9c3")]
    public interface IRefit
	{
		[Get("/tables/headline")]
		Task<List<Headline>> GetHeadlines();

		[Get("/tables/headline/{id}")]
		Task<Headline> GetHeadline(string id);
	}
}
