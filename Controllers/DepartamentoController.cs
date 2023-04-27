using enterprise.Data;
using enterprise.Models;
using Microsoft.AspNetCore.Mvc;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly EnterpriseDbContext _context;

        public DepartamentoController(EnterpriseDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> Get(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
                return NotFound();

            return departamento;
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> Create(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = departamento.DepartamentoId },
                departamento
            );
        }
    }
}
