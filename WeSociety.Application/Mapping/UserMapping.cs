using AutoMapper;
using WeSociety.Application.CQRS.Commands.Auth.Register;
using WeSociety.Application.DTO.User;
using WeSociety.Domain.Aggregates.UserRoot;

namespace WeSociety.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping() { 
            CreateMap<AppUser, GetUserDto>().ReverseMap();
            CreateMap<AppUser, GetLoginUserDto>().ReverseMap();
            
            CreateMap<RegisterCommand,AppUser >()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForSourceMember(dest => dest.Password, opt => opt.DoNotValidate());
        }
    }
}
