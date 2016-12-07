using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeadlineManager.Windows
{
    /// <summary>
    /// Interaction logic for AddHeadline.xaml
    /// </summary>
    public partial class AddHeadline : Window
    {
        MobileServiceClient client = new MobileServiceClient(Helpers.Keys.AzureServiceUrl);
        IMobileServiceTable<Models.Headline> table;

        public AddHeadline()
        {
            InitializeComponent();
            table = client.GetTable<Models.Headline>();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var headline = new Models.Headline
            {
                Text = tbxHeadline.Text,
                Url = tbxUrl.Text,
                IsTrue = (bool)chbIsReal.IsChecked,
                Source = tbxSource.Text
            };

            await Add(headline);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        async Task Add(Models.Headline headline)
        {
            await table.InsertAsync(headline);
            Headliner.Utils.MessagingCenter.Send<AddHeadline>(this, "Refresh");
            Close();
        }
    }
}
