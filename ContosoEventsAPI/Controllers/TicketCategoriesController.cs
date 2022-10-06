using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoEventsAPI.Data;
using ContosoEventsAPI.Models;

namespace ContosoEventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCategoriesController : ControllerBase
    {
        private readonly ContosoEventsDBContext _context;

        public TicketCategoriesController(ContosoEventsDBContext context)
        {
            _context = context;
        }

        // GET: api/TicketCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketCategory>>> GetTicketCategories()
        {
            return await _context.TicketCategories.ToListAsync();
        }

        // GET: api/TicketCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketCategory>> GetTicketCategory(int id)
        {
            var ticketCategory = await _context.TicketCategories.FindAsync(id);

            if (ticketCategory == null)
            {
                return NotFound();
            }

            return ticketCategory;
        }

        // PUT: api/TicketCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketCategory(int id, TicketCategory ticketCategory)
        {
            if (id != ticketCategory.TicketCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(ticketCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketCategoryExists(id))
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

        // POST: api/TicketCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketCategory>> PostTicketCategory(TicketCategory ticketCategory)
        {
            _context.TicketCategories.Add(ticketCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketCategory", new { id = ticketCategory.TicketCategoryId }, ticketCategory);
        }

        // DELETE: api/TicketCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketCategory(int id)
        {
            var ticketCategory = await _context.TicketCategories.FindAsync(id);
            if (ticketCategory == null)
            {
                return NotFound();
            }

            _context.TicketCategories.Remove(ticketCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketCategoryExists(int id)
        {
            return _context.TicketCategories.Any(e => e.TicketCategoryId == id);
        }
    }
}
