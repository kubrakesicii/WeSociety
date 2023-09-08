using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.ReadingListArticle.Create;
using WeSociety.Application.CQRS.Commands.ReadingListArticle.Delete;
using WeSociety.Application.CQRS.Queries.ReadingListArticle.GetAll;
using WeSociety.Application.CQRS.Queries.ReadingListArticle.GetIsSaved;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.DTO.ReadingListArticle;
using WeSociety.Application.Responses;

namespace WeSociety.API.Controllers
{
    public class ReadingListArticlesController : WeSocietyController
    {
        public ReadingListArticlesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> InsertReadingArticle([FromBody] CreateReadingListArticleCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return ProduceResponse();
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<List<GetArticleDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<List<GetArticleDto>>> GetArticles([FromQuery, Required] int readingListId, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new GetAllArticlesByListQuery { ReadingListId = readingListId }, cancellationToken);
            return ProduceResponse(res);
        }

        [HttpGet("IsSaved")]
        [ProducesResponseType(typeof(DataResponse<GetIsSavedArticleDto>), StatusCodes.Status200OK)]
        public async Task<DataResponse<GetIsSavedArticleDto>> GetIsSaved([FromQuery, Required] int userProfileId, [FromQuery, Required] int articleId, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new GetArticleIsSavedQuery { UserProfileId = userProfileId, ArticleId = articleId },cancellationToken);
            return ProduceResponse(res);
        }


        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> DeleteReadingArticle([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteReadingListArticleCommand { Id = id },cancellationToken);
            return ProduceResponse();
        }

    }
}
