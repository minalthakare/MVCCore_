using Microsoft.AspNetCore.Mvc;

namespace MVC8App.Areas.admin.Controllers
{
   // [Area("admin")]
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
