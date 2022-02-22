using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Teste.NET.Domain;
using PadraoRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadraoRepository.Repositorios 
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly XYZContext _carrinho;
        public CarrinhoCompraRepository(XYZContext carrinho)
        {
            _carrinho = carrinho;
        }

        public async Task<List<CarrinhoCompra>> GetCarrinhoComprasAsync()
        {
            return await _carrinho.CarrinhoCompras.ToListAsync();
        }
        public async Task<CarrinhoCompra> FindByIdAsync(int id)
        {
            return await _carrinho.CarrinhoCompras.AsNoTracking().FirstOrDefaultAsync(x => x.CarrinhoCompraId == id);
        }
        public async Task InsertAsync(CarrinhoCompra carrinho)
        {
            _carrinho.CarrinhoCompras.Add(carrinho);
            await _carrinho.SaveChangesAsync();

        }
        public async Task UpdateAsync(CarrinhoCompra carrinho)
        {
            bool hasAny = await _carrinho.CarrinhoCompras.AnyAsync(x => x.CarrinhoCompraId == carrinho.CarrinhoCompraId);
            if (!hasAny)
            {
                throw new Exception("Id not Found");
            }
            _carrinho.Update(carrinho);
            await _carrinho.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var carrinho = _carrinho.CarrinhoCompras.Find(id);
            _carrinho.CarrinhoCompras.Remove(carrinho);
            await _carrinho.SaveChangesAsync();
        }
        public decimal GetComprasTotal()
        {
            var total = _carrinho.CarrinhoCompras.Where(c => c.CarrinhoCompraId == c.CarrinhoCompraId)
                .Select(c => c.TotalGeral).Sum();

            return total;
        }


    }
}




