using Microsoft.AspNetCore.Mvc;

namespace MVC8App.Controllers
{
    [Route("[controller]")]
    public class CategoryController : BaseController
    {
        [Route("Index/{id?}")]
        public string Index(int? id)
        {

            return $" Index Action : Found {id} from url";
        }

        [Route("Index1/{id}/{name}")]
        public string Index1(int id, string name)
        {

            return $"Index1 Action :  Found {id} name : {name} from url";
        }

        [Route("Index2/{id}/{categoryname}")]
        public string Index2(int id, string categoryname)
        {

            return $"Index2 Action :  Found {id} categoryname : {categoryname} from url";
        }
    }
}
