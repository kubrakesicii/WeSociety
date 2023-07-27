using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.AggregateRoots.UserProfile.Entities;

namespace WeSociety.Application.Mapping
{
    public class ArticleMapping : Profile
    {
        public ArticleMapping() {
            CreateMap<Article, GetArticleDto>().ReverseMap();
        }
    }
}
