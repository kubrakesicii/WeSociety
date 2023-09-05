using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.Behaviors;
using WeSociety.Application.Decorators;

namespace WeSociety.Application.ServiceRegistrations
{
    public static class MediatRRegistration
    {
        public static void AddMediatr(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            //MEDIATR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            //To scan and register all the validator classes from the current assembly
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.Decorate(typeof(IRequestHandler<,>), typeof(CommandHandlerDecorator<,>));

        }

    }
}
