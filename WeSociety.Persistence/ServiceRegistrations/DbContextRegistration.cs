using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeSociety.Domain.Interfaces;
using WeSociety.Domain.Repository;
using WeSociety.Persistence.Context;
using WeSociety.Persistence.Repositories;

namespace WeSociety.Persistence.ServiceRegistrations
{
    public static class DbContextRegistration
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<WeSocietyDbContext>(options =>
            {
                options.UseSqlServer($"Server={config["DB_SERVER"]}; User={config["DB_USER"]}; Password={config["DB_PASSWORD"]} ;Database={config["DB_NAME"]};TrustServerCertificate=True;");
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }

    }
}
