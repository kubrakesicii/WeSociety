using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WeSociety.Application.Decorators;

namespace WeSociety.Application.ServiceRegistrations
{
    public static class DecoratorRegistration
    {
        public static void AddDecorators(this IServiceCollection services)
        {
            services.Decorate(typeof(IRequestHandler<,>), typeof(CommandHandlerDecorator<,>));
        }

    }
}
