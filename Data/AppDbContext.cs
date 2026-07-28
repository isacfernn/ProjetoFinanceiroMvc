using GerenciamentoFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Financeiro> Financas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { CategoriaId = "dizimo", Nome = "Dizímo" },
                new Categoria { CategoriaId = "salario", Nome = "Salário" },
                new Categoria { CategoriaId = "alimentacao", Nome = "Alimentação" },
                new Categoria { CategoriaId = "casamento", Nome = "Casamento" },
                new Categoria { CategoriaId = "saude", Nome = "Saúde" },
                new Categoria { CategoriaId = "lazer", Nome = "Lazer" },
                new Categoria { CategoriaId = "transporte", Nome = "Transporte" },
                new Categoria { CategoriaId = "moradia", Nome = "Moradia" },
                new Categoria { CategoriaId = "investimentos", Nome = "Investimentos" },
                new Categoria { CategoriaId = "emprestado", Nome = "Emprestado" },
                new Categoria { CategoriaId = "outros", Nome = "Outros" }
            );

            modelBuilder.Entity<Financeiro>()
                .Property(f => f.Valor)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transacao>().HasData(
                new Transacao { TransacaoId = "ganho", Nome = "Ganho" },
                new Transacao { TransacaoId = "gasto", Nome = "Gasto" }
            );


            base.OnModelCreating(modelBuilder);
        }

    }
}
