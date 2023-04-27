using enterprise.Data;
using enterprise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioTarefaController : ControllerBase
    {
        private readonly EnterpriseDbContext _context;

        public FuncionarioTarefaController(EnterpriseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioTarefa>>> GetFuncionarioTarefa()
        {
            return await _context.FuncionarioTarefas
                .Include(f => f.Funcionario)
                .Include(t => t.Tarefa)
                .ToListAsync();
        }
    }
}
