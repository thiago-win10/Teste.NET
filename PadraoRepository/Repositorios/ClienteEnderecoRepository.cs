using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Teste.NET.Domain;
using PadraoRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PadraoRepository.Repositorios
{
    public class ClienteEnderecoRepository : IClienteEnderecoRepository
    {
        private readonly XYZContext _enderecocliente;
        public ClienteEnderecoRepository(XYZContext endereco)
        {
            _enderecocliente = endereco;
        }

        public async Task<List<ClienteEndereco>> GetClientesEnderecoAsync()
        {
            return await _enderecocliente.ClienteEnderecos.ToListAsync();
        }
        public async Task<ClienteEndereco> FindByIdAsync(int id)
        {
            return await _enderecocliente.ClienteEnderecos.AsNoTracking().FirstOrDefaultAsync(x => x.ClienteEnderecoId == id);
        }
        public async Task InsertAsync(ClienteEndereco endereco)
        {
            _enderecocliente.ClienteEnderecos.Add(endereco);
            await _enderecocliente.SaveChangesAsync();

        }
        public async Task UpdateAsync(ClienteEndereco endereco)
        {
            bool hasAny = await _enderecocliente.ClienteEnderecos.AnyAsync(x => x.ClienteEnderecoId == endereco.ClienteEnderecoId);
            if (!hasAny)
            {
                throw new Exception("Id not Found");
            }
            _enderecocliente.Update(endereco);
            await _enderecocliente.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var endereco = _enderecocliente.ClienteEnderecos.Find(id);
            _enderecocliente.Remove(endereco);
            await _enderecocliente.SaveChangesAsync();
        }

    }
}   




