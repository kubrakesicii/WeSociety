using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.FollowRelationship.Follow;
using WeSociety.Application.CQRS.Commands.FollowRelationship.UnfollowUser;
using WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowers;
using WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowings;
using WeSociety.Application.CQRS.Queries.FollowRelationship.GetIsFollowing;
using WeSociety.Application.DTO.Category;
using WeSociety.Application.DTO.FollowRelationship;
using WeSociety.Domain.Pagination;

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
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Insert([FromBody] FollowUserProfileCommand followUserProfileCommand)
        {
            return Ok(await _mediator.Send(followUserProfileCommand));
        }

        [HttpPost("UnFollow")]
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Delete([FromBody] UnfollowUserProfileCommand unfollowUserProfileCommand)
        {
            return Ok(await _mediator.Send(unfollowUserProfileCommand));
        }

        [HttpGet("Followers")]
        [SwaggerResponse(200, Type = typeof(PaginatedList<GetFollowerDto>))]
        public async Task<IActionResult> GetAllFollowers([FromQuery,Required] int userProfileId, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllFollowersQuery { UserProfileId = userProfileId, PageIndex = pageIndex, PageSize = pageSize }));
        }

        [HttpGet("Followings")]
        [SwaggerResponse(200, Type = typeof(PaginatedList<GetFollowingDto>))]
        public async Task<IActionResult> GetAllFollowings([FromQuery, Required] int userProfileId, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllFollowingsQuery { UserProfileId = userProfileId, PageIndex = pageIndex, PageSize = pageSize }));
        }


        [HttpGet("IsFollow")]
        [SwaggerResponse(200, Type = typeof(bool))]
        public async Task<IActionResult> GetIsFollowing([FromQuery, Required] int followerId, [FromQuery, Required] int followingId)
        {
            return Ok(await _mediator.Send(new GetIsFollowingQuery { FollowerId = followerId, FollowingId = followingId }));
        }
    }
}
