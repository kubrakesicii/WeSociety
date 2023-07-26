using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.UserProfile;
using WeSociety.Domain.AggregateRoots.UserProfile;

namespace WeSociety.Application.Mapping
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<GetUserProfileDto, UserProfile>().ReverseMap();
        }
    }
}
