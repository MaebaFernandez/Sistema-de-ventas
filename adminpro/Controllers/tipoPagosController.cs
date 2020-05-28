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
    public class tipoPagosController : ControllerBase
    {
        private readonly MyDBContex _context;

        public tipoPagosController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/tipoPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tipoPago>>> GettipoPagos()
        {
            return await _context.tipoPagos.ToListAsync();
        }

        // GET: api/tipoPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tipoPago>> GettipoPago(int id)
        {
            var tipoPago = await _context.tipoPagos.FindAsync(id);

            if (tipoPago == null)
            {
                return NotFound();
            }

            return tipoPago;
        }

        // PUT: api/tipoPagos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttipoPago(int id, tipoPago tipoPago)
        {
            if (id != tipoPago.TipoPagoId)
            {
                return BadRequest();
            }

            _context.Entry(tipoPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipoPagoExists(id))
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

        // POST: api/tipoPagos
        [HttpPost]
        public async Task<ActionResult<tipoPago>> PosttipoPago(tipoPago tipoPago)
        {
            _context.tipoPagos.Add(tipoPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettipoPago", new { id = tipoPago.TipoPagoId }, tipoPago);
        }

        // DELETE: api/tipoPagos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tipoPago>> DeletetipoPago(int id)
        {
            var tipoPago = await _context.tipoPagos.FindAsync(id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            _context.tipoPagos.Remove(tipoPago);
            await _context.SaveChangesAsync();

            return tipoPago;
        }

        private bool tipoPagoExists(int id)
        {
            return _context.tipoPagos.Any(e => e.TipoPagoId == id);
        }
    }
}
