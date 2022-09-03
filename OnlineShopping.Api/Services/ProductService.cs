using OnlineShopping.Api.Database;
using OnlineShopping.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly OnlineShoppingDbContext _contxt;
        public ProductService(OnlineShoppingDbContext contxt)
        {
            _contxt = contxt;
        }

        public List<Product> GetProducts()
        {
            using (_contxt)
            {
                return _contxt.Products.ToList();
            }
        }

        public Product GetProductById(int id)
        {
            using (_contxt)
            {
                return _contxt.Products.FirstOrDefault(x => x.Id == id);
            }
        }

        public string AddProduct(Product product)
        {
            using(var transaction = _contxt.Database.BeginTransaction())
            {
                using (_contxt)
                {
                    _contxt.Products.Add(product);
                    _contxt.SaveChanges();
                    transaction.Commit();
                }
                return "Product added!";
            }
        }

        public string UpdateProduct(Product product)
        {
            using(var transaction = _contxt.Database.BeginTransaction())
            {
                using (_contxt)
                {
                    var model = _contxt.Products.FirstOrDefault(x => x.Id == product.Id);
                    if(model != null)
                    {
                        model.Id = product.Id;
                        model.ProductName = product.ProductName;
                        model.ProductImage = product.ProductImage;
                        model.Brand = product.Brand;
                        model.Category = product.Category;
                        model.Description = product.Description;
                        model.isInStock = product.isInStock;
                        model.Quantity = product.Quantity;
                        model.Price = product.Price;
                        model.Size = product.Size;
                        _contxt.Products.Update(model);
                        _contxt.SaveChanges();
                        transaction.Commit();
                    }
                }
                return "Product Updated!";
            }
        }

        public string DeleteProduct(int id)
        {
            using(var transaction = _contxt.Database.BeginTransaction())
            {
                using (_contxt)
                {
                    var product = _contxt.Products.FirstOrDefault(x => x.Id == id);
                    if (product != null)
                    {
                        _contxt.Products.Remove(product);
                        _contxt.SaveChanges();
                        transaction.Commit();
                    }
                }
                return "Product deleted";
            }
        }
    }
}
