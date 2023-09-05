using AutoMapper.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeSociety.Application.Responses;
using WeSociety.Domain.Pagination;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                var myCustomAttributes = endpoint?.Metadata?.GetMetadata<ProducesResponseTypeAttribute>();
                if (myCustomAttributes is not null)
                {
                    var type = myCustomAttributes.Type;

                    if (type.Name != "Void")
                    {
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
