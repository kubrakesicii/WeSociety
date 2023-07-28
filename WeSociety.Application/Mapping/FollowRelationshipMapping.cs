using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.FollowRelationship;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;

namespace WeSociety.Application.Mapping
{
    internal class FollowRelationshipMapping : Profile
    {
        public FollowRelationshipMapping() {
            CreateMap<FollowRelationship, GetFollowerDto>()
                .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.Follower.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Follower.FullName))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Follower.Image))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Follower.User.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Follower.User.Email));

            CreateMap<FollowRelationship,GetFollowingDto >()
                 .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.Following.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Following.FullName))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Following.Image))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Following.User.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Following.User.Email));
        }
    }
}
