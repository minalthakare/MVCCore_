using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDUsingEFCoreCodeFirstApproach.Custom_Filters
{
    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("MyActionFilter OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("MyActionFilte OnActionExecuting");
        }
    }
}
