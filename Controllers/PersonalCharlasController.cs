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
    public class PersonalCharlasController : ControllerBase
    {
        private readonly AcecsaContext _context;

        public PersonalCharlasController(AcecsaContext context)
        {
            _context = context;
        }

        // GET: api/PersonalCharlas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalCharla>>> GetPersonalCharla()
        {
          if (_context.PersonalCharla == null)
          {
              return NotFound();
          }
            return await _context.PersonalCharla.ToListAsync();
        }

        // GET: api/PersonalCharlas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalCharla>> GetPersonalCharla(int id)
        {
          if (_context.PersonalCharla == null)
          {
              return NotFound();
          }
            var personalCharla = await _context.PersonalCharla.FindAsync(id);

            if (personalCharla == null)
            {
                return NotFound();
            }

            return personalCharla;
        }

        // PUT: api/PersonalCharlas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalCharla(int id, PersonalCharla personalCharla)
        {
            if (id != personalCharla.IdPersonalCharla)
            {
                return BadRequest();
            }

            _context.Entry(personalCharla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalCharlaExists(id))
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

        // POST: api/PersonalCharlas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonalCharla>> PostPersonalCharla(PersonalCharla personalCharla)
        {
          if (_context.PersonalCharla == null)
          {
              return Problem("Entity set 'AcecsaContext.PersonalCharla'  is null.");
          }
            _context.PersonalCharla.Add(personalCharla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalCharla", new { id = personalCharla.IdPersonalCharla }, personalCharla);
        }

        // DELETE: api/PersonalCharlas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalCharla(int id)
        {
            if (_context.PersonalCharla == null)
            {
                return NotFound();
            }
            var personalCharla = await _context.PersonalCharla.FindAsync(id);
            if (personalCharla == null)
            {
                return NotFound();
            }

            _context.PersonalCharla.Remove(personalCharla);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalCharlaExists(int id)
        {
            return (_context.PersonalCharla?.Any(e => e.IdPersonalCharla == id)).GetValueOrDefault();
        }
    }
}
