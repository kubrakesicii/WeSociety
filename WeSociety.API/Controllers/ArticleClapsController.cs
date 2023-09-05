using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.ArticleClap.Create;
using WeSociety.Application.CQRS.Queries.ArticleClap.GetAllByArticle;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.DTO.ArticleClap;

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
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Insert([FromBody] CreateArticleClapCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(List<GetClapUserDto>))]
        public async Task<IActionResult> GetAllByArticle([FromQuery, Required] int articleId)
        {
            return Ok(await _mediator.Send(new GetAllClappingUsersQuery { ArticleId=articleId}));
        }
    }
}
