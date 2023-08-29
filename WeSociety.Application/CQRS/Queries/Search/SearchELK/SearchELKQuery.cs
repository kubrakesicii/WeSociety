using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.Search;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Queries.Search.SearchELK
{
    public class SearchELKQuery : IQuery<DataResponse<GetSearchResultDto>>
    {
        public string SearchKey { get; set; }
    }
}
