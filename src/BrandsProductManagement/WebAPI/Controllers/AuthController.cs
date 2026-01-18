
using Application.Features.Login;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AuthController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            LoginCommandResponse response = await mediator.Send(command);
            return Ok(response);
        }
    }
}