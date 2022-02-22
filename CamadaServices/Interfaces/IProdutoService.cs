using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace CamadaServices.Interfaces
{
    public interface IProdutoService
    {
        public Task<List<Produto>> GetProdutosAsync();
        public Task<Produto> FindByIdAsync(int id);
        public Task InsertAsync(Produto produto);
        public Task UpdateAsync(Produto produto);
        public Task DeleteAsync(int id);

    }
}


