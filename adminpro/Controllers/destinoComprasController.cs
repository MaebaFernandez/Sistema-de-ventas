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
    public class destinoComprasController : ControllerBase
    {
        private readonly MyDBContex _context;

        public destinoComprasController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/destinoCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<destinoCompra>>> GetdestinoCompras()
        {
            return await _context.destinoCompras.ToListAsync();
        }

        // GET: api/destinoCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<destinoCompra>> GetdestinoCompra(int id)
        {
            var destinoCompra = await _context.destinoCompras.FindAsync(id);

            if (destinoCompra == null)
            {
                return NotFound();
            }

            return destinoCompra;
        }

        // PUT: api/destinoCompras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdestinoCompra(int id, destinoCompra destinoCompra)
        {
            if (id != destinoCompra.DestinoCompraId)
            {
                return BadRequest();
            }

            _context.Entry(destinoCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!destinoCompraExists(id))
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

        // POST: api/destinoCompras
        [HttpPost]
        public async Task<ActionResult<destinoCompra>> PostdestinoCompra(destinoCompra destinoCompra)
        {
            _context.destinoCompras.Add(destinoCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdestinoCompra", new { id = destinoCompra.DestinoCompraId }, destinoCompra);
        }

        // DELETE: api/destinoCompras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<destinoCompra>> DeletedestinoCompra(int id)
        {
            var destinoCompra = await _context.destinoCompras.FindAsync(id);
            if (destinoCompra == null)
            {
                return NotFound();
            }

            _context.destinoCompras.Remove(destinoCompra);
            await _context.SaveChangesAsync();

            return destinoCompra;
        }

        private bool destinoCompraExists(int id)
        {
            return _context.destinoCompras.Any(e => e.DestinoCompraId == id);
        }
    }
}
