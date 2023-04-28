using enterprise.DTO;
using enterprise.Models;
using enterprise.Services;
using Microsoft.AspNetCore.Mvc;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService service;

        public FuncionarioController(IFuncionarioService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioDTO>> Get(int id)
        {
            var funcionario = await service.GetFuncionarioByIdAsync(id);
            if (funcionario == null)
                return NotFound("Funcionário não encontrado");

            return funcionario;
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioDTO>> Post(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var funcionarioDTO = await service.CreateFuncionarioAsync(funcionario);

            return CreatedAtAction(
                nameof(Get),
                new { id = funcionarioDTO?.FuncionarioId },
                funcionarioDTO
            );
        }
    }
}
