using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme_Product_Inventory_Project.models
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);
        bool InsertProduct(Product product);
        bool DeleteProduct(int productId);
        bool UpdateProduct(Product product);

    }
}
