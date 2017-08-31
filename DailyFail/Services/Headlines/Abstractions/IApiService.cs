﻿using System;
using BaitNews.Services.Headlines;

//Used for Fusillade
namespace BaitNews.Services
{
	public interface IApiService
	{
		IRefit Speculative { get; }
		IRefit UserInitiated { get; }
		IRefit Background { get; }
	}

}
