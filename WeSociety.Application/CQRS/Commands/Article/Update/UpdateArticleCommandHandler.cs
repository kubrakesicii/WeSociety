using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Helpers;
using WeSociety.Application.Interfaces;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Article.Update
{
    public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, Response>
    {
        private readonly IUnitOfWork _uow;
        private readonly IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> _elasticSearchService;

        public UpdateArticleCommandHandler(IUnitOfWork uow,IElasticSearchService<Domain.Aggregates.ArticleRoot.Article> elasticSearchService)
        {
            _uow = uow;
            _elasticSearchService = elasticSearchService;
        }

        public async Task<Response> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _uow.Articles.Get(x => x.Id == request.id);
            article.Update(request.Title,
                request.Content,
                request.CategoryId,
                request.MainImage == null ? article.MainImage : FileHelper.ConvertFileToByteArray(request.MainImage)
            );


            //ELK UPD
            var query = new TermQuery { Field = "domain", Value = article.Domain };

            await _elasticSearchService.GetDocument("articles", query); 

            return new SuccessResponse();
        }
    }
}
