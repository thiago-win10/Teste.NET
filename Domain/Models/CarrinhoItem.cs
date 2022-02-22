namespace Domain.Models
{
    public class CarrinhoItem
    {
        public int CarrinhoItemId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal SubTotal { get; set; }
    }
}
