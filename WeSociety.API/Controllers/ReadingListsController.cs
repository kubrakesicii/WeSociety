using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.ReadingList.Create;
using WeSociety.Application.CQRS.Queries.ReadingList.GetAllByUser;
using WeSociety.Application.DTO.ReadingList;
using WeSociety.Core.Responses;

namespace WeSociety.API.Controllers
{
    public class ReadingListsController : WeSocietyController
    {
        public ReadingListsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        //[Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<Response> Insert([FromBody] CreateReadingListCommand command,CancellationToken cancellationToken)
        {
            await _mediator.Send(command,cancellationToken);
            return ProduceResponse();
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<List<GetReadingListDto>>), StatusCodes.Status200OK)]
        public async Task<DataResponse<List<GetReadingListDto>>> GetAll([FromQuery, Required] int userProfileId, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new GetAllReadingListsByUserQuery { UserProfileId = userProfileId }, cancellationToken);
            return ProduceResponse(res);
        }
    }
}
