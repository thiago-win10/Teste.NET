using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Foto { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        public List<CarrinhoItem> CarrinhoItems { get; set; }

    }
}