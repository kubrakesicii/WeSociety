using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.FollowRelationship;
using WeSociety.Domain.Pagination;

namespace WeSociety.Application.CQRS.Queries.FollowRelationship.GetAllFollowers
{
    public class GetAllFollowersQuery : IQuery<PaginatedList<GetFollowerDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int UserProfileId { get; set; }
    }
}
