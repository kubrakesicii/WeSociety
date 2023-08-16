using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.ReadingListArticle.Create;
using WeSociety.Application.CQRS.Queries.ReadingListArticle.GetAll;
using WeSociety.Application.CQRS.Queries.ReadingListArticle.GetIsSaved;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReadingListArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReadingListArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertReadingArticle([FromBody] CreateReadingListArticleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles([FromQuery, Required] int readingListId)
        {
            return Ok(await _mediator.Send(new GetAllArticlesByListQuery { ReadingListId = readingListId }));
        }

        [HttpGet("IsSaved")]
        public async Task<IActionResult> GetIsSaved([FromQuery, Required] int userProfileId, [FromQuery, Required] int articleId )
        {
            return Ok(await _mediator.Send(new GetArticleIsSavedQuery { UserProfileId = userProfileId, ArticleId=articleId }));
        }


    }
}
