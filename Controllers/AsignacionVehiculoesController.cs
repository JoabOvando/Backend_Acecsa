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
    public class AsignacionVehiculoesController : ControllerBase
    {
        private readonly AcecsaContext _context;

        public AsignacionVehiculoesController(AcecsaContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionVehiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignacionVehiculo>>> GetAsignacionVehiculo()
        {
          if (_context.AsignacionVehiculo == null)
          {
              return NotFound();
          }
            return await _context.AsignacionVehiculo.ToListAsync();
        }

        // GET: api/AsignacionVehiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionVehiculo>> GetAsignacionVehiculo(int id)
        {
          if (_context.AsignacionVehiculo == null)
          {
              return NotFound();
          }
            var asignacionVehiculo = await _context.AsignacionVehiculo.FindAsync(id);

            if (asignacionVehiculo == null)
            {
                return NotFound();
            }

            return asignacionVehiculo;
        }

        // PUT: api/AsignacionVehiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacionVehiculo(int id, AsignacionVehiculo asignacionVehiculo)
        {
            if (id != asignacionVehiculo.IdAsignacion)
            {
                return BadRequest();
            }

            _context.Entry(asignacionVehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionVehiculoExists(id))
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

        // POST: api/AsignacionVehiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignacionVehiculo>> PostAsignacionVehiculo(AsignacionVehiculo asignacionVehiculo)
        {
          if (_context.AsignacionVehiculo == null)
          {
              return Problem("Entity set 'AcecsaContext.AsignacionVehiculo'  is null.");
          }
            _context.AsignacionVehiculo.Add(asignacionVehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignacionVehiculo", new { id = asignacionVehiculo.IdAsignacion }, asignacionVehiculo);
        }

        // DELETE: api/AsignacionVehiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacionVehiculo(int id)
        {
            if (_context.AsignacionVehiculo == null)
            {
                return NotFound();
            }
            var asignacionVehiculo = await _context.AsignacionVehiculo.FindAsync(id);
            if (asignacionVehiculo == null)
            {
                return NotFound();
            }

            _context.AsignacionVehiculo.Remove(asignacionVehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionVehiculoExists(int id)
        {
            return (_context.AsignacionVehiculo?.Any(e => e.IdAsignacion == id)).GetValueOrDefault();
        }
    }
}
