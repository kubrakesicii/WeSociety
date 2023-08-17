using AutoMapper;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.Aggregates.ArticleRoot;

namespace WeSociety.Application.Mapping
{
    public class ArticleMapping : Profile
    {
        public ArticleMapping() {
            CreateMap<Article, GetArticleDto>()
                .ForMember(dest => dest.ClapCount, opt => opt.MapFrom(src => src.ArticleClaps.Count))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.ArticleComments.Count));

        }
    }
}
