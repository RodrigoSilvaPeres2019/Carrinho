using System.Collections.Generic;

namespace Carrinho.Models
{
    public class CarrinhoCompras
    {
     public int Id { get; set; }   
     public List<CarrinhoProdutos> ListaProdutos { get; set; }
     public decimal TotalCompra{ get; set; }
     
     public CarrinhoCompras()
     {
        ListaProdutos = new List<CarrinhoProdutos>();
     }
    }
}