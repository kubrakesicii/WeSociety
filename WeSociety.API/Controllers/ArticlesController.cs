using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.Article.Create;
using WeSociety.Application.CQRS.Commands.Article.Delete;
using WeSociety.Application.CQRS.Commands.Article.Update;
using WeSociety.Application.CQRS.Queries.Article.GetAll;
using WeSociety.Application.CQRS.Queries.Article.GetAllByProfile;
using WeSociety.Application.CQRS.Queries.Article.GetAllDrafts;
using WeSociety.Application.CQRS.Queries.Article.GetAllPopulars;
using WeSociety.Application.CQRS.Queries.Article.GetById;
using WeSociety.Application.CQRS.Queries.Search.SearchELK;
using WeSociety.Domain.Aggregates.UserRoot;

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
        [Authorize]
        public async Task<IActionResult> Insert([FromForm] CreateArticleCommand createArticleCommand)
        {
            return Ok(await _mediator.Send(createArticleCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? searchKey, [FromQuery] int categoryId, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllArticlesQuery() {SearchKey=searchKey, CategoryId=categoryId, PageIndex=pageIndex,PageSize=pageSize}));
        }

        [HttpGet("Popular")]
        public async Task<IActionResult> GetAllPopulars([FromQuery] int categoryId)
        {
            return Ok(await _mediator.Send(new GetAllPopularArticlesQuery() { CategoryId = categoryId }));
        }

        [HttpGet("Drafts")]
        public async Task<IActionResult> GetAllDrafts([FromQuery, Required] int userProfileId,[FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllArticleDraftsByUserQuery() { UserProfileId=userProfileId,PageIndex = pageIndex,PageSize=pageSize }));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetArticleByIdQuery() { Id=id }));
        }

        [HttpGet("ByUser")]
        public async Task<IActionResult> GetAllByUser([FromQuery,Required] int userProfileId, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllArticlesByProfileQuery {UserProfileId=userProfileId, PageIndex = pageIndex, PageSize = pageSize }));
        }

        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromForm] UpdateArticleCommand updateArticleCommand)
        {
            return Ok(await _mediator.Send(updateArticleCommand));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteArticleCommand() { Id=id }));
        }
    }
}
