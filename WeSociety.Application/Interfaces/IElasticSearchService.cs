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
        Task<bool> CheckIndex(string indexName);
        Task<IndexResponse> CreateIndex(string indexName, T doc);
        Task<IndexResponse> IndexDocument(string indexName, T doc);
        Task<List<T>> Search(string indexName, string searchKey);

        Task GetDocument(string indexName, QueryContainer predicate);
    }
}
