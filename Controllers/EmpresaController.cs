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
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaDTO>> Get(int id)
        {
            var empresa = await _empresaService.GetEmpresaByIdAsync(id);

            if (empresa == null)
                return NotFound();

            return empresa;
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaDTO>> Create(Empresa empresa)
        {
            var empresaDTO = await _empresaService.CreateEmpresaAsync(empresa);
            if (empresaDTO == null)
                return BadRequest("Empresa já cadastrada.");

            return CreatedAtAction(nameof(Get), new { id = empresaDTO.Id }, empresaDTO);
        }
    }
}
