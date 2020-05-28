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
    public class estadoComprasController : ControllerBase
    {
        private readonly MyDBContex _context;

        public estadoComprasController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/estadoCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<estadoCompra>>> GetestadoCompras()
        {
            return await _context.estadoCompras.ToListAsync();
        }

        // GET: api/estadoCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<estadoCompra>> GetestadoCompra(int id)
        {
            var estadoCompra = await _context.estadoCompras.FindAsync(id);

            if (estadoCompra == null)
            {
                return NotFound();
            }

            return estadoCompra;
        }

        // PUT: api/estadoCompras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutestadoCompra(int id, estadoCompra estadoCompra)
        {
            if (id != estadoCompra.EstadoCompraId)
            {
                return BadRequest();
            }

            _context.Entry(estadoCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!estadoCompraExists(id))
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

        // POST: api/estadoCompras
        [HttpPost]
        public async Task<ActionResult<estadoCompra>> PostestadoCompra(estadoCompra estadoCompra)
        {
            _context.estadoCompras.Add(estadoCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetestadoCompra", new { id = estadoCompra.EstadoCompraId }, estadoCompra);
        }

        // DELETE: api/estadoCompras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<estadoCompra>> DeleteestadoCompra(int id)
        {
            var estadoCompra = await _context.estadoCompras.FindAsync(id);
            if (estadoCompra == null)
            {
                return NotFound();
            }

            _context.estadoCompras.Remove(estadoCompra);
            await _context.SaveChangesAsync();

            return estadoCompra;
        }

        private bool estadoCompraExists(int id)
        {
            return _context.estadoCompras.Any(e => e.EstadoCompraId == id);
        }
    }
}
