namespace enterprise.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; } = "";
        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public ICollection<FuncionarioTarefa> FuncionarioTarefas { get; set; } =
            new List<FuncionarioTarefa>();
    }
}
