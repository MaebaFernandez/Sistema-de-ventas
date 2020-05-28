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
    public class facturacionesController : ControllerBase
    {
        private readonly MyDBContex _context;

        public facturacionesController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/facturaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<facturacion>>> Getfacturaciones()
        {
            return await _context.facturaciones.ToListAsync();
        }

        // GET: api/facturaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<facturacion>> Getfacturacion(int id)
        {
            var facturacion = await _context.facturaciones.FindAsync(id);

            if (facturacion == null)
            {
                return NotFound();
            }

            return facturacion;
        }

        // PUT: api/facturaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfacturacion(int id, facturacion facturacion)
        {
            if (id != facturacion.FacturacionId)
            {
                return BadRequest();
            }

            _context.Entry(facturacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!facturacionExists(id))
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

        // POST: api/facturaciones
        [HttpPost]
        public async Task<ActionResult<facturacion>> Postfacturacion(facturacion facturacion)
        {
            _context.facturaciones.Add(facturacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfacturacion", new { id = facturacion.FacturacionId }, facturacion);
        }

        // DELETE: api/facturaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<facturacion>> Deletefacturacion(int id)
        {
            var facturacion = await _context.facturaciones.FindAsync(id);
            if (facturacion == null)
            {
                return NotFound();
            }

            _context.facturaciones.Remove(facturacion);
            await _context.SaveChangesAsync();

            return facturacion;
        }

        private bool facturacionExists(int id)
        {
            return _context.facturaciones.Any(e => e.FacturacionId == id);
        }
    }
}
