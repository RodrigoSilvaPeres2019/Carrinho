using Carrinho.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrinho.Dados
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        void IEntityTypeConfiguration<Produto>.Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
            .ToTable("produtos");

            builder
            .Property(p => p.Id)
            .HasColumnName("Id");

            builder
            .Property(p => p.Nome)
            .HasColumnName("Nome")
            .IsRequired();

            builder
            .Property(p => p.Preco)
            .HasColumnType("numeric(10,5)")
            .HasColumnName("Preco");
           

            builder
            .Property(p => p.Descricao)
            .HasColumnName("Descricao");
            

            builder
            .HasKey("Id");

            builder
            .HasOne(p => p.Setor)
            .WithMany(s => s.Produtos)
            .HasForeignKey("SetorId")
            .OnDelete(DeleteBehavior.Cascade);



        }
    }
}