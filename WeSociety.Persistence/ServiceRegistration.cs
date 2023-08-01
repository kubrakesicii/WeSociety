using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Domain.Interfaces;
using WeSociety.Domain.Repository;
using WeSociety.Persistence.Context;
using WeSociety.Persistence.Repositories;

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

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddIdentity<AppUser, IdentityRole>(_ =>
            {
                _.User.RequireUniqueEmail = true;  //username param default unique'dir.
                _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluğunu kaldırıyoruz.
                _.Password.RequireLowercase = false; //Küçük harf zorunluluğunu kaldırıyoruz.
                _.Password.RequireUppercase = false; //Büyük harf zorunluluğunu kaldırıyoruz.
                _.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<WeSocietyDbContext>().AddDefaultTokenProviders();
        }
    }
}
