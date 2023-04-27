using enterprise.Data;
using enterprise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly EnterpriseDbContext _context;

        public EmpresaController(EnterpriseDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> Get(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
                return NotFound();

            return empresa;
        }

        [HttpPost]
        public async Task<ActionResult<Empresa>> Create(Empresa empresa)
        {
            var exist = await _context.Empresas.FirstOrDefaultAsync(x => x.Cnpj == empresa.Cnpj);
            if (exist != null)
                return BadRequest("Empresa já cadastrada");

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = empresa.Id }, empresa);
        }
    }
}
