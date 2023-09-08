using MediatR;
using Microsoft.AspNetCore.Http;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.Article.Create
{
    public class CreateArticleCommand : ICommand<Unit>
    {
        public int UserProfileId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int IsPublished { get; set; }
        public IFormFile? MainImage { get; set; }
    }
}
