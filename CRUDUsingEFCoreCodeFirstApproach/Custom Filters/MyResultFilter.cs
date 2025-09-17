using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDUsingEFCoreCodeFirstApproach.Custom_Filters
{
    public class MyResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("MyResultFilter OnResultExecuted");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("MyResultFilter  OnResultExecuting");
        }
    }
}
