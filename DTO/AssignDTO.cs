using System.ComponentModel.DataAnnotations;

namespace enterprise.DTO
{
    public class AssignDTO
    {
        [Required(ErrorMessage = "O Id do funcionário é obrigatório.")]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "O Id da tarefa é obrigatório.")]
        public int TarefaId { get; set; }
    }
}
