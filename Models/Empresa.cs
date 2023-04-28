using System.ComponentModel.DataAnnotations;

namespace enterprise.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório.")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "O CNPJ da empresa é obrigatório.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "CNPJ deve conter apenas números.")]
        public string Cnpj { get; set; } = "";
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        public ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
    }
}
