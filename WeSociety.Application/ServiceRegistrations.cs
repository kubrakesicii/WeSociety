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
using FluentValidation;
using MediatR;
using WeSociety.Application.CQRS.Behaviors;

namespace WeSociety.Application
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            //AUTOMAPPER
            services.AddAutoMapper(assembly);

            //MEDIATR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            //To scan and register all the validator classes from the current assembly
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //SERILOG
           // var logger = new LoggerConfiguration()
           //.WriteTo.File(new JsonFormatter(), "../WeSociety.Application/Logs/logger.json")
           //.WriteTo.Console()
           //.WriteTo.File("../WeSociety.Application/Logs/all.logs",
           //    restrictedToMinimumLevel: LogEventLevel.Warning,
           //    rollingInterval: RollingInterval.Day)
           //.MinimumLevel.Information()
           //.CreateLogger();

           // services.AddSerilog(logger);
        }
    }
}
