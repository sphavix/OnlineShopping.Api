using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Api.Models;
using OnlineShopping.Api.Services;

namespace OnlineShopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _context;
        public ProductsController(IProductService context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_context.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            return Ok(_context.GetProductById(id));
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            return Ok(_context.AddProduct(product));
        }

        [HttpPut]
        public ActionResult UpdateProduct(Product model)
        {
            return Ok(_context.UpdateProduct(model));
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            return Ok(_context.DeleteProduct(id));
        }
    }
}
