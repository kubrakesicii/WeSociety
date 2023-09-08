using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.UserProfile.Create;
using WeSociety.Application.CQRS.Commands.UserProfile.Update;
using WeSociety.Application.CQRS.Queries.UserProfile.GetById;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Application.Responses;

namespace WeSociety.API.Controllers
{
    public class UserProfilesController : WeSocietyController
    {
        public UserProfilesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Insert([FromForm] CreateUserProfileCommand createUserProfileCommand)
        {
            await _mediator.Send(createUserProfileCommand);
            return ProduceResponse();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DataResponse<GetUserProfileDto>), StatusCodes.Status200OK)]
        public async Task<DataResponse<GetUserProfileDto>> Get([FromRoute] int id)
        {
            var res = await _mediator.Send(new GetUserProfileByIdQuery() { Id = id });
            return ProduceResponse(res);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromForm] UpdateUserProfileCommand updateUserProfileCommand)
        {
            return Ok(await _mediator.Send(updateUserProfileCommand));
        }
    }
}
