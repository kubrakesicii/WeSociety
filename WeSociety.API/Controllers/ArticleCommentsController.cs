using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.ArticleComment.Create;
using WeSociety.Application.CQRS.Queries.ArticleComment.GetAllByArticle;
using WeSociety.Application.DTO.ArticleClap;
using WeSociety.Application.DTO.ArticleComment;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleCommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Insert([FromBody] CreateArticleCommentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(List<GetArticleCommentDto>))]
        public async Task<IActionResult> GetAll([FromQuery, Required] int articleId)
        {
            return Ok(await _mediator.Send(new GetAllArticleCommentsByArticleQuery { ArticleId = articleId }));
        }
    }
}
