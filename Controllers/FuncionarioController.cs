using enterprise.Data;
using enterprise.Models;
using Microsoft.AspNetCore.Mvc;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly EnterpriseDbContext _context;

        public FuncionarioController(EnterpriseDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> Get(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
                return NotFound();

            return funcionario;
        }

        [HttpPost]
        public async Task<ActionResult<Funcionario>> Post(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = funcionario.FuncionarioId },
                funcionario
            );
        }
    }
}
