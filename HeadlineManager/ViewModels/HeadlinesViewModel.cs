using System;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadlineManager.Windows;

namespace HeadlineManager.ViewModels
{
    public class HeadlinesViewModel
    {
        public ObservableCollection<Models.Headline> Headlines = new ObservableCollection<Models.Headline>();
        MobileServiceClient client = new MobileServiceClient(Helpers.Keys.AzureServiceUrl);
        IMobileServiceTable<Models.Headline> table;
        public HeadlinesViewModel()
        {
            table = client.GetTable<Models.Headline>();
            Headliner.Utils.MessagingCenter.Subscribe<AddHeadline>(this, "Refresh", async (sender) => { await Refresh(); });
        }

        public async Task Refresh()
        {
            Headlines.Clear();
            var headlines = await table.ToEnumerableAsync();
            foreach(var headline in headlines)
            {
                Headlines.Add(headline);
            }
        }
    }
}
