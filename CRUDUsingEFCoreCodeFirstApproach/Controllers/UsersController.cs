using System.Drawing.Text;
using AutoMapper;
using CRUDUsingEFCoreCodeFirstApproach.Models;
using CRUDUsingEFCoreCodeFirstApproach.Models.Entities;
using CRUDUsingEFCoreCodeFirstApproach.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingEFCoreCodeFirstApproach.Controllers
{
    public class UsersController : Controller
    {
        private readonly ProductDbContext _dbContext;
        private readonly  IMapper _mapper;
        private readonly IMyService _myService;
        private readonly IMyService _myService1;

        public UsersController(ProductDbContext dbContext, IMapper mapper,
            IMyService myService, IMyService myService1)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _myService = myService;
            _myService1 = myService1;
        }

        public IActionResult Index()
        { 
            ViewBag.InstanceCount = _myService.InstanceCount;
            ViewBag.InstanceCount1 = _myService1.InstanceCount;
            var users = _dbContext.Users.ToList();

            var userViewModel = _mapper.Map<List<UserViewModel>>(users);
            // List<User> to List<UserViewModel>
            return View(userViewModel);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(UserViewModel user)
        {
            if(ModelState.IsValid)
            {
                var dbUser = _mapper.Map<User>(user);   
                _dbContext.Users.Add(dbUser);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(user);
        }
    }
}
