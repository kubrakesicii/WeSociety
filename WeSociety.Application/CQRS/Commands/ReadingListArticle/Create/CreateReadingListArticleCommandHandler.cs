using MediatR;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.ReadingListArticle.Create
{
    public class CreateReadingListArticleCommandHandler : ICommandHandler<CreateReadingListArticleCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public CreateReadingListArticleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateReadingListArticleCommand request, CancellationToken cancellationToken)
        {
            var readingList = await _uow.ReadingLists.Get(x => x.Id == request.ReadingListId);
            readingList.SaveArticle(request.ArticleId);
            return await Task.FromResult(Unit.Value);
        }
    }
}
