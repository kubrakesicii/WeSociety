using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.ReadingList.Create;
using WeSociety.Application.CQRS.Queries.ReadingList.GetAllByUser;

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
        public async Task<IActionResult> Insert([FromBody] CreateReadingListCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery, Required] int userProfileId)
        {
            return Ok(await _mediator.Send(new GetAllReadingListsByUserQuery { UserProfileId = userProfileId }));
        }
    }
}
