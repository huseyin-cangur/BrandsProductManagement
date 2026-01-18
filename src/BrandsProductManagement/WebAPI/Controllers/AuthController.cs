
using System.Security.Claims;
using Application.Features.Login;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var firstName = User.FindFirstValue(ClaimTypes.GivenName);
            var lastName = User.FindFirstValue(ClaimTypes.Surname);

            var roles = User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            return Ok(new
            {
                userId = userId,
                email = email,
                fullName = $"{firstName} {lastName}",
                roles = roles
            });

        }
    }
}