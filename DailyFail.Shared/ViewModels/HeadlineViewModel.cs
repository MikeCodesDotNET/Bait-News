using System;
using System.Threading.Tasks;
using DailyFail.Shared.Helpers;
using DailyFail.Shared.Models;
using DailyFail.Shared.Services;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmHelpers;

namespace DailyFail.Shared.ViewModels
{
	public class HeadlineViewModel : BaseViewModel
	{
		AzureService azureService;

		public HeadlineViewModel()
		{
			azureService = new AzureService();

#if DEBUG
			Headlines.AddRange(Helpers.HeadlineBuilder.Build());
#endif
		}

		public ObservableRangeCollection<Headline> Headlines { get; } = new ObservableRangeCollection<Headline>();

		public Headline NextHeadline()
		{
			if (Headlines.Count == 0)
				return null;
			
			var rnd = new Random();
			var i = rnd.Next(0, Headlines.Count);

			var headline = Headlines[i];
			Headlines.RemoveAt(i);
			return headline;
		}

		public async Task FetchHeadlines()
		{
			
		}
	}
}

