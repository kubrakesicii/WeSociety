using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using WeSociety.Application.CQRS.Commands.Article.Create;
using WeSociety.Application.CQRS.Commands.Article.Delete;
using WeSociety.Application.CQRS.Commands.Article.Update;
using WeSociety.Application.CQRS.Queries.Article.GetAll;
using WeSociety.Application.CQRS.Queries.Article.GetAllByProfile;
using WeSociety.Domain.AggregateRoots.Users;

namespace WeSociety.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;

        public ArticlesController(IMediator mediator, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateArticleCommand createArticleCommand)
        {

            return Ok(await _mediator.Send(createArticleCommand));
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            var curUser = await _userManager.GetUserAsync(HttpContext.User);
            var name = User.Identity.Name;
            var auth = HttpContext.User.Identity.IsAuthenticated;
            var email = HttpContext.User.FindFirstValue("email");

            //return Ok(await _mediator.Send(new GetAllArticlesQuery() {SearchKey="" }));
            return Ok(new {email=email});
        }

        [HttpGet("ByUser")]
        public async Task<IActionResult> GetAllByUser([FromQuery,Required] int userProfileId)
        {
            return Ok(await _mediator.Send(new GetAllArticlesByProfileQuery {ProfileId=userProfileId }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateArticleCommand updateArticleCommand)
        {
            return Ok(await _mediator.Send(updateArticleCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteArticleCommand() { Id=id }));
        }
    }
}
