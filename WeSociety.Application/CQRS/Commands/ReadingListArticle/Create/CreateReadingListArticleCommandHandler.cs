using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.ReadingListArticle.Create
{
    public class CreateReadingListArticleCommandHandler : ICommandHandler<CreateReadingListArticleCommand, Response>
    {
        private readonly IUnitOfWork _uow;

        public CreateReadingListArticleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(CreateReadingListArticleCommand request, CancellationToken cancellationToken)
        {
            var readingList = await _uow.ReadingLists.Get(x => x.Id == request.ReadingListId);
            readingList.SaveArticle(request.ArticleId);

            await _uow.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
