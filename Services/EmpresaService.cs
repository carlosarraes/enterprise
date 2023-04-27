using enterprise.Data;
using enterprise.DTO;
using enterprise.Models;
using Microsoft.EntityFrameworkCore;

namespace enterprise.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly EnterpriseDbContext ctx;

        public EmpresaService(EnterpriseDbContext context)
        {
            ctx = context;
        }

        public async Task<EmpresaDTO?> GetEmpresaByIdAsync(int id)
        {
            var empresa = await ctx.Empresas
                .Include(e => e.Funcionarios)
                .ThenInclude(f => f.Departamento)
                .Include(e => e.Departamentos)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (empresa == null)
                return null;

            var empresaDTO = new EmpresaDTO
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                Cnpj = empresa.Cnpj,
                Funcionarios = empresa.Funcionarios
                    .Select(
                        f =>
                            new FuncionarioDTO
                            {
                                FuncionarioId = f.FuncionarioId,
                                Nome = f.Nome,
                                DepartamentoNome = f.Departamento?.Nome
                            }
                    )
                    .ToList(),
                Departamentos = empresa.Departamentos
                    .Select(
                        d =>
                            new DepartamentoDTO
                            {
                                DepartamentoId = d.DepartamentoId,
                                Nome = d.Nome,
                                FuncionarioCount = d.Funcionarios.Count
                            }
                    )
                    .ToList()
            };

            return empresaDTO;
        }

        public async Task<CreatedEmpresaDTO?> CreateEmpresaAsync(Empresa empresa)
        {
            var exist = await ctx.Empresas.FirstOrDefaultAsync(x => x.Cnpj == empresa.Cnpj);
            if (exist != null)
                return null;

            ctx.Empresas.Add(empresa);
            await ctx.SaveChangesAsync();

            var createdEmpresaDTO = new CreatedEmpresaDTO
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                Cnpj = empresa.Cnpj
            };

            return createdEmpresaDTO;
        }
    }
}
