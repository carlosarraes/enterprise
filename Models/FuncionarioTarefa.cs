using System.ComponentModel.DataAnnotations;

namespace enterprise.Models
{
    public class FuncionarioTarefa
    {
        [Required(ErrorMessage = "O Id do funcionário é obrigatório")]
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }

        [Required(ErrorMessage = "O Id da tarefa é obrigatório")]
        public int TarefaId { get; set; }
        public Tarefa? Tarefa { get; set; }
    }
}
