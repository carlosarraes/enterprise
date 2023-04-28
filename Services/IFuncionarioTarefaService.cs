using enterprise.DTO;

namespace enterprise.Services
{
    public interface IFuncionarioTarefaService
    {
        Task<List<FuncionarioTarefaDTO>> GetAllAsync();
        Task<FuncionarioTarefaDTO?> AssignAsync(int funcionarioId, int tarefaId);
    }
}
