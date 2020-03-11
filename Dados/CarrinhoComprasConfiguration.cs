using Carrinho.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrinho.Dados
{
    public class CacrrinhoComprasConfiguration : IEntityTypeConfiguration<CarrinhoCompras>
    {
        public void Configure(EntityTypeBuilder<CarrinhoCompras> builder)
        {
            builder
            .ToTable("CarrinhoCompras");

            builder
            .Property(cc => cc.Id)
            .HasColumnName("Id");

            builder
            .Property(cc => cc.TotalCompra)
            .HasColumnName("TotalCompra")
            .IsRequired();
        }
    }
}