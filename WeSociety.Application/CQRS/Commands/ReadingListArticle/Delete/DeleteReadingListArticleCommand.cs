using MediatR;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.ReadingListArticle.Delete
{
    public class DeleteReadingListArticleCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
}
