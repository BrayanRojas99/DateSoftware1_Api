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
    public class AilmentsController : ControllerBase
    {
        private readonly DateSoftwareContext _context;

        public AilmentsController(DateSoftwareContext context)
        {
            _context = context;
        }

        // GET: api/Ailments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ailment>>> GetAilments()
        {
            return await _context.Ailments.ToListAsync();
        }

        // GET: api/Ailments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ailment>> GetAilment(int id)
        {
            var ailment = await _context.Ailments.FindAsync(id);

            if (ailment == null)
            {
                return NotFound();
            }

            return ailment;
        }

        // PUT: api/Ailments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAilment(int id, Ailment ailment)
        {
            if (id != ailment.IdAilment)
            {
                return BadRequest();
            }

            _context.Entry(ailment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AilmentExists(id))
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

        // POST: api/Ailments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ailment>> PostAilment(Ailment ailment)
        {
            _context.Ailments.Add(ailment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAilment", new { id = ailment.IdAilment }, ailment);
        }

        // DELETE: api/Ailments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAilment(int id)
        {
            var ailment = await _context.Ailments.FindAsync(id);
            if (ailment == null)
            {
                return NotFound();
            }

            _context.Ailments.Remove(ailment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AilmentExists(int id)
        {
            return _context.Ailments.Any(e => e.IdAilment == id);
        }
    }
}
