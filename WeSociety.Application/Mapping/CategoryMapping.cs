using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.Category;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;

namespace WeSociety.Application.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category,GetCategoryDto>();
        }
    }
}
