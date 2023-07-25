﻿using FluentValidation;
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext,ex);
            }
        }


        private static async Task HandleExceptionAsync(HttpContext httpContext,Exception ex)
        {
            var statusCode = GetStatusCode(ex);
            var response = new
            {
                success = false,
                status = statusCode,
                messsage = ex.Message,
                errors = GetErrors(ex)
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static int GetStatusCode(Exception exception) =>
           exception switch
           {
               LoginException => StatusCodes.Status200OK,
               Application.Exceptions.ValidationException => StatusCodes.Status400BadRequest,
               _ => StatusCodes.Status500InternalServerError
           };


        
        private static IReadOnlyDictionary<string, List<string>> GetErrors(Exception exception)
        {
            IReadOnlyDictionary<string, List<string>> errors = null;
            if (exception is Application.Exceptions.ValidationException validationException)
            {
                errors = validationException.Errors;
            }
            return errors;
        
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
