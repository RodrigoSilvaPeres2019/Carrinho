using Carrinho.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrinho.Dados
{
    public class CacrrinhoComprasConfiguration : IEntityTypeConfiguration<ComprasEfetuadas>
    {
        public void Configure(EntityTypeBuilder<ComprasEfetuadas> builder)
        {
            
        }
    }
}