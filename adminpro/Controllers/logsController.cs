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
    public class logsController : ControllerBase
    {
        private readonly MyDBContex _context;

        public logsController(MyDBContex context)
        {
            _context = context;
        }

        // GET: api/logs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<log>>> Getlogs()
        {
            return await _context.logs.ToListAsync();
        }

        // GET: api/logs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<log>> Getlog(int id)
        {
            var log = await _context.logs.FindAsync(id);

            if (log == null)
            {
                return NotFound();
            }

            return log;
        }

        // PUT: api/logs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlog(int id, log log)
        {
            if (id != log.LogId)
            {
                return BadRequest();
            }

            _context.Entry(log).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!logExists(id))
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

        // POST: api/logs
        [HttpPost]
        public async Task<ActionResult<log>> Postlog(log log)
        {
            _context.logs.Add(log);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlog", new { id = log.LogId }, log);
        }

        // DELETE: api/logs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<log>> Deletelog(int id)
        {
            var log = await _context.logs.FindAsync(id);
            if (log == null)
            {
                return NotFound();
            }

            _context.logs.Remove(log);
            await _context.SaveChangesAsync();

            return log;
        }

        private bool logExists(int id)
        {
            return _context.logs.Any(e => e.LogId == id);
        }
    }
}
