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

    public class CharlasController : ControllerBase
    {
        private readonly AcecsaContext _context;

        public CharlasController(AcecsaContext context)
        {
            _context = context;
        }

        // GET: api/Charlas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Charla>>> GetCharla()
        {
          if (_context.Charla == null)
          {
              return NotFound();
          }
            return await _context.Charla.ToListAsync();
        }

        // GET: api/Charlas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Charla>> GetCharla(int id)
        {
          if (_context.Charla == null)
          {
              return NotFound();
          }
            var charla = await _context.Charla.FindAsync(id);

            if (charla == null)
            {
                return NotFound();
            }

            return charla;
        }

        // PUT: api/Charlas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharla(int id, Charla charla)
        {
            if (id != charla.IdCharla)
            {
                return BadRequest();
            }

            _context.Entry(charla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharlaExists(id))
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

        // POST: api/Charlas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Charla>> PostCharla(Charla charla)
        {
          if (_context.Charla == null)
          {
              return Problem("Entity set 'AcecsaContext.Charla'  is null.");
          }
            _context.Charla.Add(charla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharla", new { id = charla.IdCharla }, charla);
        }

        // DELETE: api/Charlas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharla(int id)
        {
            if (_context.Charla == null)
            {
                return NotFound();
            }
            var charla = await _context.Charla.FindAsync(id);
            if (charla == null)
            {
                return NotFound();
            }

            _context.Charla.Remove(charla);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharlaExists(int id)
        {
            return (_context.Charla?.Any(e => e.IdCharla == id)).GetValueOrDefault();
        }
    }
}
