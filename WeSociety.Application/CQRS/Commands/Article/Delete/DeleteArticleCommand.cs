using MediatR;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.Article.Delete
{
    public class DeleteArticleCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
}
