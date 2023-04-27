using enterprise.Models;
using Microsoft.EntityFrameworkCore;

namespace enterprise.Data
{
    public class EnterpriseDbContext : DbContext
    {
        public EnterpriseDbContext(DbContextOptions<EnterpriseDbContext> options)
            : base(options)
        {
            Empresas = Set<Empresa>();
            Funcionarios = Set<Funcionario>();
            Departamentos = Set<Departamento>();
            Tarefas = Set<Tarefa>();
            FuncionarioTarefas = Set<FuncionarioTarefa>();
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<FuncionarioTarefa> FuncionarioTarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>().HasIndex(e => e.Cnpj).IsUnique();

            modelBuilder
                .Entity<FuncionarioTarefa>()
                .HasKey(ft => new { ft.FuncionarioId, ft.TarefaId });

            modelBuilder
                .Entity<FuncionarioTarefa>()
                .HasOne(ft => ft.Funcionario)
                .WithMany(f => f.FuncionarioTarefas)
                .HasForeignKey(ft => ft.FuncionarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<FuncionarioTarefa>()
                .HasOne(ft => ft.Tarefa)
                .WithMany(t => t.FuncionarioTarefas)
                .HasForeignKey(ft => ft.TarefaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Departamento>()
                .HasOne(d => d.Empresa)
                .WithMany(e => e.Departamentos)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
