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
    public class ExtraValuesController : ControllerBase
    {
        private readonly DateSoftwareContext _context;

        public ExtraValuesController(DateSoftwareContext context)
        {
            _context = context;
        }

        // GET: api/ExtraValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExtraValue>>> GetExtraValues()
        {
            return await _context.ExtraValues.ToListAsync();
        }

        // GET: api/ExtraValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExtraValue>> GetExtraValue(int id)
        {
            var extraValue = await _context.ExtraValues.FindAsync(id);

            if (extraValue == null)
            {
                return NotFound();
            }

            return extraValue;
        }

        // PUT: api/ExtraValues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtraValue(int id, ExtraValue extraValue)
        {
            if (id != extraValue.IdExtraValue)
            {
                return BadRequest();
            }

            _context.Entry(extraValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraValueExists(id))
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

        // POST: api/ExtraValues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExtraValue>> PostExtraValue(ExtraValue extraValue)
        {
            _context.ExtraValues.Add(extraValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtraValue", new { id = extraValue.IdExtraValue }, extraValue);
        }

        // DELETE: api/ExtraValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExtraValue(int id)
        {
            var extraValue = await _context.ExtraValues.FindAsync(id);
            if (extraValue == null)
            {
                return NotFound();
            }

            _context.ExtraValues.Remove(extraValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExtraValueExists(int id)
        {
            return _context.ExtraValues.Any(e => e.IdExtraValue == id);
        }
    }
}
