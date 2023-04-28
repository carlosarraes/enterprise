using System.ComponentModel.DataAnnotations;

namespace enterprise.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "O Id da empresa é obrigatório.")]
        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }

        [Required(ErrorMessage = "O Id do departamento é obrigatório.")]
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public ICollection<FuncionarioTarefa> FuncionarioTarefas { get; set; } =
            new List<FuncionarioTarefa>();
    }
}
