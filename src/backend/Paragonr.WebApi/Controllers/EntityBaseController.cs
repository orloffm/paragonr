using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paragonr.Application.Queries.List;

namespace Paragonr.WebApi.Controllers
{
    public abstract class EntityBaseController<TListItemVm, TDetailedVm> : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<DetailResult<TDetailedVm>>> Get(long id)
        {
            return Ok(await Mediator.Send(new DetailQuery<TDetailedVm>(id)));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<ListResult<TListItemVm>>> List()
        {
            return Ok(await Mediator.Send(new ListQuery<TListItemVm>()));
        }
    }
}