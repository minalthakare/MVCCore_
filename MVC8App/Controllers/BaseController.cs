using Microsoft.AspNetCore.Mvc;

namespace MVC8App.Controllers
{
    public abstract class BaseController : Controller
    {
      public  string LoggedInUsername {  get; set; }
    }
}
