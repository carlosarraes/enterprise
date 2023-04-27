using enterprise.Models;
using enterprise.DTO;

namespace enterprise.Services
{
    public interface ITarefaService
    {
        Task<TarefaDTO?> GetTarefaByIdAsync(int id);
        Task<TarefaDTO> CreateTarefaAsync(Tarefa tarefa);
    }
}
