namespace Carrinho.Models
{
    public class CarrinhoProdutos
    {
        public int ProdutoId { get; set; }
        public int CarrinhoId { get; set; }
        public ComprasEfetuadas Carrinho { get; set; }
        public Produto Produto { get; set; }
    }
}