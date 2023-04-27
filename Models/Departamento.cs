namespace enterprise.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nome { get; set; } = "";
        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
