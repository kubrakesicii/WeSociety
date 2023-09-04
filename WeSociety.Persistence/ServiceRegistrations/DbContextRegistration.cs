using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                //options.UseSqlServer($"Server={config["DB_SERVER"]}; Database={config["DB_NAME"]}; Trusted_Connection=True;TrustServerCertificate=True;");
                options.UseSqlServer($"Server={config["DB_SERVER"]},1433; User={config["DB_USER"]}; Password={config["DB_PASSWORD"]} ;Database={config["DB_NAME"]};TrustServerCertificate=True;");
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }

    }
}
