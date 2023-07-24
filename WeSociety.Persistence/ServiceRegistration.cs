using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<WeSocietyDbContext>(options =>
            {
                options.UseSqlServer($"Server={config["DB_SERVER"]}; Database={config["DB_NAME"]}; Trusted_Connection=True;TrustServerCertificate=True;");
            });

        }
    }
}
