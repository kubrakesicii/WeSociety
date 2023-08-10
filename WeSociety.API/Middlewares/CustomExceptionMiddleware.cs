using FluentValidation;
using Newtonsoft.Json;
using WeSociety.Application.Exceptions;

namespace WeSociety.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException ex)
            {
                await HandleExceptionAsync(httpContext,ex);
            }
        }


        private static async Task HandleExceptionAsync(HttpContext httpContext, CustomException ex)
        {
            var response = new
            {
                success = false,
                status = ex.StatusCode,
                messsage = ex.Message,
                errors = ex.Errors
            };
             
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)ex.StatusCode;
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
