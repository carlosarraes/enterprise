using enterprise.DTO;

namespace enterprise.Services
{
    public interface IFuncionarioTarefaService
    {
        Task<List<FuncionarioTarefaDTO>> GetAllAsync();
    }
}
