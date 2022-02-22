using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapping
{
    public class CarrinhoCompraMap : IEntityTypeConfiguration<CarrinhoCompra>
    {
        public void Configure(EntityTypeBuilder<CarrinhoCompra> builder)
        {
            builder.ToTable("CarrinhoCompra");
            builder.HasKey(c => c.CarrinhoCompraId);
            builder.Property(x => x.CarrinhoCompraId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.TotalGeral)
                .HasColumnType("decimal(12, 2)");
        }

    }
}
    
