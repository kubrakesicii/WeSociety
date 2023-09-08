using AutoMapper;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ArticleComment;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.ArticleComment.GetAllByArticle
{
    public class GetAllArticleCommentsByArticleQueryHandler : IQueryHandler<GetAllArticleCommentsByArticleQuery, List<GetArticleCommentDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllArticleCommentsByArticleQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetArticleCommentDto>> Handle(GetAllArticleCommentsByArticleQuery request, CancellationToken cancellationToken)
        {
            var articles = await _uow.ArticleComments.GetAllByArticleWithUser(request.ArticleId);
            var articleDtos = _mapper.Map<List<GetArticleCommentDto>>(articles);
            return articleDtos;
        }
    }
}
