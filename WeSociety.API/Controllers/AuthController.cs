using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeSociety.API.Base;
using WeSociety.Application.CQRS.Commands.Auth.Login;
using WeSociety.Application.CQRS.Commands.Auth.Register;
using WeSociety.Application.DTO.User;
using WeSociety.Core.Responses;

namespace WeSociety.API.Controllers
{
    public class AuthController : WeSocietyController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(DataResponse<GetUserDto>), StatusCodes.Status200OK)]
        public async Task<DataResponse<GetUserDto>> Register([FromBody] RegisterCommand registerCommand, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(registerCommand,cancellationToken);
            return ProduceResponse(res);
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(DataResponse<GetLoginUserDto>), StatusCodes.Status200OK)]
        public async Task<DataResponse<GetLoginUserDto>> Login([FromBody] LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(loginCommand, cancellationToken);
            return ProduceResponse(res);
        }
    }
}
