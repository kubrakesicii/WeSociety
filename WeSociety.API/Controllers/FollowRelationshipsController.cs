using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.FollowRelationship.Follow;
using WeSociety.Application.CQRS.Commands.FollowRelationship.UnfollowUser;
using WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowers;
using WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowings;
using WeSociety.Application.CQRS.Queries.FollowRelationship.GetIsFollowing;
using WeSociety.Application.DTO.FollowRelationship;
using WeSociety.Application.Responses;
using WeSociety.Domain.Pagination;

namespace WeSociety.API.Controllers
{
    public class FollowRelationshipsController : WeSocietyController
    {
        public FollowRelationshipsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Follow")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Insert([FromBody] FollowUserProfileCommand followUserProfileCommand)
        {
            await _mediator.Send(followUserProfileCommand);
            return ProduceResponse();

        }

        [HttpPost("UnFollow")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Delete([FromBody] UnfollowUserProfileCommand unfollowUserProfileCommand)
        {
            await _mediator.Send(unfollowUserProfileCommand);
            return ProduceResponse();
        }

        [HttpGet("Followers")]
        [ProducesResponseType(typeof(DataResponse<PaginatedList<GetFollowerDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<PaginatedList<GetFollowerDto>>> GetAllFollowers([FromQuery,Required] int userProfileId, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            var res = await _mediator.Send(new GetAllFollowersQuery { UserProfileId = userProfileId, PageIndex = pageIndex, PageSize = pageSize });
            return ProduceResponse(res);
        }

        [HttpGet("Followings")]
        [ProducesResponseType(typeof(DataResponse<PaginatedList<GetFollowingDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<PaginatedList<GetFollowingDto>>> GetAllFollowings([FromQuery, Required] int userProfileId, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            var res = await _mediator.Send(new GetAllFollowingsQuery { UserProfileId = userProfileId, PageIndex = pageIndex, PageSize = pageSize });
            return ProduceResponse(res);
        }


        [HttpGet("IsFollow")]
        [ProducesResponseType(typeof(DataResponse<bool>), StatusCodes.Status200OK)]
        public async Task<DataResponse<bool>> GetIsFollowing([FromQuery, Required] int followerId, [FromQuery, Required] int followingId)
        {
            var res = await _mediator.Send(new GetIsFollowingQuery { FollowerId = followerId, FollowingId = followingId });
            return ProduceResponse(res);
        }
    }
}
