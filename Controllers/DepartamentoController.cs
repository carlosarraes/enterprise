using enterprise.DTO;
using enterprise.Models;
using enterprise.Services;
using Microsoft.AspNetCore.Mvc;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService service;

        public DepartamentoController(IDepartamentoService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoDTO>> Get(int id)
        {
            var departamento = await service.GetDepartamentoByIdAsync(id);
            if (departamento == null)
                return NotFound("Departamento não encontrado");

            return departamento;
        }

        [HttpPost]
        public async Task<ActionResult<DepartamentoDTO>> Create(Departamento departamento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var departamentoDTO = await service.CreateDepartamentoAsync(departamento);

            return CreatedAtAction(
                nameof(Get),
                new { id = departamentoDTO?.DepartamentoId },
                departamentoDTO
            );
        }
    }
}
