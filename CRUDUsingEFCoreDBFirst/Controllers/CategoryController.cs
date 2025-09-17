using CRUDUsingEFCoreDBFirst.Models;
using CRUDUsingEFCoreDBFirst.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingEFCoreDBFirst.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductDbContext   _dbContext;

        public CategoryController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();
            return View(categories);
        }

        [HttpGet]

        public IActionResult Details(int? id)
        {
            var category = _dbContext.Categories.Find(id);
            return View(category);
        }

        [HttpGet]

        public IActionResult Create()
        {
             return View();   
        }

        [HttpPost]

        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                category.AddedDate = DateTime.Now;
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            var category = _dbContext.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {


                
                category.ModifiedDate = DateTime.Now;
                _dbContext.Entry(category).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

           return View(category) ;
        }
        [HttpGet]

        public IActionResult Delete(int? id)
        {
            var category = _dbContext.Categories.Find(id);
            return View(category);

        }
        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteConfirmed(int? Id)
        {

            var category = _dbContext.Categories.Find(Id);

            //_dbContext.Categories.Remove(category);
            //_dbContext.SaveChanges();

           category.DeletedDate = DateTime.Now;

            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();


           

            return RedirectToAction("Index");
        }

       

    }
}
