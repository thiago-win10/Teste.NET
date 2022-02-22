using CamadaServices.Interfaces;
using Domain.Models;
using PadraoRepository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamadaServices.Services
{
    public class ClienteEnderecoService : IClienteEnderecoService
    {
        private readonly IClienteEnderecoRepository _enderecoRepository;
        public ClienteEnderecoService(IClienteEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public async Task<List<ClienteEndereco>> GetClientesEnderecoAsync()
        {
            return await _enderecoRepository.GetClientesEnderecoAsync();
        }
        public async Task<ClienteEndereco> FindByIdAsync(int id)
        {
            return await _enderecoRepository.FindByIdAsync(id);
        }
        public async Task InsertAsync(ClienteEndereco endereco)
        {
            await _enderecoRepository.InsertAsync(endereco);
        }
        public async Task UpdateAsync(ClienteEndereco endereco)
        {
            await _enderecoRepository.UpdateAsync(endereco);

        }
        public async Task DeleteAsync(int id)
        {
            await _enderecoRepository.DeleteAsync(id);
        }

    }
}
    
