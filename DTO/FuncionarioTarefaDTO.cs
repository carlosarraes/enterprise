namespace enterprise.DTO
{
    public class FuncionarioTarefaDTO
    {
        public int TarefaId { get; set; }
        public string? Nome { get; set; }
        public bool? Status { get; set; }
        public List<string> FuncionarioNomes { get; set; } = new List<string>();
    }
}
