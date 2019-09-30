using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paragonr.Application.Info.Queries;

namespace Paragonr.WebApi.Controllers
{
    [Authorize]
    public sealed class InfoController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InfoResult>> Generic()
        {
            return Ok(await Mediator.Send(new InfoQuery()));
        }
    }
}
