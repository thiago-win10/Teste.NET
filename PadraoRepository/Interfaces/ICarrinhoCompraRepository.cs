using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PadraoRepository.Interfaces
{
    public interface ICarrinhoCompraRepository
    {
        public Task<List<CarrinhoCompra>> GetCarrinhoComprasAsync();
        public Task<CarrinhoCompra> FindByIdAsync(int id);
        public Task InsertAsync(CarrinhoCompra compra);
        public Task UpdateAsync(CarrinhoCompra compra);
        public Task DeleteAsync(int id);

    }
}


