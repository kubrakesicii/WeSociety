using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            var logger = new LoggerConfiguration()
           .WriteTo.File(new JsonFormatter(), "../WeSociety.Application/Logs/logger.json")
           .WriteTo.Console()
           .WriteTo.File("../WeSociety.Application/Logs/all.logs",
               restrictedToMinimumLevel: LogEventLevel.Warning,
               rollingInterval: RollingInterval.Day)
           .MinimumLevel.Information()
           .CreateLogger();

            services.AddSerilog(logger);
        }
    }
}
