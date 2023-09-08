using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.UserProfile;

namespace WeSociety.Application.CQRS.Queries.UserProfile.GetById
{
    public class GetUserProfileByIdQuery : IQuery<GetUserProfileDto>
    {
        public int Id { get; set; }
    }
}
