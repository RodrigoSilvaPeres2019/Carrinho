using System.Collections.Generic;

namespace Carrinho.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public Setor Setor { get; set; }

        public List<CarrinhoProdutos> Carrinhos { get; set; }

        public Produto()
        {
            Carrinhos = new List<CarrinhoProdutos>();
        }
    }
}