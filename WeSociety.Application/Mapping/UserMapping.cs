using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.User;
using WeSociety.Domain.AggregateRoots.Users;

namespace WeSociety.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping() { 
            CreateMap<AppUser, GetUserDto>().ReverseMap();
            CreateMap<AppUser, GetLoginUserDto>().ReverseMap();
        }
    }
}
