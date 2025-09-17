namespace MiddleWareDemos.MiddleWares
{
    public class CustomMiddleware1
    {
       private readonly RequestDelegate _next;

        public CustomMiddleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("MiddleWare 1 executed in request");

           await _next(context);

            Console.WriteLine("MiddleWare 1 executed in response");
        }
    }
}
