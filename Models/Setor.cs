using System.Collections.Generic;

namespace Carrinho.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IList<Produto> Produtos { get; set; } 
        
        public Setor()
        {
           Produtos = new List<Produto>();
        }
         public override string ToString(){
            return this.Nome;
        }
    }
}