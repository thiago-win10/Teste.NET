using Domain.Mapping;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Teste.NET.Domain.Models;

namespace Teste.NET.Domain
{
    public class XYZContext : DbContext
    {
        public XYZContext(DbContextOptions<XYZContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteEndereco> ClienteEnderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CarrinhoCompra> CarrinhoCompras { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entity Configuration
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            modelBuilder.ApplyConfiguration(new CarrinhoCompraMap());
            modelBuilder.ApplyConfiguration(new CarrinhoItemMap());

       
            


        }
    }
}

