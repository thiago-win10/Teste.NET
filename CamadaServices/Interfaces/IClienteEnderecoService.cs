using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaServices.Interfaces
{
    public interface IClienteEnderecoService
    {
        public Task<List<ClienteEndereco>> GetClientesEnderecoAsync();
        public Task<ClienteEndereco> FindByIdAsync(int id);
        public Task InsertAsync(ClienteEndereco endereco);
        public Task UpdateAsync(ClienteEndereco endereco);
        public Task DeleteAsync(int id);


    }
}
