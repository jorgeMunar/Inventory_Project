using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme_Product_Inventory_Project.models
{
    public class ProductRepository : IProductRepository
    {
        string path;
        SQLiteConnection conn;

        public ProductRepository(string dbName)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbName);
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn.CreateTable<Product>();
        }
        public bool DeleteProduct(int productId)
        {
            Product p = GetProductById(productId);
            if (conn.Delete(p) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Product GetProductById(int productId)
        {
            var products = conn.Table<Product>().ToList();
            return products.First(p => p.Id == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return conn.Table<Product>().ToList();
        }

        public bool InsertProduct(Product product)
        {
            if (conn.Insert(product) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            if (conn.Update(product) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
