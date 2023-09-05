using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.ReadingList.Create;
using WeSociety.Application.CQRS.Queries.ReadingList.GetAllByUser;
using WeSociety.Application.DTO.ReadingList;
using WeSociety.Application.DTO.ReadingListArticle;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReadingListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReadingListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Insert([FromBody] CreateReadingListCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(List<GetReadingListDto>))]
        public async Task<IActionResult> GetAll([FromQuery, Required] int userProfileId)
        {
            return Ok(await _mediator.Send(new GetAllReadingListsByUserQuery { UserProfileId = userProfileId }));
        }
    }
}
