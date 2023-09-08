using MediatR;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.ArticleComment.Create
{
    public class CreateArticleCommentCommand : ICommand<Unit>
    {
        public int ArticleId { get; set; }
        public int UserProfileId { get; set; }
        public string Text { get; set; }
    }
}
