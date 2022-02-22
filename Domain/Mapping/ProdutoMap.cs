using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(c => c.ProdutoId);
            builder.Property(x => x.ProdutoId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Foto)
                .HasColumnType("varbinary(max)");

            builder.Property(x => x.Preco)
                .HasColumnType("decimal(12, 2)");

        }
    }

}

