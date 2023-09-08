using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.ArticleClap.Create;
using WeSociety.Application.CQRS.Queries.ArticleClap.GetAllByArticle;
using WeSociety.Application.DTO.ArticleClap;
using WeSociety.Application.Responses;

namespace WeSociety.API.Controllers
{
    public class ArticleClapsController : WeSocietyController
    {
        public ArticleClapsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Insert([FromBody] CreateArticleClapCommand command)
        {
            await _mediator.Send(command);
            return ProduceResponse();
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<List<GetClapUserDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<List<GetClapUserDto>>> GetAllByArticle([FromQuery, Required] int articleId)
        {
            var res = await _mediator.Send(new GetAllClappingUsersQuery { ArticleId = articleId });
            return ProduceResponse(res);
        }
    }
}
