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
    public class TypeDatesController : ControllerBase
    {
        private readonly DateSoftwareContext _context;

        public TypeDatesController(DateSoftwareContext context)
        {
            _context = context;
        }

        // GET: api/TypeDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDate>>> GetTypeDates()
        {
            return await _context.TypeDates.ToListAsync();
        }

        // GET: api/TypeDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeDate>> GetTypeDate(int id)
        {
            var typeDate = await _context.TypeDates.FindAsync(id);

            if (typeDate == null)
            {
                return NotFound();
            }

            return typeDate;
        }

        // PUT: api/TypeDates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeDate(int id, TypeDate typeDate)
        {
            if (id != typeDate.IdTypeDate)
            {
                return BadRequest();
            }

            _context.Entry(typeDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDateExists(id))
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

        // POST: api/TypeDates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeDate>> PostTypeDate(TypeDate typeDate)
        {
            _context.TypeDates.Add(typeDate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeDate", new { id = typeDate.IdTypeDate }, typeDate);
        }

        // DELETE: api/TypeDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeDate(int id)
        {
            var typeDate = await _context.TypeDates.FindAsync(id);
            if (typeDate == null)
            {
                return NotFound();
            }

            _context.TypeDates.Remove(typeDate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeDateExists(int id)
        {
            return _context.TypeDates.Any(e => e.IdTypeDate == id);
        }
    }
}
