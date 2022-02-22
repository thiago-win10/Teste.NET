using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PadraoRepository.Interfaces
{
    public interface IClienteEnderecoRepository
    {
        public Task<List<ClienteEndereco>> GetClientesEnderecoAsync();
        public Task<ClienteEndereco> FindByIdAsync(int id);
        public Task InsertAsync(ClienteEndereco endereco);
        public Task UpdateAsync(ClienteEndereco endereco);
        public Task DeleteAsync(int id);

    }
}
