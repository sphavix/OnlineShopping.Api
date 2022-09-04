using Microsoft.AspNetCore.Mvc;
using OnlineShopping.UI.Models;

namespace OnlineShopping.UI.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<ProductViewModel> products;
            HttpResponseMessage response = GlobalVariables.client.GetAsync("Products").Result;
            products = response.Content.ReadAsAsync<IEnumerable<ProductViewModel>>().Result;
            return View(products);
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

        
        public ActionResult AddOrEdit(int id = 0)
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

        [HttpPost]
        public ActionResult AddOrEdit(ProductViewModel model)
        {
            HttpResponseMessage response = GlobalVariables.client.PostAsJsonAsync("Products", model).Result;
            return RedirectToAction("Index");
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
