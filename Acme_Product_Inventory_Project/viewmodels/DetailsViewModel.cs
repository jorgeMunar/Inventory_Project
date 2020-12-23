// Jorge Enrique Munar Cardenas
using Acme_Product_Inventory_Project.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme_Product_Inventory_Project.viewmodels
{
    class DetailsViewModel
    {
        private IProductRepository Db { get; }
        private Product product;

        public Product Product
        {
            get { return product; }

            set
            {
                if (product != value)
                {
                    product = value;
                    RaisePropertyChanged("Product");
                }
            }
        }

        public DetailsViewModel(int productId)
        {
            Db = App.Data;
            this.Product = Db.GetProductById(productId);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string propname)
        {
            var eh = PropertyChanged;
            if (eh != null)
                eh(this, new PropertyChangedEventArgs(propname));
        }

        public bool SaveEditedProduct(Product p)
        {
            return Db.UpdateProduct(p);
        }
    }
}
