using System.Collections.Generic;

namespace Carrinho.Models
{
    public class CarrinhoCompras
    {
     public int Id { get; set; }   

     public string EstadoCompra { get; set; }
     public List<CarrinhoProdutos> ListaProdutos { get; set; }
     
     public CarrinhoCompras()
     {
        ListaProdutos = new List<CarrinhoProdutos>();
     }
    }
}