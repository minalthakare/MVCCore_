using Microsoft.AspNetCore.Mvc;

namespace MVC8App.Areas.admin.Controllers
{
    //[Area("admin")]
    public class RoleController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
