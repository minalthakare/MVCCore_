using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDUsingEFCoreCodeFirstApproach.Custom_Filters
{
    public class MyResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("MyResourceFilter OnResourceExecuted");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("MyResourceFilter OnResourceExecuting");
        }
    }
}
