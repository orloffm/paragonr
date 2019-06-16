using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paragonr.Entities;
using Paragonr.Persistence;

namespace Paragonr.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpendingsController : ControllerBase
    {
        private readonly BudgetDbContext _context;

        public SpendingsController(BudgetDbContext context)
        {
            _context = context;
        }

        // GET: api/Spendings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spending>>> GetSpendings()
        {
            return await _context.Spendings.ToListAsync();
        }

        // GET: api/Spendings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spending>> GetSpending(long id)
        {
            var spending = await _context.Spendings.FindAsync(id);

            if (spending == null)
            {
                return NotFound();
            }

            return spending;
        }

        // PUT: api/Spendings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpending(long id, Spending spending)
        {
            if (id != spending.Id)
            {
                return BadRequest();
            }

            _context.Entry(spending).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpendingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Spendings
        [HttpPost]
        public async Task<ActionResult<Spending>> PostSpending(Spending spending)
        {
            _context.Spendings.Add(spending);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpending", new { id = spending.Id }, spending);
        }

        // DELETE: api/Spendings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spending>> DeleteSpending(long id)
        {
            var spending = await _context.Spendings.FindAsync(id);
            if (spending == null)
            {
                return NotFound();
            }

            _context.Spendings.Remove(spending);
            await _context.SaveChangesAsync();

            return spending;
        }

        private bool SpendingExists(long id)
        {
            return _context.Spendings.Any(e => e.Id == id);
        }
    }
}
