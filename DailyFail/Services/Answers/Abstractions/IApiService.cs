using System;
using BaitNews.Services.Headlines;

//Used for Fusillade
namespace BaitNews.Services.Answers

{
	public interface IApiService
	{
		IRefit Speculative { get; }
		IRefit UserInitiated { get; }
		IRefit Background { get; }
	}

}