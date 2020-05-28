using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Paragonr.WebApi.Controllers
{
    /// <summary>
    /// This is a special controller providing a simple response at /ping.
    /// </summary>
    [AllowAnonymous]
    [Route("ping")]
    public sealed class PingController : BaseController
    {
        [HttpGet]
        [Route("")]
        public ActionResult<string> Index()
        {
            return Ok("Ping!");
        }
    }
}
