using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Paragonr.WebApi.Controllers
{
    [AllowAnonymous]
    public sealed class PingController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<string>> Index()
        {
            return Ok("Default ping controller response.");
        }
    }
}