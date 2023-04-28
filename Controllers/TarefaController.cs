using enterprise.DTO;
using enterprise.Models;
using enterprise.Services;
using Microsoft.AspNetCore.Mvc;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService service;

        public TarefaController(ITarefaService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaDTO>> Get(int id)
        {
            var tarefa = await service.GetTarefaByIdAsync(id);
            if (tarefa == null)
                return NotFound("Tarefa não encontrada");

            return tarefa;
        }

        [HttpPost]
        public async Task<ActionResult<TarefaDTO>> Post(Tarefa tarefa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tarefaDTO = await service.CreateTarefaAsync(tarefa);

            return CreatedAtAction(nameof(Get), new { id = tarefaDTO.TarefaId }, tarefaDTO);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TarefaDTO?>> Patch(int id)
        {
            var tarefa = await service.DoneAsync(id);
            if (tarefa == null)
                return NotFound("Tarefa não encontrada");

            return tarefa;
        }
    }
}
