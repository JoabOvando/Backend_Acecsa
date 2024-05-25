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
    public class InsumoesController : ControllerBase
    {
        private readonly AcecsaContext _context;

        public InsumoesController(AcecsaContext context)
        {
            _context = context;
        }

        // GET: api/Insumoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insumo>>> GetInsumo()
        {
          if (_context.Insumo == null)
          {
              return NotFound();
          }
            return await _context.Insumo.ToListAsync();
        }

        // GET: api/Insumoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insumo>> GetInsumo(int id)
        {
          if (_context.Insumo == null)
          {
              return NotFound();
          }
            var insumo = await _context.Insumo.FindAsync(id);

            if (insumo == null)
            {
                return NotFound();
            }

            return insumo;
        }

        // PUT: api/Insumoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsumo(int id, Insumo insumo)
        {
            if (id != insumo.IdInsumo)
            {
                return BadRequest();
            }

            _context.Entry(insumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsumoExists(id))
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

        // POST: api/Insumoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insumo>> PostInsumo(Insumo insumo)
        {
          if (_context.Insumo == null)
          {
              return Problem("Entity set 'AcecsaContext.Insumo'  is null.");
          }
            _context.Insumo.Add(insumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsumo", new { id = insumo.IdInsumo }, insumo);
        }

        // DELETE: api/Insumoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsumo(int id)
        {
            if (_context.Insumo == null)
            {
                return NotFound();
            }
            var insumo = await _context.Insumo.FindAsync(id);
            if (insumo == null)
            {
                return NotFound();
            }

            _context.Insumo.Remove(insumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsumoExists(int id)
        {
            return (_context.Insumo?.Any(e => e.IdInsumo == id)).GetValueOrDefault();
        }
    }
}
