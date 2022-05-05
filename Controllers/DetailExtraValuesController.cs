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
    public class DetailExtraValuesController : ControllerBase
    {
        private readonly DateSoftwareContext _context;

        public DetailExtraValuesController(DateSoftwareContext context)
        {
            _context = context;
        }

        // GET: api/DetailExtraValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailExtraValue>>> GetDetailExtraValues()
        {
            return await _context.DetailExtraValues.ToListAsync();
        }

        // GET: api/DetailExtraValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailExtraValue>> GetDetailExtraValue(int id)
        {
            var detailExtraValue = await _context.DetailExtraValues.FindAsync(id);

            if (detailExtraValue == null)
            {
                return NotFound();
            }

            return detailExtraValue;
        }

        // PUT: api/DetailExtraValues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailExtraValue(int id, DetailExtraValue detailExtraValue)
        {
            if (id != detailExtraValue.IdDetailExtraValue)
            {
                return BadRequest();
            }

            _context.Entry(detailExtraValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExtraValueExists(id))
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

        // POST: api/DetailExtraValues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetailExtraValue>> PostDetailExtraValue(DetailExtraValue detailExtraValue)
        {
            _context.DetailExtraValues.Add(detailExtraValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailExtraValue", new { id = detailExtraValue.IdDetailExtraValue }, detailExtraValue);
        }

        // DELETE: api/DetailExtraValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailExtraValue(int id)
        {
            var detailExtraValue = await _context.DetailExtraValues.FindAsync(id);
            if (detailExtraValue == null)
            {
                return NotFound();
            }

            _context.DetailExtraValues.Remove(detailExtraValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailExtraValueExists(int id)
        {
            return _context.DetailExtraValues.Any(e => e.IdDetailExtraValue == id);
        }
    }
}
