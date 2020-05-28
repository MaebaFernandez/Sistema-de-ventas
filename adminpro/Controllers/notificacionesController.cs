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
    public class notificacionesController : ControllerBase
    {
        private readonly MyDBContex _context;

        public notificacionesController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/notificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<notificacion>>> Getnotificaciones()
        {
            return await _context.notificaciones.ToListAsync();
        }

        // GET: api/notificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<notificacion>> Getnotificacion(int id)
        {
            var notificacion = await _context.notificaciones.FindAsync(id);

            if (notificacion == null)
            {
                return NotFound();
            }

            return notificacion;
        }

        // PUT: api/notificaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnotificacion(int id, notificacion notificacion)
        {
            if (id != notificacion.NotificacionId)
            {
                return BadRequest();
            }

            _context.Entry(notificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!notificacionExists(id))
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

        // POST: api/notificaciones
        [HttpPost]
        public async Task<ActionResult<notificacion>> Postnotificacion(notificacion notificacion)
        {
            _context.notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnotificacion", new { id = notificacion.NotificacionId }, notificacion);
        }

        // DELETE: api/notificaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<notificacion>> Deletenotificacion(int id)
        {
            var notificacion = await _context.notificaciones.FindAsync(id);
            if (notificacion == null)
            {
                return NotFound();
            }

            _context.notificaciones.Remove(notificacion);
            await _context.SaveChangesAsync();

            return notificacion;
        }

        private bool notificacionExists(int id)
        {
            return _context.notificaciones.Any(e => e.NotificacionId == id);
        }
    }
}
