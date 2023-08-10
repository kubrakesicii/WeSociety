using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ArticleComment;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.ArticleComment.GetAllByArticle
{
    public class GetAllArticleCommentsByArticleQueryHandler : IQueryHandler<GetAllArticleCommentsByArticleQuery, DataResponse<List<GetArticleCommentDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllArticleCommentsByArticleQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<GetArticleCommentDto>>> Handle(GetAllArticleCommentsByArticleQuery request, CancellationToken cancellationToken)
        {
            var articles = await _uow.ArticleComments.GetAllByArticleWithUser(request.ArticleId);
            var articleDtos = _mapper.Map<List<GetArticleCommentDto>>(articles);
            return new SuccessDataResponse<List<GetArticleCommentDto>>(articleDtos);
        }
    }
}
