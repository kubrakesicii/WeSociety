using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.ReadingList;
using WeSociety.Domain.Aggregates.ReadingListRoot;

namespace WeSociety.Application.Mapping
{
    public class ReadingListMapping : Profile
    {
        public ReadingListMapping()
        {
            CreateMap<ReadingList, GetReadingListDto>()
                .ForMember(dest => dest.ArticleCount, opt => opt.MapFrom(src => src.ReadingListArticles.Count));
        }
    }
}
