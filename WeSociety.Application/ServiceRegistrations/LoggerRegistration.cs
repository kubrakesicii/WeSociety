using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.ServiceRegistrations
{
    public static class LoggerRegistration
    {
        public static void AddLogger(this IServiceCollection services)
        {
            // var logger = new LoggerConfiguration()
            //.WriteTo.File(new JsonFormatter(), "../WeSociety.Core/Logs/logger.json")
            //.WriteTo.Console()
            //.WriteTo.File("../WeSociety.Core/Logs/all.logs",
            //    restrictedToMinimumLevel: LogEventLevel.Warning,
            //    rollingInterval: RollingInterval.Day)
            //.MinimumLevel.Information()
            //.CreateLogger();

            // services.AddSerilog(logger);
        }

    }
}
