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
    public class CarrinhoItemRepository : ICarrinhoItemRepository
    {
        private readonly XYZContext _item;
        public CarrinhoItemRepository(XYZContext item)
        {
            _item = item;
        }

        public async Task<List<CarrinhoItem>> GetCarrinhoItensAsync()
        {
            return await _item.CarrinhoItems.ToListAsync();
        }
        public async Task<CarrinhoItem> FindByIdAsync(int id)
        {
            return await _item.CarrinhoItems.AsNoTracking().FirstOrDefaultAsync(x => x.CarrinhoItemId == id);
        }
        public async Task InsertAsync(CarrinhoItem item)
        {
            _item.CarrinhoItems.Add(item);
            await _item.SaveChangesAsync();

        }
        public async Task UpdateAsync(CarrinhoItem item)
        {
            bool hasAny = await _item.CarrinhoItems.AnyAsync(x => x.CarrinhoItemId == item.CarrinhoItemId);
            if (!hasAny)
            {
                throw new Exception("Id not Found");
            }
            _item.Update(item);
            await _item.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var item = _item.CarrinhoItems.Find(id);
            _item.CarrinhoItems.Remove(item);
            await _item.SaveChangesAsync();
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _item.CarrinhoItems.Where(carrinho => carrinho.CarrinhoItemId == carrinho.CarrinhoItemId);

            _item.CarrinhoItems.RemoveRange(carrinhoItens);

            _item.SaveChangesAsync();

        }
        public decimal GetItemSubTotal()
        {
            var subtotal = _item.CarrinhoItems.Where(c => c.CarrinhoItemId == c.CarrinhoItemId)
                .Select(c => c.SubTotal * c.Quantidade).Sum();

            return subtotal;
        }


    }
}

