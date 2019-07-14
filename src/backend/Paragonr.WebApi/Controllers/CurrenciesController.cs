using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paragonr.Application.Currencies.Queries.GetCurrenciesList;

namespace Paragonr.WebApi.Controllers
{
    public sealed class CurrenciesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CurrenciesListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCurrenciesListQuery()));
        }
    }
}