using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paragonr.Application.Auth.Commands.Login;

namespace Paragonr.WebApi.Controllers
{
    [Authorize]
    public sealed class AuthController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LoginCommandResult>> Login([FromBody] LoginCommand command)
        {
            LoginCommandResult loginResponse = await Mediator.Send(command);

            if (loginResponse == null)
            {
                return this.Unauthorized();
            }

            return Ok(loginResponse);
        }
    }
}
