using AutoMapper;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.Aggregates.ArticleRoot;

namespace WeSociety.Application.Mapping
{
    public class ArticleMapping : Profile
    {
        public ArticleMapping() {
            CreateMap<Article, GetArticleDto>();            
            
        }
    }
}
