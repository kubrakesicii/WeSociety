using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nest;
using System.Text;
using WeSociety.Application.Interfaces;
using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Interfaces;
using WeSociety.Domain.Repository;
using WeSociety.Infrastructure.Authentication;
using WeSociety.Infrastructure.ElasticSearch;
using WeSociety.Persistence.Repositories;

namespace WeSociety.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            //JWT SETTINGS
            var jwtSettings = new JwtSetting
            {
                Issuer = "wesociety",
                Audience = "wesociety",
                SecurityKey = config["JWT_SECURITY_KEY"],
                AccessTokenExpiration = 60 * 24 * 7    ///7 DAYS
            };
            services.AddSingleton(jwtSettings);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "",
                    ValidAudience = "",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddHttpContextAccessor();
            services.AddScoped<IJwtService, JwtService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //ELK CONFIG
            var settings = new ConnectionSettings(new Uri(config["ELK_BASE_URL"] ?? ""))
                .PrettyJson()
            .DefaultIndex(config["ELK_DEFAULT_IND"]);
            settings.BasicAuthentication(config["ELK_USERNAME"], config["ELK_PASS"]);
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);

            client.Indices.Create(config["ELK_DEFAULT_IND"], i => i.Map<Article>(x => x.AutoMap()));

            //ELK SERVICE
            services.AddScoped(typeof(IElasticSearchService<>), typeof(ElasticSearchService<>));



        }
    }
}
