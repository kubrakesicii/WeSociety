using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WeSociety.Application.CQRS.Commands.Article.Create;
using WeSociety.Application.CQRS.Commands.Article.Delete;
using WeSociety.Application.CQRS.Commands.Article.Update;
using WeSociety.Application.CQRS.Queries.Article.GetAll;
using WeSociety.Application.CQRS.Queries.Article.GetAllByProfile;
using WeSociety.Application.CQRS.Queries.Article.GetAllDrafts;
using WeSociety.Application.CQRS.Queries.Article.GetAllPopulars;
using WeSociety.Application.CQRS.Queries.Article.GetById;
using WeSociety.Application.DTO.Article;
using WeSociety.Domain.Pagination;

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
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Insert([FromForm] CreateArticleCommand createArticleCommand)
        {
            return Ok(await _mediator.Send(createArticleCommand));
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(PaginatedList<GetArticleDto>))]
        public async Task<IActionResult> GetAll([FromQuery] string? searchKey, [FromQuery] int categoryId, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllArticlesQuery() {SearchKey=searchKey, CategoryId=categoryId, PageIndex=pageIndex,PageSize=pageSize}));
        }

        [HttpGet("Popular")]
        [SwaggerResponse(200, Type = typeof(List<GetArticleDto>))]
        public async Task<IActionResult> GetAllPopulars([FromQuery] int categoryId)
        {
            return Ok(await _mediator.Send(new GetAllPopularArticlesQuery() { CategoryId = categoryId }));
        }

        [HttpGet("Drafts")]
        [SwaggerResponse(200, Type = typeof(PaginatedList<GetArticleDto>))]
        public async Task<IActionResult> GetAllDrafts([FromQuery, Required] int userProfileId,[FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllArticleDraftsByUserQuery() { UserProfileId=userProfileId,PageIndex = pageIndex,PageSize=pageSize }));
        }


        [HttpGet("{id}")]
        [SwaggerResponse(200, Type = typeof(GetArticleDto))]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetArticleByIdQuery() { Id=id }));
        }

        [HttpGet("ByUser")]
        [SwaggerResponse(200, Type = typeof(PaginatedList<GetArticleDto>))]
        public async Task<IActionResult> GetAllByUser([FromQuery,Required] int userProfileId, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllArticlesByProfileQuery {UserProfileId=userProfileId, PageIndex = pageIndex, PageSize = pageSize }));
        }

        
        [HttpPut("{id}")]
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Update([FromForm] UpdateArticleCommand updateArticleCommand)
        {
            return Ok(await _mediator.Send(updateArticleCommand));
        }

        [HttpDelete("{id}")]
        [Authorize]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteArticleCommand() { Id=id }));
        }
    }
}
