using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.ArticleComment.Create;
using WeSociety.Application.CQRS.Queries.ArticleComment.GetAllByArticle;
using WeSociety.Application.DTO.ArticleComment;
using WeSociety.Application.Responses;

namespace WeSociety.API.Controllers
{
    public class ArticleCommentsController : WeSocietyController
    {
        public ArticleCommentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Insert([FromBody] CreateArticleCommentCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return ProduceResponse();
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<List<GetArticleCommentDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<List<GetArticleCommentDto>>> GetAll([FromQuery, Required] int articleId, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new GetAllArticleCommentsByArticleQuery { ArticleId = articleId }, cancellationToken);
            return ProduceResponse(res);
        }
    }
}
