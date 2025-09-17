using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StateManagementTechniquesMVC.Models;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.OutputCaching;

namespace StateManagementTechniquesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
            ViewData["name"] = "Minal";
            ViewBag.email = "minal@gmail.com";

            Product p = new Product() { Id = 101, Name = "product 1", Price= 1500};
            ViewBag.Product = p;

            TempData["Address"] = "Narhe, Pune";

            TempData["product"] = p;  //Complex Object Data

            HttpContext.Session.SetString("city", "pune");

            // storing complex object using session
            string productJson = JsonSerializer.Serialize(p);
            HttpContext.Session.SetString("prod", productJson);

            Response.Cookies.Append("username", "minal_thakare");  // storing data in cookie

            return View(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            string loadedTime;
            if (_cache.TryGetValue("LoadedTime", out loadedTime))
            {
                ViewBag.LoadedTime = loadedTime;
                ViewBag.message = "Data Loaded from cache";
            }
            else
            {
                ViewBag.LoadedTime = DateTime.Now;


                var enntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(6))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                
                //storing data to cache for 20 sec

                _cache.Set("LoadedTime", DateTime.Now.ToString(), enntryOptions);
                ViewBag.message = "Data Loaded from Databasse";
            }
                ViewBag.LoadedTime = DateTime.Now;
            return View();
        }

        [HttpGet]
        //[ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any,
        //    NoStore =false)]  // storing complete response in cache

        [OutputCache(Duration = 360)]  // only in mvc 5 and 8 not in 6 7
        public IActionResult Contact()
        {
            ViewBag.Name = "vikul rathod";
            ViewBag.Contact = "9527788887";
            ViewBag.LLoadedTime = DateTime.Now;
            return View();
        }
    }
}
