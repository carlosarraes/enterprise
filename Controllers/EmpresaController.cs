using enterprise.DTO;
using enterprise.Models;
using enterprise.Services;
using Microsoft.AspNetCore.Mvc;

namespace enterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService service;

        public EmpresaController(IEmpresaService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaDTO>> Get(int id)
        {
            var empresa = await service.GetEmpresaByIdAsync(id);
            if (empresa == null)
                return NotFound("Empresa não encontrada.");

            return empresa;
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaDTO>> Create(Empresa empresa)
        {

            var empresaDTO = await service.CreateEmpresaAsync(empresa);
            if (empresaDTO == null)
                return BadRequest("Empresa já cadastrada.");

            return CreatedAtAction(nameof(Get), new { id = empresaDTO.Id }, empresaDTO);
        }
    }
}
