using enterprise.Data;
using enterprise.DTO;
using enterprise.Models;
using Microsoft.EntityFrameworkCore;

namespace enterprise.Services
{
    public class FuncionarioTarefaService : IFuncionarioTarefaService
    {
        private readonly EnterpriseDbContext ctx;

        public FuncionarioTarefaService(EnterpriseDbContext context)
        {
            ctx = context;
        }

        public async Task<List<FuncionarioTarefaDTO>> GetAllAsync()
        {
            var funcionarioTarefas = await ctx.FuncionarioTarefas
                .Include(ft => ft.Funcionario)
                .Include(ft => ft.Tarefa)
                .ToListAsync();

            var groupedByTarefa = funcionarioTarefas
                .Where(ft => ft.Tarefa != null && ft.Funcionario != null)
                .GroupBy(
                    ft =>
                        new
                        {
                            ft.TarefaId,
                            ft.Tarefa?.Nome,
                            ft.Tarefa?.Status
                        }
                )
                .Select(
                    g =>
                        new FuncionarioTarefaDTO
                        {
                            TarefaId = g.Key.TarefaId,
                            Nome = g.Key.Nome,
                            Status = g.Key.Status,
                            FuncionarioNomes = g.Select(ft => ft.Funcionario!.Nome).ToList()
                        }
                )
                .ToList();

            return groupedByTarefa;
        }

        public async Task<FuncionarioTarefaDTO?> AssignAsync(int funcionarioId, int tarefaId)
        {
            var funcionario = await ctx.Funcionarios.FindAsync(funcionarioId);
            var tarefa = await ctx.Tarefas.FindAsync(tarefaId);

            if (funcionario == null || tarefa == null)
                return null;

            var funcionarioTarefa = new FuncionarioTarefa
            {
                FuncionarioId = funcionarioId,
                TarefaId = tarefaId
            };

            ctx.FuncionarioTarefas.Add(funcionarioTarefa);
            await ctx.SaveChangesAsync();

            return new FuncionarioTarefaDTO
            {
                TarefaId = tarefaId,
                Nome = tarefa.Nome,
                Status = tarefa.Status,
                FuncionarioNomes = new List<string> { funcionario.Nome }
            };
        }
    }
}
