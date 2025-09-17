using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDUsingEFCoreCodeFirstApproach.Custom_Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("MyExceptionFilter Called");

            context.HttpContext.Session.SetString("message", context.Exception.Message);

            context.Result = new ViewResult() { ViewName = "Error" };

            context.ExceptionHandled = true;
        }
    }
}
