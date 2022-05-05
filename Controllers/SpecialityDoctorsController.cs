using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DateSoftware1_Api.Models;
using DateSoftware1_Api.Attributes;
using DateSoftware1_Api.Tools;

namespace DateSoftware1_Api.Controllers
{

    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityDoctorsController : ControllerBase
    {
        private readonly DateSoftwareContext _context;

        public SpecialityDoctorsController(DateSoftwareContext context)
        {
            _context = context;
        }

        // GET: api/SpecialityDoctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialityDoctor>>> GetSpecialityDoctors()
        {
            return await _context.SpecialityDoctors.ToListAsync();
        }

        // GET: api/SpecialityDoctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialityDoctor>> GetSpecialityDoctor(int id)
        {
            var specialityDoctor = await _context.SpecialityDoctors.FindAsync(id);

            if (specialityDoctor == null)
            {
                return NotFound();
            }

            return specialityDoctor;
        }

        // PUT: api/SpecialityDoctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialityDoctor(int id, SpecialityDoctor specialityDoctor)
        {
            if (id != specialityDoctor.IdSpecialityDoctor)
            {
                return BadRequest();
            }

            _context.Entry(specialityDoctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialityDoctorExists(id))
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

        // POST: api/SpecialityDoctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpecialityDoctor>> PostSpecialityDoctor(SpecialityDoctor specialityDoctor)
        {
            _context.SpecialityDoctors.Add(specialityDoctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialityDoctor", new { id = specialityDoctor.IdSpecialityDoctor }, specialityDoctor);
        }

        // DELETE: api/SpecialityDoctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialityDoctor(int id)
        {
            var specialityDoctor = await _context.SpecialityDoctors.FindAsync(id);
            if (specialityDoctor == null)
            {
                return NotFound();
            }

            _context.SpecialityDoctors.Remove(specialityDoctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialityDoctorExists(int id)
        {
            return _context.SpecialityDoctors.Any(e => e.IdSpecialityDoctor == id);
        }
    }
}
