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
    public class reservasController : ControllerBase
    {
        private readonly MyDBContex _context;

        public reservasController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<reserva>>> Getreservas()
        {
            return await _context.reservas.ToListAsync();
        }

        // GET: api/reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<reserva>> Getreserva(int id)
        {
            var reserva = await _context.reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        // PUT: api/reservas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreserva(int id, reserva reserva)
        {
            if (id != reserva.ReservaId)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reservaExists(id))
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

        // POST: api/reservas
        [HttpPost]
        public async Task<ActionResult<reserva>> Postreserva(reserva reserva)
        {
            _context.reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreserva", new { id = reserva.ReservaId }, reserva);
        }

        // DELETE: api/reservas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<reserva>> Deletereserva(int id)
        {
            var reserva = await _context.reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        private bool reservaExists(int id)
        {
            return _context.reservas.Any(e => e.ReservaId == id);
        }
    }
}
