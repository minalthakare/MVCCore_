using CRUDUsingEFCoreDBFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingEFCoreDBFirst.Controllers
{
    public class UsersController : Controller
    {
        private readonly ProductDbContext _dbcontext;

        public UsersController(ProductDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var users = _dbcontext.Users.ToList();
            return View(users);
        }
    }
}
