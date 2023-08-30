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

        public async Task<bool> CheckIndexAsync(string indexName)
        {
            var indexExists = await _elasticClient.Indices.ExistsAsync(indexName);
            return indexExists.Exists;
        }

        public async Task<List<T>> SearchAsync(string indexName, string searchKey)
        {
            var response = await _elasticClient.SearchAsync<T>(
                s => s.Index(indexName).Source()
                    .Query(q => q.QueryString(qs => qs.AnalyzeWildcard()
                        .Query("*" + searchKey.ToLower() + "*")
                    .Fields(fs => fs)
                )));
            return response.Documents.ToList();
        }

        public async Task<IndexResponse> CreateIndexAsync(string indexName, string docId, T doc)
        {
            var indExists = await _elasticClient.Indices.ExistsAsync(indexName);
            if (!indExists.Exists)
            {
                var createRes = await _elasticClient.Indices.CreateAsync(indexName, index =>
                   index.Map<T>(x => x.AutoMap()));
            }
            var indRes = await _elasticClient.IndexAsync<T>
                (doc, x => x.Index(indexName).Id(docId));

            return indRes;
        }

        public async Task<IndexResponse> IndexDocumentAsync(string indexName, string docId, T doc)
        {
            var res =  await _elasticClient.IndexAsync<T>
                (doc, x => x.Index(indexName).Id(docId));

            return res;
        }

        public async Task AddOrUpdateAsync(string indexName,string docId, T doc)
        {
            var updRes = await _elasticClient.UpdateAsync<T>(docId,u => u.Doc(doc).Index(indexName));
        }

    }
}
