using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.ArticleClap.Create;
using WeSociety.Application.CQRS.Queries.ArticleClap.GetAllByArticle;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleClapsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleClapsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateArticleClapCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByArticle([FromQuery, Required] int articleId)
        {
            return Ok(await _mediator.Send(new GetAllClappingUsersQuery { ArticleId=articleId}));
        }
    }
}
