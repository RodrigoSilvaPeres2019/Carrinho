using Carrinho.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrinho.Dados
{
    public class SetorConfiguration : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder
            .ToTable("Setor");

            builder
            .Property(s => s.Id)
            .HasColumnName("Id");

            builder
            .HasKey("Id");

            builder
            .HasMany(s => s.Produtos)
            .WithOne(p => p.Setor)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}