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

        public async Task<FuncionarioDTO> CreateFuncionarioAsync(Funcionario funcionario)
        {
            ctx.Funcionarios.Add(funcionario);
            await ctx.SaveChangesAsync();

            var departamento = ctx.Departamentos.FindAsync(funcionario.DepartamentoId);

            var funcionarioDTO = new FuncionarioDTO()
            {
                FuncionarioId = funcionario.FuncionarioId,
                Nome = funcionario.Nome,
                DepartamentoNome = departamento.Result?.Nome,
            };

            return funcionarioDTO;
        }

        public async Task<FuncionarioDTO?> GetFuncionarioByIdAsync(int id)
        {
            var funcionario = await ctx.Funcionarios
                .Include(f => f.Departamento)
                .FirstOrDefaultAsync(f => f.FuncionarioId == id);
            if (funcionario == null)
                return null;

            var funcionarioDTO = new FuncionarioDTO()
            {
                FuncionarioId = funcionario.FuncionarioId,
                Nome = funcionario.Nome,
                DepartamentoNome = funcionario.Departamento?.Nome,
            };

            return funcionarioDTO;
        }
    }
}
