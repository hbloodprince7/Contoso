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
    public class EventsDetailsController : ControllerBase
    {
        private readonly ContosoEventsDBContext _context;

        public EventsDetailsController(ContosoEventsDBContext context)
        {
            _context = context;
        }

        // GET: api/EventsDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventsDetail>>> GetEventsDetails()
        {
            return await _context.EventsDetails.ToListAsync();
        }

        // GET: api/EventsDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventsDetail>> GetEventsDetail(int id)
        {
            var eventsDetail = await _context.EventsDetails.FindAsync(id);

            if (eventsDetail == null)
            {
                return NotFound();
            }

            return eventsDetail;
        }

        // PUT: api/EventsDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventsDetail(int id, EventsDetail eventsDetail)
        {
            if (id != eventsDetail.EventId)
            {
                return BadRequest();
            }

            _context.Entry(eventsDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsDetailExists(id))
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

        // POST: api/EventsDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventsDetail>> PostEventsDetail(EventsDetail eventsDetail)
        {
            _context.EventsDetails.Add(eventsDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventsDetail", new { id = eventsDetail.EventId }, eventsDetail);
        }

        // DELETE: api/EventsDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventsDetail(int id)
        {
            var eventsDetail = await _context.EventsDetails.FindAsync(id);
            if (eventsDetail == null)
            {
                return NotFound();
            }

            _context.EventsDetails.Remove(eventsDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventsDetailExists(int id)
        {
            return _context.EventsDetails.Any(e => e.EventId == id);
        }
    }
}
