using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.ReadingList.Create;
using WeSociety.Application.CQRS.Queries.ReadingList.GetAllByUser;
using WeSociety.Application.DTO.ReadingList;
using WeSociety.Application.Responses;

namespace WeSociety.API.Controllers
{
    public class ReadingListsController : WeSocietyController
    {
        public ReadingListsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Insert([FromBody] CreateReadingListCommand command)
        {
            await _mediator.Send(command);
            return ProduceResponse();
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<List<GetReadingListDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<List<GetReadingListDto>>> GetAll([FromQuery, Required] int userProfileId)
        {
            var res = await _mediator.Send(new GetAllReadingListsByUserQuery { UserProfileId = userProfileId });
            return ProduceResponse(res);
        }
    }
}
