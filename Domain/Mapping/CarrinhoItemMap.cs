using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapping
{
    public class CarrinhoItemMap : IEntityTypeConfiguration<CarrinhoItem>
    {
        public void Configure(EntityTypeBuilder<CarrinhoItem> builder)
        {
            builder.ToTable("CarrinhoItem");
            builder.HasKey(c => c.CarrinhoItemId);
            builder.Property(x => x.CarrinhoItemId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Quantidade)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.SubTotal)
                .HasColumnType("decimal(12, 2)");

        }

    }
}


