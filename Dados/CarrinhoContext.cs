using Carrinho.Models;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Dados
{
    public class CarrinhoContext : DbContext
    {
        public CarrinhoContext(DbContextOptions<CarrinhoContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Setor> Setor { get; set; }

        public DbSet<CarrinhoCompras> Compras { get; set; }

        public DbSet<CarrinhoProdutos> CarrinhoProduto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new SetorConfiguration());
            modelBuilder.ApplyConfiguration(new CacrrinhoComprasConfiguration());
            modelBuilder.ApplyConfiguration(new CarrinhoProdutosConfiguration());
        }
    }
}