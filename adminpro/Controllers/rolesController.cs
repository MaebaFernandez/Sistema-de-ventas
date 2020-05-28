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
    public class rolesController : ControllerBase
    {
        private readonly MyDBContex _context;

        public rolesController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/rols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<rol>>> Getroles()
        {
            return await _context.roles.ToListAsync();
        }

        // GET: api/rols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<rol>> Getrol(int id)
        {
            var rol = await _context.roles.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }

        // PUT: api/rols/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrol(int id, rol rol)
        {
            if (id != rol.RolId)
            {
                return BadRequest();
            }

            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rolExists(id))
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

        // POST: api/rols
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<rol>> Postrol(rol rol)
        {
            _context.roles.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrol", new { id = rol.RolId }, rol);
        }

        // DELETE: api/rols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<rol>> Deleterol(int id)
        {
            var rol = await _context.roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            _context.roles.Remove(rol);
            await _context.SaveChangesAsync();

            return rol;
        }

        private bool rolExists(int id)
        {
            return _context.roles.Any(e => e.RolId == id);
        }
    }
}
