﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeSociety.Domain.Aggregates.UserRoot;
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
                //options.UseSqlServer($"Server={config["DB_SERVER"]}; Database={config["DB_NAME"]}; Trusted_Connection=True;TrustServerCertificate=True;");
                options.UseSqlServer($"Server={config["DB_SERVER"]},1433; User={config["DB_USER"]}; Password={config["DB_PASSWORD"]} ;Database={config["DB_NAME"]};TrustServerCertificate=True;");
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
