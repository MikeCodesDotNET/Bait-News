using System;
using BaitNews.Services.Headlines;

//Used for Fusillade
namespace BaitNews.Services.Headlines

{
	public interface IApiService<T>
	{
		T Speculative { get; }
		T UserInitiated { get; }
		T Background { get; }
	}

}