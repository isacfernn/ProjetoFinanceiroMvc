using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GerenciamentoFinanceiro.Models
{
    public class Financeiro
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataOperacao { get; set; }

        [ValidateNever]
        public string CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [ValidateNever]
         
        public string TransacaoId { get; set; }
        public Transacao Transacao { get; set; }
    }
}
