﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
