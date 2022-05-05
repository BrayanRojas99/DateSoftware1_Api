using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DateSoftware1_Api.Models;

namespace DateSoftware1_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailAilmentsController : ControllerBase
    {
        private readonly DateSoftwareContext _context;

        public DetailAilmentsController(DateSoftwareContext context)
        {
            _context = context;
        }

        // GET: api/DetailAilments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailAilment>>> GetDetailAilments()
        {
            return await _context.DetailAilments.ToListAsync();
        }

        // GET: api/DetailAilments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailAilment>> GetDetailAilment(int id)
        {
            var detailAilment = await _context.DetailAilments.FindAsync(id);

            if (detailAilment == null)
            {
                return NotFound();
            }

            return detailAilment;
        }

        // PUT: api/DetailAilments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailAilment(int id, DetailAilment detailAilment)
        {
            if (id != detailAilment.IdDetailAilment)
            {
                return BadRequest();
            }

            _context.Entry(detailAilment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailAilmentExists(id))
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

        // POST: api/DetailAilments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetailAilment>> PostDetailAilment(DetailAilment detailAilment)
        {
            _context.DetailAilments.Add(detailAilment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailAilment", new { id = detailAilment.IdDetailAilment }, detailAilment);
        }

        // DELETE: api/DetailAilments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailAilment(int id)
        {
            var detailAilment = await _context.DetailAilments.FindAsync(id);
            if (detailAilment == null)
            {
                return NotFound();
            }

            _context.DetailAilments.Remove(detailAilment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailAilmentExists(int id)
        {
            return _context.DetailAilments.Any(e => e.IdDetailAilment == id);
        }
    }
}
