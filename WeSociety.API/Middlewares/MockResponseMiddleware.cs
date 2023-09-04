using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WeSociety.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MockResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public MockResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MockResponseMiddlewareExtensions
    {
        public static IApplicationBuilder UseMockResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MockResponseMiddleware>();
        }
    }
}
