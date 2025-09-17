using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDUsingEFCoreCodeFirstApproach.Custom_Filters
{
    public class MyAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("MyAuthorizationFilter OnAuthorization called");
        }
    }
}
