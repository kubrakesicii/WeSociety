using AutoMapper;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Domain.Aggregates.UserProfileRoot;

namespace WeSociety.Application.Mapping
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<GetUserProfileDto, UserProfile>().ReverseMap();
            CreateMap<GetCommentUserProfileDto, UserProfile>().ReverseMap();
        }
    }
}
