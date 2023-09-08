using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.Article.Create;
using WeSociety.Application.CQRS.Commands.Article.Delete;
using WeSociety.Application.CQRS.Commands.Article.Update;
using WeSociety.Application.CQRS.Queries.Article.GetAll;
using WeSociety.Application.CQRS.Queries.Article.GetAllByProfile;
using WeSociety.Application.CQRS.Queries.Article.GetAllDrafts;
using WeSociety.Application.CQRS.Queries.Article.GetAllPopulars;
using WeSociety.Application.CQRS.Queries.Article.GetById;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.Responses;
using WeSociety.Domain.Pagination;

namespace WeSociety.API.Controllers
{
    public class ArticlesController : WeSocietyController
    {
        public ArticlesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Insert([FromForm] CreateArticleCommand createArticleCommand, CancellationToken cancellationToken)
        {
            await _mediator.Send(createArticleCommand,cancellationToken);
            return ProduceResponse();
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<PaginatedList<GetArticleDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<PaginatedList<GetArticleDto>>> GetAll([FromQuery] string? searchKey, 
            [FromQuery] int categoryId, 
            [FromQuery] int pageIndex, 
            [FromQuery] int pageSize, 
            CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new GetAllArticlesQuery() { SearchKey = searchKey, CategoryId = categoryId, PageIndex = pageIndex, PageSize = pageSize }, cancellationToken);
            return ProduceResponse(res);
        }

        [HttpGet("Popular")]
        [ProducesResponseType(typeof(DataResponse<List<GetArticleDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<List<GetArticleDto>>> GetAllPopulars([FromQuery] int categoryId)
        {
            var res = await _mediator.Send(new GetAllPopularArticlesQuery() { CategoryId = categoryId });
            return ProduceResponse(res);
        }

        [HttpGet("Drafts")]
        [ProducesResponseType(typeof(DataResponse<List<GetArticleDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<PaginatedList<GetArticleDto>>> GetAllDrafts([FromQuery, Required] int userProfileId,[FromQuery] int pageIndex, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new GetAllArticleDraftsByUserQuery() { UserProfileId = userProfileId, PageIndex = pageIndex, PageSize = pageSize }, cancellationToken);
            return ProduceResponse(res);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DataResponse<GetArticleDto>), StatusCodes.Status200OK)]
        public async Task<DataResponse<GetArticleDto>> Get([FromRoute] int id)
        {
            var res = await _mediator.Send(new GetArticleByIdQuery() { Id = id });
            return ProduceResponse(res);
        }

        [HttpGet("ByUser")]
        [ProducesResponseType(typeof(DataResponse<PaginatedList<GetArticleDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<PaginatedList<GetArticleDto>>> GetAllByUser([FromQuery,Required] int userProfileId, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            var res = await _mediator.Send(new GetAllArticlesByProfileQuery { UserProfileId = userProfileId, PageIndex = pageIndex, PageSize = pageSize });
            return ProduceResponse(res);
        }

        
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Update([FromForm] UpdateArticleCommand updateArticleCommand, CancellationToken cancellationToken)
        {
            await _mediator.Send(updateArticleCommand, cancellationToken);
            return ProduceResponse();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteArticleCommand() { Id = id }, cancellationToken);
            return ProduceResponse();
        }
    }
}
