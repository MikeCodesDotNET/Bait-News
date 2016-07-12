using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

using Plugin.Connectivity;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using BaitNews.Models;
using AppServiceHelpers;

namespace BaitNews.Services
{
    public class HeadlineService 
    {
        public ConnectedObservableCollection<Headline> Collection { get; set;}

        public HeadlineService(AppServiceHelpers.Abstractions.IEasyMobileServiceClient client)
        {
            var table = client.Table<Headline>();
            Collection = new ConnectedObservableCollection<Headline>(table);
        }

        public async Task<bool> AddHeadline(Headline headline)
        {
            await Collection.Add(headline);

            await SyncHeadlines();
            return true;
        }

        public async Task SyncHeadlines()
        {

            var connected = await CrossConnectivity.Current.IsReachable(Helpers.Keys.AzureServiceUrl);
            if (connected == false)
                return;
            try
            {
                await Collection.Refresh();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync items, that is alright as we have offline capabilities: " + ex);
            }
        }
    }
}