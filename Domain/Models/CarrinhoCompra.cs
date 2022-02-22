
using System.Collections.Generic;

namespace Domain.Models
{
    public class CarrinhoCompra
    {
        public int CarrinhoCompraId { get; set; }
        public List<CarrinhoItem> CarrinhoItems { get; set; }
        public int CarrinhoItemId { get; set; }
        public decimal TotalGeral { get; set; }
        public int ClienteId { get; set; }
        
    }
}
