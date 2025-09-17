using Microsoft.AspNetCore.Mvc;
using StateManagementTechniquesMVC.Models;

namespace StateManagementTechniquesMVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult GetCategoryById(int id)
        {
            ViewBag.Id=id;
            return View();    /// using route data
        }

        [HttpGet]

        public IActionResult GetCategoryByName(string name)
        {
            ViewBag.Name = name;
            return View();  // using query data
        }

        [HttpGet]

        public IActionResult GetCategoryByHidden(string search, int rating)
        {
            ViewBag.Search = search;
            ViewBag.Rating = rating;
            return View();  // using hidden field
        }

        [HttpPost]

        public IActionResult Create1(string name, int rating)
        {
            ViewBag.Name = name;
            ViewBag.Rating = rating;
            return View();
        }


        [HttpPost]

        public IActionResult Create2(IFormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Rating = form["rating"];
            return View();
        }



        [HttpPost]

        public IActionResult Create3([Bind("Name")]Category category)
        {
            
            return View(category);
        }

    }
}
