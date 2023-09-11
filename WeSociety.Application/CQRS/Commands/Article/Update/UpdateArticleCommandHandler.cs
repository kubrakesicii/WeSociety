using MediatR;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Interfaces;
using WeSociety.Core.Helpers;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Article.Update
{
    public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        private readonly IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> _elasticSearchService;

        public UpdateArticleCommandHandler(IUnitOfWork uow,IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> elasticSearchService)
        {
            _uow = uow;
            _elasticSearchService = elasticSearchService;
        }

        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _uow.Articles.GetAsync(x => x.Id == request.id, cancellationToken);
            article.Update(request.Title,
                request.Content,
                request.CategoryId,
                request.MainImage == null ? article.MainImage : FileHelper.ConvertFileToByteArray(request.MainImage)
            );

            //ELK UPD
            await _elasticSearchService.AddOrUpdateAsync("articles",article.Domain,
                new Domain.Aggregates.ArticleRoot.Article(article.Title, article.Domain, article.Content));

            return await Task.FromResult(Unit.Value);
        }
    }
}
