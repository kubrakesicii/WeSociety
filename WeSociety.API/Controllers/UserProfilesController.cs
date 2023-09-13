using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.UserProfile.Create;
using WeSociety.Application.CQRS.Commands.UserProfile.Update;
using WeSociety.Application.CQRS.Queries.UserProfile.GetById;
using WeSociety.Application.DTO.User;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Core.Responses;

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
        public async Task<Response> Insert([FromForm] CreateUserProfileCommand createUserProfileCommand, CancellationToken cancellationToken)
        {
            await _mediator.Send(createUserProfileCommand,cancellationToken);
            return ProduceResponse();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DataResponse<GetUserProfileDto>), StatusCodes.Status200OK)]
        public async Task<DataResponse<GetUserProfileDto>> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new GetUserProfileByIdQuery() { Id = id }, cancellationToken);
            return ProduceResponse(res);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(DataResponse<GetUpdateUserDto>), StatusCodes.Status200OK)]
        public async Task<DataResponse<GetUpdateUserDto>> Update([FromForm] UpdateUserProfileCommand updateUserProfileCommand, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(updateUserProfileCommand, cancellationToken);
            return ProduceResponse(res);
        }
    }
}
