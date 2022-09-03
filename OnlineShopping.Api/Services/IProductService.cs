using OnlineShopping.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Api.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        string AddProduct(Product product);
        string UpdateProduct(Product product);
        string DeleteProduct(int id);
    }
}
