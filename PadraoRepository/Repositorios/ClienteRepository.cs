using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Teste.NET.Domain;
using PadraoRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PadraoRepository.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly XYZContext _cliente;
        public ClienteRepository(XYZContext context)
        {
            _cliente = context;
        }
        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _cliente.Clientes.ToListAsync();

        }
        public async Task<Cliente> FindByIdAsync(int id)
        {
            return await _cliente.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.ClienteId == id);
        }
        public async Task InsertAsync(Cliente cliente)
        {
            _cliente.Clientes.Add(cliente);
            await _cliente.SaveChangesAsync();

        }
        public async Task UpdateAsync(Cliente cliente)
        {
            bool hasAny = await _cliente.Clientes.AnyAsync(x => x.ClienteId == cliente.ClienteId);
            if (!hasAny)
            {
                throw new Exception("Id not Found");
            }
            _cliente.Update(cliente);
            await _cliente.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var cliente = _cliente.Clientes.Find(id);
            _cliente.Clientes.Remove(cliente);
            await _cliente.SaveChangesAsync();
        }


    }
}



