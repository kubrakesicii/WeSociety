using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.DTO.FollowRelationship;
using WeSociety.Domain.Aggregates.ReadingListRoot.Entities;
using WeSociety.Domain.Aggregates.UserProfileRoot.Entities;

namespace WeSociety.Application.Mapping
{
    public class ReadingListArticleMapping : Profile
    {
        public ReadingListArticleMapping()
        {
            CreateMap<ReadingListArticle, GetArticleDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Article.Id))
              .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Article.Title))
              .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Article.Domain))
              .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Article.Content))
              .ForMember(dest => dest.MainImage, opt => opt.MapFrom(src => src.Article.MainImage))
              .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.Article.CreatedTime))
              .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(src => src.Article.UpdatedTime))
              .ForMember(dest => dest.UserProfile, opt => opt.MapFrom(src => src.Article.UserProfile))
              .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Article.Category));
        }
    }
}
