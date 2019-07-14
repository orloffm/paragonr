using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paragonr.Application.Currencies;
using Paragonr.Application.Queries.List;

namespace Paragonr.WebApi.Controllers
{
    public abstract class EntityBaseController<TViewModel> : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<ListResult<TViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new ListQuery<TViewModel>()));
        }
    }
}