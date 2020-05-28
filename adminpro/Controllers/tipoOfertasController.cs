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
    public class tipoOfertasController : ControllerBase
    {
        private readonly MyDBContex _context;

        public tipoOfertasController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/tipoOfertas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tipoOferta>>> GettipoOfertas()
        {
            return await _context.tipoOfertas.ToListAsync();
        }

        // GET: api/tipoOfertas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tipoOferta>> GettipoOferta(int id)
        {
            var tipoOferta = await _context.tipoOfertas.FindAsync(id);

            if (tipoOferta == null)
            {
                return NotFound();
            }

            return tipoOferta;
        }

        // PUT: api/tipoOfertas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttipoOferta(int id, tipoOferta tipoOferta)
        {
            if (id != tipoOferta.TipoOfertaId)
            {
                return BadRequest();
            }

            _context.Entry(tipoOferta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipoOfertaExists(id))
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

        // POST: api/tipoOfertas
        [HttpPost]
        public async Task<ActionResult<tipoOferta>> PosttipoOferta(tipoOferta tipoOferta)
        {
            _context.tipoOfertas.Add(tipoOferta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettipoOferta", new { id = tipoOferta.TipoOfertaId }, tipoOferta);
        }

        // DELETE: api/tipoOfertas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tipoOferta>> DeletetipoOferta(int id)
        {
            var tipoOferta = await _context.tipoOfertas.FindAsync(id);
            if (tipoOferta == null)
            {
                return NotFound();
            }

            _context.tipoOfertas.Remove(tipoOferta);
            await _context.SaveChangesAsync();

            return tipoOferta;
        }

        private bool tipoOfertaExists(int id)
        {
            return _context.tipoOfertas.Any(e => e.TipoOfertaId == id);
        }
    }
}
