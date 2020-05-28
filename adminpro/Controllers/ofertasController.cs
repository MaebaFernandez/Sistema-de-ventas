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
    public class ofertasController : ControllerBase
    {
        private readonly MyDBContex _context;

        public ofertasController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/ofertas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<oferta>>> Getofertas()
        {
            return await _context.ofertas.ToListAsync();
        }

        // GET: api/ofertas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<oferta>> Getoferta(int id)
        {
            var oferta = await _context.ofertas.FindAsync(id);

            if (oferta == null)
            {
                return NotFound();
            }

            return oferta;
        }

        // PUT: api/ofertas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putoferta(int id, oferta oferta)
        {
            if (id != oferta.OfertaId)
            {
                return BadRequest();
            }

            _context.Entry(oferta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ofertaExists(id))
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

        // POST: api/ofertas
        [HttpPost]
        public async Task<ActionResult<oferta>> Postoferta(oferta oferta)
        {
            _context.ofertas.Add(oferta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getoferta", new { id = oferta.OfertaId }, oferta);
        }

        // DELETE: api/ofertas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<oferta>> Deleteoferta(int id)
        {
            var oferta = await _context.ofertas.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }

            _context.ofertas.Remove(oferta);
            await _context.SaveChangesAsync();

            return oferta;
        }

        private bool ofertaExists(int id)
        {
            return _context.ofertas.Any(e => e.OfertaId == id);
        }
    }
}
