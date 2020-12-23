// Jorge Enrique Munar Cardenas
using Acme_Product_Inventory_Project.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Acme_Product_Inventory_Project.viewmodels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private IProductRepository Db { get; }
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }

            set
            {
                if(value != products)
                {
                    products = value;
                    NotifyPropertyChanged("Products");
                }
            }
        }

        public MainViewModel()
        {
            Db = App.Data;
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            Products = new ObservableCollection<Product>(Db.GetProducts().ToList());
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal async void AddNewProduct(Product newProduct)
        {
            if (Db.InsertProduct(newProduct))
            {
                MessageDialog md = new MessageDialog("Product added to database", "INSERT OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Product NOT added to database", "INSERT OUTCOME");
                await md.ShowAsync();
            }
        }
    }
}
