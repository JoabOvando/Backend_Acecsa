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
    public class RecursoesController : ControllerBase
    {
        private readonly AcecsaContext _context;

        public RecursoesController(AcecsaContext context)
        {
            _context = context;
        }

        // GET: api/Recursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recurso>>> GetRecurso()
        {
          if (_context.Recurso == null)
          {
              return NotFound();
          }
            return await _context.Recurso.ToListAsync();
        }

        // GET: api/Recursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recurso>> GetRecurso(int id)
        {
          if (_context.Recurso == null)
          {
              return NotFound();
          }
            var recurso = await _context.Recurso.FindAsync(id);

            if (recurso == null)
            {
                return NotFound();
            }

            return recurso;
        }

        // PUT: api/Recursoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurso(int id, Recurso recurso)
        {
            if (id != recurso.ID_Recurso)
            {
                return BadRequest();
            }

            _context.Entry(recurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(id))
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

        // POST: api/Recursoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recurso>> PostRecurso(Recurso recurso)
        {
          if (_context.Recurso == null)
          {
              return Problem("Entity set 'AcecsaContext.Recurso'  is null.");
          }
            _context.Recurso.Add(recurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecurso", new { id = recurso.ID_Recurso }, recurso);
        }

        // DELETE: api/Recursoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecurso(int id)
        {
            if (_context.Recurso == null)
            {
                return NotFound();
            }
            var recurso = await _context.Recurso.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }

            _context.Recurso.Remove(recurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecursoExists(int id)
        {
            return (_context.Recurso?.Any(e => e.ID_Recurso == id)).GetValueOrDefault();
        }
    }
}
