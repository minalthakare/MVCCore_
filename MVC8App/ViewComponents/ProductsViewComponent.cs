using Microsoft.AspNetCore.Mvc;
using MVC8App.Models;

namespace MVC8App.ViewComponents
{
    public class ProductsViewComponent : ViewComponent  
    {
        public async Task<IViewComponentResult> InvokeAsync(string description)
        {
            List<Product> products = new List<Product>()
            {
                new Product(){Name = "Samsung", Price = 90000, Description = "topRated"},
                new Product(){Name = "Apple", Price = 190000, Description = "topRated"},
                new Product(){Name = "RedMi", Price = 15000, Description = "topRated"},
                new Product(){Name = "Fridge", Price = 20000, Description = "Discount Products"},
                new Product(){Name = "Washing Machine", Price = 25000, Description = "Discount Products"},
                new Product(){Name = "TV", Price = 56000, Description = "Discount Products"},
            };
            if(!string.IsNullOrEmpty(description))
            {
               products = products.Where(p => p.Description.Contains(description)).ToList();
            }

            return View(products);
        }
    }
}
