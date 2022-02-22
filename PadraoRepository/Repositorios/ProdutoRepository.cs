using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Teste.NET.Domain;
using PadraoRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PadraoRepository.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly XYZContext _produto;
        public ProdutoRepository(XYZContext produto)
        {
            _produto = produto;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _produto.Produtos.ToListAsync();
        }
        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _produto.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.ProdutoId == id);
        }
        public async Task InsertAsync(Produto produto)
        {
            _produto.Produtos.Add(produto);
            await _produto.SaveChangesAsync();

        }
        public async Task UpdateAsync(Produto produto)
        {
            bool hasAny = await _produto.Produtos.AnyAsync(x => x.ProdutoId == produto.ProdutoId);
            if (!hasAny)
            {
                throw new Exception("Id not Found");
            }
            _produto.Update(produto);
            await _produto.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var produto = _produto.Produtos.Find(id);
            _produto.Produtos.Remove(produto);
            await _produto.SaveChangesAsync();
        }

    }
}



