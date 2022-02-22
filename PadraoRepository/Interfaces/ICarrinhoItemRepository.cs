using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PadraoRepository.Interfaces
{
    public interface ICarrinhoItemRepository
    {
        public Task<List<CarrinhoItem>> GetCarrinhoItensAsync();
        public Task<CarrinhoItem> FindByIdAsync(int id);
        public Task InsertAsync(CarrinhoItem item);
        public Task UpdateAsync(CarrinhoItem item);
        public Task DeleteAsync(int id);
        public decimal GetItemSubTotal();
        public void LimparCarrinho();
    }
}


