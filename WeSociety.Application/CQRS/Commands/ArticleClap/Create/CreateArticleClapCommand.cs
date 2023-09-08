using MediatR;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.ArticleClap.Create
{
    public class CreateArticleClapCommand : ICommand<Unit>
    {
        public int UserProfileId { get; set; }
        public int ArticleId { get; set; }
    }
}
