using enterprise.Data;
using enterprise.DTO;
using enterprise.Models;
using Microsoft.EntityFrameworkCore;

namespace enterprise.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly EnterpriseDbContext ctx;

        public DepartamentoService(EnterpriseDbContext context)
        {
            ctx = context;
        }

        public async Task<DepartamentoDTO?> GetDepartamentoByIdAsync(int id)
        {
            var departamento = await ctx.Departamentos
                .Include(d => d.Funcionarios)
                .FirstOrDefaultAsync(d => d.DepartamentoId == id);

            if (departamento == null)
                return null;

            return new DepartamentoDTO
            {
                DepartamentoId = departamento.DepartamentoId,
                Nome = departamento.Nome,
                FuncionarioCount = departamento.Funcionarios.Count
            };
        }

        public async Task<DepartamentoDTO?> CreateDepartamentoAsync(Departamento departamento)
        {
            ctx.Departamentos.Add(departamento);
            await ctx.SaveChangesAsync();

            return new DepartamentoDTO
            {
                DepartamentoId = departamento.DepartamentoId,
                Nome = departamento.Nome,
                FuncionarioCount = departamento.Funcionarios.Count
            };
        }
    }
}
