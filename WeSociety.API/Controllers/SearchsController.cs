using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Queries.Search.SearchELK;
using WeSociety.Application.DTO.ReadingList;
using WeSociety.Application.DTO.Search;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SearchsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(GetSearchResultDto))]
        public async Task<IActionResult> Search([FromQuery, Required] string searchKey)
        {
            return Ok(await _mediator.Send(new SearchELKQuery() { SearchKey = searchKey }));
        }

    }
}
