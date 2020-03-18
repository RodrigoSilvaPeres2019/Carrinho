using Carrinho.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrinho.Dados
{
    public class CarrinhoProdutosConfiguration : IEntityTypeConfiguration<CarrinhoProdutos>
    {
        public void Configure(EntityTypeBuilder<CarrinhoProdutos> builder)
        {
            builder
            .ToTable("vendas_produtos");
            builder
            .HasKey(cp => new { cp.CarrinhoId, cp.ProdutoId});

            builder
                .HasOne(cp => cp.Carrinho)
                .WithMany(c => c.ListaProdutos)
                .HasForeignKey("ProdutoId");

            builder
                .HasOne(cp => cp.Produto)
                .WithMany(p => p.Carrinhos)
                .HasForeignKey("CarrinhoId");
        }
    }
}