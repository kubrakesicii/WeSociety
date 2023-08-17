using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.ArticleClap;

namespace WeSociety.Application.Mapping
{
    public class ArticleClapMapping : Profile
    {
        public ArticleClapMapping()
        {
            CreateMap<GetClapUserGroupDto,GetClapUserDto>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.UserProfile.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.UserProfile.FullName))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.UserProfile.Bio))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.UserProfile.Image))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserProfile.User.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserProfile.User.Email));

        }
    }
}
