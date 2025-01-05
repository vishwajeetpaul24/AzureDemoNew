
namespace AzureDemo.Services
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello World \n");
            await next(context);
            await context.Response.WriteAsync("Hello World ! Very Good Morning\n");

        }
    }
}
