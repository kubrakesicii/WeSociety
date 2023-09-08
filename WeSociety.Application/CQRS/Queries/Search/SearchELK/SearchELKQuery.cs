using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Search;

namespace WeSociety.Application.CQRS.Queries.Search.SearchELK
{
    public class SearchELKQuery : IQuery<GetSearchResultDto>
    {
        public string SearchKey { get; set; }
    }
}
