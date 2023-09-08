using MediatR;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.ReadingListArticle.Create
{
    public class CreateReadingListArticleCommand : ICommand<Unit>
    {
        public int ReadingListId { get; set; }
        public int ArticleId { get; set; }
    }
}
