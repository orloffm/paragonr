using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paragonr.Application.Spendings.Commands.CreateSpending;
using Paragonr.Application.Spendings.Commands.DeleteSpending;
using Paragonr.Application.Spendings.Commands.UpdateSpending;
using Paragonr.Application.Spendings.Queries.GetSpendingDetail;
using Paragonr.Application.Spendings.Queries.GetSpendingsList;

namespace Paragonr.WebApi.Controllers
{
    [Authorize]
    public class SpendingController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SpendingsListVM>> GetAll()
        {
            return Ok(await Mediator.Send(new GetSpendingsListQuery()));
        }

        [HttpGet("{refKey}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SpendingDetailVm>> Get([FromHeader] Guid refKey)
        {
            
            
            return Ok(await Mediator.Send(new GetSpendingDetailQuery { RefKey = refKey }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateSpendingCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{refKey}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateSpendingCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{refKey}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromHeader] Guid refKey)
        {
            await Mediator.Send(new DeleteSpendingCommand { RefKey = refKey });

            return NoContent();
        }
    }
}
