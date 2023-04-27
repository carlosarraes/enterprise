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

        [HttpPost("{tarefaId}/{funcionarioId}")]
        public async Task<ActionResult<FuncionarioTarefa>> Post(int tarefaId, int funcionarioId)
        {
            var tarefa = await _context.Tarefas.FindAsync(tarefaId);
            if (tarefa == null)
                return NotFound();

            var funcionario = await _context.Funcionarios.FindAsync(funcionarioId);
            if (funcionario == null)
                return NotFound();

            var funcionarioTarefa = new FuncionarioTarefa
            {
                FuncionarioId = funcionarioId,
                TarefaId = tarefaId
            };

            _context.FuncionarioTarefas.Add(funcionarioTarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = tarefa.TarefaId }, funcionarioTarefa);
        }
    }
}
