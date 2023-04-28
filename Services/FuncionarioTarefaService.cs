using enterprise.Data;
using enterprise.DTO;
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
    }
}
