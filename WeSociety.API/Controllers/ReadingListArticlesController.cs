using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.ReadingListArticle.Create;
using WeSociety.Application.CQRS.Commands.ReadingListArticle.Delete;
using WeSociety.Application.CQRS.Queries.ReadingListArticle.GetAll;
using WeSociety.Application.CQRS.Queries.ReadingListArticle.GetIsSaved;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.DTO.FollowRelationship;
using WeSociety.Application.DTO.ReadingListArticle;
using WeSociety.Domain.Pagination;

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
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> InsertReadingArticle([FromBody] CreateReadingListArticleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(PaginatedList<GetArticleDto>))]
        public async Task<IActionResult> GetArticles([FromQuery, Required] int readingListId)
        {
            return Ok(await _mediator.Send(new GetAllArticlesByListQuery { ReadingListId = readingListId }));
        }

        [HttpGet("IsSaved")]
        [SwaggerResponse(200, Type = typeof(GetIsSavedArticleDto))]
        public async Task<IActionResult> GetIsSaved([FromQuery, Required] int userProfileId, [FromQuery, Required] int articleId )
        {
            return Ok(await _mediator.Send(new GetArticleIsSavedQuery { UserProfileId = userProfileId, ArticleId=articleId }));
        }


        [HttpDelete("{id}")]
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> DeleteReadingArticle([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteReadingListArticleCommand { Id=id}));
        }

    }
}
