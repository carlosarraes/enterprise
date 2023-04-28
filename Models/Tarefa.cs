using System.ComponentModel.DataAnnotations;

namespace enterprise.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = "";
        public bool Status { get; set; } = false;
        public ICollection<FuncionarioTarefa> FuncionarioTarefas { get; set; } =
            new List<FuncionarioTarefa>();
    }
}
