using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WeSociety.Domain.Pagination;

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

        public async Task Invoke(HttpContext httpContext)
        {
            var mockEnable = httpContext.Request.GetTypedHeaders().Get<bool>("Mock-Enable");
            if(!mockEnable) await _next(httpContext);

            else
            {
                var endpoint = httpContext.GetEndpoint();
                var method = endpoint.Metadata.GetType().GetMethods().First().ReturnType;


                var responseAttribute = endpoint?.Metadata?.GetMetadata<ProducesResponseTypeAttribute>();
                if (responseAttribute is not null)
                {
                    var res = responseAttribute.Type;

                    if (res.GenericTypeArguments.Count() > 0)
                    {
                        var type = res.GenericTypeArguments[0];
                        var isGenericList = type.IsGenericType && 
                            (type.GetGenericTypeDefinition() == typeof(List<>) || type.GetGenericTypeDefinition() == typeof(PaginatedList<>));

                        var instanceType = isGenericList ? type.GenericTypeArguments[0] : type;
                        var data = isGenericList ? new List<object> { Activator.CreateInstance(instanceType, null) } :
                            Activator.CreateInstance(instanceType, null);
                        var mockData = type.Name.Contains("PaginatedList") ? new { count = 0, items = data } : data;

                        var response = new
                        {
                            success = true,
                            message = "OK",
                            data= mockData
                        };
                        httpContext.Response.ContentType = "application/json";
                        await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));

                    }
                    else
                    {
                        var response = new
                        {
                            success = true,
                            message = "OK",
                        };
                        httpContext.Response.ContentType = "application/json";
                        await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));

                    }
                }
            }
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
