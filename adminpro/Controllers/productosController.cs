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
    public class productosController : ControllerBase
    {
        private readonly MyDBContex _context;

        public productosController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<producto>>> Getproductos()
        {
            return await _context.productos.ToListAsync();
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<producto>> Getproducto(int id)
        {
            var producto = await _context.productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproducto(int id, producto producto)
        {
            if (id != producto.ProductoId)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productoExists(id))
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

        // POST: api/productos
        [HttpPost]
        public async Task<ActionResult<producto>> Postproducto(producto producto)
        {
            _context.productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproducto", new { id = producto.ProductoId }, producto);
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<producto>> Deleteproducto(int id)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.productos.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        private bool productoExists(int id)
        {
            return _context.productos.Any(e => e.ProductoId == id);
        }
    }
}
