using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.Article.Create;
using WeSociety.Application.CQRS.Commands.Article.Delete;
using WeSociety.Application.CQRS.Queries.Article.GetAll;
using WeSociety.Application.CQRS.Queries.Article.GetAllByProfile;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateArticleCommand createArticleCommand)
        {
            return Ok(await _mediator.Send(createArticleCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string searchKey)
        {
            return Ok(await _mediator.Send(new GetAllArticlesQuery() {SearchKey=searchKey }));
        }

        [HttpGet("ByUser")]
        public async Task<IActionResult> GetAllByUser([FromQuery,Required] int userProfileId)
        {
            return Ok(await _mediator.Send(new GetAllArticlesByProfileQuery {ProfileId=userProfileId }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteArticleCommand() { Id=id }));
        }
    }
}
