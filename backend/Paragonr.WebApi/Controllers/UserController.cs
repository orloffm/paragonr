using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paragonr.Application.Users.Commands.ChangePassword;

namespace Paragonr.WebApi.Controllers
{
    [Authorize]
    public sealed class UserController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<ChangePasswordResult>> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok();
        }
    }
}
