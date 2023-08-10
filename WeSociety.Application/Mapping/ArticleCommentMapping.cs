using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.Commands.ArticleComment.Create;
using WeSociety.Application.DTO.ArticleComment;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;

namespace WeSociety.Application.Mapping
{
    public class ArticleCommentMapping : Profile
    {
        public ArticleCommentMapping()
        {
            CreateMap<CreateArticleCommentCommand, ArticleComment>();
            CreateMap<ArticleComment, GetArticleCommentDto>();
        }
    }
}
