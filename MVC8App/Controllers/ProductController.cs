using Microsoft.AspNetCore.Mvc;
using MVC8App.Models;

namespace MVC8App.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.UserName = LoggedInUsername;
            return View();
        }

        [HttpGet]
        public IActionResult Index1()
        {
            return View();   // Views/Product or shared/index1.cshtml
        }

        [HttpGet]

        public IActionResult Index2()
        {
            List<Product> products = new List<Product>()
            {
              new Product(){ Name = "Product1", Price = 599},
              new Product(){ Name = "Product2", Price = 1599},
              new Product(){ Name = "Product3", Price = 2000},
            };

            return View(products);  
        }

        [HttpGet]

        public IActionResult Index3()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index3(Product product)
        {
            Console.WriteLine($"MySelf");
            Console.WriteLine($"MySelf");
            return View();
        }

    }
}
