using CamadaServices.Interfaces;
using Domain.Models;
using PadraoRepository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamadaServices.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }
        public async Task<Cliente> FindByIdAsync(int id)
        {
            return await _clienteRepository.FindByIdAsync(id);
        }
        public async Task InsertAsync(Cliente cliente)
        {
            await _clienteRepository.InsertAsync(cliente);
        }
        public async Task UpdateAsync(Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);

        }
        public async Task DeleteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }

    }
}

