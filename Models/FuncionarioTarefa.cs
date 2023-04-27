namespace enterprise.Models
{
    public class FuncionarioTarefa
    {
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
        public int TarefaId { get; set; }
        public Tarefa? Tarefa { get; set; }
    }
}
