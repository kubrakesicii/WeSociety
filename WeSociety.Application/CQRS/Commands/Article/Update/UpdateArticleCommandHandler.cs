using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Article.Update
{
    public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public UpdateArticleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _uow.Articles.Get(x => x.Id == request.Id);
            article.Update(request.Title,request.Content);

            //await _uow.Articles.Update(article);   //EF Core change track edildigi icin update etmeye gerek duymadan degisikligi yansıtıyor
            await _uow.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
