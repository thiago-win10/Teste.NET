using Teste.NET.Domain; 
using System.Linq;
using Domain.Models;

namespace Domain.Data
{
    public class SeedingProdutos
    {

        private XYZContext _context;

        public SeedingProdutos(XYZContext context)
        {
            _context = context;
        }

        public void Seed() // Gerando a população da base de dados da Classe Produto
        {
            if (_context.Produtos.Any())
            {
                return;
            }

            Produto p1 = new Produto { Nome = "PS5", Descricao = "Memória RAM: 16 GB Console", Preco = 4500 };
            Produto p2 = new Produto { Nome = "TV Samart Sony", Descricao = "4K Otima Resolução", Preco = 9500 };
            Produto p3 = new Produto { Nome = "Geladeira", Descricao = "Consul Inox", Preco = 6500 };
            Produto p4 = new Produto { Nome = "NotBook", Descricao = "Apple", Preco = 12300 };
            Produto p5 = new Produto { Nome = "Celular Samsung S10", Descricao = "Memória RAM: 64 GB - Azul", Preco = 7800 };
            Produto p6 = new Produto { Nome = "Bicicleta", Descricao = "Aro Black", Preco = 9000 };
            Produto p7 = new Produto { Nome = "SSD", Descricao = "256 GB Velocidade", Preco = 400 };
            Produto p8 = new Produto { Nome = "Filtro de Agua", Descricao = "Lorenzetti", Preco = 800 };
            Produto p9 = new Produto { Nome = "Quadro Frances", Descricao = "Obra de Arte", Preco = 9300 };
            Produto p10 = new Produto { Nome = "Fone de Ouvido", Descricao = "Conector wi fire", Preco = 1500 };


            _context.Produtos.AddRange(p1, p2, p3, p4, p5,
                                        p6, p7, p8, p9, p10);

            _context.SaveChanges();

        }
    }

}