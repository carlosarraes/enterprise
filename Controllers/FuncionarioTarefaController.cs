using enterprise.DTO;
using enterprise.Services;
using Microsoft.AspNetCore.Mvc;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioTarefaController : ControllerBase
    {
        private readonly IFuncionarioTarefaService service;

        public FuncionarioTarefaController(IFuncionarioTarefaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioTarefaDTO>>> GetFuncionarioTarefa()
        {
            var funcionarioTarefa = await service.GetAllAsync();

            return Ok(funcionarioTarefa);
        }
    }
}
