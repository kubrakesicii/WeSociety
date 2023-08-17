using AutoMapper;
using WeSociety.Application.DTO.User;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Domain.Aggregates.UserProfileRoot;

namespace WeSociety.Application.Mapping
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserProfile, GetUserProfileDto>();
            CreateMap<UserProfile, GetUserDto>();
            CreateMap<GetCommentUserProfileDto, UserProfile>().ReverseMap();

            CreateMap<UserProfile, GetUpdateUserDto>()
                .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.Id));

        }
    }
}
