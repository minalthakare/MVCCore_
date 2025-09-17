using CRUDUsingEFCoreCodeFirstApproach.Models;
using CRUDUsingEFCoreCodeFirstApproach.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingEFCoreCodeFirstApproach.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _dbContext;

        public ProductController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int? categoryId)
        {
            ////var products = _dbContext.Products.ToList();
            //List<Product> products = new List<Product>();

            //if (categoryId != null)
            //{
            //    products = _dbContext.Products.Where(p => p.categoryId == categoryId).ToList();

            //}
            //else
            //{
            //    products = _dbContext.Products.ToList();
            //}

            //return View(products);

         
            List<Product> products;

            if (categoryId != null)
            {
                products = _dbContext.Products
                                     .Include(p => p.Category)
                                     .Where(p => p.categoryId == categoryId)
                                     .ToList();
            }
            else
            {
                products = _dbContext.Products
                                     .Include(p => p.Category)
                                     .ToList();
            }

            return View(products);
        }

        

        [HttpGet]

        public IActionResult Details(int? id)
        {
            var products = _dbContext.Products.Find(id);
            return View(products);
        }

        [HttpGet]

        public IActionResult Create()
        {
            //return View();
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View();
        }

        [HttpPost]

        public IActionResult Create(Product products)
        {

            //_dbContext.Products.Add(products);
            //_dbContext.SaveChanges();

            //return RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                _dbContext.Products.Add(products);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _dbContext.Categories.ToList(); // to refill dropdown on error
            return View(products);

        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            //var product = _dbContext.Products.Find(id);
            //return View(product);
            var product = _dbContext.Products.Find(id);
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            //_dbContext.Entry(product).State = EntityState.Modified;
            //_dbContext.SaveChanges();

            //return RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _dbContext.Categories.ToList(); // to refill dropdown on error
            return View(product);

        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //var product = _dbContext.Products.Find(id);
            var product = _dbContext.Products
                .Include(p => p.Category) // <-- This includes the related category
                .FirstOrDefault(p => p.Id == id);
            return View(product);

        }

        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteConfirmed(int? Id)
        {
            var products = _dbContext.Products.Find(Id);

            //_dbContext.Entry(products).State = EntityState.Modified;
            //_dbContext.SaveChanges();

            _dbContext.Products.Remove(products);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
