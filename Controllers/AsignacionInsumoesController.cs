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
    public class AsignacionInsumoesController : ControllerBase
    {
        private readonly AcecsaContext _context;

        public AsignacionInsumoesController(AcecsaContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionInsumoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignacionInsumo>>> GetAsignacionInsumo()
        {
          if (_context.AsignacionInsumo == null)
          {
              return NotFound();
          }
            return await _context.AsignacionInsumo.ToListAsync();
        }

        // GET: api/AsignacionInsumoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionInsumo>> GetAsignacionInsumo(int id)
        {
          if (_context.AsignacionInsumo == null)
          {
              return NotFound();
          }
            var asignacionInsumo = await _context.AsignacionInsumo.FindAsync(id);

            if (asignacionInsumo == null)
            {
                return NotFound();
            }

            return asignacionInsumo;
        }

        // PUT: api/AsignacionInsumoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacionInsumo(int id, AsignacionInsumo asignacionInsumo)
        {
            if (id != asignacionInsumo.IdAsignacion)
            {
                return BadRequest();
            }

            _context.Entry(asignacionInsumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionInsumoExists(id))
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

        // POST: api/AsignacionInsumoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignacionInsumo>> PostAsignacionInsumo(AsignacionInsumo asignacionInsumo)
        {
          if (_context.AsignacionInsumo == null)
          {
              return Problem("Entity set 'AcecsaContext.AsignacionInsumo'  is null.");
          }
            _context.AsignacionInsumo.Add(asignacionInsumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignacionInsumo", new { id = asignacionInsumo.IdAsignacion }, asignacionInsumo);
        }

        // DELETE: api/AsignacionInsumoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacionInsumo(int id)
        {
            if (_context.AsignacionInsumo == null)
            {
                return NotFound();
            }
            var asignacionInsumo = await _context.AsignacionInsumo.FindAsync(id);
            if (asignacionInsumo == null)
            {
                return NotFound();
            }

            _context.AsignacionInsumo.Remove(asignacionInsumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionInsumoExists(int id)
        {
            return (_context.AsignacionInsumo?.Any(e => e.IdAsignacion == id)).GetValueOrDefault();
        }
    }
}
