using System.ComponentModel.DataAnnotations;

namespace enterprise.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "O nome do departamento é obrigatório.")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "O Id da empresa é obrigatório.")]
        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
