namespace enterprise.DTO
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Cnpj { get; set; } = "";
        public ICollection<FuncionarioDTO> Funcionarios { get; set; } = new List<FuncionarioDTO>();
        public ICollection<DepartamentoDTO> Departamentos { get; set; } =
            new List<DepartamentoDTO>();
    }

    public class CreatedEmpresaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Cnpj { get; set; } = "";
    }
}
