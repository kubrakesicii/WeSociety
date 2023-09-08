using Azure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeSociety.Application.Responses;

namespace WeSociety.API.Base
{
    [Route("[controller]")]
    [ApiController]
    public abstract class WeSocietyController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public WeSocietyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected DataResponse<T> ProduceResponse<T>(T data)
        {
            return new DataResponse<T>(data,true);
        }
        protected Application.Responses.Response ProduceResponse()
        {
            return new Application.Responses.Response(true);
        }
    }
}
