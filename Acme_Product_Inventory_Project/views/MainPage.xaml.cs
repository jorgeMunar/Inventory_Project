//Jorge Enrique Munar Cardenas
using Acme_Product_Inventory_Project.models;
using Acme_Product_Inventory_Project.viewmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Acme_Product_Inventory_Project.views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainViewModel viewModel;

        public MainPage()
        {
            this.InitializeComponent();
            viewModel = new MainViewModel();
            if (!viewModel.IsDataLoaded)
                { viewModel.LoadData(); }

            DataContext = viewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = MainListBox.SelectedItem as Product;

            if (product != null)
            {
                Frame.Navigate(typeof(views.DetailsPage), product.Id);
            }

            MainListBox.SelectedIndex = -1;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!viewModel.IsDataLoaded)
            {
                viewModel.LoadData();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainListBox.SelectedItem = null;
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(views.NewPage));
        }
    }
}
