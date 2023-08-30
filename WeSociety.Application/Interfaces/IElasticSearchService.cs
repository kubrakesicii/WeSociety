using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Common;

namespace WeSociety.Application.Interfaces
{
    public interface IElasticSearchService<T> where T : AggregateRoot
    {
        Task<bool> CheckIndexAsync(string indexName);
        Task<IndexResponse> CreateIndexAsync(string indexName,string docId, T doc);
        Task<IndexResponse> IndexDocumentAsync(string indexName, string docId, T doc);
        Task<List<T>> SearchAsync(string indexName, string searchKey);

        Task AddOrUpdateAsync(string indexName, string docId, T doc);
    }
}
