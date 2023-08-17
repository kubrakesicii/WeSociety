using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ReadingListArticle;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.ReadingListArticle.GetIsSaved
{
    public class GetArticleIsSavedQueryHandler : IQueryHandler<GetArticleIsSavedQuery, DataResponse<GetIsSavedArticleDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetArticleIsSavedQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<DataResponse<GetIsSavedArticleDto>> Handle(GetArticleIsSavedQuery request, CancellationToken cancellationToken)
        {
            var savedData = await _uow.ReadingListArticles.GetIsArticleSaved(request.UserProfileId,request.ArticleId);

            return new SuccessDataResponse<GetIsSavedArticleDto>(new GetIsSavedArticleDto
            {
                IsSaved = savedData != null ? true : false,
                Id = savedData != null ? savedData.Id : 0
            });
        }
    }
}
