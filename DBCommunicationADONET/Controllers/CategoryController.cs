using System.Data;
using DBCommunicationADONET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace DBCommunicationADONET.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService dbService)
        {
            _categoryService = dbService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
               
                if (_categoryService.Create(category))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }

        [HttpGet]

        public IActionResult Details(int? id)
        {
           var category = _categoryService.GetById(id ?? 0);
            return View(category);
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            var categories = _categoryService.GetById(id ?? 0);
            return View(categories);
            
        }

        [HttpPost]

        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
         
                if (_categoryService.Update(category))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {

            var categories = _categoryService.GetById(id);
            return View(categories);
        }

        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteConfirmed(int? Id)
        {
        
            if (_categoryService.Delete(Id ?? 0))
            {
                return RedirectToAction("Index");
            }

            var categories = _categoryService.GetById(Id ?? 0);
            return View(categories);
        }

        
    }
}

