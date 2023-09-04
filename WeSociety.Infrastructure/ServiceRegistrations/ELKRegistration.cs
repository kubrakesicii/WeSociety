using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.Interfaces;
using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Infrastructure.ElasticSearch;

namespace WeSociety.Infrastructure.ServiceRegistrations
{
    public static class ELKRegistration
    {
        public static void AddELKService(this IServiceCollection services, IConfiguration config)
        {
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
