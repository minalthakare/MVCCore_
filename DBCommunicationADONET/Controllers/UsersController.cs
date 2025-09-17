using DBCommunicationADONET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DBCommunicationADONET.Controllers
{
    public class UsersController : Controller
    {
        private readonly string _connectionString;

        private readonly IUserService _userService;
        public UsersController(IConfiguration config, IUserService userService)
        {
            _connectionString = config.GetConnectionString("B25ADONETCOREDB");
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Users model)
        {

            if(ModelState.IsValid)
            {
                model.AddedDate = DateTime.Now;
                if (_userService.Create(model))
                    {
                        return RedirectToAction("Index");
                    }
            }
                return View(model);
        }

        [HttpGet]

        public IActionResult Details(int? id)
        {
            // Users user = GetUserById(id ?? 0);
            Users user = _userService.GetById(id ?? 0);

           return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // Users user = GetUserById(id ?? 0);
            Users user = _userService.GetById(id ?? 0);

            return View(user);
        }

        [HttpPost]

        public IActionResult Edit(Users user)
        {
            if (ModelState.IsValid)
            {
               
                    if (_userService.Update(user))
                    {
                        return RedirectToAction("Index");
                    }
                
            }

            return View(user);
        }

        [HttpGet]

        public IActionResult Delete(int? id)
        {
            // Users user = GetUserById(id ?? 0);
            Users user = _userService.GetById(id ?? 0);

            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteConfirmed(int? Id)
        {
            if (_userService.Delete(Id ?? 0))
            {
                return RedirectToAction("Index");
            }
        
            Users user = _userService.GetById(Id ?? 0);
            return View(user);
        }

        //private Users GetUserById(int id)
        //{
            
        //}

        
    }
}
