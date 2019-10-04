using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Paragonr.WebApi.Controllers
{
    [AllowAnonymous]
    public sealed class PingController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Index()
        {
            return Ok();
        }
    }
}
