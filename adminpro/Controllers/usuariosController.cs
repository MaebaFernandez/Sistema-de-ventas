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
    public class usuariosController : ControllerBase
    {
        private readonly MyDBContex _context;

        public usuariosController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<usuario>>> Getusuarios()
        {
            return await _context.usuarios.ToListAsync();
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<usuario>> Getusuario(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putusuario(int id, usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuarioExists(id))
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

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<usuario>> Postusuario(usuario usuario)
        {
            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getusuario", new { id = usuario.UsuarioId }, usuario);
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<usuario>> Deleteusuario(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool usuarioExists(int id)
        {
            return _context.usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
