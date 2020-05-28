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
    public class departamentosController : ControllerBase
    {
        private readonly MyDBContex _context;

        public departamentosController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/departamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<departamento>>> Getdepartamentos()
        {
            return await _context.departamentos.ToListAsync();
        }

        // GET: api/departamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<departamento>> Getdepartamento(int id)
        {
            var departamento = await _context.departamentos.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return departamento;
        }

        // PUT: api/departamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdepartamento(int id, departamento departamento)
        {
            if (id != departamento.DepartamentoId)
            {
                return BadRequest();
            }

            _context.Entry(departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!departamentoExists(id))
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

        // POST: api/departamentos.
        [HttpPost]
        public async Task<ActionResult<departamento>> Postdepartamento(departamento departamento)
        {
            _context.departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdepartamento", new { id = departamento.DepartamentoId }, departamento);
        }

        // DELETE: api/departamentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<departamento>> Deletedepartamento(int id)
        {
            var departamento = await _context.departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.departamentos.Remove(departamento);
            await _context.SaveChangesAsync();

            return departamento;
        }

        private bool departamentoExists(int id)
        {
            return _context.departamentos.Any(e => e.DepartamentoId == id);
        }
    }
}
