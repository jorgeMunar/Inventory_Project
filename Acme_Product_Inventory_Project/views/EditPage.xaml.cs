// Jorge Enrique munar Cardenas
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
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Acme_Product_Inventory_Project.views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage : Page
    {
        DetailsViewModel viewModel;
        public EditPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int id = (int)e.Parameter;

            if (viewModel == null)
            {
                viewModel = new DetailsViewModel(id);
                DataContext = viewModel.Product;
            }
        }

        private async void Accept_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Product.ProductName = txtName.Text;
            viewModel.Product.Quantity = int.Parse(txtQuantity.Text);
            viewModel.Product.Price = int.Parse(txtPrice.Text);
            if (viewModel.SaveEditedProduct(viewModel.Product))
            {
                MessageDialog md = new MessageDialog("Product changes updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Product changes NOT updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }

            Frame.Navigate(typeof(views.DetailsPage), viewModel.Product.Id);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(views.DetailsPage), viewModel.Product.Id);
        }
    }
}
