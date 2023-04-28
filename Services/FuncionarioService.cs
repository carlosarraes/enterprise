using enterprise.Data;
using enterprise.DTO;
using enterprise.Models;
using Microsoft.EntityFrameworkCore;

namespace enterprise.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly EnterpriseDbContext ctx;

        public FuncionarioService(EnterpriseDbContext context)
        {
            ctx = context;
        }

        private FuncionarioDTO asDTO(Funcionario funcionario)
        {
            return new FuncionarioDTO()
            {
                FuncionarioId = funcionario.FuncionarioId,
                Nome = funcionario.Nome,
                DepartamentoNome = funcionario.Departamento?.Nome,
            };
        }

        public async Task<FuncionarioDTO> CreateFuncionarioAsync(Funcionario funcionario)
        {
            ctx.Funcionarios.Add(funcionario);
            await ctx.SaveChangesAsync();

            var departamento = ctx.Departamentos
                .Include(d => d.Funcionarios)
                .FirstOrDefault(d => d.DepartamentoId == funcionario.DepartamentoId);

            return asDTO(funcionario);
        }

        public async Task<FuncionarioDTO?> GetFuncionarioByIdAsync(int id)
        {
            var funcionario = await ctx.Funcionarios
                .Include(f => f.Departamento)
                .FirstOrDefaultAsync(f => f.FuncionarioId == id);
            if (funcionario == null)
                return null;

            return asDTO(funcionario);
        }
    }
}
