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
    public class provinciasController : ControllerBase
    {
        private readonly MyDBContex _context;

        public provinciasController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/provincias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<provincia>>> Getprovincias()
        {
            return await _context.provincias.ToListAsync();
        }

        // GET: api/provincias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<provincia>> Getprovincia(int id)
        {
            var provincia = await _context.provincias.FindAsync(id);

            if (provincia == null)
            {
                return NotFound();
            }

            return provincia;
        }

        // PUT: api/provincias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putprovincia(int id, provincia provincia)
        {
            if (id != provincia.ProvinciaId)
            {
                return BadRequest();
            }

            _context.Entry(provincia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!provinciaExists(id))
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

        // POST: api/provincias
        [HttpPost]
        public async Task<ActionResult<provincia>> Postprovincia(provincia provincia)
        {
            _context.provincias.Add(provincia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getprovincia", new { id = provincia.ProvinciaId }, provincia);
        }

        // DELETE: api/provincias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<provincia>> Deleteprovincia(int id)
        {
            var provincia = await _context.provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }

            _context.provincias.Remove(provincia);
            await _context.SaveChangesAsync();

            return provincia;
        }

        private bool provinciaExists(int id)
        {
            return _context.provincias.Any(e => e.ProvinciaId == id);
        }
    }
}
