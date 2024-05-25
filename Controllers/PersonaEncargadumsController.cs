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
    public class PersonaEncargadumsController : ControllerBase
    {
        private readonly AcecsaContext _context;

        public PersonaEncargadumsController(AcecsaContext context)
        {
            _context = context;
        }

        // GET: api/PersonaEncargadums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaEncargadum>>> GetPersona_Encargada()
        {
          if (_context.Persona_Encargada == null)
          {
              return NotFound();
          }
            return await _context.Persona_Encargada.ToListAsync();
        }

        // GET: api/PersonaEncargadums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaEncargadum>> GetPersonaEncargadum(int id)
        {
          if (_context.Persona_Encargada == null)
          {
              return NotFound();
          }
            var personaEncargadum = await _context.Persona_Encargada.FindAsync(id);

            if (personaEncargadum == null)
            {
                return NotFound();
            }

            return personaEncargadum;
        }

        // PUT: api/PersonaEncargadums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaEncargadum(int id, PersonaEncargadum personaEncargadum)
        {
            if (id != personaEncargadum.ID_Encargado)
            {
                return BadRequest();
            }

            _context.Entry(personaEncargadum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaEncargadumExists(id))
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

        // POST: api/PersonaEncargadums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonaEncargadum>> PostPersonaEncargadum(PersonaEncargadum personaEncargadum)
        {
          if (_context.Persona_Encargada == null)
          {
              return Problem("Entity set 'AcecsaContext.Persona_Encargada'  is null.");
          }
            _context.Persona_Encargada.Add(personaEncargadum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonaEncargadum", new { id = personaEncargadum.ID_Encargado }, personaEncargadum);
        }

        // DELETE: api/PersonaEncargadums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaEncargadum(int id)
        {
            if (_context.Persona_Encargada == null)
            {
                return NotFound();
            }
            var personaEncargadum = await _context.Persona_Encargada.FindAsync(id);
            if (personaEncargadum == null)
            {
                return NotFound();
            }

            _context.Persona_Encargada.Remove(personaEncargadum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaEncargadumExists(int id)
        {
            return (_context.Persona_Encargada?.Any(e => e.ID_Encargado == id)).GetValueOrDefault();
        }
    }
}
