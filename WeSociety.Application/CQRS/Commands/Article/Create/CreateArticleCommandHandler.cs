using Nest;
using System;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Helpers;
using WeSociety.Application.Interfaces;
using WeSociety.Application.Responses;
using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Article.Create
{
    public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand, Response>
    {
        private readonly IUnitOfWork _uow;
        private readonly IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> _elasticSearchService;

        public CreateArticleCommandHandler(IUnitOfWork uow, IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> elasticSearchService)
        {
            _uow = uow;
            _elasticSearchService = elasticSearchService;
        }

        public async Task<Response> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            //var profileId = await _authService.GetProfileId();
            var userProfile = await _uow.UserProfiles.Get(x => x.Id == request.UserProfileId);
            var newArticle = userProfile.AddArticle(
                request.Title,
                Guid.NewGuid().ToString(),
                request.Content,
                request.IsPublished,
                request.CategoryId,
                request.MainImage == null ? null : FileHelper.ConvertFileToByteArray(request.MainImage)
            );

            await _uow.UserProfiles.Update(userProfile);

            //ELK INDEXING
            var createRes = await _elasticSearchService.CreateIndexAsync("articles", newArticle.Domain, newArticle);

            return new SuccessResponse();
        }
    }
}
