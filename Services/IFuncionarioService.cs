using enterprise.Models;
using enterprise.DTO;

namespace enterprise.Services
{
    public interface IFuncionarioService
    {
        Task<FuncionarioDTO?> GetFuncionarioByIdAsync(int id);
        Task<FuncionarioDTO> CreateFuncionarioAsync(Funcionario funcionario);
    }
}
