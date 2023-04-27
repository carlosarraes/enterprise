namespace enterprise.DTO
{
    public class TarefaDTO
    {
        public int TarefaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool? Status { get; set; }
        public ICollection<LazyFuncionarioDTO> Funcionarios { get; set; } =
            new List<LazyFuncionarioDTO>();
    }
}
