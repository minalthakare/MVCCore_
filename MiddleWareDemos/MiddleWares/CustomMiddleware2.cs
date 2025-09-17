namespace MiddleWareDemos.MiddleWares
{
    public class CustomMiddleware2
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("MiddleWare 2 executed in request");

            await _next(context);

            Console.WriteLine("MiddleWare 2 executed in response");
        }
    }
}
