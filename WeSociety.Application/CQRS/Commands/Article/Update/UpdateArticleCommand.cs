using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.Article.Update
{
    public class UpdateArticleCommand : ICommand<Unit>
    {
        [FromRoute]
        public int id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? MainImage { get; set; }
    }
}
