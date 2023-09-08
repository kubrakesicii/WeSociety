using MediatR;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.ArticleComment.Create
{
    public class CreateArticleCommentCommandHandler : ICommandHandler<CreateArticleCommentCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public CreateArticleCommentCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateArticleCommentCommand request, CancellationToken cancellationToken)
        {
            var article = await _uow.Articles.Get(x => x.Id == request.ArticleId);
            article.AddComment(request.UserProfileId, request.Text);
            return await Task.FromResult(Unit.Value);
        }
    }
}
