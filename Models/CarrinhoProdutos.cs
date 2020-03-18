namespace Carrinho.Models
{
    public class CarrinhoProdutos
    {
        public int ProdutoId { get; set; }
        public int CarrinhoId { get; set; }
        public int QtdProduto { get; set; }
        public CarrinhoCompras Carrinho { get; set; }
        public Produto Produto { get; set; }
    }
}