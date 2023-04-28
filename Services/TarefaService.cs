using enterprise.Data;
using enterprise.DTO;
using enterprise.Models;
using Microsoft.EntityFrameworkCore;

namespace enterprise.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly EnterpriseDbContext ctx;

        public TarefaService(EnterpriseDbContext context)
        {
            ctx = context;
        }

        private TarefaDTO asDTO(Tarefa tarefa)
        {
            var tarefaDTO = new TarefaDTO
            {
                TarefaId = tarefa.TarefaId,
                Descricao = tarefa.Descricao,
                Nome = tarefa.Nome,
                Status = tarefa.Status,
                Funcionarios = tarefa.FuncionarioTarefas
                    .Select(ft => new LazyFuncionarioDTO { Nome = ft.Funcionario?.Nome })
                    .ToList()
            };

            return tarefaDTO;
        }

        public async Task<TarefaDTO?> GetTarefaByIdAsync(int id)
        {
            var tarefa = await ctx.Tarefas
                .Include(t => t.FuncionarioTarefas)
                .ThenInclude(ft => ft.Funcionario)
                .FirstOrDefaultAsync(t => t.TarefaId == id);

            if (tarefa == null)
                return null;

            return asDTO(tarefa);
        }

        public async Task<TarefaDTO> CreateTarefaAsync(Tarefa tarefa)
        {
            ctx.Tarefas.Add(tarefa);
            await ctx.SaveChangesAsync();

            return asDTO(tarefa);
        }

        public async Task<TarefaDTO?> DoneAsync(int id)
        {
            var tarefa = await ctx.Tarefas
                .Include(t => t.FuncionarioTarefas)
                .ThenInclude(ft => ft.Funcionario)
                .FirstOrDefaultAsync(t => t.TarefaId == id);
            if (tarefa == null)
                return null;

            tarefa.Status = true;
            await ctx.SaveChangesAsync();

            return asDTO(tarefa);
        }
    }
}
