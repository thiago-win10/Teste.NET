using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapping
{
    public class ClienteEnderecoMap : IEntityTypeConfiguration<ClienteEndereco>
    {
        public void Configure(EntityTypeBuilder<ClienteEndereco> builder)
        {
            builder.ToTable("ClienteEndereco");
            builder.HasKey(c => c.ClienteEnderecoId);
            builder.Property(x => x.ClienteEnderecoId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Logradouro)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Numero)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Complemento)
                .HasMaxLength(100);

            builder.Property(c => c.Bairro)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.CEP)
                .HasColumnType("char(9)");

            builder.Property(c => c.UF)
                .HasColumnType("char(2)");


            //Relacionamentos
            builder.HasOne(c => c.Cliente)
                .WithOne(c => c.ClienteEndereco);
            

        }
    }
}