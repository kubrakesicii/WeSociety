using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Queries.Category.GetAll;
using WeSociety.Application.DTO.Article;
using WeSociety.Application.DTO.Category;
using WeSociety.Core.Responses;

namespace WeSociety.API.Controllers
{
    public class CategoriesController : WeSocietyController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<List<GetArticleDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<List<GetCategoryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new GetAllCategoriesQuery(),cancellationToken);
            return ProduceResponse(res);
        }
    }
}
