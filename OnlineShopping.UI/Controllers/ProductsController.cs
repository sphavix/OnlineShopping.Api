using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopping.UI.Models;

namespace OnlineShopping.UI.Controllers
{
    public class ProductsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string Url = "https://localhost:7231/api/Products";
            var products = new List<ProductViewModel>();
            HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync(Url);
                string apiResponse = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductViewModel>>(apiResponse);
            }
            catch (Exception x)
            {
                throw x.InnerException;
            }
            return View(products);
        }

        public ViewResult GetProductById() => View();

        [HttpPost]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = new ProductViewModel();
            string Url = "https://localhost:7231/api/Products/";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(Url + id);
            var apiResponse = await response.Content.ReadAsStringAsync();
            product = JsonConvert.DeserializeObject<ProductViewModel>(apiResponse);
            return View(product);
        }

        public ActionResult Details(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.client.GetAsync("Products/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ProductViewModel>().Result);
            }
        }

        
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.client.PostAsJsonAsync("Products", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Product added!";
                }
                else
                {
                    TempData["Error"] = "Opps! an error occured!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.client.DeleteAsync("Products/" + id.ToString()).Result;
                return RedirectToAction("Index");
            }
        }
    }
}
