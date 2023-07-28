using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.FollowRelationship.Follow;
using WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowers;
using WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowings;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FollowRelationshipsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FollowRelationshipsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Follow")]
        public async Task<IActionResult> Insert([FromBody] FollowUserProfileCommand followUserProfileCommand)
        {
            return Ok(await _mediator.Send(followUserProfileCommand));
        }

        [HttpGet("Followers")]
        public async Task<IActionResult> GetAllFollowers([FromQuery,Required] int userProfileId)
        {
            return Ok(await _mediator.Send(new GetAllFollowersQuery { UserProfileId = userProfileId }));
        }

        [HttpGet("Followings")]
        public async Task<IActionResult> GetAllFollowings([FromQuery, Required] int userProfileId)
        {
            return Ok(await _mediator.Send(new GetAllFollowingsQuery { UserProfileId = userProfileId }));
        }
    }
}
