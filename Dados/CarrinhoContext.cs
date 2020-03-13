using Carrinho.Models;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Dados
{
    public class CarrinhoContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Setor> Setor { get; set; }

        public DbSet<CarrinhoCompras> Carrinho { get; set; }

        public DbSet<CarrinhoProdutos> CarrinhoProduto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Carrinho.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new SetorConfiguration());
            modelBuilder.ApplyConfiguration(new CacrrinhoComprasConfiguration());
            modelBuilder.ApplyConfiguration(new CarrinhoProdutosConfiguration());
        }
    }
}