namespace enterprise.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public bool Status { get; set; }
        public ICollection<FuncionarioTarefa> FuncionarioTarefas { get; set; } =
            new List<FuncionarioTarefa>();
    }
}
