using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeSociety.Core.Responses;

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
            return new DataResponse<T>(data,true,"OK");
        }
        protected Response ProduceResponse()
        {
            return new Response(true,"OK");
        }
    }
}
