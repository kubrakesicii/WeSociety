using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Exceptions;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Article.Delete
{
    public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public DeleteArticleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _uow.Articles.Get(x => x.Id == request.Id);
            if (article == null) throw new NotfoundException();

            var userProfile = await _uow.UserProfiles.Get(x => x.Id == article.ProfileId);
            userProfile.DeleteArticle(article);

            await _uow.SaveChangesAsync();

            return new SuccessResponse();
        }
    }
}
