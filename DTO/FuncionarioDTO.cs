namespace enterprise.DTO
{
    public class FuncionarioDTO
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; } = "";
        public string? DepartamentoNome { get; set; }
    }

    public class LazyFuncionarioDTO
    {
        public string? Nome { get; set; }
    }
}
