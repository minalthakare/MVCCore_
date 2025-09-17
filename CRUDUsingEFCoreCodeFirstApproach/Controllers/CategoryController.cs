using System.Reflection.Metadata.Ecma335;
using CRUDUsingEFCoreCodeFirstApproach.Custom_Filters;
using CRUDUsingEFCoreCodeFirstApproach.Models;
using CRUDUsingEFCoreCodeFirstApproach.Models.Entities;
using CRUDUsingEFCoreCodeFirstApproach.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingEFCoreCodeFirstApproach.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMyService _myService;

        public CategoryController(ProductDbContext dbContext, IMyService myService)
        {
            _dbContext = dbContext;
            _myService = myService;
        }

        //[ServiceFilter(typeof(MyResourceFilter))]
        //[ServiceFilter(typeof(MyAuthorizationFilter))]
        //[ServiceFilter(typeof(MyActionFilter))]
        //[ServiceFilter(typeof(MyResultFilter))]
        [ServiceFilter(typeof(MyExceptionFilter))]
        public IActionResult Index()
        {
            ViewBag.InstanceCount = _myService.InstanceCount;

         throw new Exception("Custom Exception Thrown");

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
            if(ModelState.IsValid)
            {
                _dbContext.Entry(category).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
                
            }
            return View(category);
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

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();



            //_dbContext.Entry(category).State = EntityState.Modified;
            //_dbContext.SaveChanges();




            return RedirectToAction("Index");
        }
    }
}
