using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WeSociety.Application.CQRS.Commands.UserProfile.Create;
using WeSociety.Application.CQRS.Commands.UserProfile.Update;
using WeSociety.Application.CQRS.Queries.UserProfile.GetById;
using WeSociety.Application.DTO.Search;
using WeSociety.Application.DTO.UserProfile;

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
        [SwaggerResponse(200, Type = null)]
        public async Task<IActionResult> Insert([FromForm] CreateUserProfileCommand createUserProfileCommand)
        {
            return Ok(await _mediator.Send(createUserProfileCommand));
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, Type = typeof(GetUserProfileDto))]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetUserProfileByIdQuery() { Id = id }));
        }

        [HttpPut("{id}")]
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Update([FromForm] UpdateUserProfileCommand updateUserProfileCommand)
        {
            return Ok(await _mediator.Send(updateUserProfileCommand));
        }
    }
}
