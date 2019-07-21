using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paragonr.Application.Queries.Info;

namespace Paragonr.WebApi.Controllers
{
    public sealed class CurrenciesController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CurrencyResult>> Get(long id)
        {
            return Ok(await Mediator.Send(new CurrencyQuery(id)));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InfoResult>> List()
        {
            return Ok(await Mediator.Send(new InfoQuery()));
        }
    }

    public sealed class CategoriesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DomainsAndCategoriesResult>> List()
        {
            return Ok(await Mediator.Send(new DomainsAndCategoriesQuery()));
        }
    }
}