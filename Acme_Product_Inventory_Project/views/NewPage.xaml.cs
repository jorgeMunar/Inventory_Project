// Jorge Enrique Munar Cardenas
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
    public sealed partial class NewPage : Page
    {
        private MainViewModel viewModel;

        public NewPage()
        {
            this.InitializeComponent();
            viewModel = new MainViewModel();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product();
            p.ProductName = txtName.Text;
            p.Quantity = int.Parse(txtQuantity.Text);
            p.Price = int.Parse(txtPrice.Text);
            viewModel.AddNewProduct(p);

            Frame.Navigate(typeof(views.MainPage));

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(views.MainPage));
        }
    }
}
