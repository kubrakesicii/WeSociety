using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Queries.Search.SearchELK;
using WeSociety.Application.DTO.Search;
using WeSociety.Application.Responses;

namespace WeSociety.API.Controllers
{
    public class SearchsController : WeSocietyController
    {
        public SearchsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<GetSearchResultDto>), StatusCodes.Status200OK)]
        public async Task<DataResponse<GetSearchResultDto>> Search([FromQuery, Required] string searchKey, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new SearchELKQuery() { SearchKey = searchKey }, cancellationToken);
            return ProduceResponse(res);
        }

    }
}
