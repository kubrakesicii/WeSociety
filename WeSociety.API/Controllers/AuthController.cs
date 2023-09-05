using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WeSociety.Application.CQRS.Commands.Auth.Login;
using WeSociety.Application.CQRS.Commands.Auth.Register;
using WeSociety.Application.DTO.ArticleComment;
using WeSociety.Application.DTO.User;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        [SwaggerResponse(200, null)]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            return Ok(await _mediator.Send(registerCommand));
        }

        [HttpPost("Login")]
        [SwaggerResponse(200, Type = typeof(GetLoginUserDto))]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            return Ok(await _mediator.Send(loginCommand));
        }
    }
}
