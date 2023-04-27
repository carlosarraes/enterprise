using enterprise.Data;
using enterprise.Models;
using Microsoft.AspNetCore.Mvc;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly EnterpriseDbContext _context;

        public TarefaController(EnterpriseDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> Get(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
                return NotFound();

            return tarefa;
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> Post(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = tarefa.TarefaId }, tarefa);
        }
    }
}
