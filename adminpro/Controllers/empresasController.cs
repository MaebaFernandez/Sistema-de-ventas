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
    public class empresasController : ControllerBase
    {
        private readonly MyDBContex _context;

        public empresasController(MyDBContex contexto)
        {
            _context = contexto;
        }

        //peticion tipo GET: api/empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<empresa>>> GetEmpresaItems()
        {
            return await _context.empresas.ToListAsync();
        }
        
    }
}