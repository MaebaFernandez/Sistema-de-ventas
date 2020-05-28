using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using adminpro.Models;

namespace adminpro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sucursalesController : ControllerBase
    {
        private readonly MyDBContex _context;

        public sucursalesController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/sucursales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<sucursal>>> Getsucursales()
        {
            return await _context.sucursales.ToListAsync();
        }

        // GET: api/sucursales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<sucursal>> Getsucursal(int id)
        {
            var sucursal = await _context.sucursales.FindAsync(id);

            if (sucursal == null)
            {
                return NotFound();
            }

            return sucursal;
        }

        // PUT: api/sucursales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsucursal(int id, sucursal sucursal)
        {
            if (id != sucursal.SucursalId)
            {
                return BadRequest();
            }

            _context.Entry(sucursal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sucursalExists(id))
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

        // POST: api/sucursales
        [HttpPost]
        public async Task<ActionResult<sucursal>> Postsucursal(sucursal sucursal)
        {
            _context.sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsucursal", new { id = sucursal.SucursalId }, sucursal);
        }

        // DELETE: api/sucursales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<sucursal>> Deletesucursal(int id)
        {
            var sucursal = await _context.sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _context.sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();

            return sucursal;
        }

        private bool sucursalExists(int id)
        {
            return _context.sucursales.Any(e => e.SucursalId == id);
        }
    }
}
