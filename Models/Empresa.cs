namespace enterprise.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Cnpj { get; set; } = "";
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        public ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
    }
}
