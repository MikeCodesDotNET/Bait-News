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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeadlineManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModels.HeadlinesViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModels.HeadlinesViewModel();
            viewModel.Refresh();

            datagrid.DataSource = viewModel.Headlines;               
            foreach(var field in datagrid.Records.FieldLayout.Fields)
            {
                if (field.Label.ToString() == "Id")
                {
                    field.Visibility = Visibility.Hidden;
                }
                if (field.Label.ToString() == "CreatedAt")
                {
                    field.Visibility = Visibility.Collapsed;
                }
                if (field.Label.ToString() == "UpdatedAt")
                {
                    field.Visibility = Visibility.Collapsed;
                }
                if (field.Label.ToString() == "AzureVersion")
                {
                    field.Visibility = Visibility.Collapsed;
                }
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addHeadline = new Windows.AddHeadline();
            addHeadline.Show();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Refresh();
        }
    }
}
