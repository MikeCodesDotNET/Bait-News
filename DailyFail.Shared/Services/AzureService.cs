using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Diagnostics;

using DailyFail.Shared.Models;
using DailyFail.Shared.Helpers;

namespace DailyFail.Shared.Services
{
	public class AzureService
	{
		public MobileServiceClient MobileService { get; set; }
		IMobileServiceSyncTable<Headline> headlineTable;

		bool isInitialized;
		public async Task Initialize()
		{
			if (isInitialized)
				return;


			var handler = new AuthHandler();
			//Create our client
			MobileService = new MobileServiceClient("https://dailyfailapp.azurewebsites.net", handler);
			handler.Client = MobileService;

			if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
			{
				MobileService.CurrentUser = new MobileServiceUser(Settings.UserId);
				MobileService.CurrentUser.MobileServiceAuthenticationToken = Settings.AuthToken;
			}

			const string path = "syncstore.db";
			//setup our local sqlite store and intialize our table
			var store = new MobileServiceSQLiteStore(path);

			store.DefineTable<Headline>();

			await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

			//Get our sync table that will call out to azure
			headlineTable = MobileService.GetSyncTable<Headline>();

			isInitialized = true;
		}

		public async Task<IEnumerable<Headline>> GetHeadlines()
		{
			await Initialize();
			await SyncHeadline();
			return await headlineTable.ToEnumerableAsync();
		}

		public async Task AddHeadline(Headline headline)
		{
			await Initialize();

		
			await headlineTable.InsertAsync(headline);

			await SyncHeadline();
		}


		public async Task SyncHeadline()
		{
			try
			{
				await headlineTable.PullAsync("allHeadlines", headlineTable.CreateQuery());
				await MobileService.SyncContext.PushAsync();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Unable to sync headlines, that is alright as we have offline capabilities: " + ex);
			}
		}
	}

}

