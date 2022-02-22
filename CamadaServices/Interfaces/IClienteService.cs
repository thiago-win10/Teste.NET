using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamadaServices.Interfaces
{
    public interface IClienteService
    {
        public Task<List<Cliente>> GetClientesAsync();
        public Task<Cliente> FindByIdAsync(int id);
        public Task InsertAsync(Cliente cliente);
        public Task UpdateAsync(Cliente cliente);
        public Task DeleteAsync(int id);

    }
}

