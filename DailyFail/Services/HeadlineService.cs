using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

using Plugin.Connectivity;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using BaitNews.Models;

namespace BaitNews.Services
{
    public class HeadlineService : IHeadlineService
    {
        public MobileServiceClient MobileService { get; set; }
        IMobileServiceSyncTable<Headline> headlineTable;

        bool isInitialized;
        public async Task Initialize()
        {
            if (isInitialized)
                return;

            MobileService = new MobileServiceClient(Helpers.Keys.AzureServiceUrl, null)
            {
                SerializerSettings = new MobileServiceJsonSerializerSettings()
                {
                    CamelCasePropertyNames = true
                }
            };

            var store = new MobileServiceSQLiteStore("dankheadlines.db");
            store.DefineTable<Headline>();

            await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            headlineTable = MobileService.GetSyncTable<Headline>();

            isInitialized = true;
        }

        public async Task<bool> AddHeadline(Headline headline)
        {
            await Initialize();

            await headlineTable.InsertAsync(headline);
            //Synchronize todos
            await SyncToDos();
            return true;
        }

        public async Task SyncToDos()
        {
            var connected = await Plugin.Connectivity.CrossConnectivity.Current.IsReachable(Helpers.Keys.AzureServiceUrl);
            if (connected == false)
                return;

            try
            {
                await MobileService.SyncContext.PushAsync();
                await headlineTable.PullAsync("allHeadlineItems", headlineTable.CreateQuery());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync items, that is alright as we have offline capabilities: " + ex);
            }
        }

        public async Task<IEnumerable<Headline>> GetHeadlines()
        {
            await Initialize();
            await SyncToDos();
            return await headlineTable.ToEnumerableAsync();
        }
    }
}