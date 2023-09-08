using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.ReadingListArticle;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Queries.ReadingListArticle.GetIsSaved
{
    public class GetArticleIsSavedQueryHandler : IQueryHandler<GetArticleIsSavedQuery, GetIsSavedArticleDto>
    {
        private readonly IUnitOfWork _uow;

        public GetArticleIsSavedQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<GetIsSavedArticleDto> Handle(GetArticleIsSavedQuery request, CancellationToken cancellationToken)
        {
            var savedData = await _uow.ReadingListArticles.GetIsArticleSaved(request.UserProfileId,request.ArticleId);

            return new GetIsSavedArticleDto
            {
                IsSaved = savedData != null ? true : false,
                Id = savedData != null ? savedData.Id : 0
            };
        }
    }
}
