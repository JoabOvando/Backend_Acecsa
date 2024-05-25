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
    public class AsignacionRecursoesController : ControllerBase
    {
        private readonly AcecsaContext _context;

        public AsignacionRecursoesController(AcecsaContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionRecursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignacionRecurso>>> GetAsignacionRecurso()
        {
          if (_context.AsignacionRecurso == null)
          {
              return NotFound();
          }
            return await _context.AsignacionRecurso.ToListAsync();
        }

        // GET: api/AsignacionRecursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionRecurso>> GetAsignacionRecurso(int id)
        {
          if (_context.AsignacionRecurso == null)
          {
              return NotFound();
          }
            var asignacionRecurso = await _context.AsignacionRecurso.FindAsync(id);

            if (asignacionRecurso == null)
            {
                return NotFound();
            }

            return asignacionRecurso;
        }

        // PUT: api/AsignacionRecursoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacionRecurso(int id, AsignacionRecurso asignacionRecurso)
        {
            if (id != asignacionRecurso.IdAsignacion)
            {
                return BadRequest();
            }

            _context.Entry(asignacionRecurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionRecursoExists(id))
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

        // POST: api/AsignacionRecursoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignacionRecurso>> PostAsignacionRecurso(AsignacionRecurso asignacionRecurso)
        {
          if (_context.AsignacionRecurso == null)
          {
              return Problem("Entity set 'AcecsaContext.AsignacionRecurso'  is null.");
          }
            _context.AsignacionRecurso.Add(asignacionRecurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignacionRecurso", new { id = asignacionRecurso.IdAsignacion }, asignacionRecurso);
        }

        // DELETE: api/AsignacionRecursoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacionRecurso(int id)
        {
            if (_context.AsignacionRecurso == null)
            {
                return NotFound();
            }
            var asignacionRecurso = await _context.AsignacionRecurso.FindAsync(id);
            if (asignacionRecurso == null)
            {
                return NotFound();
            }

            _context.AsignacionRecurso.Remove(asignacionRecurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionRecursoExists(int id)
        {
            return (_context.AsignacionRecurso?.Any(e => e.IdAsignacion == id)).GetValueOrDefault();
        }
    }
}
