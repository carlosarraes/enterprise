using enterprise.Models;
using enterprise.DTO;

namespace enterprise.Services
{
    public interface IEmpresaService
    {
        Task<EmpresaDTO?> GetEmpresaByIdAsync(int id);
        Task<CreatedEmpresaDTO?> CreateEmpresaAsync(Empresa empresa);
    }
}
