using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DateSoftware1_Api.Models;
using DateSoftware1_Api.Attributes;

namespace DateSoftware1_Api.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolsController : ControllerBase
    {
        private readonly DateSoftwareContext _context;

        public UserRolsController(DateSoftwareContext context)
        {
            _context = context;
        }

        // GET: api/UserRols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRol>>> GetUserRols()
        {
            return await _context.UserRols.ToListAsync();
        }

        // GET: api/UserRols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRol>> GetUserRol(int id)
        {
            var userRol = await _context.UserRols.FindAsync(id);

            if (userRol == null)
            {
                return NotFound();
            }

            return userRol;
        }

        // PUT: api/UserRols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRol(int id, UserRol userRol)
        {
            if (id != userRol.UserRoleId)
            {
                return BadRequest();
            }

            _context.Entry(userRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRolExists(id))
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

        // POST: api/UserRols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRol>> PostUserRol(UserRol userRol)
        {
            _context.UserRols.Add(userRol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRol", new { id = userRol.UserRoleId }, userRol);
        }

        // DELETE: api/UserRols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRol(int id)
        {
            var userRol = await _context.UserRols.FindAsync(id);
            if (userRol == null)
            {
                return NotFound();
            }

            _context.UserRols.Remove(userRol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRolExists(int id)
        {
            return _context.UserRols.Any(e => e.UserRoleId == id);
        }
    }
}
