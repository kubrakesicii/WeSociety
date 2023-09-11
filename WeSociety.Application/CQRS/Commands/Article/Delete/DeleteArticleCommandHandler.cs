using MediatR;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Core.Exceptions;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Article.Delete
{
    public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeleteArticleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _uow.Articles.GetAsync(x => x.Id == request.Id,cancellationToken);
            if (article == null) throw new NotfoundException();

            var userProfile = await _uow.UserProfiles.GetAsync(x => x.Id == article.UserProfileId, cancellationToken);
            userProfile.DeleteArticle(article);
            return await Task.FromResult(Unit.Value);
        }
    }
}
