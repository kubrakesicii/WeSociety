using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeSociety.Domain.Aggregates.UserRoot;
using WeSociety.Persistence.Context;

namespace WeSociety.Persistence.ServiceRegistrations
{
    public static class IdentityRegistration
    {
        public static void AddIdentity(this IServiceCollection services, IConfiguration config)
        {
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
