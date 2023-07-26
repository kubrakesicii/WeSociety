using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeSociety.Application.Exceptions;

namespace WeSociety.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            throw new LoginException();
        }
    }
}
