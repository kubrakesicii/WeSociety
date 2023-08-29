using Azure.Core;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.Interfaces;
using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Common;

namespace WeSociety.Infrastructure.ElasticSearch
{
    public class ElasticSearchService<T> : IElasticSearchService<T> where T : AggregateRoot { 

        private readonly IElasticClient _elasticClient;

        public ElasticSearchService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<bool> CheckIndex(string indexName)
        {
            var indexExists = await _elasticClient.Indices.ExistsAsync(indexName);
            return indexExists.Exists;
        }

        public async Task<List<T>> Search(string indexName, string searchKey)
        {
            var response = await _elasticClient.SearchAsync<T>(
                s => s.Index(indexName).Source()
                    .Query(q => q.QueryString(qs => qs.AnalyzeWildcard()
                        .Query("*" + searchKey.ToLower() + "*")
                    .Fields(fs => fs)
                )));
            return response.Documents.ToList();
        }

        public async Task<IndexResponse> CreateIndex(string indexName, T doc)
        {
            var indExists = await _elasticClient.Indices.ExistsAsync(indexName);
            if (!indExists.Exists)
            {
                var createRes = await _elasticClient.Indices.CreateAsync(indexName, index =>
                   index.Map<T>(x => x.AutoMap()));
            }
            var indRes = await _elasticClient.IndexAsync<T>
                (doc, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));

            return indRes;
        }

        public async Task<IndexResponse> IndexDocument(string indexName, T doc)
        {
            var res =  await _elasticClient.IndexAsync<T>
                (doc, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));

            return res;
        }

        public async Task GetDocument(string indexName, QueryContainer predicate)
        {
           var searchRes = await _elasticClient.SearchAsync<T>(s => s.Index(indexName).Source().Query(q => predicate));
            var doc = searchRes.Documents.ToList();

            //var res = _elasticClient.UpdateAsync(DocumentPath<T>.Id("ca0cf8e6-fb94-4023-8132-210873ee6ee3"),
            //    u => u.Index(indexName).DocAsUpsert(true).Doc()

            var res = await _elasticClient.IndexAsync(doc,x => x.Index(indexName));
        }

    }
}
