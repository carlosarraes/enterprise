using enterprise.Models;
using enterprise.DTO;

namespace enterprise.Services
{
    public interface IDepartamentoService
    {
        Task<DepartamentoDTO?> GetDepartamentoByIdAsync(int id);
        Task<DepartamentoDTO> CreateDepartamentoAsync(Departamento departamento);
    }
}
