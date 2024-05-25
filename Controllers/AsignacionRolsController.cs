using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiACECSA.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiACECSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AsignacionRolsController : ControllerBase
    {
        private readonly AcecsaContext _context;

        public AsignacionRolsController(AcecsaContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionRols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignacionRol>>> GetAsignacionRol()
        {
          if (_context.AsignacionRol == null)
          {
              return NotFound();
          }
            return await _context.AsignacionRol.ToListAsync();
        }

        // GET: api/AsignacionRols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionRol>> GetAsignacionRol(int id)
        {
          if (_context.AsignacionRol == null)
          {
              return NotFound();
          }
            var asignacionRol = await _context.AsignacionRol.FindAsync(id);

            if (asignacionRol == null)
            {
                return NotFound();
            }

            return asignacionRol;
        }

        // PUT: api/AsignacionRols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacionRol(int id, AsignacionRol asignacionRol)
        {
            if (id != asignacionRol.IdAsignacion)
            {
                return BadRequest();
            }

            _context.Entry(asignacionRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionRolExists(id))
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

        // POST: api/AsignacionRols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignacionRol>> PostAsignacionRol(AsignacionRol asignacionRol)
        {
          if (_context.AsignacionRol == null)
          {
              return Problem("Entity set 'AcecsaContext.AsignacionRol'  is null.");
          }
            _context.AsignacionRol.Add(asignacionRol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignacionRol", new { id = asignacionRol.IdAsignacion }, asignacionRol);
        }

        // DELETE: api/AsignacionRols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacionRol(int id)
        {
            if (_context.AsignacionRol == null)
            {
                return NotFound();
            }
            var asignacionRol = await _context.AsignacionRol.FindAsync(id);
            if (asignacionRol == null)
            {
                return NotFound();
            }

            _context.AsignacionRol.Remove(asignacionRol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionRolExists(int id)
        {
            return (_context.AsignacionRol?.Any(e => e.IdAsignacion == id)).GetValueOrDefault();
        }
    }
}
