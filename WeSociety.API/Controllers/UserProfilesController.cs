using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeSociety.Application.CQRS.Commands.UserProfile.Create;
using WeSociety.Application.CQRS.Commands.UserProfile.Update;
using WeSociety.Application.CQRS.Queries.UserProfile.GetById;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insert([FromForm] CreateUserProfileCommand createUserProfileCommand)
        {
            return Ok(await _mediator.Send(createUserProfileCommand));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetUserProfileByIdQuery() { Id = id }));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromForm] UpdateUserProfileCommand updateUserProfileCommand)
        {
            return Ok(await _mediator.Send(updateUserProfileCommand));
        }
    }
}
