using System.Collections.Generic;

namespace Carrinho.Models
{
    public class ComprasEfetuadas
    {
     public int Id { get; set; }   
     public List<CarrinhoProdutos> ListaProdutos { get; set; }
     
     public ComprasEfetuadas()
     {
        ListaProdutos = new List<CarrinhoProdutos>();
     }
    }
}